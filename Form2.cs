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
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //user need serialization
            //create list of users
            //parameter enable
            /*
            //http://professorweb.ru/my/csharp/thread_and_files/level4/4_1.php
            */
            /*AppDomain myDomain = Thread.GetDomain();

            myDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal myPrincipal = (WindowsPrincipal)Thread.CurrentPrincipal;
            Console.WriteLine("{0} belongs to: ", myPrincipal.Identity.Name.ToString());
            Array wbirFields = Enum.GetValues(typeof(WindowsBuiltInRole));
            foreach (object roleName in wbirFields)
            {
                try
                {
                    Console.WriteLine("{0}? {1}.", roleName, myPrincipal.IsInRole((WindowsBuiltInRole)roleName));
                    Console.WriteLine("The RID for this role is: " + ((int)roleName).ToString());
                }
                catch (Exception)
                {
                    Console.WriteLine("{0} : Could not obtain role for this RID.", roleName);
                }
            }
            // Get the role using the string value of the role.
            Console.WriteLine("{0}? {1}.", "Administrators",
                myPrincipal.IsInRole("BUILTIN\\" + "Administrators"));
            Console.WriteLine("{0}? {1}.", "Users",
                myPrincipal.IsInRole("BUILTIN\\" + "Users"));
            // Get the role using the WindowsBuiltInRole enumeration value.
            Console.WriteLine("{0}? {1}.", WindowsBuiltInRole.Administrator,
               myPrincipal.IsInRole(WindowsBuiltInRole.Administrator));
            // Get the role using the WellKnownSidType.
            SecurityIdentifier sid = new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null);
            Console.WriteLine("WellKnownSidType BuiltinAdministratorsSid  {0}? {1}.", sid.Value, myPrincipal.IsInRole(sid));
            //string sUserName = "Softy.com";
            
            //WindowsIdentity newUser = new WindowsIdentity(sUserName);
            //Console.WriteLine("Created a Windows identity object named " + newUser.Name + ".");
            /*var Text = textBox1.Text;
            var Password = textBox2.Text;
            string sUserName = "Softy";
            string authenticationType = "WindowsAuthentication";
            IntPtr key = new IntPtr();
            WindowsIdentity newUser = new WindowsIdentity(sUserName,authenticationType);
            Console.WriteLine("Created a Windows identity object named " + newUser.Name + ".");*/
            this.Close();
        }
    }
}
