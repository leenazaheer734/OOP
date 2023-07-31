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
    public partial class OpenAccount : UserControl
    {
        public OpenAccount()
        {
            InitializeComponent();
        }


        private Client takeAccountInput()
        {
            string name = nameTB.Text;
            string password = passwordTB.Text;
            string accounttype = acctypeTB.Text;
            string contact = contactTB.Text;
            double balance = 0;

            if (!IsValidName(name) || !IsValidPassword(password) || !IsValidAccountType(accounttype) || !IsValidPhoneNumber(contact) || Double.TryParse(strtAmtTB.Text, out balance) == false)
            {
                return null;
            }
            else
            {
                Person nu = new Person(name, password, "client", contact);
                Account acc = new Account(Form1.accountnum, balance, "running", accounttype);
                Client info = new Client(nu, acc);
                Form1.accountnum++;

                return info;
            }
        }

        private bool IsValidName(string name)
        {
            // Assuming a valid name should contain only alphabets
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }

        private bool IsValidPassword(string password)
        {
            // Assuming a valid password should be exactly 4 digits
            return !string.IsNullOrWhiteSpace(password) && password.Length == 4 && password.All(char.IsDigit);
        }

        private bool IsValidAccountType(string accounttype)
        {
            // Assuming a valid account type should be either "salary" or "current"
            return accounttype.Equals("salary", StringComparison.OrdinalIgnoreCase) || accounttype.Equals("current", StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Assuming a valid phone number should contain only digits and be 11 digits long
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }


        private void crtAccTB_Click(object sender, EventArgs e)
        {
            if (nameTB.Text == null || passwordTB.Text == null || contactTB.Text == null || strtAmtTB.Text == null || acctypeTB.Text == null)
            {
                // Display an error message to the user
                MessageBox.Show("Please fill in all the required fields.");
                return;        
            }
           
            Client c = takeAccountInput(); 
            if (c == null)
            {
                emptyTextBoxes();
                MessageBox.Show("Invalid Input! Enter again");              // Input is invalid, do not proceed with creating the account
                return;
            }

            // If all required fields are filled, proceed with creating the account
            ClientDL.AddClientinList(c);
            ClientDL.StoreClientInFile(c);
            MessageBox.Show("Account Created");
            emptyTextBoxes();
        }

        private void OpenAccount_Load(object sender, EventArgs e)
        {
            emptyTextBoxes();
        }
        private void emptyTextBoxes()
        {
            nameTB.Text = null;
            passwordTB.Text = null;
            contactTB.Text = null;
            strtAmtTB.Text = null;
            acctypeTB.Text = null;
        }
    }
}
