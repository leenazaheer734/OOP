using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bankGUI.BL;
using bankGUI.DL;

namespace bankGUI
{
    public partial class SignInForm : Form
    {
        public SignInForm()
        {
            InitializeComponent();
        }

       
        private Person takeInputWithoutRole()
        {
            string loginusername = nameTB.Text;
            //loginusername = BankUI.checkNameValidity(loginusername);
            string loginpassword = passwordTB.Text;
            // loginpassword = BankUI.checkPinLength(loginpassword);
            // loginpassword = BankUI.checkPinDigits(loginpassword).ToString();

            if (loginusername != null && loginpassword != null)
            {
                Person user = new Person(loginusername, loginpassword);
                return user;
            }
            return null;
        }

        private void signinBTN_Click(object sender, EventArgs e)
        {
            Person plogin = takeInputWithoutRole();
            if (plogin != null)
            {
                nameTB.Text = null;
                passwordTB.Text = null;

                Client c1 = ClientDL.checkPersonIsClient(plogin);
                Admin a1 = AdminDL.checkAdmin(plogin);

                if (a1 == null && c1 == null)
                {
                    MessageBox.Show("Account not Found");
                }
                else if (c1 == null && a1 != null)
                {
                    MessageBox.Show("Admin");
                    this.Close();
                    AdminMenu am = new AdminMenu();
                    am.Show();
                }
                else
                {
                    MessageBox.Show("Client");
                }

            }
        }

        private void SignInForm_Load(object sender, EventArgs e)
        {

        }
    }
}
