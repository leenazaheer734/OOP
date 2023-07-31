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
    public partial class ViewAccounts : UserControl
    {
        public ViewAccounts()
        {
            InitializeComponent();
        }
    
        private void ViewAccounts_Load(object sender, EventArgs e)
        {
            dataBind();
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
      
        private void SearchClient(int searchTerm)
        {
            // Get the client list from your data source (e.g., ClientDL.getClientList())
            Client c = ClientDL.seacrhwithACCnumber(searchTerm);

            if(c!= null)
            {
                List<Client> matchingClients = new List<Client> { c };

                clientsGV.DataSource = null;
                clientsGV.DataSource = matchingClients.Select(client => new { c.Account.AccountNumber, c.ClientCred.Username, c.ClientCred.Phonenumber, c.Account.Balance, c.Account.Status, c.Account.Type }).ToList();
                clientsGV.Refresh();
            }
        }

        private void srchBTN_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(accNumTB.Text))
            {
                MessageBox.Show("Enter Account Number First, NoInput ");
                return;
            }
            if (!int.TryParse(accNumTB.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number. Please enter a valid number.");
                return;
            }

            // At this point, accountNumber variable holds the parsed integer value.
            SearchClient(accountNumber);
        }

   
    }
}
