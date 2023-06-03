using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankwithClasses.BL;
using System.IO;
using BankwithClasses.UI;


namespace BankwithClasses.DL
{
    class LoanDL
    {
        static List<Loan> loanholders = new List<Loan>();
        static List<Loan> loanReqs = new List<Loan>();
        public static void addrequest(Loan l)
        {
            loanReqs.Add(l);
        }
        public static void addloandetail(Loan l)
        {
            loanholders.Add(l);
        }
        public static void storeloandetailsinfile(Loan l)
        {
            string path = "D:\\OOP\\loan.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(l.loanreq.accountnumbers + "," + l.loanreq.credentials.username + "," + l.loanamount);
            myFile.Flush();
            myFile.Close();
        }
        public static void loadDatafromFile3()
        {
            string line, path = "D:\\OOP\\loan.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');

                        int accountnumber = int.Parse(filedata[0]);
                        string name = filedata[1];
                        float loanAmount = float.Parse(filedata[2]);
                        
                        BUser nu = new BUser(name);
                        Client info = new Client(nu, accountnumber);
                        Loan tl = new Loan(info, loanAmount);
                        addrequest(tl);
                    }
                }
                myFile.Close();
            }
        }
        public static void Updatedatainfile3()
        {
            string path = "D:\\OOP\\loan.txt";
            StreamWriter myFile = new StreamWriter(path);

            for (int idx = 1; idx < loanReqs.Count; idx++)
            {
                myFile.WriteLine(loanReqs[idx].loanreq.accountnumbers + "," + loanReqs[idx].loanreq.credentials.username + "," + loanReqs[idx].loanamount);
            }
            myFile.Close();
        }
        public static bool checkpreviousloanrequest(int accountnumber)
        {
            for (int i = 0; i < loanReqs.Count; i++) // dont request loan if u have already requested
            {
                if (loanReqs[i].loanreq.accountnumbers == accountnumber)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkvalidityofrequestloan(int accountnumber)
        {
            for (int i = 0; i < loanholders.Count; i++)
            {
                if (loanholders[i].loanreq.accountnumbers == accountnumber)
                {
                    return true;
                }
            }
            return false;
        }
        public static void finadloareq()
        {
            for (int index = 0; index < loanReqs.Count; index++)
            {
                LoanUI.showloan(loanReqs[index]);
            }
        }
        public static bool checkagaingvingofloan(string name, int accountnumber)
        {
            for (int i = 0; i < loanholders.Count; i++)
            {
                if (name == loanholders[i].loanreq.credentials.username && accountnumber == loanholders[i].loanreq.accountnumbers)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool checkgivingtorequests(string name, int accountnumber)
        {
            for (int i = 0; i < loanReqs.Count; i++)
            {
                if (name == loanReqs[i].loanreq.credentials.username && accountnumber == loanReqs[i].loanreq.accountnumbers)
                {
                    return true;
                }
            }
            return false;
        }
        public static float findrequestedloan(string name, int loanholderaccount)
        {
            float amount = 0F;
            for (int i = 0; i < loanReqs.Count; i++)
            {
                if (loanReqs[i].loanreq.accountnumbers == loanholderaccount && loanReqs[i].loanreq.credentials.username == name)
                {
                    amount = loanReqs[i].loanamount;
                }
            }
            return amount;
        }

        public static void deleteloanrequest(Loan l)
        {
            for (int i =0;i < loanReqs.Count; i++)
            {
                if (loanReqs[i].loanreq.accountnumbers == l.loanreq.accountnumbers)
                {
                    loanReqs.RemoveAt(i);
                }
            }
        }
        public static void storedatainfile4(Loan l)
        {
            string path = "D:\\OOP\\loanpeople.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(l.loanreq.accountnumbers + "," + l.loanreq.credentials.username + "," + l.loanamount+ ',' + l.loanTime);
            myFile.Flush();
            myFile.Close();
        }
        public static void Updatedatainfile4()
        {
            string path = "D:\\OOP\\loanpeople.txt";
            StreamWriter myFile = new StreamWriter(path);

            for (int idx = 1; idx < loanholders.Count; idx++)
            {
                myFile.WriteLine(loanholders[idx].loanreq.accountnumbers + "," + loanholders[idx].loanreq.credentials.username + "," + loanholders[idx].loanamount+',' + loanholders[idx].loanTime);
            }
            myFile.Close();
        }
        public static void loadDatafromFile4()
        {
            string line, path = "D:\\OOP\\loanpeople.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    if ((line = myFile.ReadLine()) != null)
                    {
                        string[] filedata = line.Split(',');

                        int accountnumber = int.Parse(filedata[0]);
                        string name = filedata[1];
                        float loanAmount = float.Parse(filedata[2]);
                        string days = filedata[3];

                        BUser nu = new BUser(name);
                        Client info = new Client(nu, accountnumber);
                        Loan tl = new Loan(info, loanAmount, days);
                        addloandetail(tl);
                    }
                }
                myFile.Close();
            }
        }
        public static void viewloanp()
        {
            for (int index = 0; index < loanholders.Count; index++)
            {
                LoanUI.showloanperson(loanholders[index]);
            }
        }
        public static void findloan(Client u)
        {
            for (int index = 0; index < loanholders.Count; index++)
            {
                if (loanholders[index].loanreq.credentials.username == u.credentials.username && loanholders[index].loanreq.accountnumbers == u.accountnumbers)
                {
                    // displaying loan details
                    LoanUI.yourloan(loanholders[index]);
                }
            }
        }
        public static void Return_Loan(Client c)
        {
            for (int index = 0; index < loanholders.Count; index++)
            {
                if (loanholders[index].loanreq.credentials.username == c.credentials.username && loanholders[index].loanreq.accountnumbers == c.accountnumbers)
                {
                    c.balances = c.balances - loanholders[index].loanamount;
                    // returning loan

                    loanholders.RemoveAt(index);
                    Updatedatainfile3();
                    Updatedatainfile4();
                    Console.WriteLine("  You have no loan now!");
                    break;
                }
            }
        }


    }


}
