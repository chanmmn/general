using System;
using System.Collections.Generic;
using System.Linq;

namespace ConAppLinqList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>();
            myList.Add("701111-13-6031");
            myList.Add("701112-13-6032");
            myList.Add("701113-13-6033");

            var result = from r in myList select r;

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            var result1 = myList.Contains("701112");

            Console.WriteLine(result1);
            Console.WriteLine();

            //var result2 = (from r in myList select r).Contains("701112-13-6032");
                        
            var result2 = from r in myList where r.Contains("701111") select r;

            foreach (string item in result2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
