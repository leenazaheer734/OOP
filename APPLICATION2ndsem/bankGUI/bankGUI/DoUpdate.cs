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
    public partial class DoUpdate : UserControl
    {
        private int updatingAccount;
        private ErrorProvider errorProvider;

        public DoUpdate()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public int UpdatingAccount { get => updatingAccount; set => updatingAccount = value; }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            if (checkTextBoxes()) { return; };
            if (!validateInputs()) { return; };


            Client d =  ClientDL.seacrhwithACCnumber(updatingAccount);   //searching a user's details
            if (d != null)
            {
                d.ClientCred.Phonenumber = contactTB.Text.ToString(); 
                d.ClientCred.Password = passwordTB.Text.ToString();
                d.Account.Status = statusTB.Text.ToString();
                d.Account.Type = acctypeTB.Text.ToString();

                ClientDL.UpdateClientDataInFile();
            }
            MessageBox.Show("Updated");
            Controls.Clear();
            UpdateClientInfo update = new UpdateClientInfo();
            this.Controls.Add(update);
            update.Visible = true;
        }
        private bool checkTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(contactTB.Text) || string.IsNullOrWhiteSpace(passwordTB.Text) ||
               string.IsNullOrWhiteSpace(statusTB.Text) || string.IsNullOrWhiteSpace(acctypeTB.Text))
            {
                MessageBox.Show("Fill the Information First");
                return true;
            }
            return false;
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return !string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length == 11 && phoneNumber.All(char.IsDigit);
        }

        private bool validateInputs()
        {
            bool isValid = true;

            if (!IsValidPhoneNumber(contactTB.Text))
            {
                isValid = false;
                errorProvider.SetError(contactTB, "Invalid phone number. Phone number should contain 11 digits.");
            }
            else
            {
                errorProvider.SetError(contactTB, "");
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
        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrWhiteSpace(password) && password.Length == 4 && password.All(char.IsDigit);
        }
    }
}
