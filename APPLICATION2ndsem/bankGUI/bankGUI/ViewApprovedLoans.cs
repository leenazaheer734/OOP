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
    public partial class ViewApprovedLoans : UserControl
    {
        public ViewApprovedLoans()
        {
            InitializeComponent();
        }

        private void ViewApprovedLoans_Load(object sender, EventArgs e)
        {
            dataBind();
        }
        private void dataBind()
        {
            clientsGV.DataSource = null;
            if (LoanDL.viewApprovedLoans().Count != 0)
            {
                foreach (var o in LoanDL.viewApprovedLoans())
                {
                    if (o.PledgeItem is Gold)
                    {
                        clientsGV.DataSource = LoanDL.viewApprovedLoans().Select(loan => new { ACCNumber = loan.Loanclient.Account.AccountNumber, Name = loan.Loanclient.ClientCred.Username, RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, PledgeItem = "Gold", ItemWorth = loan.PledgeItem.getValue() }).ToList();
                    }
                    else if (o.PledgeItem is Property)
                    {
                        clientsGV.DataSource = LoanDL.viewApprovedLoans().Select(loan => new { ACCNumber = loan.Loanclient.Account.AccountNumber, Name = loan.Loanclient.ClientCred.Username, RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, PledgeItem = "Property", ItemWorth = loan.PledgeItem.getValue() }).ToList();
                    }
                }
                clientsGV.Refresh();
            }
            else
            {
                MessageBox.Show("No approved loans");
                Controls.Clear();
                welcomeadmin wa = new welcomeadmin();
                Controls.Add(wa);
                wa.Visible = true;
            }
        }
    }
}
