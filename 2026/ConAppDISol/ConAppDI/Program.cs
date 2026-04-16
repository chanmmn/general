namespace ConAppNoDI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            IGameLoader gameLoader = new GameLoader("God of War");
            PlaystationConsole playstationConsole = new PlaystationConsole(gameLoader);
            playstationConsole.Play();
        }
    }
}
