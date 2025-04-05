using System.Net;

namespace ConsoleLinuxFTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            TransferFileToFTP("HelloFtp.txt");
        }

        static void TransferFileToFTP(string filePath)
        {
            string ftpServer = "ftp://172.23.143.141";
            string username = "user1";
            string password = "password";
            string ftpFilePath = $"{ftpServer}/{Path.GetFileName(filePath)}";
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpFilePath);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            byte[] fileContents;
            using (StreamReader sourceStream = new StreamReader(filePath))
            {
                fileContents = System.Text.Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }
            request.ContentLength = fileContents.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }
    }
}
