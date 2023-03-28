namespace c__project.Tests.PolymorphismTest
{
    public class PolymorphismTest
    {
        public static void RunPolimorphismTest()
        {
            List<Alphabet> alphabet = new List<Alphabet>()
            {
                new LatinAlphabet("latin alphabet"),
                new ChineseAlphabet("chinese alphabet")
            };
            Console.WriteLine(alphabet[0].GetType());
            Console.WriteLine(alphabet[1].GetType());

            Alphabet[] alphabet2 = new Alphabet[2]
            {
                        new LatinAlphabet("latin alphabet"),
                        new ChineseAlphabet("chinese alphabet")
            };

            return;
        }
    }

    public class Alphabet
    {
    }

    public class LatinAlphabet : Alphabet
    {
        public string somethingLatin;
        public LatinAlphabet(string _specialCaracters)
        {
            somethingLatin = _specialCaracters;
        }
    }

    public class ChineseAlphabet : Alphabet
    {
        public string somethingChinese;
        public ChineseAlphabet(string _specialCaracter)
        {
            somethingChinese = _specialCaracter;
        }
    }
}
