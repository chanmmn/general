using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number1 = 0;
            int number2 =0;
            int number3 = 0;

            InputNumber(ref number1, ref number2, ref number3);

            int Big = Biggest(number1, number2, number3);
            int Small = Smallest(number1, number2, number3);

            Console.WriteLine("Biggest number is {0}", Big);
            Console.WriteLine("Smallest number is {0}", Small);

            Tuple<int, int> t = GetCompareNumberForSmall(number1, number2, number3,Big);
            int Small2 = Smallest2(t.Item1, t.Item2);
            Console.WriteLine("Smallest2 number is {0}", Small2);
        }

        public static void InputNumber(ref int number1, ref int number2, ref int number3)
        {
            Console.WriteLine("Enter number 1");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter number 2");
            string str2 = Console.ReadLine();
            Console.WriteLine("Enter number 3");
            string str3 = Console.ReadLine();
            number1 = int.Parse(str1);
            number2 = int.Parse(str2);
            number3 = int.Parse(str3);
        }

        public static int Biggest(int number1, int number2, int number3)
        {
            if ((number1 > number2) && (number1 > number3)) 
            {
                return number1;
            }
            else if ((number2 > number1) && (number2 > number3)) 
            {
                return number2;
            }
            else
            {
                return number3;
            }
        }

        public static int Smallest(int number1, int number2, int number3)
        {
            if ((number3 < number1) && (number3 < number1)) 
            {
                return number3;
            }
            else if ((number2 < number1) && (number2 < number3)) 
            {
                return number2;
            }
            else
            {
                return number1;
            }
        }

        public static Tuple<int, int> GetCompareNumberForSmall(int number1, int number2, int number3, int Big)
        {
            int num1 = 0;
            int num2 = 0;

            if ((number1 != Big) && (number2 != Big))
            {
                num1 = number1;
                num2 = number2;
            }
            else
            {
                num1 = number1;
                num2 = number3;
            }

            Tuple<int, int> t = new Tuple<int, int>(num1, num2);
            return t;
        }

        public static int Smallest2(int num1, int num2)
        {
            if (num1 < num2)
            {
                return num1; 
            }
            else
            {
                return num2;
            }
        }
    }
}