using System;
using System.Collections.Generic;

namespace TenThousandand1stPrime
{
    class Program
    {

        private static bool keepRunning = true;

        enum Options
        {
            findNthPrime,
            Quit = 9
        }

        public static int FindNthPrime(int num)
        {
            List<int> PrimeFactors = new List<int>();
            int prime = 1;

            Console.Write("Find {0}th prime:\n", num);

            for (int i = 2; i <= num+1; i++)
            {



                prime = calculateNextPrime(prime);
                
            }


            return prime;
        }


        public static int calculateNextPrime(int number)
        {
            bool isPrime = false;

            while (!isPrime)
            {

                //increment the number by 1 each time
                number = number + 1;
                isPrime = true;
                int squareRtNumber = (int)Math.Sqrt(number);

                //start at 2 and increment by 1 until it gets to the squared number
                for (int i = 2; i <= squareRtNumber; i++)
                {
                    //how do I check all i's?
                    if (number % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            return number;
        }


        static void getUserInput()
        {

            int input = -1;
            bool inputreceived = false;
            int OptionSelected = -1;

            while (!Options.IsDefined(typeof(Options), OptionSelected))
            {
                Console.WriteLine("Enter a the action you would like to accomplish: ");
                Console.WriteLine("0 for " + Options.findNthPrime);
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

            while (!inputreceived && (Options)OptionSelected != Options.Quit)
            {
                string Prompt = "";
                switch ((Options)OptionSelected)
                {
                    case Options.findNthPrime:
                        {
                            Prompt = "Enter nth Prime to find: ";
                        }
                        break;

                }

                Console.Write(Prompt);
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    inputreceived = true;

                }
                catch (Exception ex)
                {
                    Console.Write("The value entered was not an number. Try again. ");
                }
            }

            long answer = -1;
            switch ((Options)OptionSelected)
            {
                case Options.findNthPrime:
                    {
                        answer = FindNthPrime(input);

                    }
                    break;
                default: { Program.keepRunning = false; return; }

            }

            Console.WriteLine("Answer is: " + answer);

        }
        static void Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            while (Program.keepRunning) getUserInput();

            AfterLoop:
            Console.WriteLine("exited gracefully");
        }
    }
}
