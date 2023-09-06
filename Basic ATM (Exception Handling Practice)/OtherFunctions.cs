using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_ATM__Exception_Handling_Practice_
{
    internal class OtherFunctions
    {

        /// <summary>
        /// Generates a withdrawal notification message.
        /// </summary>
        /// <param name="balance">The current balance.</param>
        /// <param name="withdraw">The amount withdrawn.</param>
        /// <returns>A notification message.</returns>
        public static string? NotificationWithdrawMessage(double balance,double withraw)
        {
            string ? message =$@"From your balance ({balance} AZN) => {withraw} AZN was withdrawn.";
            return message;
        }



        /// <summary>
        /// Generates a notification message for card-to-card transactions.
        /// </summary>
        /// <param name="send">The amount sent.</param>
        /// <param name="toOrFromPan">The PAN (Primary Account Number) of the other account involved in the transaction.</param>
        /// <param name="flag">A flag indicating the direction of the transaction (true for outgoing, false for incoming).</param>
        /// <returns>A notification message.</returns>
        public static string? NotificationCardToCardMessage(double send,string? toOrFromPan,bool flag=true)
        {
            
            if (flag)
            {
                return $@"{send} AZN was sent from your account to the account with PAN number : {toOrFromPan}.";    
            }
            return $@"{send} AZN was sent from the account associated with PAN number : {toOrFromPan} to your account.";
        }
    }
}
