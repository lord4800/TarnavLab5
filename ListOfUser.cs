using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
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
            //Hashtable addresses = new Hashtable();
            FileStream fs = new FileStream("DataFile.soap", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            try
            {
                formatter.Serialize(fs, userlist);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to serialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
            }
        }

        public void loadUserList()
        {
            List<User> _userlist;
            FileStream fs = new FileStream("DataFile.soap", FileMode.Open);
            try
            {
                SoapFormatter formatter = new SoapFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                _userlist = (List<User>)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
                userlist = _userlist;
            }

            // To prove that the table deserialized correctly, 
            // display the key/value pairs to the console.
            foreach (User _user in _userlist)
            {
                
            }
        }
    }
}
