using System.IO;
using System;
using System.Security.Cryptography;

class Program
{
    static void Main()
    {
        SHA1 lHasher = SHA1.Create();
        string input;
        while (true)
        {
            input = Console.ReadLine();
            if (input == "") break;
            byte[] lHash = lHasher.ComputeHash(GetBytes(input));
            Console.WriteLine(BitConverter.ToString(lHash).Replace("-", "").ToLower());
        }
    }


    static byte[] GetBytes(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(char)];
        System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
        return bytes;
    }
}