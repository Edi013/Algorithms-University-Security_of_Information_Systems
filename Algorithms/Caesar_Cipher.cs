using System;
using System.Text;

namespace c__project.Algorithms
{
    public static class CaesarCipher
    {
        private static string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static char[] alphabet = alphabetString.ToCharArray();

        //ana are mere -> bob bsf nfsf, shiftValue = 1
        public static string Encrypt(string plainMessage, int shiftValue)
        {
            char[] _plainMessage = plainMessage.ToCharArray();
            StringBuilder encryptedMessage = new StringBuilder();

            for(int contor = 0; contor < plainMessage.Length; contor++)
            {
                char currentLetter = _plainMessage[contor];

                if (Char.IsLetter(currentLetter))
                {
                    encryptedMessage.Append(ShiftedLetter(currentLetter, shiftValue));
                    continue;
                }

                encryptedMessage.Append(currentLetter);
            }
            
            return encryptedMessage.ToString();
        }

        //bob bsf nfsf -> ana are mere  , shiftValue = 1
        public static string Decrypt(string cryptedMessage, int shiftValue)
        {
            shiftValue = -1 * shiftValue;

            char[] _cryptedMessage = cryptedMessage.ToCharArray();
            StringBuilder dencryptedMessage = new StringBuilder();

            for (int contor = 0; contor < cryptedMessage.Length; contor++)
            {
                char currentLetter = _cryptedMessage[contor];

                if (Char.IsLetter(currentLetter))
                {
                    dencryptedMessage.Append(ShiftedLetter(currentLetter, shiftValue));
                    continue;
                }

                dencryptedMessage.Append(currentLetter);
            }

            return dencryptedMessage.ToString();
        }

        private static char ShiftedLetter(char letterToShift, int shiftValue)
        {
            int indexOfPlainLetter = Array.IndexOf(alphabet, Char.ToUpper(letterToShift));

            int newIndex = (indexOfPlainLetter + shiftValue) % (alphabetString.Length - 1);

            newIndex = newIndex >= 0
                ? newIndex
                : (alphabetString.Length - 1) - newIndex;

            char encryptedChar = alphabet[newIndex];

            return IsUpper(letterToShift) == true
                ? encryptedChar
                : Char.ToLower(encryptedChar);
        }
        private static bool IsUpper(char questionedChar)
        {
            return char.ToUpper(questionedChar) == questionedChar;
        }
    }
}
