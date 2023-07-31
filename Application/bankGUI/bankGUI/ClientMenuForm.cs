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

namespace bankGUI
{
    public partial class ClientMenuForm : Form
    {
        public ClientMenuForm()
        {
            InitializeComponent();
        }


        private void ClientMenuForm_Load(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            welcomeclient WC = new welcomeclient();
            clientmenupanel.Controls.Add(WC);
            WC.Visible = true;
        }

        private void viewbalanceBTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            ViewCBalance viewCBalance = new ViewCBalance();
            clientmenupanel.Controls.Add(viewCBalance);
            viewCBalance.Visible = true;
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            WIthdrawAmount withdrawamounts = new WIthdrawAmount();
            clientmenupanel.Controls.Add(withdrawamounts);
            withdrawamounts.Visible = true;
        }

        private void depositAmount_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            DepositAmount da = new DepositAmount();
            clientmenupanel.Controls.Add(da);
            da.Visible = true;
        }

        private void ViewTran_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            ViewTransForm viewt = new ViewTransForm();
            clientmenupanel.Controls.Add(viewt);
            viewt.Visible = true;
        }

        private void transferAmount_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            TransferForm transferform = new TransferForm();
            clientmenupanel.Controls.Add(transferform);
            transferform.Visible = true;
        }

        private void reqLoan_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            RequestLoanForm rloanf = new RequestLoanForm();
            clientmenupanel.Controls.Add(rloanf);
            rloanf.Visible = true;
        }


        private void viewLoan_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            ViewLoanStatus viewclientloan = new ViewLoanStatus();
            clientmenupanel.Controls.Add(viewclientloan);
            viewclientloan.Visible = true;
        }


        private void RetLoan_BTN_Click(object sender, EventArgs e)
        {
            clientmenupanel.Controls.Clear();

            ReturnloanForm retloanf = new ReturnloanForm();
            clientmenupanel.Controls.Add(retloanf);
            retloanf.Visible = true;
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            SignInForm sif = new SignInForm();
            sif.Show();
        }
    }
}
