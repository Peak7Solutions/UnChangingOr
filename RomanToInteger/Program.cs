using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanToInteger
{
    class Program
    {
        private static bool keepRunning = true;

        static Dictionary<char, int> romanNumeralLegend = new Dictionary<char, int>
            {
              { 'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };

        static Dictionary<int, string> integertoRomanLegend = new Dictionary<int, string>
        {
             { 1000, "M" },
            { 900, "CM" },
            { 500, "D" },
            { 400, "CD" },
            { 100, "C" },
            { 90, "XC" },
            { 50, "L" },
            { 40, "XL" },
            { 10, "X" },
            { 9, "IX" },
            { 5, "V" },
            { 4, "IV" },
            { 1, "I" },
        };

        static int solution(string s)
        {
                   
           Dictionary<char, string> isSubtracted = new Dictionary<char, string> {
                {'I', "VX"},
                {'X', "LC"},
                {'C', "DM"}
            };

            int answer = 0;
            for (var x = 0; x < s.Length; x++)
            {
                var aChar = s[x];
                var nextChar = (x + 1 < s.Length) ? s[x + 1] : '0';
                if (isSubtracted.ContainsKey(aChar) && isSubtracted[aChar].Contains(nextChar))
                {
                    ;
                    // is subtracted

                    answer += -(romanNumeralLegend[s[x]]);
                }
                else
                {
                    answer += romanNumeralLegend[s[x]];
                }
            }

            return answer;

        }

        static string Solution(int s) {
            int tmp = s;
            var answer = new StringBuilder();
           
           foreach(var item in integertoRomanLegend)
            {
               while (tmp >= item.Key)
                {
                    answer.Append(item.Value);
                    tmp -= item.Key;
                }
                
            }

            return answer.ToString();
        }
        static void getUserInput()
        {
            string input = "";
            string RomanAnswer = "";
            int IntegerAnswer = -1;
            string mode = "";
            int result = 0;
            bool inputreceived = false;
            while (!inputreceived)
            {
                Console.Write("Enter an integer or Roman Numeral: ");
                try
                {
                    input = Console.ReadLine();
                    inputreceived = true;
                    if (Int32.TryParse(input,out result))
                    {
                        mode = "IntToRoman";
                    } else if (!String.IsNullOrEmpty(input))
                    {
                        // ensure is roman numeral;

                        foreach(char numeral in input)
                        {
                            inputreceived = romanNumeralLegend.ContainsKey(numeral);
                            if (!inputreceived) Console.WriteLine("The value entered was neither an integer nor a Roman Numeral. Try Again. ");
                        }
                        mode = "RomanToInt";
                    }
                }
                catch (Exception ex)
                {
                    Console.Write("Something went wrong");
                }


            }

            switch (mode)
            {
                case "IntToRoman": {
                        RomanAnswer = Solution(result);
                    } break;
                case "RomanToInt": {
                        IntegerAnswer = solution(input);
                    } break;
            }

            var something = !(String.IsNullOrEmpty(RomanAnswer)) ? RomanAnswer : IntegerAnswer.ToString();
            Console.WriteLine("Answer is: " + something);

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
