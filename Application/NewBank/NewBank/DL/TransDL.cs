using NewBank.BL;
using System;
using System.Collections.Generic;
using System.IO;


namespace NewBank.DL
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
            if (c.getAccount().getStatus() == "running") return true;
            else return false;
        }
        public static void addMoneyInAccount(double amount, Client c1)
        {
            double tBalance = c1.getAccount().getBalance() + amount;
            c1.getAccount().setBalance(tBalance);
        }
        public static void minusMoneyFromAccount(double amount, Client c)
        {
            double mBalance = c.getAccount().getBalance() - amount;
            c.getAccount().setBalance(mBalance);
        }

        public static void StoreTransactionInFile(Transaction info)
        {
            string path = "TransData.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(info.getPersonInfo().getName() + "," + info.getPersonInfo().getPassword() + "," + "client" + "," + info.getPersonInfo().getNumber() + "," + info.getPersonInfo().getAddress() + "," + info.getAccountInfo().GetACCnumber() + "," + info.getAccountInfo().getBalance() + "," + info.getAccountInfo().getType() + "," + info.getAccountInfo().getStatus() + "," + info.getAmount() + "," + info.getDateTime().ToString() + "," + info.getTypeofTrans() + ","+ info.getRefAccNo());
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
                        string address = filedata[4];
                        int accountnumber = int.Parse(filedata[5]);
                        double balance = double.Parse(filedata[6]);
                        string type = filedata[7];
                        string status = filedata[8];
                        double transAmount = double.Parse(filedata[9]);
                        DateTime transTime = DateTime.Parse(filedata[10]);
                        string transType = filedata[11];
                        string refAccNo = filedata[12];

                        Person p = new Person(name, password, role, contact, address);
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
                if (t.getPersonInfo().getName() == c.GetPerson().getName() && t.getPersonInfo().getPassword() == c.GetPerson().getPassword() && t.getAccountInfo().GetACCnumber() == c.getAccount().GetACCnumber())
                {
                    DateTime t_date = t.getDateTime();
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
