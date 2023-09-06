using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Card
    {
        public Card() { }

        public Card(string? pan,  string? pin)
        {
            PAN = pan;
            PIN = pin;
            CVC=GetCVC();
            Balance =GetBalance();
            int currentYear = DateTime.Now.Year % 100;
            int currentMonth = DateTime.Now.Month;
            ExpireDate = $"{currentMonth:D2}/{currentYear:D2}";
        }

        private string? pan;

        public string? PAN
        {
            get => pan;
            set { if (Validation.CheckPan(value)) pan = value?.Trim(); }
        }

        private string? pin;

        public string? PIN
        {
            get => pin;
            set { if (Validation.CheckPin(value)) pin = value?.Trim(); }
        }

        public int CVC { get; private set; }

        private double balance;

        public double Balance
        {
            get => balance;
            set { if (Validation.CheckBalance(value)) balance = value; }
        }

        public string? ExpireDate { get; private set; }


        Random random = new Random();

        /// <summary>
        /// To obtain a CVC using the Random class
        /// </summary>
        /// <returns>Return a value between 100 and 999</returns>
        public int GetCVC()
        {
            return random.Next(100, 1000);
        }

        /// <summary>
        /// To obatin a Salary using the Random class
        /// </summary>
        /// <returns>Return a value between 0 and 11000</returns>
        public double GetBalance()
        {
            return Convert.ToDouble((random.Next(0, 10000) + random.NextDouble()).ToString("N2"));
        }



        /// <summary>
        /// A function to withdraw money from the card balance
        /// </summary>
        /// <param name="withdraw">withdrawn money</param>
        public void WithdrawFromBalance(double withdraw) {
            if (Validation.CheckBalanceForWithdraw(Balance, withdraw))
            {
                Balance -= withdraw;
            }
        }


        /// <summary>
        /// Displays all card information
        /// </summary>
        public void ShowCardInfo()
        {
            Console.WriteLine("\n = = = Card Info = = = \n");
            Console.WriteLine($"PAN         : {PAN}");
            Console.WriteLine($"PIN         : {PIN}");
            Console.WriteLine($"CVC         : {CVC}");
            Console.WriteLine($"Balance     : {Balance} AZN");
            Console.WriteLine($"Expire Date : {ExpireDate}");
        }
    }
}
