namespace StringApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s1 = "AEUB";
            string s2 = "AUEB"; // String Interning
            string passwd1 = "pass";
            string passwd2 = "Pass";

            // Equality
            Console.WriteLine($"{s1.Equals(s2)}");
            Console.WriteLine($"{s1 == s2}");
            Console.WriteLine($"{ReferenceEquals(s1, s2)}");

            // < <= > >=
            Console.WriteLine($"{String.Compare(s1, s2)}");
            Console.WriteLine($"{s1.CompareTo(s2)}");

            // concat
            string hello = "Hello";
            string aueb = $"{s1}";
            string helloAueb = hello + aueb;

            // ToUpper(), ToLower()
            bool areEqual = passwd1.ToUpper() == passwd2.ToUpper();

            // IndexOf
            string str = "C# Programming Language";
            int index = str.IndexOf("#");   // 1
            int index2 = str.IndexOf("a", 15);
            str.Substring(0);
            string subStr = str.Substring(3);   // Programming Language
            string subStr2 = str.Substring(3, 11);  // Programming

            // Trim()
            string s = "   Smtng ";
            char[] chars = [' ', '$', '#'];
            string trimmed = s.Trim(chars);
        }

        public static bool IsPalindrome(string s)
        {
            bool palindrome = true;
            for (int i = 0, j = s.Length; i < j; i++, j--)
            {
                if (s[i] != s[j])
                {
                    palindrome = false;
                    break;
                }
            }
            return palindrome;
        }
    }
}
