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
    public partial class OpenAccount : UserControl
    {
        public OpenAccount()
        {
            InitializeComponent();
        }


        private Client takeAccountInput()
        {
            string name = nameTB.Text;
            string password = passwordTB.Text;
            string accounttype = acctypeTB.Text;
            string contact = contactTB.Text;
            double balance = 0;

            if (Double.TryParse(strtAmtTB.Text, out balance) == false)
            {
                MessageBox.Show("Invalid input. Please enter a valid amount.");
            }
            
            //name = BankUI.checkNameValidity(name);                                 // checking if name has only alphabets
            //name = BankUI.Nametakenvalidity(name);                                 // checking if name is already taken
            //password = BankUI.checkPinLength(password);                      // checing 4digits of password
            //password = BankUI.checkPinDigits(password).ToString();
            //password = BankUI.CheckpinValidity(password);                         // checking if passwords is alreadytaken
            //accounttype = BankUI.checkaccounttype(accounttype);                     // checking if account type is only salary or current
            //double balance = BankUI.checkBalanceValidity(tempbalance);         // chceking if balance enetered contains only numbers
            //balance = BankUI.Minimum_balance(balance, accounttype);
            //phone = BankUI.checkNumberLength(phone);                            // getting 11 digit phone number
            //phone = BankUI.checkPinDigits(phone).ToString();                    // checking if phonenumber contains only numbers

             
            Console.WriteLine();
            Console.WriteLine("    Account number " + Form1.accountnum + " successfully created! ");
            Person nu = new Person(name, password, "client", contact);
            Account acc = new Account(Form1.accountnum, balance, "running", accounttype);
            Client info = new Client(nu, acc);
            Form1.accountnum++;

            return info;
        }

        private void crtAccTB_Click(object sender, EventArgs e)
        {
            Client c = takeAccountInput();
            ClientDL.AddClientinList(c);
            ClientDL.StoreClientInFile(c);        // storing data of user file
            MessageBox.Show("Account Created");
            nameTB.Text = null;
            passwordTB.Text = null;
            contactTB.Text = null;
            strtAmtTB.Text = null;
            acctypeTB.Text = null;
        }
    }
}
