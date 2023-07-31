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
    public partial class ReturnloanForm : UserControl
    {
        private ErrorProvider errorProvider;
        public ReturnloanForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        private void ReturnloanForm_Load(object sender, EventArgs e)
        {
            Loan l = LoanDL.findClientLoan(ExtraDL.CurrentClient);
            if(l!= null)
            {
                r_lbl.Text = l.GivenAmount.ToString();
            }
            else
            {
                r_lbl.Text = "0";
            }
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
            double ret;
            if (!double.TryParse(amountTB.Text, out ret))
            {
                errorProvider.SetError(amountTB, "Invalid amount. Please enter a valid number.");
                return;
            }
            else if (ret <= 0)
            {
                errorProvider.SetError(amountTB, "Amount should be greater than zero.");
                return;
            }
            else
            {
                errorProvider.SetError(amountTB, ""); // Clear error if input is valid
            }

            Client c = ExtraDL.CurrentClient;
            
            Loan l = LoanDL.findClientLoan(c);
            if (l != null)
            {
                if (l.LoanStatus == 1)
                {
                    MessageBox.Show("   Your Loan is not approved Yet!");
                }
                else if (l.GivenAmount > 0 && l.LoanStatus == 2)
                {
                    if (ExtraDL.CurrentClient.Account.Balance >= ret)
                    {
                        if (ret <= l.GivenAmount)
                        {
                            l.GivenAmount = l.GivenAmount - ret;
                            c.Account.Balance = c.Account.Balance - ret;
                        }
                        else if (ret > l.GivenAmount)
                        {
                            c.Account.Balance = c.Account.Balance - l.GivenAmount;
                            l.GivenAmount = 0;
                        }
                        if(l.GivenAmount == 0)
                        {
                            LoanDL.deleteLoanReq(c);
                        }
                        ClientDL.UpdateClientDataInFile();
                    }
                    else
                    {
                        MessageBox.Show("   You dont have sufficient balance!");
                    }
                }
                else if (l.GivenAmount == 0)
                {
                    r_lbl.Text = "0";
                    LoanDL.deleteLoanReq(c);
                }
                LoanDL.storeLoanInFile();
            }
            else
            {
                MessageBox.Show("  You have no loan to return");
            }

            amountTB.Text = null;
            if (l != null)
            {
                r_lbl.Text = l.GivenAmount.ToString();
            }
            else
            {
                r_lbl.Text = "0";
            }
        }
    }
}
