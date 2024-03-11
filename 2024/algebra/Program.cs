internal class Program
{
    private static void Main(string[] args)
    {
        decimal Price = 0;
        Console.WriteLine("Hello, Algebra");
        Price = CalculateCharge(20,4,7);
        Console.WriteLine(Price);
    }

    static decimal CalculateCharge(int BaseCharge, int PerItemCharge, int Window)
        {
            //const decimal BaseCharge = 20.0m;
            //const decimal PerItemCharge = 4.0m;

            decimal totalCharge = BaseCharge + (PerItemCharge * Window);
            return totalCharge;
        }
}