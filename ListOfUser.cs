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
    public class ListOfUser
    {
        public List<User> userlist;
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
        public void deleteUser(User _findUser)
        {
            List<User> _userlist = new List<User>();
            foreach (User _currentUser in userlist)
            {
                if (_currentUser != _findUser)
                {
                    _userlist.Add(_currentUser);
                }
            }
            userlist = new List<User>();
            userlist = _userlist;
        }
        public void saveUserList()
        {
            Hashtable users = new Hashtable();
            foreach (User _user in userlist)
            {
                users.Add(_user.getUserName(),_user);
            }
            FileStream fs = new FileStream("DataFile.soap", FileMode.Create);
            SoapFormatter formatter = new SoapFormatter();
            try
            {
                formatter.Serialize(fs, users);
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
            Hashtable users = null;
            FileStream fs = new FileStream("DataFile.soap", FileMode.Open);
            try
            {
                SoapFormatter formatter = new SoapFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                users = (Hashtable)formatter.Deserialize(fs);
            }
            catch (SerializationException e)
            {
                Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
                throw;
            }
            finally
            {
                fs.Close();
                //userlist = _userlist;
            }
            foreach (DictionaryEntry de in users)
            {
                User locuser = new User();
                locuser = (User)de.Value;
                Console.WriteLine(locuser.getUserName() + "\n");
                userlist.Add((User)de.Value);
            }

        }
    }
}
