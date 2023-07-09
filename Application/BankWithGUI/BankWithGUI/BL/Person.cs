﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWithGUI.BL
{
    class Person
    {
        private string username;
        private string password;
        private string role;
        private string phonenumber;
        private string address;

        public string Username { get => username; set => username = value; }
        public string Address { get => address; set => address = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }

        public Person(string username, string password, string role, string contact, string address)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
            this.Phonenumber = contact;
            this.Address = address;
        }
        public Person(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password;
            this.Role = role;
        }
        public Person(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
        public Person(string username)
        {
            this.Username = username;
        }

    }
}
