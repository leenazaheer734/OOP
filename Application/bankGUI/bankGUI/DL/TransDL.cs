using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bankGUI.BL;
using System.IO;
using System.Windows.Forms;

namespace bankGUI.DL
{
    class TransDL
    {
        private static List<Transaction> transactions = new List<Transaction>();
        public static List<Transaction> getTransactions()
        {
            return transactions;
        }

        public static void AddTransactionInList(Transaction t)
        {
            transactions.Add(t);
        }

        public static bool checkStatusOfAccount(Client c)
        {
            if (c.Account.Status.ToLower() == "running") return true;
            else return false;
        }
        public static void addMoneyInAccount(double amount, Client c1)
        {
            c1.Account.Balance = c1.Account.Balance + amount;
        }
        public static void minusMoneyFromAccount(double amount, Client c)
        {
            c.Account.Balance = c.Account.Balance - amount;
        }
    
        public static void StoreTransactionInFile(Transaction info)
        {
            string path = "TransData.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(info.T_Client.ClientCred.Username + "," + info.T_Client.ClientCred.Password + "," + "client" + "," + info.T_Client.ClientCred.Phonenumber + "," + info.T_Client.Account.AccountNumber + "," + info.T_Client.Account.Balance + "," + info.T_Client.Account.Type + "," + info.T_Client.Account.Status + "," + info.Amount + "," + info.Date.ToString() + "," + info.TransactionType + "," + info.RefrenceAccount);
            myFile.Flush();
            myFile.Close();
        }
        public static void LoadTransactionDataFromFile()
        {
            string path = "TransData.txt";
            if (File.Exists(path))
            {
                string line = "";
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');

                        string name = filedata[0];
                        string password = filedata[1];
                        string role = filedata[2];
                        string contact = filedata[3];
                        int accountnumber = int.Parse(filedata[4]);
                        double balance = double.Parse(filedata[5]);
                        string type = filedata[6];
                        string status = filedata[7];
                        double transAmount = double.Parse(filedata[8]);
                        DateTime transTime = DateTime.Parse(filedata[9]);
                        string transType = filedata[10];
                        string refAccNo = filedata[11];

                        Person p = new Person(name, password, role, contact);
                        Account a = new Account(accountnumber, balance, status, type);
                        Client c = new Client(p, a);
                        Transaction t = new Transaction(c, transAmount, transTime, transType, refAccNo);
                        AddTransactionInList(t);
                    }
                }
                myFile.Close();
            }
        }
        public static List<Transaction> checkOneMonthDateDiff(Client c)
        {
            List<Transaction> t_pastMonth = new List<Transaction>();

            foreach (Transaction t in getTransactions())
            {
                if (t.T_Client.ClientCred.Username == c.ClientCred.Username && t.T_Client.ClientCred.Password == c.ClientCred.Password && t.T_Client.Account.AccountNumber == c.Account.AccountNumber)
                {
                    DateTime t_date = t.Date;
                    TimeSpan difference = DateTime.Now.Subtract(t_date);

                    // Check if the difference is one month
                    if (difference.TotalDays >= 0 && difference.TotalDays < 31)
                    {
                        t_pastMonth.Add(t);
                    }
                }
            }
            return t_pastMonth;
        }
    }
}
