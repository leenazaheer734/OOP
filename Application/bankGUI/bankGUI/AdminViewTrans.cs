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

namespace bankGUI
{
    public partial class AdminViewTrans : UserControl
    {
        public AdminViewTrans()
        {
            InitializeComponent();
        }

       
        private void dataBind()
        {
            clientsGV.DataSource = null;
            foreach (var o in TransDL.getTransactions())
            {
                clientsGV.DataSource = TransDL.getTransactions().Select(c => new {c.T_Client.Account.AccountNumber, c.T_Client.ClientCred.Username, c.Date, c.RefrenceAccount, c.Amount, c.TransactionType, c.T_Client.Account.Balance }).ToList();
            }
            // yield
            clientsGV.Refresh();
        }

        private void AdminViewTrans_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void save_BTN_Click(object sender, EventArgs e)
        {
            Pdf_For_Admin pdfGenerator = new Pdf_For_Admin();
            pdfGenerator.GeneratePdfReport(TransDL.getTransactions());
            MessageBox.Show("Saved as PDF");
        }
    }
}
