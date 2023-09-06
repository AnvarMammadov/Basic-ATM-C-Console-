using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Notification
    {
        public Notification() { }  
        public Notification(string? message)
        {
            Message = message?.Trim();
            Date = DateTime.Now;
        }

        public string? Message { get; set; }
        public DateTime Date { get; private set; }

        /// <summary>
        /// This function is designed to provide information based on the actions it performs for the Client.
        /// (Contains Message and Date)
        /// </summary>
        public void ShowNotificationDetails()
        {
            Console.WriteLine($"Message : {Message}");
            Console.WriteLine($"Date    : {Date}");
        }
    }
}
