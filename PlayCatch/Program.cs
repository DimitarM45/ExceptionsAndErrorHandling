using System;
using System.Linq;

namespace PlayCatch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] integers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int exceptionCount = 0;

            IndexOutOfRangeException indexOutOfRangeException = new IndexOutOfRangeException("The index does not exist!");
            FormatException formatException = new FormatException("The variable is not in the correct format!");

            while (true)
            {
                if (exceptionCount == 3)
                    break;

                string[] commandTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string command = commandTokens[0];

                int index;

                try
                {
                    switch (command)
                    {
                        case "Replace":
                            index = int.Parse(commandTokens[1]);
                            int element = int.Parse(commandTokens[2]);

                            Replace(integers, index, element);
                            break;

                        case "Print":
                            int startIndex = int.Parse(commandTokens[1]);
                            int endIndex = int.Parse(commandTokens[2]);

                            Print(integers, startIndex, endIndex);
                            break;

                        case "Show":
                            index = int.Parse(commandTokens[1]);

                            Show(integers, index);
                            break;
                    }
                }
                catch (FormatException)
                {
                    exceptionCount++;

                    Console.WriteLine(formatException.Message);
                }
                catch (IndexOutOfRangeException)
                {
                    exceptionCount++;

                    Console.WriteLine(indexOutOfRangeException.Message);
                }
            }

            Console.WriteLine(string.Join(", ", integers));
        }

        static void Replace(int[] integers, int index, int element) => integers[index] = element;

        static void Print(int[] integers, int startIndex, int endIndex)
        {
            int[] numbers = new int[endIndex - startIndex + 1];

            for (int i = startIndex, j = 0; i <= endIndex; i++, j++)
                numbers[j] = integers[i];

            Console.WriteLine(string.Join(", ", numbers));
        }

        static void Show(int[] integers, int index) => Console.WriteLine(integers[index]);
    }
}
