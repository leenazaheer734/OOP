using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bankGUI
{
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void logoutBTN_Click(object sender, EventArgs e)
        {
            this.Close();
            SignInForm sif = new SignInForm();
            sif.Show();
        }

        private void createBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            OpenAccount oa = new OpenAccount();
            mainadminpanel.Controls.Add(oa);
            oa.Visible = true;
        }


        private void closeAccBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            DeleteAccount delacc = new DeleteAccount();
            mainadminpanel.Controls.Add(delacc);
            delacc.Visible = true;

        }

        private void viewAccBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            ViewAccounts va = new ViewAccounts();
            mainadminpanel.Controls.Add(va);
            va.Visible = true;
        }

        private void updateAccBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            UpdateClientInfo uci = new UpdateClientInfo();
            mainadminpanel.Controls.Add(uci);
            uci.Visible = true;
        }

        private void viewTotalBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            ViewTotalMoney vtm = new ViewTotalMoney();
            mainadminpanel.Controls.Add(vtm);
            vtm.Visible = true;
        }
        private void AdminMenu_Load(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();
            welcomeadmin wa = new welcomeadmin();
            mainadminpanel.Controls.Add(wa);
            wa.Visible = true;
        }

        private void viewtransactionBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            AdminViewTrans avt = new AdminViewTrans();
            mainadminpanel.Controls.Add(avt);
            avt.Visible = true;
        }

        private void manageLoanBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            ManageloanForm manageloanf = new ManageloanForm();
            mainadminpanel.Controls.Add(manageloanf);
            manageloanf.Visible = true;
        }

        private void viewLoanBTN_Click(object sender, EventArgs e)
        {
            mainadminpanel.Controls.Clear();

            ViewApprovedLoans val = new ViewApprovedLoans();
            mainadminpanel.Controls.Add(val);
            val.Visible = true;
        }
    }
}
