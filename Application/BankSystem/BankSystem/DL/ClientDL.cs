using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.BL;

namespace BankSystem.DL
{
    class ClientDL
    {
        private static List<Client> clients = new List<Client>();
        
        public static List<Client> getClientsList()
        {
            return clients;
        }
        public static void AddClientinList(Client nperson)
        {
            clients.Add(nperson);
        }

        public static Client loginperson(Person u)
        {
           /* for (int idx = 1; idx < clients.Count; idx++)
            {
                if (clients[idx].getClient().getName() == u.getName() && clients[idx].getClient().getPassword() == u.getPassword())
                {
                    return clients[idx];
                }
            }*/
            return null;
        }
    }
}
