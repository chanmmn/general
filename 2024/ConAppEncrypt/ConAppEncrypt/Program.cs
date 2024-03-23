using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class StringEncryptionService
{
    private readonly string _encryptionKey; // Replace with your secret key
    //static byte[] key = new byte[16] { 3, 3, 3, 5, 222, 13, 155, 55, 122, 123, 165, 187, 188, 1, 11, 133 };
    public StringEncryptionService(string encryptionKey)
    {
        _encryptionKey = encryptionKey;
    }

    public string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);
            
            //aesAlg.Key = key;

            //aesAlg.Key = Convert.FromBase64String(_encryptionKey);
            aesAlg.IV = new byte[16]; // Initialization Vector (IV) for AES

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            MemoryStream msEncrypt = new MemoryStream();

            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                csEncrypt.Write(plainTextBytes, 0, plainTextBytes.Length);
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }
    }

    public string Decrypt(string encryptedText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);

            //aesAlg.Key = key;
            aesAlg.IV = new byte[16];

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string secretKey = "1234567890123456"; // Replace with your actual secret key

        StringEncryptionService encryptionService = new StringEncryptionService(secretKey);

        string originalText = "Hello, this is a secret message!";
        string encryptedText = encryptionService.Encrypt(originalText);
        string decryptedText = encryptionService.Decrypt(encryptedText);

        Console.WriteLine($"Original Text: {originalText}");
        Console.WriteLine($"Encrypted Text: {encryptedText}");
        Console.WriteLine($"Decrypted Text: {decryptedText}");
    }
}
