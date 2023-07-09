using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using NewBank.UI;
using System.IO;

namespace NewBank.DL
{
    class LoanDL
    {
        private static List<Loan> loansList = new List<Loan>();

        public static void storeLoanInList(Loan l)
        {
            loansList.Add(l);
        }
        public static List<Loan> getLoanList()
        {
            return loansList;
        }
        public static void deleteLoanReq(Client c)
        {
            for (int i = 0; i < loansList.Count; i++)
            {
                if (LoanUI.checkClientMatch(c, loansList[i]))
                {
                    loansList.RemoveAt(i);
                }
            }
        }
        public static void storeLoanInFile()
        {
            StreamWriter myFile = new StreamWriter("loandata.txt");

            foreach (Loan l in loansList)
            {
                if (l.PledgeItem is Gold)
                    myFile.WriteLine(l.Loanclient.GetPerson().getName() + "," + l.Loanclient.getAccount().GetACCnumber() + "," + l.ReqDate + "," + l.ApprovalDate + "," + l.ReturningDate + "," + l.ReqAmount + "," + l.GivenAmount + "," + l.Interset + "," + l.LoanStatus + "," + l.Purpose + "," + l.PledgeItem.getValue() + "," + l.PledgeItem.getWeight() + "," + l.PledgeItem.getPurity());
                else if (l.PledgeItem is Property)
                    myFile.WriteLine(l.Loanclient.GetPerson().getName() + "," + l.Loanclient.getAccount().GetACCnumber() + "," + l.ReqDate + "," + l.ApprovalDate + "," + l.ReturningDate + "," + l.ReqAmount + "," + l.GivenAmount + "," + l.Interset + "," + l.LoanStatus + "," + l.Purpose + "," + l.PledgeItem.getValue() + "," + l.PledgeItem.getPropertyAddress());
            }
            myFile.Flush();
            myFile.Close();
        }
        public static void LoadLoanDataFromFile()
        {
            string line, path = "loandata.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    line = myFile.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] filedata = line.Split(',');

                        string name = filedata[0];
                        int accnumber = int.Parse(filedata[1]);

                        Person per = new Person(name);
                        Account a = new Account(accnumber);
                        Client c = ClientDL.SearchClientAccount(new Client(per, a));

                        DateTime rdate = DateTime.Parse(filedata[2]);
                        DateTime adate = DateTime.Parse(filedata[3]);
                        DateTime retdate = DateTime.Parse(filedata[4]);
                        double reqAmount = double.Parse(filedata[5]);
                        double givenAmount = double.Parse(filedata[6]);
                        double interest = double.Parse(filedata[7]);
                        int status = int.Parse(filedata[8]);
                        string purpose = filedata[9];
                        double itemvalue = double.Parse(filedata[10]);

                        if (filedata.Length == 13)
                        {
                            double weight = double.Parse(filedata[11]);
                            string purety = filedata[12];
                            Gold g = new Gold(purety, weight, itemvalue);
                            Loan l = new Loan(c, rdate, adate, retdate, reqAmount, purpose, g, givenAmount, interest, status);
                            storeLoanInList(l);
                        }
                        else if (filedata.Length == 12)
                        {
                            string address = filedata[11];
                            Property p = new Property(address, itemvalue);
                            Loan l = new Loan(c, rdate, adate, retdate, reqAmount, purpose, p, givenAmount, interest, status);
                            storeLoanInList(l);
                        }

                    }
                }
                myFile.Close();
            }
        }

    }
}
