using System;

namespace UnChangingOr
{
    class Program
    {
        private static bool keepRunning = true;
        static int pow2(int bits)
        {
            return 1 << bits; // 2 ^ bits
        }

        static int max_num(int bits)
        {
            return pow2(bits + 1) - 1;
        }

        static void solution()
        {

          

            int N = 0;
            bool integerReceived = false;
            while (!integerReceived)
            {
                Console.Write("Enter an integer: ");
                try
                {
                    N = Convert.ToInt32(Console.ReadLine());
                    integerReceived = true;
                }
                catch (Exception ex)
                {
                    Console.Write("The value entered was not an integer. Try again. ");
                }
            }

            int bit_count = 0;
            while (N >> bit_count != 0)
            {
                bit_count++;
            }

            int ans = 0;
            for(int i = 1; i < bit_count; ++i)
            {
                ans =Math.Min(N, max_num(i)) - pow2(i);
            }

            Console.WriteLine("Answer is: " + ans);
        }

        static int Main(string[] args)
        {
            Console.CancelKeyPress += delegate (object sender, ConsoleCancelEventArgs e) {
                e.Cancel = true;
                Program.keepRunning = false;
            };
            while (Program.keepRunning) solution();

            Console.WriteLine("exited gracefully");
            return 0;
        }
    }
}
