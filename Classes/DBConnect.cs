﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
using SCPDb.Classes;

namespace SCPDb.Classes
{
    public class DBConnect
    {
        private MySqlConnection mConnection;
        private SSHConnector mSSH;
        private string mServer;
        private string mDatabase;
        private string mUid;
        private string mPassword;
        private string mSessionID;
        private User activeUser;

        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            mServer = "localhost";
            mDatabase = "SCP_DB";
            mUid = "root";
            mPassword = "scpdbpass123";
            string lConnectionString;
            lConnectionString = "SERVER=" + mServer + ";" + "DATABASE=" +
            mDatabase + ";" + "UID=" + mUid + ";" + "PASSWORD=" + mPassword + ";";

            mConnection = new MySqlConnection(lConnectionString);
            mSSH = new SSHConnector();
            mSSH.Connect();
            this.OpenConnection();
        }

        private void Update()
        {
            setActiveUser(activeUser.UserID);
        }

        public bool CloseAll()
        {
            return this.CloseConnection() & mSSH.Disconnect();
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                mConnection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                mConnection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public int SelectUID(int aUID, string aPassword)
        {
            MySqlDataReader lDataReader = null;
            MySqlCommand lUserIDLoginCmd;
            int lUID = -1;
            try
            {
                string lQuery = "SELECT userID FROM Users WHERE userID = @uid AND passwd = @pass";
                lUserIDLoginCmd = new MySqlCommand(lQuery, mConnection);
                lUserIDLoginCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lUserIDLoginCmd.Parameters.Add("@pass", MySqlDbType.String);
                lUserIDLoginCmd.Parameters["@uid"].Value = aUID;
                lUserIDLoginCmd.Parameters["@pass"].Value = Hash(aPassword);
                lUserIDLoginCmd.Prepare();
                lDataReader = lUserIDLoginCmd.ExecuteReader();
                while (lDataReader.Read())
                {
                    lUID = Convert.ToInt32(lDataReader["userID"]);
                }
                lDataReader.Close();
            }
            catch
            {
                if(lDataReader != null)
                    lDataReader.Close();
                lUID = -1;
            }
            return lUID;
        }

        public string getNextAddendum(int scpNum)
        {
            string lQuery = "SELECT DISTINCT a.refNum FROM Addendum a WHERE a.scpNum = @scp ORDER BY a.refNum DESC LIMIT 1;";
            string retval = "A";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Parameters.AddWithValue("@scp", scpNum);
            lCmd.Prepare();
            MySqlDataReader lReader = lCmd.ExecuteReader();
            while (lReader.Read())
            {
                retval = (((retval = ((char)((int)(lReader[0].ToString()[0]) + 1)).ToString())[0]) == ('Z' + 1)) ? "AA" : retval;
            }
            lReader.Close();
            return retval;
        }

        public bool addAddendum(int scpNum, string refNum, string content)
        {
            string lQuery = "INSERT INTO Addendum VALUES (@scp, @refNum, @content)";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            lCmd.Transaction = lTrans;
            lCmd.Parameters.Add("@scp", MySqlDbType.Int16);
            lCmd.Parameters.Add("@refNum", MySqlDbType.String);
            lCmd.Parameters.Add("@content", MySqlDbType.Text);
            lCmd.Parameters["@scp"].Value = scpNum;
            lCmd.Parameters["@refNum"].Value = refNum;
            lCmd.Parameters["@content"].Value = content;
            lCmd.Prepare();
            if (lCmd.ExecuteNonQuery() != 1)
            {
                lTrans.Rollback();
                return false;
            }
            else
                lTrans.Commit();
            return true;
        }

        public string Hash(string aPasswd)
        {
            SHA1 lHasher = SHA1.Create();
            byte[] lHash = lHasher.ComputeHash(GetBytes(aPasswd));
            return BitConverter.ToString(lHash).Replace("-", "").ToLower();
        }


        public int SelectUID(string aSession)
        {
            string lQuery = "SELECT userID FROM Users WHERE sessionID = @session";
            int lUID = -1;
            MySqlCommand lSessionLookup = new MySqlCommand(lQuery, mConnection);
            lSessionLookup.Parameters.Add("@session", MySqlDbType.String);
            lSessionLookup.Parameters["@session"].Value = aSession;
            lSessionLookup.Prepare();
            MySqlDataReader lDataReader = lSessionLookup.ExecuteReader();
            while (lDataReader.Read())
            {
                lUID = Convert.ToInt32(lDataReader["userID"]);
            }
            lDataReader.Close();
            return lUID;
        }

        public bool ExecuteLogin(int aUID, string aPassword)
        {
            int lValidUID = this.SelectUID(aUID, aPassword);
            string lQuery = "UPDATE Users SET sessionID=@session WHERE userID=@uid";
            TimeSpan span = DateTime.Now.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc));

