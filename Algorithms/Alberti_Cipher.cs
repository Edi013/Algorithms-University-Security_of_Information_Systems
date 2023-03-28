using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace c__project.Algorithms
{
    public static class AlbertCipher
    {
        public static string Decrypt(string _cipheredText)
        {
            //Implementarea algoritmului Alberti Cipher

            string largeWheel = "ABCDEFGILMNOPQRSTVXZ1234";
            string smallWheel = "gklnprtuz&xysomqihfdbace";
            char[] smallWheelCharArr = smallWheel.ToCharArray();
            string left = "left";
            string right = "right";
            int cipheredIndex = Array.IndexOf(smallWheelCharArr, 'k');

            void ChangeAlphabet(int amoutOfShifts)
            {
                if (amoutOfShifts > 0)
                    Shift(smallWheelCharArr, right, amoutOfShifts);
                else
                    Shift(smallWheelCharArr, left, amoutOfShifts);

            }
            void Shift(char[] source, string direction, int timesToRepet)
            {

                if (direction == left)
                {
                    timesToRepet = Math.Abs(timesToRepet);
                    for (int i = 0; i < timesToRepet; i++)
                        LeftShift(source);
                }
                else if (direction == right)
                {
                    for (int i = 0; i < timesToRepet; i++)
                        RightShift(source);
                }
                else
                {
                    throw new InvalidOperationException("Direction is invalid");
                }

            }
            void LeftShift(char[] source)
            {
                if (source == null)
                    throw new ArgumentNullException();

                var lastIndex = source.Length - 1;
                var temp = source[0];

                for (int j = 0; j + 1 < source.Length; j++)
                {
                    source[j] = source[j + 1];
                }

                source[lastIndex] = temp;
            }
            void RightShift(char[] source)
            {
                if (source == null)
                    throw new ArgumentNullException();

                var lastIndex = source.Length - 1;
                var temp = source[lastIndex];

                for (int j = lastIndex; j > 0; j--)
                {
                    source[j] = source[j - 1];
                }

                source[0] = temp;
            }

            bool IsUpper(char questionedChar)
            {
                return char.ToUpper(questionedChar) == questionedChar;
            }

            String Decipher(string cipheredText)
            {
                char[] ciphered_arr = cipheredText.ToCharArray();
                List<char> decipheredText = new List<char>();
                int i = 0; // contor of ciphered_arr
                int endIndex = ciphered_arr.Length - 1;

                char first_char = ciphered_arr[0];
                if (first_char >= 'A' && first_char  <= 'Z')
                {
                    int largeWheelIndex = largeWheel.IndexOf(first_char);
                    cipheredIndex = largeWheelIndex;
                    i++;
                }

                while (i <= endIndex)
                {
                    char currentChar = ciphered_arr[i];

                    if (IsUpper(currentChar))
                    {
                        int indexInLargeWheel = largeWheel.IndexOf(currentChar);
                        int indexInSmallWheel = cipheredIndex;
                        int amoutOfShifts = indexInLargeWheel - indexInSmallWheel;

                        ChangeAlphabet(amoutOfShifts);
                        decipheredText.Add(' ');
                        i++;
                        continue;
                    }
                        int indexToSearch = Array.IndexOf(smallWheelCharArr, currentChar);
                        char correspondingLetter = largeWheel.ElementAt(indexToSearch);

                        decipheredText.Add(correspondingLetter);
                    i++;
                }

                string ToStringForCharArr(List<char> arr)
                {
                    StringBuilder stringBuiler = new StringBuilder();
                    for (int i = 0; i < arr.Count; i++)
                        stringBuiler.Append(arr[i]);

                    return stringBuiler.ToString();
                }
                return ToStringForCharArr(decipheredText);
            }

            string uncipheredText = Decipher(_cipheredText); // "BgxggmpDxlsl"
            return uncipheredText;
        }
    }
}
