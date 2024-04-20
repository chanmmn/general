using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            ExtractDate();
            // Example date

        }

        public static void ExtractDate()
        {
            DateTime date = DateTime.Now;

            // Extracting 2 digits for day, month, and year
            string day = date.ToString("dd");
            string month = date.ToString("MM");
            string year = date.ToString("yy");

            // Printing the extracted values
            Console.WriteLine($"Day: {day}");
            Console.WriteLine($"Month: {month}");
            Console.WriteLine($"Year: {year}");
    }
}
}