            string lSessionID = span.TotalMilliseconds.ToString();

            if (lValidUID != aUID)
                return false;
            else
            {
                MySqlCommand lSessionCmd = new MySqlCommand(lQuery, mConnection);
                lSessionCmd.Parameters.Add("@session", MySqlDbType.String);
                lSessionCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lSessionCmd.Parameters["@uid"].Value = lValidUID;
                lSessionCmd.Parameters["@session"].Value = lSessionID;
                if (lSessionCmd.ExecuteNonQuery() == 1)
                {
                    mSessionID = lSessionID;
                    setActiveUser(lValidUID);
                    return true;
                }
                return false;
            }
        }

        public User activeAgent
        {
            get
            {
                return this.activeUser;
            }
        }

        public bool ExecuteLogout(int aUID)
        {
            string lQuery = "UPDATE Users SET sessionID = NULL WHERE userID=@uid";
            string lSessionID = DateTime.Now.ToFileTime().ToString();
            MySqlCommand lSessionCmd = new MySqlCommand(lQuery, mConnection);
            lSessionCmd.Parameters.Add("@session", MySqlDbType.String);
            lSessionCmd.Parameters.Add("@uid", MySqlDbType.Int16);
            lSessionCmd.Parameters["@uid"].Value = aUID;
            if (lSessionCmd.ExecuteNonQuery() == 1)
            {
                mSessionID = "";
                activeUser = null;
                return true;
            }
            return false;
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //Select statement
        private void setActiveUser(int userID)
        {
            string lQuery = "SELECT name, class FROM Users WHERE userID = @UID";
            string lAgentName = "";
            int lAgentID = 0;
            ClassType lAgentClass = ClassType.L1;
            //Create Command
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Parameters.Add("@UID", MySqlDbType.Int16);
            lCmd.Parameters["@UID"].Value = userID;

            //Create a data reader and Execute the command
            MySqlDataReader lDataReader = lCmd.ExecuteReader();

            //Read the data and store them in the list
            while (lDataReader.Read())
            {
                lAgentName = Convert.ToString(lDataReader["name"]);
                lAgentClass = (ClassType)Convert.ToInt32(lDataReader["class"]);
            }
            lAgentID = userID;
            this.activeUser = new User(lAgentID, (int)lAgentClass, lAgentName);
            //close Data Reader
            lDataReader.Close();
        }


        public List<int> getAssignedSCPs(User aUser)
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT scpNum FROM Assigned WHERE userID = @uid ORDER BY scpNum ASC";
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@uid", aUser.UserID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
            while (lReader.Read())
            {
                lSCPList.Add(Convert.ToInt32(lReader["scpNum"]));
            }
            lReader.Close();
            return lSCPList;
        }

        // Gets list of scps overseeing user can unassign from another user
        public List<int> getUnassignableSCPs(User aUser)
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT a.scpNum FROM Assigned a, (SELECT a1.scpNum FROM Assigned a1 WHERE userID = @admin) as u WHERE a.userID = @uid AND a.scpNum IN (u.scpNum) ORDER BY a.scpNum ASC";
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@uid", aUser.UserID);
            lCommand.Parameters.AddWithValue("@admin", activeUser.UserID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
            while (lReader.Read())
            {
                lSCPList.Add(Convert.ToInt32(lReader["scpNum"]));
            }
            lReader.Close();
            return lSCPList;
        }



        public List<int> getSCPDb()
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT DISTINCT i.scpNum FROM Item i LEFT OUTER JOIN Assigned a ON i.scpNum = a.scpNum WHERE i.class < @class OR a.userID = @uid ORDER BY i.scpNum";
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@class", activeUser.Class);
            lCommand.Parameters.AddWithValue("@uid", activeUser.UserID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
            while (lReader.Read())
            {
                lSCPList.Add(Convert.ToInt32(lReader["scpNum"]));
            }
            lReader.Close();
            return lSCPList;
        }

        public List<int> getAssignableSCPsO5(int aUID)
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT DISTINCT i.scpNum FROM Item i WHERE i.scpNum NOT IN (SELECT a.scpNum FROM Assigned a WHERE a.userID = @uid);";
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@uid", aUID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
            while (lReader.Read())
            {
                lSCPList.Add(Convert.ToInt32(lReader["scpNum"]));
            }
            lReader.Close();
            return lSCPList;
        }


        public List<User> getUsersManaged()
        {
            List<User> lUserList = new List<User>();
            string lQuery = "SELECT u2.* FROM Users u1, Users u2 WHERE u1.userID = @uid AND u2.class < u1.class Order By class";
            int lUID;
            int lClass;
            string lName;
            
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@uid", activeUser.UserID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
                
            while (lReader.Read())
            {
                lUID = int.Parse(lReader["userID"].ToString());
                lClass = int.Parse(lReader["class"].ToString());
                lName = lReader["name"].ToString();
                lUserList.Add(new User(lUID,lClass,lName));
            }
            lReader.Close();
            return lUserList;
        }
        
        public List<User> getUsers()
        {
            List<User> lUserList = new List<User>();
            string lQuery = "SELECT u.* FROM Users u ORDER BY userID";
            int lUID;
            int lClass;
            string lName;
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();

            while (lReader.Read())
            {
                lUID = int.Parse(lReader["userID"].ToString());
                lClass = int.Parse(lReader["class"].ToString());
                lName = lReader["name"].ToString();
                lUserList.Add(new User(lUID, lClass, lName));
            }
            lReader.Close();
            return lUserList;
        }

        public List<int> getAssignableSCP(int aUID)
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT i.scpNum FROM Item i WHERE i.scpNum NOT IN (SELECT DISTINCT scpNum FROM Assigned a WHERE userID = @UID2) AND i.scpNum IN (SELECT scpNum FROM Assigned a2 WHERE userID = @UID1);";
            MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
            lCommand.Parameters.AddWithValue("@UID2", aUID);
            lCommand.Parameters.AddWithValue("@UID1", activeUser.UserID);
            lCommand.Prepare();
            MySqlDataReader lReader = lCommand.ExecuteReader();
            while (lReader.Read())
            {
                lSCPList.Add(int.Parse(lReader["scpNum"].ToString()));
            }
            lReader.Close();
            return lSCPList;
        }

        public bool updateUserClass(User aUser, ClassType aClass)
        {
            if (aClass > this.getAgentClass() && this.getAgentClass() != ClassType.O5)
                return false;
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            string lQuery = "UPDATE Users SET class = @class WHERE userID = @uid";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Transaction = lTrans;
            lCmd.Parameters.Add("@class", MySqlDbType.Int16);
            lCmd.Parameters.Add("@uid", MySqlDbType.Int16);
            lCmd.Parameters["@class"].Value = (int)aClass;
            lCmd.Parameters["@uid"].Value = aUser.UserID;
            lCmd.ExecuteNonQuery();
            this.setActiveUser(this.getAgentID());
            if (aClass > this.getAgentClass() && this.getAgentClass() != ClassType.O5)
            {
                lTrans.Rollback();
                return false;
            }
            else
                lTrans.Commit();
            return true;
        }

        public bool addUser(User aUser)
        {
            bool retval = true;
            if ((ClassType)activeUser.Class != ClassType.O5)
                return false;
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            try
            {
                string lQuery = "INSERT INTO Users VALUES (@uid, @name, @password, @class, NULL)";
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
                lCmd.Transaction = lTrans;
                lCmd.Parameters.Add("@class", MySqlDbType.Int16);
                lCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lCmd.Parameters.Add("@name", MySqlDbType.String);
                lCmd.Parameters.Add("@password", MySqlDbType.String);
                lCmd.Parameters["@uid"].Value = aUser.UserID;
                lCmd.Parameters["@class"].Value = (int)aUser.Class;
                lCmd.Parameters["@name"].Value = aUser.Name;
                lCmd.Parameters["@password"].Value = Hash(aUser.Password);
                if (lCmd.ExecuteNonQuery() != 1)
                {
                    lTrans.Rollback();
                    return false;
                }
                else
                    lTrans.Commit();
            }
            catch
            {
                lTrans.Rollback();
                retval = false;
            }
            return retval;
        }

        public int getNextUserID()
        {
            int nextUserID = -1;
            string lQuery = "SELECT userID FROM Users ORDER BY userID DESC LIMIT 1";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            MySqlDataReader lReader = lCmd.ExecuteReader();
            while (lReader.Read())
            {
                nextUserID = Convert.ToInt32(lReader["userID"]);
            }
            lReader.Close();
            if (nextUserID == -1)
                throw new Exception("Lookup failed!");
            return ++nextUserID;
        }

        public bool editUser(User aUser)
        {
            bool retval = true;
            string lQuery;
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            try
            {
                if(aUser.Password == "")
                    lQuery = "UPDATE Users SET name=@name, class=@class WHERE userID = @uid";
                else
                    lQuery = "UPDATE Users SET name=@name, passwd=@password, class=@class WHERE userID = @uid";
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
                lCmd.Transaction = lTrans;
                lCmd.Parameters.Add("@class", MySqlDbType.Int16);
                lCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lCmd.Parameters.Add("@name", MySqlDbType.String);
                if(aUser.Password != "")
                    lCmd.Parameters.Add("@password", MySqlDbType.String);
                lCmd.Parameters["@uid"].Value = aUser.UserID;
                lCmd.Parameters["@class"].Value = (int)aUser.Class;
                lCmd.Parameters["@name"].Value = aUser.Name;
                if (aUser.Password != "")
                    lCmd.Parameters["@password"].Value = Hash(aUser.Password);
                if (lCmd.ExecuteNonQuery() != 1)
                {
                    lTrans.Rollback();
                    return false;
                }
                else
                    lTrans.Commit();
            }
            catch
            {
                lTrans.Rollback();
                retval = false;
            }
            return retval;
        }

        public bool insertNewAssignment(User aUser, int scpNum)
        {
            if (aUser.Class > this.getAgentClass())
                return false;
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            string lQuery = "INSERT INTO Assigned VALUES (@user , @SCP)";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Transaction = lTrans;
            lCmd.Parameters.Add("@user", MySqlDbType.Int16);
            lCmd.Parameters.Add("@SCP", MySqlDbType.Int16);
            lCmd.Parameters["@user"].Value = aUser.UserID;
            lCmd.Parameters["@SCP"].Value = scpNum;
            try {lCmd.ExecuteNonQuery();}
            catch { lTrans.Rollback();
                    return false;
            }
            
            lTrans.Commit();
            return true;
        }

        public string[] getSCP(int scpNum)
        {
            string lQuery = "SELECT i.scpNum, i.class, s.content AS scp, d.content AS descript FROM Item i INNER JOIN SCP s ON i.scpProcID = s.scpProcID INNER JOIN Description d ON i.descriptID = d.descriptID WHERE i.scpNum = @scp LIMIT 1";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            string[] lSCP = new string[4];
            lCmd.Parameters.AddWithValue("@scp", scpNum);
            lCmd.Prepare();
            MySqlDataReader lReader = lCmd.ExecuteReader();
            if (!lReader.Read())
            {
                lReader.Close();
                throw new Exception("Unable to find SCP!");
            }
            lSCP[0] = lReader["scpNum"].ToString();
            lSCP[1] = lReader["class"].ToString();
            lSCP[2] = lReader["scp"].ToString();
            lSCP[3] = lReader["descript"].ToString();
            lReader.Close();
            return lSCP;
        }

        public string getInterviewText(int scpNum)
        {
            string lQuery = "SELECT DISTINCT i.invNum, i.content, u.name FROM Interview i LEFT OUTER JOIN Attended a ON a.invNum = i.invNum INNER JOIN Users u ON a.userID = u.userID WHERE i.scpNum = @scp ORDER BY i.invNum, a.userID;";
            StringBuilder retval = new StringBuilder();
            string lInterviewNumOld= "";
            string lInterviewNumNew = "";
            string lContent = "";
            List<string> lInterviewAttended = new List<string>();
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Parameters.AddWithValue("@scp", scpNum);
            lCmd.Prepare();
            MySqlDataReader lReader = lCmd.ExecuteReader();
            while (lReader.Read())
            {
                lInterviewNumNew = lReader[0].ToString();
                if (lInterviewNumNew != lInterviewNumOld)
                {
                    if (lContent != "")
                        retval.Append("\n\n");
                    retval.Append(lContent);
                    if (lContent != "")
                        retval.Append("\n\n-------------------------------------\n\n");
                    lContent = lReader[1].ToString();
                    retval.Append("Interview Num: " + lInterviewNumNew);
                    retval.Append("\n");
                    retval.Append("Attendees: ");
                    retval.Append("\n");
                    if (lReader[2].ToString() == "")
                        retval.Append("None");
                    else
                        retval.Append(lReader[2].ToString());
                    retval.Append("\n");
                    lInterviewNumOld = lInterviewNumNew;
                }
                else
                {
                    if (lReader[2].ToString() != "")
                    {
                        retval.Append(lReader[2].ToString());
                        retval.Append("\n");
                    }
                }
            }
            if (lContent != "")
                retval.Append("\n\n" + lContent);
            lReader.Close();
            return retval.ToString();
        }

        public string getAddendumText(int scpNum)
        {
            string lQuery = "SELECT DISTINCT a.refNum, a.content FROM Addendum a WHERE a.scpNum = @scp ORDER BY a.refNum;";
            StringBuilder retval = new StringBuilder();
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Parameters.AddWithValue("@scp", scpNum);
            lCmd.Prepare();
            MySqlDataReader lReader = lCmd.ExecuteReader();
            while (lReader.Read())
            {
                retval.Append("\n\n-------------------------------------\n\n");
                retval.Append("Addenum Num: " + lReader[0]);
                retval.Append("\n");
                retval.Append(lReader[1].ToString());
            }
            lReader.Close();
            return retval.ToString();
        }

        public bool updateItem(int scpNum, int cType, string SCPcontent, string descript)
        {
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            string lQuery = "UPDATE SCP SET content = @SCP WHERE scpProcID = @scpNum;";
            string lQuery2 = "UPDATE Description SET content = @descript WHERE descriptID = @scpNum;";
            string lQuery3 = "UPDATE Item SET class=@cType, creatoruserID=@userID WHERE scpNum = @scpNum;";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            MySqlCommand lCmd2 = new MySqlCommand(lQuery2, mConnection);
            MySqlCommand lCmd3 = new MySqlCommand(lQuery3, mConnection);
            lCmd.Transaction = lTrans;
            lCmd.Parameters.Add("@scpNum", MySqlDbType.Int16);
            lCmd.Parameters.Add("@SCP", MySqlDbType.Text);
            lCmd2.Parameters.Add("@descript", MySqlDbType.Text);
            lCmd2.Parameters.Add("@scpNum", MySqlDbType.Int16);
            lCmd3.Parameters.Add("@cType", MySqlDbType.Int16);
            lCmd3.Parameters.Add("@userID", MySqlDbType.Int16);
            lCmd3.Parameters.Add("@scpNum", MySqlDbType.Int16);
            lCmd.Parameters["@scpNum"].Value = scpNum;
            lCmd.Parameters["@SCP"].Value = SCPcontent;
            lCmd2.Parameters["@descript"].Value = descript;
            lCmd2.Parameters["@scpNum"].Value = scpNum;
            lCmd3.Parameters["@scpNum"].Value = scpNum;
            lCmd3.Parameters["@cType"].Value = cType;
            lCmd3.Parameters["@userID"].Value = getAgentID();
            lCmd.Prepare();
            lCmd2.Prepare();
            lCmd3.Prepare();
            if (lCmd.ExecuteNonQuery() != 1)
            {
                lTrans.Rollback();
                return false;
            }
            else
            {
                if (lCmd2.ExecuteNonQuery() != 1)
                {
                    lTrans.Rollback();
                    return false;
                }
                else
                {
                    if (lCmd3.ExecuteNonQuery() != 1)
                    {
                        lTrans.Rollback();
                        return false;
                    }
                    else
                        lTrans.Commit();
                }
            }
            return true;
        }

        public bool deleteAssignment(User aUser, int scpNum)        {
            if (aUser.Class > this.getAgentClass())
                return false;
            MySqlTransaction lTrans = mConnection.BeginTransaction();
            string lQuery = "DELETE FROM Assigned WHERE userID = @user AND scpNum = @SCP";
            MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
            lCmd.Transaction = lTrans;
            lCmd.Parameters.Add("@user", MySqlDbType.Int16);
            lCmd.Parameters.Add("@SCP", MySqlDbType.Int16);
            lCmd.Parameters["@user"].Value = aUser.UserID;
            lCmd.Parameters["@SCP"].Value = scpNum;

            if (lCmd.ExecuteNonQuery() != 1)
            {
                lTrans.Rollback();
                return false;
            }
            else
                lTrans.Commit();
            return true;
        }

        //Count statement
        public int Count()
        {
            return 0;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }

        // GET METHODS

        public string getAgentName()
        {
            return activeUser.Name;
        }

        public int getAgentID()
        {
            return activeUser.UserID;
        }

        public ClassType getAgentClass()
        {
            return activeUser.Class;
        }

        public string getSessionID()
        {
            return mSessionID;
        }
    }
}
