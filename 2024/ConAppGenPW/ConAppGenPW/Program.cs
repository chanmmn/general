using System.Text;

namespace ConAppGenPW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            List<string> passwords = GeneratePasswords(349, 6);
            foreach (var password in passwords)
            {
                Console.WriteLine(password);
            }
        }

        public static List<string> GeneratePasswords(int count, int length)
        {
            List<string> passwords = new List<string>();
            for (int i = 0; i < count; i++)
            {
                passwords.Add(GeneratePassword(length));
            }
            return passwords;
        }

        public static string GeneratePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}
