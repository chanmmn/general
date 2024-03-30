using System;

public class LCMCalculator
{
    // Function to find the greatest common factor (GCF) using Euclid's Algorithm
    static int GCF(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    // Function to calculate the least common multiple (LCM)
    static int LCM(int a, int b)
    {
        // LCM = (a * b) / GCF(a, b)
        return (a / GCF(a, b)) * b;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Enter two numbers to find their LCM:");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());

        int result = LCM(num1, num2);
        Console.WriteLine($"LCM of {num1} and {num2} is {result}");

        Console.ReadLine();
    }
}
