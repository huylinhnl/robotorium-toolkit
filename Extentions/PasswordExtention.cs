using System.Security.Cryptography;
using System.Text;

namespace RoboToolkit.Extentions;

public static class PasswordExtention
{
    public static string Encrypt(this string text, string password)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(text);

        byte[] salt = new byte[8];
        new Random().NextBytes(salt);

        FindKeyAndIV(salt, password, out byte[] key, out byte[] iv);

        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] resultBytes = des.CreateEncryptor(key, iv).TransformFinalBlock(textBytes, 0, textBytes.Length);

        byte[] encryptedBytes = new byte[resultBytes.Length + salt.Length];
        Array.Copy(salt, encryptedBytes, salt.Length);
        Array.Copy(resultBytes, 0, encryptedBytes, salt.Length, resultBytes.Length);

        return Convert.ToBase64String(encryptedBytes);
    }

    public static string Decrypt(this string text, string password)
    {
        byte[] textBytes = Convert.FromBase64String(text);

        byte[] salt = new byte[8];
        byte[] encryptedBytes = new byte[textBytes.Length - salt.Length];
        Array.Copy(textBytes, salt, salt.Length);
        Array.Copy(textBytes, salt.Length, encryptedBytes, 0, encryptedBytes.Length);

        FindKeyAndIV(salt, password, out byte[] key, out byte[] iv);

        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] decryptedBytes = des.CreateDecryptor(key, iv).TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);

        return Encoding.UTF8.GetString(decryptedBytes);
    }

    private static void FindKeyAndIV(byte[] salt, string password, out byte[] key, out byte[] iv)
    {
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = new byte[passwordBytes.Length + salt.Length];
        Array.Copy(passwordBytes, hash, passwordBytes.Length);
        Array.Copy(salt, 0, hash, passwordBytes.Length, salt.Length);

        MD5 md5 = new MD5CryptoServiceProvider();

        //md5 iterations: 1000
        for (int i = 0; i < 1000; i++)
        {
            hash = md5.ComputeHash(hash);
        }

        key = new byte[8];
        iv = new byte[8];
        Array.Copy(hash, 0, key, 0, 8);
        Array.Copy(hash, 8, iv, 0, 8);
    }

}
