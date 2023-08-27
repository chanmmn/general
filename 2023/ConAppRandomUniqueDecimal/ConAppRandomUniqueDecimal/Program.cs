namespace ConAppRandomUniqueDecimal
{
    internal class Program
    {
        private static List<decimal> lstDec = new List<decimal>();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Start!");
            GenDecimal();
            Console.WriteLine("Hello, End!");
        }

        public static void GenDecimal()
        {
            Random rnd = new Random();
            decimal rndNumber = 0;
            for (int j = 0; j < 10; j++)
            {
                rndNumber = new decimal(rnd.Next(30));
                //Console.WriteLine(rndNumber);//returns random integers < 10
                //rndNumber = Math.Truncate(rndNumber*100)/100;
                //Console.WriteLine(rndNumber);
                if (CheckUniqueDecimal(rndNumber) == -1)
                {
                    j--;
                }
                else
                {
                    string str = String.Format("{0:0.00}", rndNumber);
                    Console.WriteLine(str);
                }
            }
        }

        public static decimal CheckUniqueDecimal(decimal dec)
        {
            decimal rndNumber = 0;
            if (lstDec.Contains(dec))
            {
                return -1;
            }
            else
            {
                lstDec.Add(dec);
                return rndNumber;
            }
        }
    }
}