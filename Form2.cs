using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;
using System.Security.Cryptography;


namespace Lab5
{
    public partial class Form2 : Form
    {
        ListOfUser listOfUser;
        public Form2(ListOfUser _listOfUser)
        {
            listOfUser = new ListOfUser();
            listOfUser = _listOfUser;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User newUser = new User(textBox1.Text, textBox2.Text, "user");
            listOfUser.addNewUser(newUser);
            listOfUser.saveUserList();
            this.Close();
        }
    }
}
