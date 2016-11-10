using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    [Serializable]
    class User
    {
        private string name;
        private string password;
        private string tag;

        public void changeUserPref(string _newName, string _newPassword)
        {
            name = _newName;
            password = _newPassword;
        }

        public User(string _newName, string _newPassword, string _newTag)
        {
            name = _newName;
            password = _newPassword;
            tag = _newTag;
        }

        public User()
        {
            name = "";
            password = "";
            tag = "";
        }

        public void setUserPref(string _newName, string _newPassword, string _newTag)
        {
            name = _newName;
            password = _newPassword;
            tag = _newTag;
        }

        public string getUserName()
        {
            return name;
        }

        public string getUserPassword()
        {
            return password;
        }

        public string getUserTag()
        {
            return tag;
        }
        
    }
}
