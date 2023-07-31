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
    public partial class RequestLoanForm : UserControl
    {
        public double amount = 0;
        public string purpose = "";
        public string item;
        private ErrorProvider errorProvider;
        public RequestLoanForm()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(checkEmptyTextBoxes()) {return;}
            if (string.IsNullOrWhiteSpace(P_TB.Text) || !IsValidName(P_TB.Text))
            {
                errorProvider.SetError(P_TB, "Invalid purpose");
                return;
            }
            else
            {
                errorProvider.SetError(P_TB, "");
            }
            if (!IsValidAmount(amountTB.Text))
            {
                errorProvider.SetError(amountTB, "Invalid amount. Please enter a valid positive number.");
                return;
            }
            else
            {
                errorProvider.SetError(amountTB, "");
            }
            
            Loan l = LoanDL.findLoanNotRejected(ExtraDL.CurrentClient);
            if (l == null)
            {
                if (ExtraDL.CurrentClient.Account.Type.ToLower() == "current")
                {
                    amount = double.Parse(amountTB.Text.ToString());
                    purpose = P_TB.Text.ToString();
                    item = item_cb.Text.ToString();

                    if (item.ToLower() == "gold")
                    {
                        goldpanel.Visible = true;
                        guna2Button2.Visible = true;
                    }
                    else if (item.ToLower() == "property")
                    {
                        item_panel.Visible = true;
                        guna2Button2.Visible = true;
                    }
                }
                else
                {
                    MessageBox.Show("   You cannot request Loan ,You have salary account!");
                    amountTB.Text = null;
                    P_TB.Text = null;
                    item_cb.Text = null;
                }
            }
            else
            {
                MessageBox.Show("   You cannot request Loan!");
                amountTB.Text = null;
                P_TB.Text = null;
                item_cb.Text = null;
            }
        }

        private void RequestLoanForm_Load(object sender, EventArgs e)
        {
            item_panel.Visible = false;
            goldpanel.Visible = false;
            guna2Button2.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Loan l = new Loan();
            if (item_panel.Visible == true)
            {
                Property p = new Property(address_TB.Text.ToString() , double.Parse(pWorth_TB.Text.ToString()));
                l = new Loan(ExtraDL.CurrentClient, DateTime.Now, amount, purpose, p);
            }
            else if (goldpanel.Visible == true)
            {
                Gold g = new Gold(pGold_TB.Text.ToString(), double.Parse(gWeight_TB.Text.ToString()), double.Parse(gValue_TB.Text.ToString()));
                l = new Loan(ExtraDL.CurrentClient, DateTime.Now, amount, purpose, g);
            }
            if(l!= null)
            {
                LoanDL.storeLoanInList(l);
                LoanDL.storeLoanInFile();
                MessageBox.Show("Request Submitted");
            }
            else
            {
                MessageBox.Show("Enter values");
            }
            setTextBoxesToNull();   
        }
        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }
        private bool IsValidAmount(string amountText)
        {
            if (string.IsNullOrWhiteSpace(amountText))
                return false;

            if (!double.TryParse(amountText, out double amount))
                return false;

            return amount > 0;
        }
        private bool checkEmptyTextBoxes()
        {
            if (string.IsNullOrWhiteSpace(amountTB.Text) || string.IsNullOrWhiteSpace(P_TB.Text) || string.IsNullOrWhiteSpace(item_cb.Text))
            {
                errorProvider.SetError(amountTB, "Please fill in this first");
                errorProvider.SetError(P_TB, "Please fill in this first");
                errorProvider.SetError(item_cb, "Please fill in this first");
                return true;
            }
            else
            {
                errorProvider.SetError(amountTB, "");
                errorProvider.SetError(P_TB, "");
                errorProvider.SetError(item_cb, "");
                return false;
            }
        }
        private void setTextBoxesToNull()
        {
            amountTB.Text = null;
            P_TB.Text = null;
            item_cb.Text = null;
            address_TB.Text = null;
            pWorth_TB.Text = null;
            gWeight_TB.Text = null;
            gValue_TB.Text = null;
            pGold_TB.Text = null;
            item_panel.Visible = false;
            goldpanel.Visible = false;
            guna2Button2.Visible = false;
        }
    }
}
