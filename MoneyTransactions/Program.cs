using System;
using System.Collections.Generic;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries);

            Dictionary<int, double> bankAccounts = new Dictionary<int, double>();

            FillDictionary(input, bankAccounts);

            string[] commandTokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            while (commandTokens[0] != "End")
            {
                int accountNumber = int.Parse(commandTokens[1]);

                double sum = double.Parse(commandTokens[2]);

                try
                {
                    switch (commandTokens[0])
                    {
                        case "Deposit":
                            bankAccounts[accountNumber] += sum;
                            break;

                        case "Withdraw":
                            double suntractedBalance = bankAccounts[accountNumber] - sum;

                            if (suntractedBalance < 0)
                                throw new ArgumentException("Insufficient balance!");

                            bankAccounts[accountNumber] -= sum;
                            break;

                        default:
                            throw new ArgumentException("Invalid command!");
                    }

                    Console.WriteLine($"Account {accountNumber} has new balance: {bankAccounts[accountNumber]:f2}");
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                commandTokens = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries);
            }
        }

        private static void FillDictionary(string[] input, Dictionary<int, double> bankAccounts)
        {
            foreach (string bankAccount in input)
            {
                string[] bankAccountInfo = bankAccount.Split('-', StringSplitOptions.RemoveEmptyEntries);

                int accountNumber = int.Parse(bankAccountInfo[0]);

                double accountBalance = double.Parse(bankAccountInfo[1]);

                bankAccounts.Add(accountNumber, accountBalance);
            }
        }
    }
}
