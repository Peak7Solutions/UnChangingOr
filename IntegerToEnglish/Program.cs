using System;
using System.Collections.Generic;

namespace IntegerToEnglish
{
    class Program
    {

        private static bool keepRunning = true;

        static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
        static string[] teens = new string[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
        static string[] tens = new string[] { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string[] thousandsGroups = { "", " Thousand", " Million", " Billion" };


        private static string FriendlyInteger(int n, string leftDigits, int thousands)
        {
            if (n == 0)
            {
                return leftDigits;
            }

            string friendlyInt = leftDigits;

            if (friendlyInt.Length > 0)
            {
                friendlyInt += " ";
            }

            if (n < 10)
            {
                friendlyInt += ones[n];

            } else if ( n < 20 )
            {
                friendlyInt += teens[n - 10];
            } else if (n < 100)
            {
                friendlyInt += FriendlyInteger(n % 10, tens[n / 10 - 2], 0);
            } else if (n < 1000)
            {
                friendlyInt += FriendlyInteger(n % 100, (ones[n / 100] + " Hundred"), 0);
            } else
            {
                friendlyInt += FriendlyInteger(n % 1000, FriendlyInteger(n / 1000, "", thousands + 1), 0);
                if (n % 1000 == 0)
                {
                    return friendlyInt;
                }
            }

            return friendlyInt + thousandsGroups[thousands];
        }

        public static string NumberToWords(int num)
        {
          if (num == 0)
            {
                return "Zero";
            } else if ( num < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return FriendlyInteger(num, "", 0);
        }

        static void getUserInput()
        {
            int input = -1;
            string RomanAnswer = "";
            int IntegerAnswer = -1;
            string mode = "";
            int result = 0;
            bool inputreceived = false;
            while (!inputreceived)
            {
                Console.Write("Enter an integer to convert to english: ");
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    inputreceived = true;
                   
                }
                catch (Exception ex)
                {
                    Console.Write("The value entered was not an integer. Try again. ");
                }
            }

            var answer = NumberToWords(input);
            Console.WriteLine("Answer is: " + answer);

        }
        static int Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            while (Program.keepRunning) getUserInput();

            Console.WriteLine("exited gracefully");
            return 0;
        }
    }
}
