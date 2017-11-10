/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 *  Enterprise Manager is distributed under the GNU General Public License version 3 and  
 *  is also available under alternative licenses negotiated directly with Simon Carter.  
 *  If you obtained Enterprise Manager under the GPL, then the GPL applies to all loadable 
 *  Enterprise Manager modules used on your system as well. The GPL (version 3) is 
 *  available at https://opensource.org/licenses/GPL-3.0
 *
 *  This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY;
 *  without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 *  See the GNU General Public License for more details.
 *
 *  The Original Code was created by Simon Carter (s1cart3r@gmail.com)
 *
 *  Copyright (c) 2010 - 2017 Simon Carter.  All Rights Reserved.
 *
 *  Product:  Enterprise Manager
 *  
 *  File: StringCipher.cs
 *
 *  Purpose:  
 *
 *  Date        Name                Reason
 *  
 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Library.Utils
{
    /// <summary>
    /// Encrypt/Decrypt strings
    /// </summary>
    public static class StringCipher
    {
        // This constant string is used as a "salt" value for the PasswordDeriveBytes function calls.
        // This size of the IV (in bytes) must = (keysize / 8).  Default keysize is 256, so the IV must be
        // 32 bytes long.  Using a 16 character string here gives us 32 bytes when converted to a byte array.
        private const string initVector = "k4uf19G0S2hpo9wS";

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;

        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            try
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                try
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        try
                        {
                            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                            try
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();

                                return (Convert.ToBase64String(memoryStream.ToArray()));
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
                        encryptor.Dispose();
                        encryptor = null;
                    }
                }
                finally
                {
                    symmetricKey.Dispose();
                    symmetricKey = null;
                }
            }
            finally
            {
                password.Dispose();
                password = null;
            }
        }

        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            try
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                RijndaelManaged symmetricKey = new RijndaelManaged();
                try
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
                    try
                    {
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
                        decryptor.Dispose();
                        decryptor = null;
                    }
                }
                finally
                {
                    symmetricKey.Dispose();
                    symmetricKey = null;
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