using System.Text.RegularExpressions;

namespace ConsoleApp2
{
    public class Test
    {
        public static string WordParser(string input)
        {
            string result = string.Empty;

            char[] delims = GetSpecialCharacters(input);
            List<string> lstTest = SplitString(input, delims).ToList();
            foreach (string str in lstTest)
            {
                if (str.Count() > 2)
                {
                    int countDistinct = str.Distinct().Count() - 2;
                    result += string.Format("{0}{1}{2}", str[0], countDistinct, str[str.Length - 1]);
                }
                else { result += str; }

            }
            return result;


        }
        public static IEnumerable<string> SplitString(string s, char[] delimitators)
        {
            int start = 0;
            int index = 0;

            while ((index = s.IndexOfAny(delimitators, start)) != -1)
            {
                if (index - start > 0)
                    yield return s.Substring(start, index - start);
                yield return s.Substring(index, 1);
                start = index + 1;
            }

            if (start < s.Length)
            {
                yield return s.Substring(start);
            }
        }
        public static char[] GetSpecialCharacters(string input)
        {
            char[] chars = input.ToCharArray();
            List<char> result = new List<char>();
            for (int i = 0; i < chars.Length; i++)
            {
                if (!Char.IsLetterOrDigit(chars[i]))
                {
                    result.Add(chars[i]);
                }
            }
            return result.ToArray();
        }
        public static void Main()
        {
            string output = WordParser("Creativity is thinking-up. New things Innovation is doing new things!");
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}