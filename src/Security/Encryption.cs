```csharp
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace src.Security
{
    public static class Encryption
    {
        private static readonly byte[] salt = Encoding.ASCII.GetBytes("Enter a random string here for salt");

        public static string Encrypt(string plainText, string password)
        {
            var algorithm = GetAlgorithm(password);

            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            using (ICryptoTransform encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV))
            {
                return Convert.ToBase64String(InMemoryCrypt(plainBytes, encryptor));
            }
        }

        public static string Decrypt(string encryptedText, string password)
        {
            var algorithm = GetAlgorithm(password);

            byte[] encryptedBytes = Convert.FromBase64String(encryptedText);

            using (ICryptoTransform decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV))
            {
                return Encoding.Unicode.GetString(InMemoryCrypt(encryptedBytes, decryptor));
            }
        }

        private static RijndaelManaged GetAlgorithm(string password)
        {
            var key = new Rfc2898DeriveBytes(password, salt);

            var algorithm = new RijndaelManaged();
            algorithm.Key = key.GetBytes(algorithm.KeySize / 8);
            algorithm.IV = key.GetBytes(algorithm.BlockSize / 8);

            return algorithm;
        }

        private static byte[] InMemoryCrypt(byte[] data, ICryptoTransform transform)
        {
            MemoryStream memory = new MemoryStream();
            using (Stream stream = new CryptoStream(memory, transform, CryptoStreamMode.Write))
            {
                stream.Write(data, 0, data.Length);
            }

            return memory.ToArray();
        }
    }
}
```