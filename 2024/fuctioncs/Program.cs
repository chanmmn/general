using System;

namespace EquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Example usage: Solve 2b = 6
            double b = SolveEquation(2, 6);
            Console.WriteLine($"The value of b is: {b}");
        }

        static double SolveEquation(double coefficient, double constant)
        {
            // Solve for b: 2b = 6
            // Divide both sides by 2
            double b = constant / coefficient;
            return b;
        }
    }
}
