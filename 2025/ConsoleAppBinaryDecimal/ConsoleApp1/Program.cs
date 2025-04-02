namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string binaryNumber = "110";
            double decimalNumber = BinaryToDecimal(binaryNumber);
            Console.WriteLine($"Binary: {binaryNumber}, Decimal: {decimalNumber}");
        }
        static double BinaryToDecimal(string binary)
        {
            string[] parts = binary.Split('.');
            int integerPart = Convert.ToInt32(parts[0], 2);
            double fractionalPart = 0;
            if (parts.Length > 1)
            {
                for (int i = 0; i < parts[1].Length; i++)
                {
                    if (parts[1][i] == '1')
                    {
                        fractionalPart += 1.0 / (1 << (i + 1));
                    }
                }
            }
            return integerPart + fractionalPart;
        }
    }
}
