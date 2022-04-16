using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonHouseProblems1
{
    class Program
    {

        public static int[] Houses = new int[] { 1, 1, 1, 0, 1, 1, 1, 1 };
        public static int[] arr = new int[] { 24, 36, 148 };

        public static int[] cellCompete(int[] states, int days)
        {
            var tmp = states;
            if (days == 0) return tmp;

            for (var i = 0; i < days; i++)
            {
                int[] newDayState = new int[8];
                for (var j = 0; j < newDayState.Length; j++)
                {
                    if (j == 0)
                    {
                        newDayState[j] = compete(tmp[j + 1]);
                    }
                    else if (j == tmp.Length - 1)
                    {
                        newDayState[j] = compete(tmp[j - 1]);
                    }
                    else
                    {
                        newDayState[j] = compete(tmp[j - 1] , tmp[j + 1]);
                    }
                }

                tmp = newDayState;
            }
            return tmp;
        }

        public static int compete(int b)
        {
            return compete(0, b);
        }
        public static int compete(int a, int b)
        {
            if (a == b) return 0;
            else return 1;
        }

        public static Dictionary<int, int> PrimeFactorization(int num)
        {
            Dictionary<int, int> PrimeFactors = new Dictionary<int, int>();
            int j;

            Console.Write("Prime factor of {0}:\n", num);

            for (int i = 2; i <= num; i = calculateNextPrime(i))
            {
                // check for divisibility
                while (num % i == 0) {

                    if (!PrimeFactors.ContainsKey(i))
                    {
                        PrimeFactors[i] = 1;
                    }
                    else
                    {
                        PrimeFactors[i]++;
                    }

                    num = num / i;
                }
            }


            return PrimeFactors;
        }

        public static double generalizedGCD(int num, int[] arr)
        {
            // all positive numbers can be divided by 1;
            int GCD = 1;

            Array.Sort(arr);
            Dictionary<int, Dictionary<int, int>> FactorsList = new Dictionary<int, Dictionary<int, int>>();
            Dictionary<int, int> GCDParts = new Dictionary<int, int>();
            // find factors for each number
            for (int x = 0; x < num; x++)
            {
                var dict = PrimeFactorization(arr[x]);

                FactorsList.Add(arr[x], dict);
            }

            // interate factors to see if common
            // foreach factor in first. 
            int minInSet = FactorsList.Keys.First();
            double candidateCommonDivisor = 1;
            int candidateExponent = 0;
            foreach(var factor in FactorsList[minInSet])
            {
                var hasCommon = FactorsList.All(factorSet => factorSet.Value.ContainsKey(factor.Key));
                if (hasCommon)
                {
                    // found a common factor
                    // what is the common exponent? 
                    var exp = FactorsList.Where(factorSet => factorSet.Value.ContainsKey(factor.Key)).Min(s => s.Value[factor.Key]);
                    candidateCommonDivisor = candidateCommonDivisor * (Math.Pow(factor.Key,exp));
                }

               
            }

            // if none found
            // then 1 is common. 
            // return GCD; 

            return Math.Floor(candidateCommonDivisor);
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

        static void Main(string[] args)
        {
           var result = generalizedGCD(3, arr);

            //foreach (var item in result)
            //{
            //    Console.WriteLine("Factor " + item.Key + " has the following factors:  ");

            //    foreach (var list in item.Value)
                //{
                    Console.WriteLine(result + " is the greatest common divisor. ");
            //    }
            //}
        }
    }
}
