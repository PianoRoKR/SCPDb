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
        }

        public bool CloseSSH()
        {
            return mSSH.Disconnect();
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

        //Insert statement
        public void Insert()
        {
            string lQuery = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);

                //Execute command
                lCmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update()
        {
            string lQuery = "UPDATE tableinfo SET name='Joe', age='22' WHERE name='John Smith'";

            //Open connection
            if (this.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand lCmd = new MySqlCommand();
                //Assign the query using CommandText
                lCmd.CommandText = lQuery;
                //Assign the connection using Connection
                lCmd.Connection = mConnection;

                //Execute query
                lCmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string lQuery = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
                lCmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        public int SelectUID(int aUID, string aPassword)
        {
            string lQuery = "SELECT userID FROM Users WHERE userID = @uid AND passwd = @pass";
            int lUID = -1;
            if (this.OpenConnection() == true)
            {
                MySqlCommand lUserIDLoginCmd = new MySqlCommand(lQuery, mConnection);
                lUserIDLoginCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lUserIDLoginCmd.Parameters.Add("@pass", MySqlDbType.String);
                lUserIDLoginCmd.Parameters["@uid"].Value = aUID;
                SHA1 lHasher = SHA1.Create();
                byte[] lHash = lHasher.ComputeHash(GetBytes(aPassword));
                lUserIDLoginCmd.Parameters["@pass"].Value = BitConverter.ToString(lHash).Replace("-", "").ToLower();
                lUserIDLoginCmd.Prepare();
                MySqlDataReader lDataReader = lUserIDLoginCmd.ExecuteReader();
                while (lDataReader.Read())
                {
                    lUID = Convert.ToInt32(lDataReader["userID"]);
                }
                this.CloseConnection();
            }
            return lUID;
        }

        public int SelectUID(string aSession)
        {
            string lQuery = "SELECT uid FROM Users WHERE sessionid = @session";
            int lUID = -1;
            if (this.OpenConnection() == true)
            {
                MySqlCommand lSessionLookup = new MySqlCommand(lQuery, mConnection);
                lSessionLookup.Parameters.Add("@session", MySqlDbType.String);
                lSessionLookup.Parameters["@session"].Value = aSession;
                lSessionLookup.Prepare();
                MySqlDataReader lDataReader = lSessionLookup.ExecuteReader();
                while (lDataReader.Read())
                {
                    lUID = Convert.ToInt32(lDataReader["uid"]);
                }
                this.CloseConnection();
            }
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
                if (this.OpenConnection() == true)
                {
                    MySqlCommand lSessionCmd = new MySqlCommand(lQuery, mConnection);
                    lSessionCmd.Parameters.Add("@session", MySqlDbType.String);
                    lSessionCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                    lSessionCmd.Parameters["@uid"].Value = lValidUID;
                    lSessionCmd.Parameters["@session"].Value = lSessionID;
                    if (lSessionCmd.ExecuteNonQuery() == 1)
                    {
                        mSessionID = lSessionID;
                        this.CloseConnection();
                        setActiveUser(lValidUID, true);
                        mLoggedIn = true;
                        return true;
                    }
                    else
                    {
                        this.CloseConnection();
                        return false;
                    }
                }
                return false;
            }
        }

        public bool ExecuteLogout(int aUID)
        {
            string lQuery = "UPDATE Users SET sessionid = NULL WHERE userid=@uid";
            string lSessionID = DateTime.Now.ToFileTime().ToString();
            if (this.OpenConnection() == true)
            {
                MySqlCommand lSessionCmd = new MySqlCommand(lQuery, mConnection);
                lSessionCmd.Parameters.Add("@session", MySqlDbType.String);
                lSessionCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lSessionCmd.Parameters["@uid"].Value = aUID;
                if (lSessionCmd.ExecuteNonQuery() == 1)
                {
                    mSessionID = "";
                    this.CloseConnection();
                    activeUser = null;
                    mLoggedIn = false;
                    return true;
                }
                else
                {
                    this.CloseConnection();
                    return false;
                }
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
        private void setActiveUser(int userID, bool openConnection)
        {
            string lQuery = "SELECT name, class FROM Users WHERE userID = @UID";
            string lAgentName = "";
            int lAgentID = 0;
            ClassType lAgentClass = ClassType.L1;
            //Open connection
            if (!openConnection || this.OpenConnection() == true)
            {
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

                //close Connection
                this.CloseConnection();
            }
            else throw new Exception("userLookupFailed");
        }

        public List<string> getSCPDb()
        {
            List<string> lSCPList = new List<string>();
            string lQuery = "SELECT DISTINCT i.scpNum FROM Item i LEFT OUTER JOIN Assigned a ON i.scpNum = a.scpNum WHERE i.class < @class OR a.userId = @uid ORDER BY i.scpNum";
            if (this.OpenConnection() == true && mLoggedIn)
            {
                MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
                lCommand.Parameters.AddWithValue("@class", activeUser.Class);
                lCommand.Parameters.AddWithValue("@uid", activeUser.UserID);
                lCommand.Prepare();
                MySqlDataReader lReader = lCommand.ExecuteReader();
                while (lReader.Read())
                {
                    lSCPList.Add(lReader["scpNum"].ToString());
                }

                this.CloseConnection();
            }
            else
            {
                return null;
            }
            return lSCPList;
        }

        public List<User> getUsersManaged()
        {
            List<User> lUserList = new List<User>();
            string lQuery = "SELECT u2.* FROM Users u1, Users u2 WHERE u1.userID = @uid AND u2.class < u1.class";
            int lUID;
            int lClass;
            string lName;
            if (this.OpenConnection() == true && mLoggedIn)
            {
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

                this.CloseConnection();
            }
            else
            {
                return null;
            }
            return lUserList;
        }
        
        public List<User> getUsers()
        {
            List<User> lUserList = new List<User>();
            string lQuery = "SELECT u.* FROM Users u";
            int lUID;
            int lClass;
            string lName;
            if (this.OpenConnection() == true && mLoggedIn)
            {
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

                this.CloseConnection();
            }
            else
            {
                return null;
            }
            return lUserList;
        }

        public List<int> getAssignableSCP(int aUID)
        {
            List<int> lSCPList = new List<int>();
            string lQuery = "SELECT i.scpNum FROM Item i WHERE i.scpNum NOT IN (SELECT DISTINCT scpNum FROM Assigned a WHERE userID = @UID2) AND i.scpNum IN (SELECT scpNum FROM Assigned a2 WHERE userID = @UID1);";
            if (this.OpenConnection() == true && mLoggedIn)
            {
                MySqlCommand lCommand = new MySqlCommand(lQuery, mConnection);
                lCommand.Parameters.AddWithValue("@UID2", aUID);
                lCommand.Parameters.AddWithValue("@UID1", activeUser.UserID);
                lCommand.Prepare();
                MySqlDataReader lReader = lCommand.ExecuteReader();
                while (lReader.Read())
                {
                    lSCPList.Add(int.Parse(lReader["scpNum"].ToString()));
                }

                this.CloseConnection();
            }
            else
            {
                return null;
            }
            return lSCPList;
        }

        public bool updateUserClass(User aUser, ClassType aClass)
        {
            if (aClass >= this.getAgentClass() && this.getAgentClass() != ClassType.O5)
                return false;
            if (this.OpenConnection() == true)
            {
                MySqlTransaction lTrans = mConnection.BeginTransaction();
                string lQuery = "UPDATE Users SET class = @class WHERE userID = @uid";
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
                lCmd.Transaction = lTrans;
                lCmd.Parameters.Add("@class", MySqlDbType.Int16);
                lCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lCmd.Parameters["@class"].Value = (int)aClass;
                lCmd.Parameters["@uid"].Value = aUser.UserID;
                lCmd.ExecuteNonQuery();
                this.setActiveUser(this.getAgentID(), false);
                if (aClass >= this.getAgentClass() && this.getAgentClass() != ClassType.O5)
                {
                    lTrans.Rollback();
                    this.CloseConnection();
                    return false;
                }
                else
                    lTrans.Commit();
            }
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
