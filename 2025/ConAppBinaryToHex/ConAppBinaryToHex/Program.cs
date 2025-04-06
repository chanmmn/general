namespace ConAppBinaryToHex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a binary number with optional decimal point:");
            string binaryInput = Console.ReadLine();
            string hexOutput = BinaryToHex(binaryInput);
            Console.WriteLine($"Hexadecimal: {hexOutput}");
        }

        static string BinaryToHex(string binary)
        {
            if (string.IsNullOrEmpty(binary))
                return string.Empty;
            string[] parts = binary.Split('.');
            string integerPart = parts[0];
            string fractionalPart = parts.Length > 1 ? parts[1] : string.Empty;
            string hexIntegerPart = Convert.ToInt64(integerPart, 2).ToString("X");
            string hexFractionalPart = string.Empty;
            if (!string.IsNullOrEmpty(fractionalPart))
            {
                double fractionalValue = 0;
                for (int i = 0; i < fractionalPart.Length; i++)
                {
                    if (fractionalPart[i] == '1')
                    {
                        fractionalValue += Math.Pow(2, -(i + 1));
                    }
                }
                hexFractionalPart = ConvertFractionToHex(fractionalValue);
            }
            return string.IsNullOrEmpty(hexFractionalPart) ? hexIntegerPart : $"{hexIntegerPart}.{hexFractionalPart}";
        }
        static string ConvertFractionToHex(double fraction)
        {
            string hex = string.Empty;
            while (fraction > 0)
            {
                fraction *= 16;
                int digit = (int)fraction;
                hex += digit.ToString("X");
                fraction -= digit;
            }
            return hex;
        }
    }
}
