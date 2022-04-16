using System;
using System.Collections.Generic;
using System.Linq;

namespace LargestPrimeFactor
{
    class Program
    {
        private static bool keepRunning = true;
        enum Options
        {
            largestPrimeFactor,
            largestPalindrome,
            Quit = 9
        }

        public static long largestPrimeFactor(long num = 4000000)
        {
            long maxPrime = -1;

            while (num % 2 == 0)
            {
                maxPrime = 2;

                // equivalent to n/= 2;
                num >>= 1;
            }

            while ( num % 3 == 0 )
            {
                maxPrime = 3;
                num = num / 3;
            }

            for (int i = 5; i < Math.Sqrt(num); i += 6)
            {
                while (num % i == 0)
                {
                    maxPrime = i;
                    num = num / i;
                }
                while (num % (i + 2) == 0 )
                {
                    maxPrime = i + 2;
                    num = num / (i + 2);
                }
            }

            if (num > 4) maxPrime = num;

            return maxPrime;
        }

        public static int largestPalindrome(int numDigits)
        {
            int largest = 0;
            string maxNumber = "";
            string minNumber = "1";
            for(int x= 0; x < numDigits; x++)
            {
                maxNumber += '9';
            }

            for(int x=0; x < numDigits -1; x++)
            {
                minNumber += '0';
            }

            int highRange = Convert.ToInt32(maxNumber);
            int lowRange = Convert.ToInt32(minNumber);

            for(int i = highRange; i >= lowRange; i--)
            {
                for (int j = i; j >= lowRange; j--)
                {
                    int N = i * j;
                    if (checkIfPalidrome(N) && N > largest) largest = N;
                }
            }
            
            return largest;
        }

        public static bool checkIfPalidrome(int product)
        {
            var strProduct = product.ToString();
            var strProductReversArray = strProduct.Reverse().ToArray();
            var StrProductRev = new string(strProductReversArray);
            int intStrProductRev =  Convert.ToInt32(StrProductRev);
            return intStrProductRev == product;
        }

        static void getUserInput()
        {
        
            long input = -1;
            bool inputreceived = false;
            int OptionSelected = -1;

            while (!Options.IsDefined(typeof(Options), OptionSelected))
            {
                Console.WriteLine("Enter a the action you would like to accomplish: ");
                Console.WriteLine("0 for " + Options.largestPrimeFactor);
                Console.WriteLine("1 for " + Options.largestPalindrome);
                Console.WriteLine("9 for " + Options.Quit);

                try
                {
                    OptionSelected = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.Write("The value entered was not an Option. ");
                }

            }

            while (!inputreceived && (Options) OptionSelected != Options.Quit)
            {
                string Prompt = "";
                switch ((Options)OptionSelected)
                {
                    case Options.largestPrimeFactor:
                        {
                            Prompt = "Enter a number that you want to find the largest Prime factor: ";
                        }
                        break;

                    case Options.largestPalindrome:
                        {
                            Prompt = "Enter the number of digits for factors: ";
                        }
                        break;
                }

                Console.Write(Prompt);
                try
                {
                    input = Convert.ToInt64(Console.ReadLine());
                    inputreceived = true;

                }
                catch (Exception ex)
                {
                    Console.Write("The value entered was not an number. Try again. ");
                }
            }

            long answer = -1;
            switch ((Options) OptionSelected)
            {
                case Options.largestPrimeFactor: {
                    answer = largestPrimeFactor(input);
                   
                 } break;

                case Options.largestPalindrome: {
                    answer = largestPalindrome((int) input);
                } break;
                default: { Program.keepRunning = false; return; }

            }

            Console.WriteLine("Answer is: " + answer);

        }
        static int Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            while (Program.keepRunning) getUserInput();

            AfterLoop:
            Console.WriteLine("exited gracefully");
            return 0;
        }
    }
}
