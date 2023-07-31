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
    public partial class DeleteAccount : UserControl
    {
        public DeleteAccount()
        {
            InitializeComponent();
        }

        private void DeleteAccount_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void dataBind()
        {
            clientsGV.DataSource = null;
            foreach (var o in ClientDL.getClientList())
            {
                clientsGV.DataSource = ClientDL.getClientList().Select(c => new { c.Account.AccountNumber,c.ClientCred.Username, c.ClientCred.Phonenumber,c.Account.Balance, c.Account.Status, c.Account.Type }).ToList();
            }
            // yield
            clientsGV.Refresh();
        }

        public void delBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accNumTB.Text) || string.IsNullOrWhiteSpace(cnameTB.Text))
            {
                MessageBox.Show("Fill information first ");
                return;
            }

            string name = cnameTB.Text;
            if (!IsValidName(name))
            {
                MessageBox.Show("Invalid Name. Name should contain only alphabets.");
                return;
            }
            
            if (!int.TryParse(accNumTB.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number. Please enter a valid number.");
                return;
            }
            int accno = int.Parse(accNumTB.Text);

            Person p = new Person(name);
            Account a = new Account(accno);
            Client c = new Client(p, a);
            bool check = ClientDL.CheckifClientExixts(c);
            if (check == true)
            {
                AdminDL.Account_close(c);
                ClientDL.UpdateClientDataInFile();
                dataBind();
            }
            else
            {
                MessageBox.Show("Account not Found");
            }
            cnameTB.Text = null;
            accNumTB.Text = null;
        }
        private bool IsValidName(string name)
        {
            // A valid name should contain only alphabets
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }

    }
}
