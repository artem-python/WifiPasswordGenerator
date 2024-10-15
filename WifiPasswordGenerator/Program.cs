using System;
using System.IO;

namespace WifiPasswordGenerator
{
    public class Program
    {
        const byte minLength = 8;
        const byte maxLength = 63;
        static string[] chars = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "`", "~", "_", "=", "!", "@", "#", "$", "%", "^", "&", "(", ")", ".", ",", "<", ">", "?", "'", '"'.ToString(), "[", "]", "{", "}", ":", ";", "q", "Q", "w", "W", "e", "E", "r", "R", "t", "T", "y", "Y", "u", "U", "i", "I", "o", "O", "p", "P", "a", "A", "s", "S", "d", "D", "f", "F", "g", "G", "h", "H", "j", "J", "k", "K", "l", "L", "z", "Z", "x", "X", "c", "C", "v", "V", "b", "B", "n", "N", "m", "M", "й", "Й", "ц", "Ц", "у", "У", "к", "К", "е", "Е", "н", "Н", "г", "Г", "ш", "Ш", "щ", "Щ", "з", "З", "х", "Х", "ъ", "Ъ", "ф", "Ф", "ы", "Ы", "в", "В", "а", "А", "п", "П", "р", "Р", "о", "О", "л", "Л", "д", "Д", "ж", "Ж", "э", "Э", "я", "Я", "ч", "Ч", "с", "С", "м", "М", "и", "И", "т", "Т", "ь", "Ь", "б", "Б", "ю", "Ю" };
        static void Main()
        {
            if (File.Exists("test.txt")) { File.Delete("test.txt"); }
            for (byte i = minLength; i <= maxLength; i++)
            {
                Console.WriteLine($"{i} => {PassGen.CalcPow(chars.Length, i)}");
                PassGen.GeneratePassword(chars, i);
            }
            Console.WriteLine("Done");
            Console.ReadKey(false);
        }
    }
}
