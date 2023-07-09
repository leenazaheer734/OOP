using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewBank.BL
{
    class Person
    {
        private  string username;
        private string password;
        private string role;
        private string phonenumber;
        private string address;

        public Person(string username, string password, string role, string contact, string address)
        {
            this.username = username;
            this.password = password;
            this.role = role;
            this.phonenumber = contact;
            this.address = address;
        }
        public Person(string username, string password, string role)
        {
            this.username = username;
            this.password = password;
            this.role = role;
        }
        public Person(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public Person(string username)
        {
            this.username = username;
        }

        public string getName()
        {
            return this.username;
        }
        public string getPassword()
        {
            return this.password;
        }
        public string getRole()
        {
            return this.role;
        }
        public string getNumber()
        {
            return this.phonenumber;
        }
        public string getAddress()
        {
            return this.address;
        }

        public void setName(string name)
        {
            this.username = name;
        }
        public void setRole(string role)
        {
            this.role = role;
        }
        public void setPassword(string password)
        {
            this.password = password;
        }
        public void setNumber(string number)
        {
            this.phonenumber = number;
        }
        public void setAddress(string address)
        {
            this.phonenumber = address;
        }


    }
}
