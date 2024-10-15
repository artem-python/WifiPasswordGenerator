using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;

namespace WifiPasswordGenerator
{
    public static class PassGen
    {
        public static void GeneratePassword(string[] chars, byte length)
        {
            if (length <= 1) { return; }
            BigInteger resultLength = CalcPow(chars.Length, length);
            ulong[] numbers = new ulong[length];
            for (byte i = 0; i < numbers.Length; i++) { numbers[i] = 0; }
            for (BigInteger x = 0; x < resultLength; x++)
            {
                string result = "";
                for (byte y = 0; y < length; y++) { result += chars[numbers[y]]; }
                using (StreamWriter sw = new StreamWriter("test.txt", true)) { sw.WriteLine(result); }
                numbers[numbers.Length - 1]++;
                for (int y = numbers.Length - 1; y >= 0; y--)
                {
                    if (numbers[y] >= (ulong)chars.Length)
                    {
                        numbers[y] = 0;
                        if (y >= 1) { numbers[y - 1]++; }
                    }
                }
            }
        }
        public static BigInteger CalcPow(int a, byte b)
        {
            BigInteger result = 1;
            for (int i = 0; i < b; i++) { result *= (ulong)a; }
            return result;
        }
    }
}
