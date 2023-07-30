using Accord.Statistics.Testing;

namespace ConAppOneSampleTTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, start!");

            // Consider a sample generated from a Gaussian
            // distribution with mean 0.5 and unit variance.

            double[] sample =
            {
    -0.849886940156521,    3.53492346633185,  1.22540422494611, 0.436945126810344, 1.21474290382610,
     0.295033941700225, 0.375855651783688, 1.98969760778547, 1.90903448980048,    1.91719241342961
};

            // One may rise the hypothesis that the mean of the sample is not
            // significantly different from zero. In other words, the fact that
            // this particular sample has mean 0.5 may be attributed to chance.

            double hypothesizedMean = 0;

            // Create a T-Test to check this hypothesis
            TTest test = new TTest(sample, hypothesizedMean,
                   OneSampleHypothesis.ValueIsDifferentFromHypothesis);

            // Check if the mean is significantly different test.Significant should be true

// Now, we would like to test if the sample mean is
// significantly greater than the hypothesized zero.

            // Create a T-Test to check this hypothesis
TTest greater = new TTest(sample, hypothesizedMean,
       OneSampleHypothesis.ValueIsGreaterThanHypothesis);
            Console.WriteLine("Greater {0}", greater);

            // Check if the mean is significantly larger greater.Significant should be true

// Now, we would like to test if the sample mean is
// significantly smaller than the hypothesized zero.

            // Create a T-Test to check this hypothesis
TTest smaller = new TTest(sample, hypothesizedMean,
       OneSampleHypothesis.ValueIsSmallerThanHypothesis);
            Console.WriteLine("Smaller {0}",smaller);
            // Check if the mean is significantly smaller smaller.Significant should be false
            Console.WriteLine("Hello, end!");
        }
    }
}