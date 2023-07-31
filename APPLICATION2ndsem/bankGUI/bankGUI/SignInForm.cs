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
        private ErrorProvider errorProvider;
        public SignInForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private Person takeInputWithoutRole()
        {
            string loginusername = nameTB.Text.Trim();
            string loginpassword = passwordTB.Text;

            if (string.IsNullOrWhiteSpace(loginusername) || string.IsNullOrWhiteSpace(loginpassword))
            {
                MessageBox.Show("Please enter name and password.");
                return null;
            }

            // Validate name (should contain only alphabets)
            if (!IsValidName(loginusername))
            {
                return null;
            }

            // Validate password (should be exactly 4 digits)
            if (!IsValidPassword(loginpassword))
            {
                return null;
            }

            Person user = new Person(loginusername, loginpassword);
            return user;
        }


        private void signinBTN_Click(object sender, EventArgs e)
        {
            if (!validateInputs()) { return; };

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
                    this.Close();
                    ClientMenuForm cmf = new ClientMenuForm();
                    ExtraDL.CurrentClient = c1;
                    cmf.Show();
                }

            }
        }
        private bool validateInputs()
        {
            bool isValid = true;

            if (!IsValidName(nameTB.Text))
            {
                isValid = false;
                errorProvider.SetError(nameTB, "Invalid name. Phone number should alphabets.");
            }
            else
            {
                errorProvider.SetError(nameTB, "");
            }

            if (!IsValidPassword(passwordTB.Text))
            {
                isValid = false;
                errorProvider.SetError(passwordTB, "Invalid password. Password should be exactly 4 digits.");
            }
            else
            {
                errorProvider.SetError(passwordTB, "");
            }

            return isValid;
        }
        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }
        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length == 4 && password.All(char.IsDigit);
        }
        private void SignInForm_Load(object sender, EventArgs e) {}
    }
}
