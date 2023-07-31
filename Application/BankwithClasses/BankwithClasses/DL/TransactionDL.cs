using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using BankwithClasses.BL;
using BankwithClasses.UI;

namespace BankwithClasses.DL
{
    class TransactionDL
    {
        static List<Transaction> allTransactoins = new List<Transaction>();
        public static void doTransaction(Transaction t)
        {
            allTransactoins.Add(t);
        }
        public static void storeDatainfile2(Transaction t)
        {
            string path = "D:\\OOP\\data.txt";
            StreamWriter myFile = new StreamWriter(path, true);

            myFile.WriteLine(t.transPerson.accountnumbers + "," + t.transPerson.credentials.username + "," + t.transAmount + "," + t.transType + "," + t.transTime);
            myFile.Flush();
            myFile.Close();
        }
        public static void ViewAlltransactions()
        {
            foreach (Transaction t in allTransactoins)
            {

                TransUI.viewdata(t);
            }
        }
        public static void loadDatafromFile2()
        {
            string line, path = "D:\\OOP\\data.txt";
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
                        float transAmount = float.Parse(filedata[2]);
                        string transType = filedata[3];
                        string transTime = filedata[4];

                        BUser nu = new BUser(name);
                        Client info = new Client(nu, accountnumber);
                        Transaction t = new Transaction(info, transAmount, transType, transTime);
                        doTransaction(t);
                    }
                }
                myFile.Close();
            }
        }

    }
}
