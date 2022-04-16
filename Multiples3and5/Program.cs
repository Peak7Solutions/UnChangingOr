using System;
using System.Collections.Generic;
using System.Linq;

namespace Multiples3and5
{
    class Program
    {

        private static bool keepRunning = true;

        static Dictionary<int, int> multiples = new Dictionary<int, int>();

        public static int sumOfMultiples(int num)
        {
            for (var x = 1; x < num; x++)
            {
                if (x % 3 == 0 || x % 5 == 0)
                {
                    // is a multiple
                    if (!multiples.ContainsKey(x))
                    {
                        multiples[x] = 1;
                    } else
                    {
                        multiples[x]++;
                    }

                }
            }

            var sum = multiples.Sum(x => x.Key);

            return sum;
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
                Console.Write("Enter an integer determine sum of multiples 3 and 5: ");
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

            var answer = sumOfMultiples(input);
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
