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
    public partial class ViewLoanStatus : UserControl
    {
        public ViewLoanStatus()
        {
            InitializeComponent();
        }

        private void ViewLoanStatus_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void dataBind()
        {
            Loan l = LoanDL.findClientLoan(ExtraDL.CurrentClient);
            if (l != null)
            {
                clientsGV.DataSource = null;
                List<Loan> matchingLoan = new List<Loan> { l };

                if (l.LoanStatus == 2)
                {
                    // If LoanStatus is 2, the loan is approved
                    clientsGV.DataSource = matchingLoan.Select(loan => new {RequestDate = loan.ReqDate, Status = "Approved", ApprovelDate = loan.ApprovalDate, ReturnDate = loan.ReturningDate , GivenAmount = loan.GivenAmount, Interest = loan.Interset}).ToList();
                }
                else if (l.PledgeItem is Gold && l.LoanStatus == 1)
                {
                    // If LoanStatus is 1 and the pledge item is "Gold"
                    clientsGV.DataSource = matchingLoan.Select(loan => new { RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, Status = "Requested", ItemType = "Gold", ItemValue = loan.PledgeItem.getValue(),Purpose = loan.Purpose }).ToList();
                }
                
                else if (l.PledgeItem is Property && l.LoanStatus == 1)
                {
                    // If LoanStatus is 1 and the pledge item is "Property"
                    clientsGV.DataSource = matchingLoan.Select(loan => new { RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, Status = "Requested", ItemType = "Property", ItemValue = loan.PledgeItem.getValue(), Purpose = loan.Purpose }).ToList();
                }
                clientsGV.Refresh();
            }
            else if(l == null)
            {
                MessageBox.Show("You have no loan Requests");
                Controls.Clear();
                welcomeclient wc = new welcomeclient();
                Controls.Add(wc);
                wc.Visible = true;
            }
        }

        private void save_BTN_Click(object sender, EventArgs e)
        {
            dataBind();
        }
    }
}
