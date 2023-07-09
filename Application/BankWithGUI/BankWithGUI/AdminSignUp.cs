using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BankWithGUI.BL;
using BankWithGUI.DL;

namespace BankWithGUI
{
    public partial class AdminSignUp : Form
    {
        public AdminSignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            string password = PasswordTB.Text;
            // password = BankUI.checkPinLength(password);
            // password = BankUI.checkPinDigits(password).ToString();
            string phonenumber = ContactTB.Text;
           // phonenumber = BankUI.checkNumberLength(phonenumber);
           //phonenumber = BankUI.checkPinDigits(phonenumber).ToString();
            string address = AddressTB.Text;
           // address = BankUI.checkAddress(address);
            Person p1 = new Person(name, password, "admin", phonenumber, address);
            Admin ad1 = new Admin(p1);

            AdminDL.StoreAdminInList(ad1);
            AdminDL.StoreAdminDatainFile(ad1);
            MessageBox.Show("Admin Succesfully Signed Up");
        }

        private void AdminSignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
