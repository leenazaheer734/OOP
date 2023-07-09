using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewBank.BL;
using System.IO;

namespace NewBank.DL
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
                if (c.GetPerson().getName() == person.getName() && c.GetPerson().getPassword() == person.getPassword())
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
                if (c.GetPerson().getName() == s.GetPerson().getName() && c.getAccount().GetACCnumber() == s.getAccount().GetACCnumber())
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
            myFile.WriteLine(info.GetPerson().getName() + "," + info.GetPerson().getPassword() + "," + "client" + "," + info.GetPerson().getNumber() + "," + info.GetPerson().getAddress() + "," + info.getAccount().GetACCnumber() + "," + info.getAccount().getBalance() + "," + info.getAccount().getType() + "," + info.getAccount().getStatus() );
            myFile.Flush();
            myFile.Close();
        }
        public static bool CheckifClientExixts(Client n)
        {
            foreach (Client temp in clients)
            {
                if (temp.GetPerson().getName() == n.GetPerson().getName() && temp.getAccount().GetACCnumber() == n.getAccount().GetACCnumber())
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
                myFile.WriteLine(c.GetPerson().getName() + "," + c.GetPerson().getPassword() + "," + "client" + "," + c.GetPerson().getNumber() + "," + c.GetPerson().getAddress() + "," + c.getAccount().GetACCnumber() + "," + c.getAccount().getBalance() + "," + c.getAccount().getType() + "," + c.getAccount().getStatus());
            }
            myFile.Flush();
            myFile.Close();
        }
        public static int CheckNewAccountnumber()
        {
            int largest = clients[0].getAccount().GetACCnumber();
            for (int index = 0; index < clients.Count; index++)
            {
                if (largest < clients[index].getAccount().GetACCnumber())
                {
                    largest = clients[index].getAccount().GetACCnumber();
                }
            }
            return largest;
        }
        public static void LoadClientDataFromFile(ref int accountnum)
        {
            string line , path = "clientdata.txt";
            if (File.Exists(path))
            {
                StreamReader myFile = new StreamReader(path);
                while (!myFile.EndOfStream)
                {
                    line = myFile.ReadLine();
                    if(!string.IsNullOrEmpty(line))
                    {
                        string[] filedata = line.Split(',');

                        string name = filedata[0];
                        string password = filedata[1];
                        string role = filedata[2];
                        string phonenumber = filedata[3];
                        string address = filedata[4];
                        int accnumber = int.Parse(filedata[5]);
                        double balance = double.Parse(filedata[6]);
                        string accounttype = filedata[7];
                        string status = filedata[8];

                        Person person = new Person(name, password, "client",phonenumber,address);
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
                total = total + clients[index].getAccount().getBalance(); // adding money present in bank
            }
            return total;
        }
        public static void Account_close(Client n)
        {
            for (int index = 0; index < clients.Count; index++)
            {
                if (clients[index].GetPerson().getName() == n.GetPerson().getName() && clients[index].getAccount().GetACCnumber() == n.getAccount().GetACCnumber())
                {
                    clients.RemoveAt(index);         // finding index where data of user is stored in list
                }
            }
        }
        public static bool Freeze_Account(Client del)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].GetPerson().getName() == del.GetPerson().getName() && clients[idx].getAccount().GetACCnumber() == del.getAccount().GetACCnumber())
                {
                    clients[idx].getAccount().setStatus("freeze");
                    return true;
                }
            }
            return false;
        }
        public static bool AlreadyTakenName(string name)
        {
            for (int idx = 0; idx < clients.Count; idx++)
            {
                if (clients[idx].GetPerson().getName() == name)
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
                if (clients[idx].GetPerson().getPassword() == pin)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
