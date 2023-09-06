using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal static  class Validation
    {
        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="name">Whatsoever string value is received (considered for a name or surname)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckName(string? name)
        {
            if (name?.Trim().Length < 3) throw new ArgumentException("Name must not be less than 3 characters.");
            return true;
        }

        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="age">Whatsoever int value is received (considered for a age)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckAge(int age)
        {
            if(!(age>=18 && age <= 100)) { throw new ArgumentException("Age must be greater than 18 and less than 100."); }
            return true;    
        }


        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="salary">Whatsoever int value is received (considered for a salary)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckSalary(double salary)
        {
            if (salary < 0) throw new ArgumentException("Salary must be greater than zero");
            return true;
        }


        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="balance">Whatsoever int value is received (considered for a balance)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckBalance(double balance)
        {
            if (balance < 0) throw new ArgumentException("Balance must be greater than zero");
            return true;
        }


        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="pan">Whatsoever int value is received (considered for a pan)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckPan(string? pan) {
            long _pan;
            if (!(long.TryParse(pan, out _pan))) throw new ArgumentException("Pan can only consist digits");
            if (pan.Trim().Length != 16) throw new ArgumentException("Pan must be 16 digits");
            return true;
        }

        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met; otherwise, it throws an exception
        /// </summary>
        /// <param name="pin">Whatsoever int value is received (considered for a pin)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckPin(string?pin) {

            int _pin;
            if (!(int.TryParse(pin, out _pin))) throw new ArgumentException("Pin can only consist digits");
            if (pin.Trim().Length != 4) throw new ArgumentException("Pin must be 4 digits");
            return true;
        }

        /// <summary>
        /// This function checks the incoming value and returns true if the conditions are met(null or not null); otherwise, it throws an exception
        /// </summary>
        /// <param name="temp">Whatsoever int value is received (considered for all referance)</param>
        /// <returns>true or exception</returns>
        /// <exception cref="ArgumentException"></exception>
        public static bool CheckNull(dynamic? temp)
        {
            if (temp == null) throw new ArgumentException("This object is null");
            return true;
        }

        /// <summary>
        /// Checks if the balance is sufficient for a withdrawal operation.
        /// </summary>
        /// <param name="balance">The current account balance.</param>
        /// <param name="withdraw">The amount to be withdrawn.</param>
        /// <returns>True if there are sufficient funds, otherwise throws an ArgumentException.</returns>
        public static bool CheckBalanceForWithdraw(double balance,double withdraw)
        {
            if (balance - withdraw < 0) throw new ArgumentException("Insufficient balance...There are insufficient funds in your account to withdraw this amount");
            return true;
        }
    }
}
