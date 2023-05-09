using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LfsrPathSeed
{
    //Line Feedback Shift Register + 
    class LFSR
    {
        public static void Bootstrap(string pathToApp)
        {
            string pathInBinary = strToBinary(pathToApp);
            Run(pathInBinary);
        }
        private static string strToBinary(String s)
        {
            StringBuilder binaryString = new StringBuilder("");
            int n = s.Length;

            for (int i = 0; i < n; i++)
            {
                // convert each char to
                // ASCII value
                int val = s[i];

                // Convert ASCII value to binary
                StringBuilder collectBinary = new StringBuilder("");
                while (val > 0)
                {
                    if (val % 2 == 1)
                    {
                        collectBinary.Append("1");
                    }
                    else
                        collectBinary.Append("0");
                    val /= 2;
                }

                binaryString.Append(reverse(collectBinary.ToString()));
            }
                return binaryString.ToString();
        }
        private static String reverse(String input)
        {
            char[] a = input.ToCharArray();
            int l, r = 0;
            r = a.Length - 1;

            for (l = 0; l < r; l++, r--)
            {
                // Swap values of l and r
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return String.Join("", a);
        }
        private static void Run(string seed)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < seed.Length; i++)
                numbers.Add(Convert.ToInt32(seed.ElementAt(i).ToString()));

            foreach (var item in numbers)
                Console.Write(item);
            Console.WriteLine();
            Console.WriteLine();

            var chosenIndex = 1;
            var noOfUsedPositions = 5;
            int result = numbers[chosenIndex];

            for(int i = chosenIndex; i < 2 * (noOfUsedPositions-1); i+=2)
            {
                result = XorForGivenNumbers(numbers[i+2], numbers[i]);
                numbers[i] = numbers[i + 2] = result;
                numbers = RightShift(numbers);
            }

            foreach (var item in numbers)
                Console.Write(item);
            Console.WriteLine();
        }
        private static List<int> RightShift(List<int> source)
        {
            if (source == null)
                throw new ArgumentNullException();

            var lastIndex = source.Count - 1;

            for (int j = lastIndex; j > 0; j--)
            {
                source[j] = source[j - 1];
            }

            return source;
        }
        private static Int32 XorForGivenNumbers(int number1, int number2)
        {
            return number1 ^ number2;
        }
    }
    /*
            public static void Run(string seed)
        {
            List<int> numbers = new List<int>();

            for (int i = 0; i < seed.Length; i++)
                numbers.Add(Convert.ToInt32(seed.ElementAt(i).ToString()));
            
            var initialSeed= new List<int>(numbers);
            var firstIndex = 1;
            var secondIndex = 3;
            
            for(int i = 1; i <= Math.Pow(2, seed.Length) - 1; i++)
            {
                var aux = numbers[firstIndex] ^ numbers[secondIndex];
                RightShift(numbers);
                numbers[0] = aux;

                foreach (var item in numbers)
                    Console.Write(item + " ");
                Console.WriteLine();
            }
            
        }
    */
}
