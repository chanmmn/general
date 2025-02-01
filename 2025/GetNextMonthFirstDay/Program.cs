internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(ChangeFormat());
    }

       private static string ChangeFormat()
    {
        DateTime FirstDayNextMonth = GetFirstDayOfNextMonth();
        Console.WriteLine("Last day of last month is: " + FirstDayNextMonth.ToString("yyyy-MM-dd HH:mm:ss"));
        return FirstDayNextMonth.ToString("yyyy-MM-dd HH:mm:ss");
    }

    private static DateTime GetFirstDayOfNextMonth()
    {
        DateTime today = DateTime.Today;
        DateTime firstDayOfNextMonth = new DateTime(today.Year, today.Month, 1).AddMonths(1);
        return firstDayOfNextMonth;
    }

}