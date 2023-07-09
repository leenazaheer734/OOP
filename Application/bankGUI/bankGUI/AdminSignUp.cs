using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using bankGUI.DL;
using bankGUI.BL;

namespace bankGUI
{
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
        }

        private void signupBTN_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            //name = BankUI.checkNameValidity(name);
            string password = passwordTB.Text;
            // password = BankUI.checkPinLength(password);
            // password = BankUI.checkPinDigits(password).ToString();
            string phonenumber = contactTB.Text;
            // phonenumber = BankUI.checkNumberLength(phonenumber);
            // phonenumber = BankUI.checkPinDigits(phonenumber).ToString();

            Person p1 = new Person(name, password, "admin", phonenumber);
            Admin ad1 = new Admin(p1);

            AdminDL.StoreAdminInList(ad1);
            AdminDL.StoreAdminDatainFile(ad1);
            MessageBox.Show("Successfully Signed Up");
            this.Close();
            SignInForm sif = new SignInForm();
            sif.Show();
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
