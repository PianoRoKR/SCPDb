using System;
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
        private bool mLoggedIn = false;

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
            string lQuery = "SELECT userID FROM Users WHERE userID = @uid AND passwd = @pass";
            int lUID = -1;
            MySqlCommand lUserIDLoginCmd = new MySqlCommand(lQuery, mConnection);
            lUserIDLoginCmd.Parameters.Add("@uid", MySqlDbType.Int16);
            lUserIDLoginCmd.Parameters.Add("@pass", MySqlDbType.String);
            lUserIDLoginCmd.Parameters["@uid"].Value = aUID;
            lUserIDLoginCmd.Parameters["@pass"].Value = Hash(aPassword);
            lUserIDLoginCmd.Prepare();
            MySqlDataReader lDataReader = lUserIDLoginCmd.ExecuteReader();
            while (lDataReader.Read())
            {
                lUID = Convert.ToInt32(lDataReader["userID"]);
            }
            lDataReader.Close();
            return lUID;
        }

        public string Hash(string aPasswd)
        {
            SHA1 lHasher = SHA1.Create();
            byte[] lHash = lHasher.ComputeHash(GetBytes(aPasswd));
            return BitConverter.ToString(lHash).Replace("-", "").ToLower();
        }


        public int SelectUID(string aSession)
        {
            string lQuery = "SELECT uid FROM Users WHERE sessionid = @session";
            int lUID = -1;
            MySqlCommand lSessionLookup = new MySqlCommand(lQuery, mConnection);
            lSessionLookup.Parameters.Add("@session", MySqlDbType.String);
            lSessionLookup.Parameters["@session"].Value = aSession;
            lSessionLookup.Prepare();
            MySqlDataReader lDataReader = lSessionLookup.ExecuteReader();
            while (lDataReader.Read())
            {
                lUID = Convert.ToInt32(lDataReader["uid"]);
            }
            lDataReader.Close();
            return lUID;
        }

        public bool ExecuteLogin(int aUID, string aPassword)
        {
            int lValidUID = this.SelectUID(aUID, aPassword);
            string lQuery = "UPDATE Users SET sessionid=@session WHERE userid=@uid";
            string lSessionID = DateTime.Now.ToFileTime().ToString();
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
                    mLoggedIn = true;
                    return true;
                }
                return false;
            }
        }

        public bool ExecuteLogout(int aUID)
        {
            string lQuery = "UPDATE Users SET sessionid = NULL WHERE userid=@uid";
            string lSessionID = DateTime.Now.ToFileTime().ToString();
            MySqlCommand lSessionCmd = new MySqlCommand(lQuery, mConnection);
            lSessionCmd.Parameters.Add("@session", MySqlDbType.String);
            lSessionCmd.Parameters.Add("@uid", MySqlDbType.Int16);
            lSessionCmd.Parameters["@uid"].Value = aUID;
            if (lSessionCmd.ExecuteNonQuery() == 1)
            {
                mSessionID = "";
                activeUser = null;
                mLoggedIn = false;
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

        public List<int> getSCPDb()
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT DISTINCT i.scpNum FROM Item i LEFT OUTER JOIN Assigned a ON i.scpNum = a.scpNum WHERE i.class < @class OR a.userId = @uid ORDER BY i.scpNum";
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
            string lQuery = "SELECT u2.* FROM Users u1, Users u2 WHERE u1.userID = @uid AND u2.class < u1.class";
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
            catch (Exception ex)
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
