using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_ssi.Algorithms
{
    //Line Feedback Shift Register
    class MonedaLFSR
    {
        public static List<int> RightShift(List<int> source)
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

        public static List<int> Run(string seed)
        {
            List<char> numbers = new List<char>();
            List<int> outputPlayer = new List<int>();

            for (int i = 0; i < seed.Length; i++)
                numbers.Add(Convert.ToInt32(seed.ElementAt(i).ToString()));

            var initialSeed = new List<int>(numbers);
            var firstIndex = 1;
            var secondIndex = 3;

            for (int i = 1; i <= Math.Pow(2, seed.Length) - 1; i++)
            {
                var aux = numbers[firstIndex] ^ numbers[secondIndex];
                outputPlayer.Add(numbers[numbers.Count - 1]);
                RightShift(numbers);
                numbers[0] = aux;

                foreach (var item in numbers)
                    Console.Write(item + " ");
                Console.WriteLine();
            }

            return outputPlayer;
        }
        void GameBoostrapper()
        {
            Console.WriteLine("Start game:");
            var player1Result = Run("Geani");
            var player2Result = Run("Radu");
            
        }

        private static bool CheckEquality(List<int> numbers, List<int> initialSeed)
        {
            int contorEqulPositions = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] != initialSeed[i])
                    contorEqulPositions++;
            }

            if (contorEqulPositions == numbers.Count)
                return true;

            return false;
        }
    }
}
