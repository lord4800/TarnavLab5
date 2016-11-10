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
    public partial class Form1 : Form
    {
        public ListOfUser listOfUser;
        public static User currentUser = new User("","","nouser");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            listOfUser = new ListOfUser();
            var Name = WindowsIdentity.GetCurrent().Name;
            var Token = WindowsIdentity.GetCurrent().Token;
            var IsAuthenticated = WindowsIdentity.GetCurrent().IsAuthenticated;
            var SID = WindowsIdentity.GetCurrent().User;
            this.richTextBox1.Text = "Сведения о текущем пользователе\n";
            Console.WriteLine("Сведения о текущем пользователе\n");
            this.richTextBox1.Text += ("Имя: " + Name + "\n");
            Console.WriteLine("Имя: " + Name);
            this.richTextBox1.Text += ("Аутентифицирован: " + IsAuthenticated + "\n");
            Console.WriteLine("Аутентифицирован: " + IsAuthenticated);
            this.richTextBox1.Text += ("SID: " + SID + "\n");
            Console.WriteLine("SID: " + SID);

            this.richTextBox1.Text += ("\n");

            AppDomain myDomain = Thread.GetDomain();
            //Выполняется привязка к участнику при выполнении в этом домене приложения
            myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //Определяется текущий принципал
            WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            //Определяется аутентификатор принципала
            WindowsIdentity identity = (WindowsIdentity)myPrincipal.Identity;
            //Выводятся идентификационные сведения о принципале
            this.richTextBox1.Text += ("Тип идентификации: " + identity + "\n");
            Console.WriteLine("Тип идентификации: " + identity);
            this.richTextBox1.Text += ("Имя: " + identity.Name + "\n");
            Console.WriteLine("Имя: " + identity.Name);
            //Получение роли из перечисления WindowsBuiltInRole
            Console.WriteLine("Пользователи? " + myPrincipal.IsInRole(WindowsBuiltInRole.User));
            this.richTextBox1.Text += ("Пользователи? " + myPrincipal.IsInRole(WindowsBuiltInRole.User) + "\n");
            //Получение роли из текстовой строки
            this.richTextBox1.Text += ("Администраторы? " + myPrincipal.IsInRole(@"BUILTIN\Administrators") + "\n");
            Console.WriteLine("Администраторы? " + myPrincipal.IsInRole(@"BUILTIN\Administrators"));
            setPrivate(myPrincipal);
            
        }

        private void setPrivate(WindowsPrincipal _principal)
        {
            if (_principal.IsInRole(@"BUILTIN\Administrators"))
            {
                this.createToolStripMenuItem.Enabled = true;
                this.banToolStripMenuItem.Enabled = true;
                this.deleteToolStripMenuItem.Enabled = true;
                this.changeToolStripMenuItem.Enabled = true;
                this.inToolStripMenuItem.Enabled = false;
                this.exitToolStripMenuItem.Enabled = true;
            }
            else
            {
                this.createToolStripMenuItem.Enabled = true;
                this.banToolStripMenuItem.Enabled = false;
                this.deleteToolStripMenuItem.Enabled = false;
                this.changeToolStripMenuItem.Enabled = true;
                this.inToolStripMenuItem.Enabled = true;
                this.exitToolStripMenuItem.Enabled = true;
            }
        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void inToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(listOfUser);
            f2.Show();
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentUser.getUserTag() != "user")
            {
                this.richTextBox1.Text += ("You need Entry. Program made by Bomba \n");
            }
            else
            {
                this.richTextBox1.Text += ("Current User \"" + currentUser.getUserName() + "\" Program made by Bomba \n");
            }
        }
    }
}
