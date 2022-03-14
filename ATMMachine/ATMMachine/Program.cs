using System;
using System.Collections.Generic;
using System.Text;

namespace ATMMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "ATM Machine";
            Console.ForegroundColor = ConsoleColor.White;
            Dictionary<int, BankCard> allCards = new Dictionary<int, BankCard>();

            Console.WriteLine("Hello user! Please enter your 4 digit pin!");
            string PIN = RequestPin();
            int incorrectPasswords = 0;
            while (true)
            {
                if (PIN.Length != 4)
                {
                    incorrectPasswords++;
                    if (incorrectPasswords == 3)
                    {
                        Console.WriteLine($"You failed your password 3 time! Try again later!");
                        break;
                    }
                    Console.WriteLine("Incorrect password format!!!");
                    Console.WriteLine("Enter your password!");
                    RequestPin();
                }
                else
                {
                    Random random = new Random();
                    StringBuilder cardNumAsSb = new StringBuilder();
                    for (int i = 0; i < 9; i++)
                    {
                        int currDigit = random.Next(9);
                        cardNumAsSb.Append(currDigit);
                    }
                    int cardNum = int.Parse(cardNumAsSb.ToString());
                    if (allCards.ContainsKey(cardNum))
                    {

                    }
                    else
                    {
                        Console.WriteLine($"Card N{cardNum} is not registered!");
                        Console.WriteLine($"Do you want to create a new account?");

                    }
                }
            }
        }
        private static string RequestPin()
        {
            StringBuilder sb = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
            } while (keyInfo.Key != ConsoleKey.Enter);
            {
                return sb.ToString();
            }
        }
    }
}
