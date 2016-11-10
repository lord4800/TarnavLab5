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
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            var Name = WindowsIdentity.GetCurrent().Name;
            var Token = WindowsIdentity.GetCurrent().Token;
            var IsAuthenticated = WindowsIdentity.GetCurrent().IsAuthenticated;
            var SID = WindowsIdentity.GetCurrent().User;
            Console.WriteLine("Сведения о текущем пользователе\n");
            Console.WriteLine("Имя: " + Name);
            Console.WriteLine("Аутентифицирован: " + IsAuthenticated);
            Console.WriteLine("SID: " + SID);


            
            AppDomain myDomain = Thread.GetDomain();
            //Выполняется привязка к участнику при выполнении в этом домене приложения
            myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            //Определяется текущий принципал
            WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            //Определяется аутентификатор принципала
            WindowsIdentity identity = (WindowsIdentity)myPrincipal.Identity;
            //Выводятся идентификационные сведения о принципале
            Console.WriteLine("Тип идентификации: " + identity);
            Console.WriteLine("Имя: " + identity.Name);
            //Получение роли из перечисления WindowsBuiltInRole
            Console.WriteLine("Пользователи? " + myPrincipal.IsInRole(WindowsBuiltInRole.User));
            //Получение роли из текстовой строки
            Console.WriteLine("Администраторы? " + myPrincipal.IsInRole(@"BUILTIN\Administrators"));
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

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void banToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void changeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
