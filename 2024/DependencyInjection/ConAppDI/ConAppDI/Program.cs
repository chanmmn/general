namespace ConAppNoDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            PlaystationConsole playstationConsole = new PlaystationConsole(new GameLoader("God of War"));
            playstationConsole.Play();
        }
    }
}
