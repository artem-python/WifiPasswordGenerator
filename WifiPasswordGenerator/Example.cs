using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Threading.Tasks;

namespace WifiPasswordGenerator
{
    public class Example
    {
        const byte minLength = 8;
        const byte maxLength = 63;
        static readonly string[] chars = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "+", "-", "*", "/", "`", "~", "_", "=", "!", "@", "#", "$", "%", "^", "&", "(", ")", ".", ",", "<", ">", "?", "'", '"'.ToString(), "[", "]", "{", "}", ":", ";", "q", "Q", "w", "W", "e", "E", "r", "R", "t", "T", "y", "Y", "u", "U", "i", "I", "o", "O", "p", "P", "a", "A", "s", "S", "d", "D", "f", "F", "g", "G", "h", "H", "j", "J", "k", "K", "l", "L", "z", "Z", "x", "X", "c", "C", "v", "V", "b", "B", "n", "N", "m", "M", "й", "Й", "ц", "Ц", "у", "У", "к", "К", "е", "Е", "н", "Н", "г", "Г", "ш", "Ш", "щ", "Щ", "з", "З", "х", "Х", "ъ", "Ъ", "ф", "Ф", "ы", "Ы", "в", "В", "а", "А", "п", "П", "р", "Р", "о", "О", "л", "Л", "д", "Д", "ж", "Ж", "э", "Э", "я", "Я", "ч", "Ч", "с", "С", "м", "М", "и", "И", "т", "Т", "ь", "Ь", "б", "Б", "ю", "Ю" };

        static void Main()
        {
            List<Task> tasks = new List<Task>();
            if (!Directory.Exists("passes")) { Directory.CreateDirectory("passes"); }
            Console.WriteLine($"Total pass files count: {maxLength - minLength + 1}");
            for (byte i = minLength; i <= maxLength; i++)
            {
                byte cache = i;
                Task task = new Task(() => { Work(cache); }, TaskCreationOptions.AttachedToParent);
                tasks.Add(task);
            }
            foreach (Task task in tasks) { task.Start(); }
            Task.WaitAll(tasks.ToArray());
            Console.ReadKey(false);
        }

        static void Work(byte i)
        {
            Console.WriteLine($"Start {i} => {BigInteger.Pow(chars.Length, i)}");
            PassGen.GeneratePassword(chars, i, (pass) =>
            { using (StreamWriter sw = new StreamWriter($"passes/pass_{i}.txt", true)) { sw.WriteLine(pass); } });
            Console.WriteLine($"{i} is done");
        }
    }
}
