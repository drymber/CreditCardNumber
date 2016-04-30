using System;
using CreditCardNumber;

namespace Kottans.Task
{
    public class Program
    {
        // Testing result
        public static void Main()
        {
            try
            {
                string number = "4561 2612 1234 5467";
                // Find out the vendor of the credit card
                string vendor = CreditCard.GetCreditCardVendor(number);
                Console.WriteLine(vendor);
                // Find out whether credit card number is valid (according to Luhn algorithm) or not
                bool isValid = CreditCard.IsCreditCardNumberValid(number);
                Console.WriteLine(isValid);
                // Generate next valid number for credit card 
                string nextNumber = CreditCard.GenerateNextCreditCardNumber(number);
                Console.WriteLine(nextNumber);

                Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();
            }
        }
    }
}