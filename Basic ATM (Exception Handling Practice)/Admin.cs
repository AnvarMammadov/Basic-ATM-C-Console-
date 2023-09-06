using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Admin
    {

        public Admin() { }
        public Admin(string? name, string? pass)
        {
            Name = name;
            Pass = pass;
        }

        public string? Name { get; set; } = "";
        public string? Pass { get; set; } = "";

        public Client[]? Clients { get; set; }

        public int countClient { get; set; }



        /// <summary>
        /// This function displays all clients and their card information.
        /// </summary>
        public void ShowAllClients()   
        {
            foreach (var client in Clients)
            {
                Console.WriteLine($" ID : {client.ID}");
                client.ShowClientInfo();
                client.BankCard?.ShowCardInfo();
                Console.WriteLine("\n\n");
            }
        }



        /// <summary>
        /// This function is for adding a new client.
        /// </summary>
        /// <param name="newclient">New client parametr</param>
        public void AddClient(Client newclient)
        {
            var temp = new Client[++countClient];
            if (Clients!= null)
            {
                Clients.CopyTo(temp, 0);
            }
            temp[temp.Length-1] = newclient;

            Clients= temp;  
        }


        /// <summary>
        /// This function is for obtaining a client; client information is filled out here and it returns a new client.
        /// </summary>
        /// <returns>This function returns an object from the Client class.</returns>
        public Client GetClient()
        {
            Console.WriteLine("Enter Information For New Client\n");
            Console.Write("Enter Name : ");
            string?name=Console.ReadLine();
            Console.Write("Enter Surname : ");
            string? surname = Console.ReadLine();
            Console.Write("Enter Age : ");
            int age=Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Salary : ");
            double salary=Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter  Card PAN : ");
            string?pan=Console.ReadLine();
            bool flag=false;
            foreach (var client in Clients)
            {
                if (pan == client.BankCard.PAN) { flag = true; break; }
            }
            if (flag)
            {
                Console.WriteLine("This PAN already exist...");return null;
            }
            else
            {
                Console.Write("Enter card PIN : ");
                string? pin = Console.ReadLine();

                Client newClient=new Client(name,surname,age,salary,new Card(pan,pin));
                return newClient;
            }
        }


        /// <summary>
        /// It deletes the appropriate client based on the assigned ID.
        /// </summary>
        /// <param name="id">Client ID</param>
        public void RemoveClient(int id) {
            int index=-1;
            if(Clients!= null)
            {
                for (int i = 0; i < countClient; i++)
                {
                    if (id == Clients[i].ID) { index = i; break; }
                }
                var temp = new Client[countClient - 1];
                if (index < 0) { Console.WriteLine("Client not found..."); }
                if (index > 0) { Array.Copy(Clients, 0, temp, 0, index); }
                if (index < countClient - 1) { Array.Copy(Clients, index + 1, temp, index, countClient - index - 1); }
                --countClient;
                Clients = temp;
            }
        }
    }
}
