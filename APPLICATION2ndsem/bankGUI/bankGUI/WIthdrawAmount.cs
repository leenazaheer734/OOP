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
    public partial class WIthdrawAmount : UserControl
    {
        private ErrorProvider errorProvider;
        public WIthdrawAmount()
        {
            InitializeComponent();
            // Initialize the ErrorProvider
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void wBTN_Click(object sender, EventArgs e)
        {
            checkemptyInput();
            double wamount;
            if (!double.TryParse(amountTB.Text, out wamount))
            {
                errorProvider.SetError(amountTB, "Invalid amount. Please enter a valid number.");
                return;
            }
            else if (wamount <= 0)
            {
                errorProvider.SetError(amountTB, "Amount should be greater than zero.");
                return;
            }
            else if( wamount >= 100000)
            {
                errorProvider.SetError(amountTB, "You cannot withdraw this much");
                return;
            }
            else
            {
                errorProvider.SetError(amountTB, ""); // Clear error if input is valid
            }


            if (TransDL.checkStatusOfAccount(ExtraDL.CurrentClient))
            {
                TransDL.minusMoneyFromAccount(wamount, ExtraDL.CurrentClient);
                DateTime date = DateTime.Now;
                Transaction t = new Transaction(ExtraDL.CurrentClient, wamount, date, "withdraw");

                TransDL.AddTransactionInList(t);
                TransDL.StoreTransactionInFile(t);
                ClientDL.UpdateClientDataInFile();
                MessageBox.Show("Transaction Successfull");
            }
            else
            {
                MessageBox.Show("Your Account is blocked you cannot withdraw money");
            }
            amountTB.Text = null;
        }
        private void checkemptyInput()
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
        }
    }
}
