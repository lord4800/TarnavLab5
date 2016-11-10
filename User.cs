using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

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
            password = GetHash(_newPassword);
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
        public static string GetHash(string str)
        {
            //переводим строку в байт-массим
            Byte[] strBytes = Encoding.Default.GetBytes(str);
            //создаем объект для получения средст шифрования
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //вычисляем хеш-представление в байтах
            Byte[] hashBytes = md5.ComputeHash(strBytes);
            //формируем одну цельную строку из массива
            string hash = string.Empty;
            foreach (var item in hashBytes)
            {
                hash += string.Format("{0:x2}", item);
            }
            return hash;
        }
    }
}
