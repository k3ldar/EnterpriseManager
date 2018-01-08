using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SieraDelta.Website.Members.Licence
{

    /// <summary>
    /// Encrypt/Decrypt strings
    /// </summary>
    internal static class StringCipher
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "l4uf17G0S5hpo9tS";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        /// <summary>
        /// Second password for passing data to/from website
        /// </summary>
        internal static string _webPassword = "ID8Jjduyd7JDIE9EKDJi93k993k8887jak-933784-plndhcuyRT";

        internal static string _licPassword = "Every cLoud Has a Silver lIgning - EventuaLLY";

        internal static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            try
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                try
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                    try
                    {
                        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                        cryptoStream.FlushFinalBlock();
                        byte[] cipherTextBytes = memoryStream.ToArray();
                        return Convert.ToBase64String(cipherTextBytes);
                    }
                    finally
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                        cryptoStream = null;
                    }
                }
                finally
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                    memoryStream = null;
                }
            }
            finally
            {
                password.Dispose();
                password = null;
            }
            
        }

        internal static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            try
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                symmetricKey.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
                try
                {
                    CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
                    try
                    {
                        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                        
                        return (Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount));
                    }
                    finally
                    {
                        cryptoStream.Close();
                        cryptoStream.Dispose();
                        cryptoStream = null;
                    }
                }
                finally
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                    memoryStream = null;
                }
            }
            finally
            {
                password.Dispose();
                password = null;
            }
        }
    }
}