namespace ConAppVariance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = { 85, 90, 78, 92, 88 };
            Console.WriteLine("Population Variance: " + CalculatePopulationVariance(numbers));
            Console.WriteLine("Sample Variance: " + CalculateSampleVariance(numbers));
        }

        static double CalculatePopulationVariance(double[] numbers)
        {
            double mean = numbers.Average();
            double variance = numbers.Average(v => Math.Pow(v - mean, 2));
            return variance;
        }
        static double CalculateSampleVariance(double[] numbers)
        {
            double mean = numbers.Average();
            double variance = numbers.Sum(v => Math.Pow(v - mean, 2)) / (numbers.Length - 1);
            return variance;
        }
    }
}
