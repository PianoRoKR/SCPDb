using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCPDb.Classes
{
    public enum ClassType
    {
        L1 = 1,
        L2 = 2,
        L3 = 3,
        L4 = 4,
        O5 = 5
    }
    public class User
    {
        private int mUserID;
        private ClassType mClass;
        private string mName;
        private string mPass;

        public int UserID
        {
            get
            {
                return mUserID;
            }
        }

        public ClassType Class
        {
            get
            {
                return mClass;
            }
            set
            {
                mClass = value;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public string Password
        {
            get
            {
                return mPass;
            }
        }

        public User(int aUserID, int aClass, string aName)
        {
            mUserID = aUserID;
            mClass = (ClassType)aClass;
            mName = aName;
        }

        public User(int aUserID, int aClass, string aName, string aPass)
        {
            mUserID = aUserID;
            mClass = (ClassType)aClass;
            mName = aName;
            mPass = aPass;
        }

        public override string ToString()
        {
            StringBuilder lStringBuilder = new StringBuilder();
            lStringBuilder.Append(this.Name);
            string lString = lStringBuilder.ToString().PadRight(32);
            lStringBuilder.Clear();
            lStringBuilder.Append(lString);
            lStringBuilder.Append(this.mClass.ToString());
            return lStringBuilder.ToString();
        }

        
    }
}
