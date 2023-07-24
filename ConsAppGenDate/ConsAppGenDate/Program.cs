using System;

namespace ConsAppGenDate
{

    class RandomDateTime
    {
        DateTime start;
        Random gen;
        int range;

        public RandomDateTime()
        {
            start = new DateTime(1970, 1, 1);
            gen = new Random();
            range = (DateTime.Today - start).Days;
        }

        public DateTime Next()
        {
            return start.AddDays(gen.Next(range)).AddHours(gen.Next(0, 24)).AddMinutes(gen.Next(0, 60)).AddSeconds(gen.Next(0, 60));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RandomDateTime date = new RandomDateTime();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(date.Next());
            }
            Console.ReadKey();
        }

    }
}

//https://www.csharp-console-examples.com/csharp-console/generate-random-date-in-c/
