using System.Data;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Threading.Tasks.Sources;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Client c1 = new Client("Anvar", "Mammadov", 22, 5000, new Card("4169123456781234", "1111"));
                Client c2 = new Client("Ali", "Aliyev", 24, 10000, new Card("4169234234324324", "2222"));
                Client c3 = new Client("Murad", "Gojayev", 21, 20000, new Card("4169843759874358", "3333"));
                Client c4 = new Client("Samir", "Ahmedov", 25, 15000, new Card("4169546947438757", "4444"));
                Client c5 = new Client("Nizami", "Gurbanov", 36, 12000, new Card("4169835443843858", "5555"));

                Client[] clients = { c1, c2, c3, c4, c5 };

                Bank bank = new Bank("Local Bank", clients);
                Admin admin = new Admin { Clients = bank.Clients, Name = "admin", Pass = "admin", countClient = bank.Clients.Length };

                while (true)
                {
                    MyClear();
                    Console.WriteLine("\t\t= = = =  W E L C O M E  = =  L O C A L  = =  B A N K  = = = = \n\n\n");
                    Console.WriteLine("Client   [1]");
                    Console.WriteLine("Admin    [2]");
                    Console.WriteLine("Exit App [3]");
                    string? choose = Console.ReadLine()?.Trim();
                    MyClear();
                    if (choose != null)
                    {

                        if (choose == "1")
                        {
                            Console.Write("PAN : ");
                            string? pan = Console.ReadLine()?.Trim();
                            bool correct = false;
                            Client currentClient = new Client();
                            if (Validation.CheckPan(pan))
                            {
                                foreach (var client in bank.Clients)
                                {
                                    if (client.BankCard?.PAN == pan) { correct = true; break; }
                                    correct = false;
                                }
                            }
                            if (correct)
                            {
                                Console.Write("PIN : ");
                                string? pin = Console.ReadLine()?.Trim();
                                if (Validation.CheckPin(pin))
                                {
                                    foreach (var client in bank.Clients)
                                    {
                                        if (client.BankCard?.PIN == pin) { correct = true; currentClient = client; break; }
                                        correct = false;
                                    }
                                }
                                if (correct)
                                {
                                    MyClear();
                                    Console.WriteLine($"\t\tWelcome  {currentClient.Name} {currentClient.Surname}\n\n" +
                                        $"\tPlease choose one of the following options\n\n");
                                    while (true)
                                    {
                                        Console.WriteLine("Please enter any key..."); Console.ReadLine();
                                        MyClear();
                                        Console.WriteLine("Balance       [1]");
                                        Console.WriteLine("Withdraw Cash [2]");
                                        Console.WriteLine("Notifications [3]");
                                        Console.WriteLine("Card to Card  [4]");
                                        Console.WriteLine("Back          [0]");
                                        string? choos = Console.ReadLine()?.Trim();
                                        if (choos == "1")
                                        {
                                            Console.WriteLine($"Balance : {currentClient.BankCard?.Balance} AZN");
                                        }
                                        else if (choos == "2")
                                        {
                                            Console.WriteLine("10  AZN   [1]");
                                            Console.WriteLine("20  AZN   [2]");
                                            Console.WriteLine("50  AZN   [3]");
                                            Console.WriteLine("100 AZN   [4]");
                                            Console.WriteLine("Other     [5]");
                                            string? ch = Console.ReadLine()?.Trim();
                                            if (ch == "1")
                                            {
                                                currentClient.BankCard?.WithdrawFromBalance(10);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationWithdrawMessage(currentClient.BankCard.Balance, 10)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                            else if (ch == "2")
                                            {
                                                currentClient.BankCard?.WithdrawFromBalance(20);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationWithdrawMessage(currentClient.BankCard.Balance, 20)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                            else if (ch == "3")
                                            {
                                                currentClient.BankCard?.WithdrawFromBalance(50);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationWithdrawMessage(currentClient.BankCard.Balance, 50)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                            else if (ch == "4")
                                            {
                                                currentClient.BankCard?.WithdrawFromBalance(100);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationWithdrawMessage(currentClient.BankCard.Balance, 100)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                            else if (ch == "5")
                                            {
                                                Console.Write("Please enter the amount you want to withdraw from your balance :");
                                                double withdraw = Convert.ToDouble(Console.ReadLine());
                                                currentClient.BankCard?.WithdrawFromBalance(withdraw);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationWithdrawMessage(currentClient.BankCard.Balance, withdraw)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                        }
                                        else if (choos == "3")
                                        {
                                            int index = 0;
                                            Console.WriteLine(" \t\t= = = =  N O T I F I C A T I O N S = = = =\n\n");
                                            Console.WriteLine($"Name :{currentClient.Name} - Surname : {currentClient.Surname}\n");
                                            if (currentClient.Notifications != null)
                                            {
                                                foreach (var not in currentClient.Notifications)
                                                {
                                                    Console.WriteLine($"{++index} . "); not.ShowNotificationDetails();
                                                    Console.WriteLine("\n");
                                                }
                                            }

                                        }
                                        else if (choos == "4")
                                        {
                                            Console.WriteLine("\t\t = = = = C A R D  TO  C A R D = = = =\n\n");
                                            Console.Write("Enter PAN for send : ");
                                            string? panForSend = Console.ReadLine()?.Trim();
                                            var clientForSent = new Client();
                                            bool flag = false;
                                            bool equal = false;
                                            foreach (var client in bank.Clients)
                                            {
                                                if (client.BankCard.PAN == panForSend && currentClient.BankCard.PAN != panForSend)
                                                {
                                                    clientForSent = client; flag = true; break;
                                                }
                                                if (currentClient.BankCard.PAN == panForSend)
                                                {
                                                    Console.WriteLine("You can't send money to yourself, please try again.."); equal = true; break;
                                                }
                                            }
                                            if (flag)
                                            {
                                                Console.Write($"Enter money for send to PAN : {clientForSent.BankCard?.PAN} : ");
                                                double moneyForSend = Convert.ToDouble(Console.ReadLine());
                                                currentClient.BankCard?.WithdrawFromBalance(moneyForSend);
                                                currentClient.AddNotification
                                                    (new Notification(OtherFunctions.NotificationCardToCardMessage(moneyForSend, clientForSent.BankCard?.PAN, true)));
                                                clientForSent.AddNotification(new Notification(OtherFunctions.NotificationCardToCardMessage(moneyForSend,
                                                    currentClient.BankCard?.PAN, false)));
                                                Console.WriteLine("Operation Successfully"); continue;
                                            }
                                            else if (!equal && !flag) { Console.WriteLine("Pan can not found..Please try again..."); continue; }
                                        }
                                        else if (choos == "0") { break; }
                                        else { Console.WriteLine("Operation not found..."); continue; }

                                    }
                                }
                                else { Console.WriteLine("The PIN is incorrect, please try again.."); continue; }
                            }
                            else
                            {
                                Console.WriteLine("No PAN found like this, please try again.."); continue;
                            }
                        }
                        else if (choose == "2")
                        {
                            Console.Write("Username : ");
                            string? username = Console.ReadLine();
                            Console.Write("Password : ");
                            string? password = Console.ReadLine()?.Trim();
                            if (username == admin.Name && password == admin.Pass)
                            {
                                while (true)
                                {
                                    Console.WriteLine("Please enter any key..."); Console.ReadLine();
                                    MyClear();
                                    Console.WriteLine("\t\t\tWelcome Admin\n\n");
                                    Console.WriteLine("Show All Clients  [1]");
                                    Console.WriteLine("Add Client        [2]");
                                    Console.WriteLine("Remove Client     [3]");
                                    Console.WriteLine("Back              [0]");
                                    string? choice = Console.ReadLine()?.Trim();
                                    MyClear();
                                    if (choice == "1")
                                    {
                                        admin.ShowAllClients();
                                    }
                                    else if (choice == "2")
                                    {
                                        var newClient = admin.GetClient();
                                        if (newClient != null) admin.AddClient(newClient);
                                        else { continue; }
                                    }
                                    else if (choice == "3")
                                    {
                                        admin.ShowAllClients();
                                        Console.Write("Enter client ID for remove from Bank : ");
                                        int idFR = Convert.ToInt32(Console.ReadLine());
                                        admin.RemoveClient(idFR);
                                    }
                                    else if (choice == "0") { break; }
                                    else { Console.WriteLine("Operation not found ..."); continue; }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Username or Pass incorrect...Please try again..."); continue;
                            }
                        }
                        else if (choose == "3") { Console.WriteLine("Application Closed..."); break; }
                        else { Console.WriteLine("Operation not found..."); continue; }
                    }
                    else { throw new NullReferenceException("This value is null"); }
                }
            }
            catch(Exception ex) {
                Console.WriteLine(ex.StackTrace);
            }
        }

        /// <summary>
        /// Clears the console screen.
        /// </summary>
        public static void MyClear()
        {
            Console.Clear(); Console.WriteLine("\x1b[3J");
        }
    }
}