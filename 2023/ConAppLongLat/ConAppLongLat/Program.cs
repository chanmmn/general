namespace ConAppLongLat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, start!");
            bool outside1km = Outside1km(2.7877, 101.7769, 2.7977, 101.7779);
            if (outside1km)
            {
                Console.WriteLine("The distance is more than 1 km");
            }
        }
        public static bool Outside1km(double latitude, double longitude, double lat, double lon)
        {
            bool in1km = false;
            double latAdd = latitude + 0.01;
            double longAdd = longitude + 0.001;
            double latDeduct = latitude - 0.01;
            double longDeduct = longitude - 0.001;

            if (lon > longitude)
            {
                if (lon > longAdd) { in1km = true; }
            }
            else
            {
                if (lon < longDeduct) { in1km = true; }
            }
            if (lat > latitude)
            {
                if (lat > latAdd) { in1km = true; }
            }
            else
            {
                if (lat < latDeduct) { in1km = true; }
            }
            return in1km;
        }
    }
}