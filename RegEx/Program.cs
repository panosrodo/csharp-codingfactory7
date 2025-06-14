using System.Text.RegularExpressions;
namespace RegEx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input1 = "hello123";
            string pattern2 = @"[a-z]+\d+";
            OneMatch(input1, pattern2);
        }

        public static void OneMatch(string input, string pattern)
        {
            Match match = Regex.Match(input, pattern);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
