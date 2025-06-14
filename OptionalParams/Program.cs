namespace OptionalParams
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime dateTime = GetDateTime();
            Console.WriteLine($"{dateTime:D}");

            DateTime dateTime2 = GetDateTime();
            Console.WriteLine($"{dateTime2:F}");
        }

        public static DateTime GetDateTime(int year = 2025, int month = 6, int day = 14, int min = 0, int sec = 0, int milli = 0)
        {
            return new DateTime(year, month, day, min, sec, milli, DateTimeKind.Utc);
        }
    }
}