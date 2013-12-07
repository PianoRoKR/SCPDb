using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace SCPDb
{
    class DBConnect
    {
        private MySqlConnection mConnection;
        private string mServer;
        private string mDatabase;
        private string mUid;
        private string mPassword;
        private string mSessionID;
        //Constructor
        public DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            mServer = "scpdb.dyndns.info";
            mDatabase = "scpdb";
            mUid = "root";
            mPassword = "scpdbpass123";
            string lConnectionString;
            lConnectionString = "SERVER=" + mServer + ";" + "DATABASE=" +
            mDatabase + ";" + "UID=" + mUid + ";" + "PASSWORD=" + mPassword + ";";

            mConnection = new MySqlConnection(lConnectionString);            
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
            string lQuery = "SELECT uid FROM Users WHERE userID = @uid AND password = @pass";
            string lUID = null;
            if (this.OpenConnection() == true)
            {
                MySqlCommand lUserIDLoginCmd = new MySqlCommand(lQuery, mConnection);
                MySqlDataReader lDataReader = lUserIDLoginCmd.ExecuteReader();
                lUserIDLoginCmd.Parameters.Add("@uid", MySqlDbType.Int16);
                lUserIDLoginCmd.Parameters.Add("@pass", MySqlDbType.String);
                lUserIDLoginCmd.Parameters["@uid"].Value = aUID;
                SHA1 lHasher = SHA1.Create();
                byte[] lHash = lHasher.ComputeHash(GetBytes(aPassword));
                lUserIDLoginCmd.Parameters["@pass"].Value = BitConverter.ToString(lHash).Replace("-", "");
                lUserIDLoginCmd.Prepare();
                while (lDataReader.Read())
                {
                    lUID = Convert.ToString(lDataReader["uid"]);
                }
            }
            return lUID;
        }

        public int SelectUID(string aSession)
        {
            string lQuery = "SELECT uid FROM Users WHERE sessionid = @session";
            string lUID = null;
            if (this.OpenConnection() == true)
            {
                MySqlCommand lSessionLookup = new MySqlCommand(lQuery, mConnection);
                lSessionLookup.Parameters.Add("@session", MySqlDbType.String);
                lSessionLookup.Parameters["@session"].Value = aSession;
                lSessionLookup.Prepare();
                MySqlDataReader lDataReader = lSessionLookup.ExecuteReader();
                while (lDataReader.Read())
                {
                    lUID = Convert.ToString(lDataReader["uid"]);
                }
            }
            return lUID;
        }

        public bool ExecuteLogin(int aUID, string aPassword)
        {
            int lValidUID = this.SelectUID(aUID, aPassword);
            string lUpdateStatement = "UPDATE Users SET sessionid=@session WHERE userid=@uid";

            if (lValidUID == -1)
                return false;
            else
            {

            }
        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        //Select statement
        public List<string>[] SelectUID()
        {
            string lQuery = "SELECT uid FROM tableinfo";

            //Create a list to store the result
            List<string>[] lList = new List<string>[3];
            lList[0] = new List<string>();
            lList[1] = new List<string>();
            lList[2] = new List<string>();

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand lCmd = new MySqlCommand(lQuery, mConnection);
                //Create a data reader and Execute the command
                MySqlDataReader lDataReader = lCmd.ExecuteReader();

                //Read the data and store them in the list
                while (lDataReader.Read())
                {
                    lList[0].Add(lDataReader["id"] + "");
                    lList[1].Add(lDataReader["name"] + "");
                    lList[2].Add(lDataReader["age"] + "");
                }

                //close Data Reader
                lDataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return lList;
            }
            else
            {
                return lList;
            }
        }

        //Count statement
        public int Count()
        {
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
