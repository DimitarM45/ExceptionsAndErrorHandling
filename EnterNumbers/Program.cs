using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace EnterNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> validNumbers = new List<int>();

            int start = 1;

            const int END = 100;

            while (validNumbers.Count < 10)
            {
                try
                {
                    int validNumber = ReadNumber(start, END);

                    start = validNumber;

                    validNumbers.Add(validNumber);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(", ", validNumbers));
        }

        static int ReadNumber(int start, int end)
        {
            int number;

            try
            {
                number = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                throw new FormatException("Invalid Number!");
            }

            if (number <= start || number >= end)
                throw new ArgumentException($"Your number is not in range {start} - {end}!");

            return number;
        }
    }
}
