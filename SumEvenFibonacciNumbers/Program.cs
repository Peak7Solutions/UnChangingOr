using System;
using System.Collections.Generic;

namespace SumEvenFibonacciNumbers
{
    class Program
    {

        private static bool keepRunning = true;

        static List<int> fibonacci = new List<int>();

        public static int sumOfEvenFiconacciNums(int num = 4000000) {
            fibonacci.Clear();
            int trigger = num;
            int x = 1;
            fibonacci.Add(1);
            fibonacci.Add(2);
            var sum = 2;
            while (x <= trigger)
            {
                var index = fibonacci.Count - 1;
                x = fibonacci[index] + fibonacci[index - 1];

                if (x % 2 == 0) sum += x;
                fibonacci.Add(x);
            }

            return sum;
        }

        static void getUserInput()
        {
            int input = -1;
            bool inputreceived = false;
            while (!inputreceived)
            {
                Console.Write("Enter an integer not to exceed: ");
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

            var answer = sumOfEvenFiconacciNums(input);
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
