using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class Client
    {
		public Client() { }	

		public Client( string?_name,string?_surname,int _age,double _salary,Card _bankCard) {
			ID = ++id;
			Name= _name;
			Surname= _surname;
			Age= _age;
			Salary= _salary;
			BankCard= _bankCard;	
		}

		private static int id = 0;

		public int ID { get; private set; }


		private string? name;

		public string? Name
		{
			get => name;
			set { if(Validation.CheckName(value)) name = value?.Trim(); }
		}

		private string? surname;

		public string? Surname
		{
			get => surname;
			set {if(Validation.CheckName(value)) surname = value?.Trim(); }
		}

		private int age;

		public int Age
		{
			get => age;
			set { if (Validation.CheckAge(value)) age = value; }
		}

		private double salary;

		public double Salary
		{
			get => salary;
			set {if(Validation.CheckSalary(value)) salary = value; }
		}

		private Card? bankCard;

		public Card? BankCard
		{
			get => bankCard;
			set {if(Validation.CheckNull(value)) bankCard = value; }
        }

        public Notification[]? Notifications { get; set; }
        public int NotificationsCount { get; set; }


        /// <summary>
        /// This function is for adding a notification.
        /// </summary>
        /// <param name="notification"> New Notification</param>
        public void AddNotification(Notification notification)
		{
			Notification[] temp = new Notification[++NotificationsCount];
			if (Notifications != null)
			{
				Notifications?.CopyTo(temp, 0);
			}
				temp[temp.Length - 1] = notification;
				Notifications = temp;
		}


		/// <summary>
		/// Displays all Client Information
		/// </summary>
		public void ShowClientInfo()
		{
            Console.WriteLine(" = = = = Info = = = = ");
            Console.WriteLine($"Name    : {Name}");
            Console.WriteLine($"Surname : {Surname}");
            Console.WriteLine($"Age     : {Age}");
            Console.WriteLine($"Salary  : {Salary}");
        }

	}
}
