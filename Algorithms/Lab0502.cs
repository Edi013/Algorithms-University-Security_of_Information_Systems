using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__project.Algorithms
{
    static class Lab0502
    {
        public static void Run()
        {
            string plainText = Console.ReadLine("Introduceti textul in clar");
            global::System.Console.WriteLine(plainText);
            byte[] textInBinary = ConvertToByteArray(plainText, Encoding.ASCII);
            global::System.Console.WriteLine(textInBinary);


        }
        private static byte[] ConvertToByteArray(string str, Encoding encoding)
        {
            return encoding.GetBytes(str);
        }

        private static String ToBinary(Byte[] data)
        {
            return string.Join(" ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
        }
    }
}
