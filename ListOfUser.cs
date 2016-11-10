using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Lab5
{
    [Serializable]
    class ListOfUser
    {
        private List<User> userlist;
        public ListOfUser()
        {
            userlist = new List<User>();
        }
        public void addNewUser(User _newUser)
        {
            userlist.Add(_newUser);
        }

        public void addNewUser(string _newName, string _newPassword, string _newTag)
        {
            User _newUser = new User(_newName,_newPassword,_newTag);
            userlist.Add(_newUser);
        }

        public User findUser(User _user)
        {
            User _findUser = new User();
            foreach (User _currentUser in userlist)
            {
                if (_currentUser.getUserName() == _user.getUserName())
                {
                    if (_currentUser.getUserPassword() == _user.getUserPassword())
                    {
                        _findUser = _currentUser;
                    }
                }
            }
            return _findUser;
        }

        public User findUser(string _name, string _password)
        {
            User _findUser = new User();
            foreach (User _currentUser in userlist)
            {
                if (_currentUser.getUserName() == _name)
                {
                    if (_currentUser.getUserPassword() == _password)
                    {
                        _findUser = _currentUser;
                    }
                }
            }
            return _findUser;
        }

        public void saveUserList()
        {
            BinaryFormatter binFormat = new BinaryFormatter();
            // Сохранить объект в локальном файле.
            using (Stream fStream = new FileStream("user.dat",
               FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, userlist);
            }
        }
    }
}
