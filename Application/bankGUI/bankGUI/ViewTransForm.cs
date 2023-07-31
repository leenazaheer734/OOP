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
    public partial class ViewTransForm : UserControl
    {
        List<Transaction> pastTransactionList = TransDL.checkOneMonthDateDiff(ExtraDL.CurrentClient);
        public ViewTransForm()
        {
            InitializeComponent();
        }

        private void ViewTransForm_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void dataBind()
        {
            if(pastTransactionList.Count != 0)
            {
                clientsGV.DataSource = null;
                foreach (var o in pastTransactionList)
                {
                    clientsGV.DataSource = pastTransactionList.Select(c => new { c.Date, c.RefrenceAccount, c.Amount, c.TransactionType, c.T_Client.Account.Balance }).ToList();
                }
                // yield
                clientsGV.Refresh();
            }
            else
            {
                MessageBox.Show("No Transaction History");
                Controls.Clear();
                welcomeclient wc = new welcomeclient();
                Controls.Add(wc);
                wc.Visible = true;
            }
           
        }

        private void save_BTN_Click(object sender, EventArgs e)
        {
            PdfGenerator pdfGenerator = new PdfGenerator();
            pdfGenerator.GeneratePdfReport(pastTransactionList);
            MessageBox.Show("Saved as PDF");
        }
    }
}
