namespace ConAppExtractDateofMonth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dates = GetBeingAndEndDateOfTheMonth();
            Console.WriteLine($"Start Date: {dates.Item1}");
            Console.WriteLine($"End Date: {dates.Item2}");
        }

        public static Tuple<string, string> GetBeingAndEndDateOfTheMonth()
        {
            DateTime today = DateTime.Today;
            DateTime startDate = new DateTime(today.Year, today.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            return Tuple.Create(startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd"));
        }
    }
}
