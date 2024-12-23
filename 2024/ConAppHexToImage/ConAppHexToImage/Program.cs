using System.Data;
using System.Drawing;

namespace ConAppHexToImage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            ReadBlobAndConvertToJpg();
        }

        public static void ReadBlobAndConvertToJpg()
        {
            string hexString = File.ReadAllText("HexImage.txt");

            string base64String = hexString.Substring(2); // Remove the "0x" prefix

            byte[] newByte = ToByteArray(base64String);
            MemoryStream memStream = new MemoryStream(newByte);
            Bitmap.FromStream(memStream).Save("img11Dec2024.jpg");
        }

        public static byte[] ToByteArray(string HexString)
        {
            //int NumberChars = HexString.Length-1;
            int NumberChars = HexString.Length;
            byte[] bytes = new byte[NumberChars / 2];

            for (int i = 0; i < NumberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(HexString.Substring(i, 2), 16);
            }
            return bytes;
        }
    }
}
