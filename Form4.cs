using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ListOfUser listOfUser = new ListOfUser();
            User locUser = new User();
            listOfUser.loadUserList();
            listOfUser.deleteUser(Form1.currentUser);
            //Form1.currentUser = listOfUser.findUser(locUser);
            locUser = listOfUser.findUser(Form1.currentUser);
            locUser.changeUserPref(this.textBox1.Text, this.textBox2.Text);
            Form1.currentUser = locUser;
            listOfUser.addNewUser(locUser);
            listOfUser.saveUserList();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
