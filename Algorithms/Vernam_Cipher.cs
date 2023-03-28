using System.Text;

namespace c__project.Algorithms
{
    public class VernamCipher
    {
        private static string alphabetString = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static char[] alphabet = alphabetString.ToCharArray();

        public static string Encrypt(string plainText)
        {
            StringBuilder cipheredText = new StringBuilder();
            string key = GenerateKeyFor(plainText);

            for(int kth = 0; kth < plainText.Length; kth++)
            {
                cipheredText.Append(plainText.ElementAt(kth) ^ key.ElementAt(kth));
            }

            return cipheredText.ToString();
        }

        public static string GenerateKeyFor(string text)
        {
            StringBuilder key = new StringBuilder();

            for(int i = 0; i < text.Length; i++)
            {
                key.Append( alphabet[text.ElementAt(i).GetHashCode() % alphabetString.Length]);
            }

            return key.ToString().ToLower();
        }
    }
}
