//////using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using bankGUI.BL;

namespace bankGUI.DL
{
    class ClientDL
    {
        private static List<Client> clients = new List<Client>();

        public static List<Client> getClientList()
        {
            return clients;
        }
        public static void AddClientinList(Client c)
        {
            clients.Add(c);
        }
        public static Client checkPersonIsClient(Person person)
        {
            foreach (Client c in clients)
            {
                if (c.ClientCred.Username == person.Username && c.ClientCred.Password == person.Password)
                {
                    return c;
                }
            }
            return null;
        }
        public static Client SearchClientAccount(Client s)
        {
            foreach (Client c in clients)
            {
                if (c.ClientCred.Username == s.ClientCred.Username && c.Account.AccountNumber == s.Account.AccountNumber)
                {
                    return c;
                }
            }
            return null;
        }
        public static void StoreClientInFile(Client info)
        {
            string path = "clientdata.txt";

            StreamWriter myFile = new StreamWriter(path, true);
            myFile.WriteLine(info.ClientCred.Username + "," + info.ClientCred.Password + "," + "client" + "," + info.ClientCred.Phonenumber + "," + info.Account.AccountNumber + "," + info.Account.Balance + "," + info.Account.Type + "," + info.Account.Status);
            myFile.Flush();
            myFile.Close();
        }
        public static bool CheckifClientExixts(Client n)
        {
            foreach (Client temp in clients)
            {
                if (temp.ClientCred.Username == n.ClientCred.Username && temp.Account.AccountNumber == n.Account.AccountNumber)
                {

                    return true;
                }
            }

            return false;
        }
        public static void UpdateClientDataInFile()
        {
            StreamWriter myFile = new StreamWriter("clientdata.txt");

            foreach (Client c in clients)
            {
                myFile.WriteLine(c.ClientCred.Username + "," + c.ClientCred.Password + "," + "client" + "," + c.ClientCred.Phonenumber + "," + "," + c.Account.AccountNumber + "," + c.Account.Balance + "," + c.Account.Type + "," + c.Account.Status);
            }
            myFile.Flush();
            myFile.Close();
        }
        public static int CheckNewAccountnumber()
        {
            int largest = clients[0].Account.AccountNumber;
            for (int index = 0; index < clients.Count; index++)
            {
                if (largest < clients[index].Account.AccountNumber)
                {
                    largest = clients[index].Account.AccountNumber;
                }
            }
            return largest;
        }
        public static void LoadClientDataFromFile(ref int accountnum)
        {
            string line, path = "clientdata.txt";
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
                        string password = filedata[1];
                        string role = filedata[2];
                        string phonenumber = filedata[3];
                        int accnumber = int.Parse(filedata[4]);
                        double balance = double.Parse(filedata[5]);
                        string accounttype = filedata[6];
                        string status = filedata[7];

                        Person person = new Person(name, password, "client", phonenumber);
                        Account acc = new Account(accnumber, balance, status, accounttype);
                        Client info = new Client(person, acc);
                        AddClientinList(info);
                    }
                }
                myFile.Close();
                if (clients.Count != 0)
                {
                    accountnum = CheckNewAccountnumber() + 1;

                }
            }
        }


        public static double Totalmoney()
        {
            double total = 0;
            for (int index = 0; index < clients.Count; index++)
            {
                total = total + clients[index].Account.Balance; // adding money present in bank
            }
            return total;
        }
        public static void Account_close(Client n)
        {
            for (int index = 0; index < clients.Count; index++)
            {
                if (clients[index].ClientCred.Username == n.ClientCred.Username && clients[index].Account.AccountNumber == n.Account.AccountNumber)
                {
                    clients.RemoveAt(index);         // finding index where data of user is stored in list
                }
            }
        }
        public static bool Freeze_Account(Client del)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].ClientCred.Username == del.ClientCred.Username && clients[idx].Account.AccountNumber == del.Account.AccountNumber)
                {
                    clients[idx].Account.Status = "freeze";
                    return true;
                }
            }
            return false;
        }
        public static bool AlreadyTakenName(string name)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].ClientCred.Username == name)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool AlreadyTakenPin(string pin)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].ClientCred.Password == pin)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
