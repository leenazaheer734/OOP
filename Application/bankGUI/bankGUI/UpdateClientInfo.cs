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
    public partial class UpdateClientInfo : UserControl
    {
        public UpdateClientInfo()
        {
            InitializeComponent();
        }

        private void dataBind()
        {
            clientsGV.DataSource = null;
            foreach (var o in ClientDL.getClientList())
            {
                clientsGV.DataSource = ClientDL.getClientList().Select(c => new { c.Account.AccountNumber, c.ClientCred.Username, c.ClientCred.Phonenumber, c.Account.Balance, c.Account.Status, c.Account.Type }).ToList();
            }
            // yield
            clientsGV.Refresh();
        }

        private void clientsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                accNumTB.Text = clientsGV[clientsGV.Columns["AccountNumber"].Index, e.RowIndex].Value.ToString();
            }
        }

        private void UpdateClientInfo_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accNumTB.Text))
            {
                MessageBox.Show("Enter Account Number First, NoInput ");
                return;
            }
            if (!int.TryParse(accNumTB.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number. Please enter a valid number.");
                return;
            }

            this.Controls.Clear();
            DoUpdate du = new DoUpdate();
            du.UpdatingAccount = int.Parse(accNumTB.Text);
            this.Controls.Add(du);
            du.Visible = true;
        }
    }
}
