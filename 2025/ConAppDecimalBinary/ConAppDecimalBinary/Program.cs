namespace ConAppDecimalBinary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            float decimalNumber = 43.23f
                ;
            string binaryNumber2 = DecimalToBinary(decimalNumber);
            Console.WriteLine($"Decimal: {decimalNumber}, Binary: {binaryNumber2}");
        }

        private static string DecimalToBinary(float decimalNumber)
        {
            int intPart = (int)decimalNumber;
            float floatPart = decimalNumber - intPart;
            string binaryIntPart = "";
            string binaryFloatPart = "";
            while (intPart > 0)
            {
                binaryIntPart = (intPart % 2) + binaryIntPart;
                intPart /= 2;
            }
            while (floatPart > 0)
            {
                floatPart *= 2;
                binaryFloatPart += (int)floatPart;
                floatPart -= (int)floatPart;
            }
            return binaryIntPart + "." + binaryFloatPart;
        }

    }
}
