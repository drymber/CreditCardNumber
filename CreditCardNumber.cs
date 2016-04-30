using System;
using System.Text;

namespace Kottans.Task
{
    public class CreditCard
    {
        public static string GetCreditCardVendor(string creditCardNumber)
        {
            creditCardNumber.Replace(" ", "");
            if (!IsNumber(creditCardNumber))
            {
                throw new ArgumentException("Invalid credit card number");
            }

            int IIN = Convert.ToInt32(creditCardNumber.Substring(0, 2));
            int longIIN = Convert.ToInt32(creditCardNumber.Substring(0, 4));
            if (IIN == 34 || IIN == 37)
            {
                return "American Express";
            }
            if (IIN == 50 || (IIN >= 56 && IIN <= 69))
            {
                return "Maestro";
            }
            if (IIN >= 51 && IIN <= 55)
            {
                return "MasterCard";
            }
            if (creditCardNumber[0].Equals('4'))
            {
                return "VISA";
            }
            if (longIIN >= 3528 && longIIN <= 3589)
            {
                return "JCB";
            }
            return "Unknown";
        }
        public static bool IsCreditCardNumberValid(string creditCardNumber)
        {
            creditCardNumber = creditCardNumber.Replace(" ", "");
            if (!IsNumber(creditCardNumber))
            {
                throw new FormatException("Invalid credit card number");
            }

            int sum = 0;
            for (var i = creditCardNumber.Length - 1; i >= 0; i--)
            {
                int number = Convert.ToInt32(creditCardNumber[i].ToString());
                if (i % 2 == 0)
                {
                    number *= 2;
                    if (number > 9)
                    {
                        number -= 9;
                    }
                }
                sum += number;
            }
            bool isValid = (sum % 10 == 0) ? true : false;
            return isValid;
        }
        public static string GenerateNextCreditCardNumber(string creditCardNumber)
        {
			if (!IsNumber(creditCardNumber))
			{
				throw new FormatException("Invalid credit card number");
			}
            creditCardNumber = creditCardNumber.Replace(" ", "");
            decimal number = Convert.ToDecimal(creditCardNumber);
            do
            {
                number++;
            }
            while (!IsCreditCardNumberValid(number.ToString()));
            return number.ToString();
        }
		// Method to check if given credit card number consists only of numbers
        private static bool IsNumber(string number)
        {
            try
            {
                foreach (char c in number)
                {
                    Convert.ToInt32(c.ToString());
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    public class Program
    {
        public static void Main()
        {
			// Testing result
            string number = "4561 2612 1234 5467";
            string vendor = CreditCard.GetCreditCardVendor(number);
            bool isValid = CreditCard.IsCreditCardNumberValid(number);
            string nextNumber = CreditCard.GenerateNextCreditCardNumber(number);
            Console.WriteLine(nextNumber);
            Console.WriteLine(vendor);
            Console.WriteLine(isValid);
            Console.ReadLine();
        }
    }
}