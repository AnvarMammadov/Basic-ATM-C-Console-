using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Bank
    {
        Bank() { }
        public Bank(string bankname,Client[]? clients)
        {
            BankName = bankname;
            Clients = clients;
        }


        public Client[]? Clients { get; set; }
        public string? BankName { get; set; }

        public Admin Admin { get; set; }
        
    }
}
