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
    public partial class ManageloanForm : UserControl
    {
        public ManageloanForm()
        {
            InitializeComponent();
        }


        private void dataBind()
        {
            clientsGV.DataSource = null;
            foreach (var o in LoanDL.viewRequestededLoans())
            {
                if (o.PledgeItem is Gold)
                {
                    clientsGV.DataSource = LoanDL.viewRequestededLoans().Select(loan => new { ACCNumber = loan.Loanclient.Account.AccountNumber, Name = loan.Loanclient.ClientCred.Username,RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, PledgeItem = "Gold", ItemWorth = loan.PledgeItem.getValue()}).ToList();
                }
                else if(o.PledgeItem is Property)
                {
                    clientsGV.DataSource = LoanDL.viewRequestededLoans().Select(loan => new { ACCNumber = loan.Loanclient.Account.AccountNumber, Name = loan.Loanclient.ClientCred.Username, RequestDate = loan.ReqDate, RequestedAmount = loan.ReqAmount, PledgeItem = "Property", ItemWorth = loan.PledgeItem.getValue() }).ToList();
                }
            }
            clientsGV.Refresh();
        }

        private void approveBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accnumberTB.Text) || string.IsNullOrWhiteSpace(nameTB.Text))
            {
                MessageBox.Show("Fill information first ");
                return;
            }
            string name = nameTB.Text;
            if (!IsValidName(name))
            {
                MessageBox.Show("Invalid Name. Name should contain only alphabets.");
                return;
            }

            if (!int.TryParse(accnumberTB.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number. Please enter a valid number.");
                return;
            }
            int accno = int.Parse(accnumberTB.Text);

            Person p = new Person(name);
            Account a = new Account(accno);
            Client c = new Client(p, a);
            doloanApproval(c);
            dataBind();
        }
        private void doloanApproval(Client c)
        {
            Client c2 = ClientDL.SearchClientAccount(c);
            if (c2 != null)
            {
                Loan l = LoanDL.findClientLoan(c2);
                if (l != null && l.LoanStatus == 1)
                {
                    l.LoanStatus = 2;
                    l.ApprovalDate = DateTime.Now;
                    l.ReturningDate = l.ApprovalDate.AddDays(365);
                    l.GivenAmount = l.ReqAmount + (l.ReqAmount * 0.1);
                    l.Interset = 10;
                    MessageBox.Show("Loan Approved");
                }
                else
                {
                    MessageBox.Show("You cannot give Loan to this client");
                }
            }
            else
            {
                MessageBox.Show("Account u entered does not exists");
            }
            nameTB.Text = null;
            accnumberTB.Text = null;
        }
        private void doloanRejection(Client c)
        {
            Client c2 = ClientDL.SearchClientAccount(c);
            if (c2 != null)
            {
                Loan l = LoanDL.findClientLoan(c2);
                if (l != null && l.LoanStatus == 1)
                {
                    LoanDL.SetrejectLoanReqStatus(c2);
                    MessageBox.Show("Loan Rejected");
                }
                else
                {
                    MessageBox.Show("You cannot reject this requset");
                }
            }
            else
            {
                MessageBox.Show("Account u entered does not exists");
            }
            nameTB.Text = null;
            accnumberTB.Text = null;
        }
        private void rejectBTN_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(accnumberTB.Text) || string.IsNullOrWhiteSpace(nameTB.Text))
            {
                MessageBox.Show("Fill information first ");
                return;
            }
            string name = nameTB.Text;
            if (!IsValidName(name))
            {
                MessageBox.Show("Invalid Name. Name should contain only alphabets.");
                return;
            }

            if (!int.TryParse(accnumberTB.Text, out int accountNumber))
            {
                MessageBox.Show("Invalid Account Number. Please enter a valid number.");
                return;
            }
            int accno = int.Parse(accnumberTB.Text);

            Person p = new Person(name);
            Account a = new Account(accno);
            Client c = new Client(p, a);

            doloanRejection(c);
            LoanDL.storeLoanInFile();
            dataBind();
        }

        private void ManageloanForm_Load(object sender, EventArgs e)
        {
            dataBind();
        }

        private void clientsGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int accnumber  = int.Parse(clientsGV[clientsGV.Columns["ACCNumber"].Index, e.RowIndex].Value.ToString());
                string name = clientsGV[clientsGV.Columns["Name"].Index, e.RowIndex].Value.ToString();
          
                Person p = new Person(name);
                Account a = new Account(accnumber);
                Client c = new Client(p, a);

                doloanApproval(c);
                LoanDL.storeLoanInFile();
            }
            else if (e.ColumnIndex == 1)
            {
                int accnumber = int.Parse(clientsGV[clientsGV.Columns["ACCNumber"].Index, e.RowIndex].Value.ToString());
                string name = clientsGV[clientsGV.Columns["Name"].Index, e.RowIndex].Value.ToString();
                Person p = new Person(name);
                Account a = new Account(accnumber);
                Client c = new Client(p, a);

                doloanRejection(c);
                LoanDL.storeLoanInFile();
            }
            dataBind();
        }
        private bool IsValidName(string name)
        {
            // A valid name should contain only alphabets
            return !string.IsNullOrWhiteSpace(name) && name.All(char.IsLetter);
        }
    }
}
