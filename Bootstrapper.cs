using lab_ssi.Algorithms;
using System;

namespace c__project.Algorithms
{
    public class Bootstrapper
    {
        public static void Main()
        {
            const string albertiCipher = "Albert Cipher";
            const string caesarCipher = "Caesar Cipher";
            const string vernamCipher = "Vernam Cipher";
            const string stringLFSR = "LFSR";
            const string exempluMoneda = "exempluMoneda";
            //cum faci char to binary?
            //

            const string algorithm = stringLFSR;

            switch (algorithm)
            {
                case albertiCipher:
                    Console.WriteLine("Decrypting:");
                    Console.WriteLine("BgxggmpDxlsl : " + AlbertCipher.Decrypt("BgxggmpDxlsl")); ;
                    break;

                case caesarCipher:
                    Console.WriteLine("Encrypting:");
                    Console.WriteLine("Ana are mere : " + CaesarCipher.Encrypt("Ana are mere", 1));
                    Console.WriteLine("Decrypting:");
                    Console.WriteLine("Bob bsf nfsf : " + CaesarCipher.Decrypt("Bob bsf nfsf", 1));
                    break;

                case vernamCipher:
                    Console.WriteLine(VernamCipher.Encrypt("hello"));
                    break;

                case stringLFSR:
                    LFSR.Run("10111");
                    break;
                case exempluMoneda:

                    break;
            }
        }
    }
}

