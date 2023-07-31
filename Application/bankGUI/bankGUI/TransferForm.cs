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
    public partial class TransferForm : UserControl
    {
        private ErrorProvider errorProvider;
        public TransferForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void transfer_BTN_Click(object sender, EventArgs e)
        {
            if(checkEmptyTextBoxes() ||!IsValidInput()) { return; }
            if (TransDL.checkStatusOfAccount(ExtraDL.CurrentClient))
            {
                Transaction t = transferMoney(ExtraDL.CurrentClient);
                if (t != null)
                {
                    TransDL.AddTransactionInList(t);
                    ClientDL.UpdateClientDataInFile();
                    TransDL.StoreTransactionInFile(t);
                    MessageBox.Show("Transferred Succesfully");
                }
                else
                {
                    MessageBox.Show("Account Not Found");
                }
            }
            else
            {
                MessageBox.Show("Money cannot be transferred! Your account is blocked!");
            }
            recpACCNUM_tb.Text = null;
            recpAMOUNT_tb.Text = null;
            recpNAME_tb.Text = null;
        }

        private Transaction transferMoney(Client c)
        {
            string name = recpNAME_tb.Text.ToString();
            int accountnum = int.Parse(recpACCNUM_tb.Text);
            double amount = double.Parse(recpAMOUNT_tb.Text);

            Account a = new Account(accountnum);
            Person p = new Person(name);
            Client c1 = new Client(p, a);
            c1 = ClientDL.SearchClientAccount(c1);        //checking if recipient's account exists
            if (c1 != null)
            {
                string transfeeAccount = c1.Account.AccountNumber.ToString();

                TransDL.addMoneyInAccount(amount, c1);     //addming money in recipient's account
                TransDL.minusMoneyFromAccount(amount, c);   //subtracting from sender's account

                Transaction t = new Transaction(c, amount, DateTime.Now, "transfer", transfeeAccount);
                return t;
            }
            else
            {
                return null;
            }
        }
        private bool IsValidInput()
        {
            bool isValid = true;

            // Validate recipient name
            if (string.IsNullOrWhiteSpace(recpNAME_tb.Text) || !IsValidName(recpNAME_tb.Text))
            {
                isValid = false;
                errorProvider.SetError(recpNAME_tb, "Invalid name");
            }
            else
            {
                errorProvider.SetError(recpNAME_tb, "");
            }

            // Validate recipient account number
            if (!int.TryParse(recpACCNUM_tb.Text, out int accountNum) || accountNum <= 0)
            {
                isValid = false;
                errorProvider.SetError(recpACCNUM_tb, "Invalid account number");
            }
            else
            {
                errorProvider.SetError(recpACCNUM_tb, "");
            }

            // Validate transfer amount
            if (!double.TryParse(recpAMOUNT_tb.Text, out double amount) || amount <= 0)
            {
                isValid = false;
                errorProvider.SetError(recpAMOUNT_tb, "Invalid amount");
            }
            else
            {
                errorProvider.SetError(recpAMOUNT_tb, "");
            }

            return isValid;
        }
        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }
        private bool checkEmptyTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(recpAMOUNT_tb.Text) || string.IsNullOrWhiteSpace(recpACCNUM_tb.Text) || string.IsNullOrWhiteSpace(recpNAME_tb.Text))
            {
                errorProvider.SetError(recpAMOUNT_tb, "Please fill in this first");
                errorProvider.SetError(recpACCNUM_tb, "Please fill in this first");
                errorProvider.SetError(recpNAME_tb, "Please fill in this first");
                return true;
            }
            else
            {
                errorProvider.SetError(recpAMOUNT_tb, "");
                errorProvider.SetError(recpACCNUM_tb, "");
                errorProvider.SetError(recpNAME_tb, "");
                return false;
            }
        }
    }
}
