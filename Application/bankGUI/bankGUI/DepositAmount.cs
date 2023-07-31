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
    public partial class DepositAmount : UserControl
    {
        private ErrorProvider errorProvider;
        public DepositAmount()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void wBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(amountTB.Text))
            {
                errorProvider.SetError(amountTB, "Please enter an amount.");
                return;
            }
            else
            {
                errorProvider.SetError(amountTB, ""); // Clear error if input is valid
            }
            double damount;
            if (!double.TryParse(amountTB.Text, out damount))
            {
                errorProvider.SetError(amountTB, "Invalid amount. Please enter a valid number.");
                return;
            }
            else if (damount <= 0)
            {
                errorProvider.SetError(amountTB, "Amount should be greater than zero.");
                return;
            }
            else if (damount > 50000)
            {
                errorProvider.SetError(amountTB, "You cannot deposit this much");
                return;
            }
            else
            {
                errorProvider.SetError(amountTB, ""); // Clear error if input is valid
            }
            
            if (TransDL.checkStatusOfAccount(ExtraDL.CurrentClient))
            {
                TransDL.addMoneyInAccount(damount, ExtraDL.CurrentClient);
                DateTime date = DateTime.Now;
                Transaction t = new Transaction(ExtraDL.CurrentClient, damount, date, "deposit");

                TransDL.AddTransactionInList(t);
                TransDL.StoreTransactionInFile(t);
                ClientDL.UpdateClientDataInFile();
                MessageBox.Show("Transaction Successfull");
            }
            else
            {
                MessageBox.Show("Your Account is blocked you cannot deposit money");
            }
            amountTB.Text = null;
        }
    }
}
