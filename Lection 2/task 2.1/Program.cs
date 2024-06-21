using System;

namespace task_2._1;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text:");

        string InputEnocde = Convert.ToString(Console.ReadLine());
        byte[] InputBytesEnocde = System.Text.Encoding.UTF8.GetBytes(InputEnocde);
        byte[] HashBytesEnocde = SHA2.GetHash(InputBytesEnocde);
        string HashStringEnocde = BitConverter.ToString(HashBytesEnocde).Replace("-", "").ToLower();

        Console.WriteLine($"Entered text: {InputEnocde}\nHash code: {HashStringEnocde}");
    }
}