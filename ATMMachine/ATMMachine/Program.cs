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
            Console.WriteLine();
            int incorrectPasswords = 0;
            while (true)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
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
                    Console.WriteLine();
                }
                else
                {
                    //Random random = new Random();
                    //StringBuilder cardNumAsSb = new StringBuilder();
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    int currDigit = random.Next(9);
                    //    cardNumAsSb.Append(currDigit);
                    //}
                    //int cardNum = int.Parse(cardNumAsSb.ToString());
                    Console.WriteLine($"Please enter your card Number");
                    int cardNum = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please enter your password!");
                    PIN = RequestPin();
                    Console.WriteLine();
                    if (allCards.ContainsKey(cardNum))
                    {
                        BankCard currCard = allCards[cardNum];
                        if (currCard.PIN == PIN)
                        {

                            Console.WriteLine($"Hello {currCard.OwnerFirstName} {currCard.OwnerLastName}!");
                            Console.WriteLine("Please select the service you want:");
                            Console.WriteLine("1. Current Balance");
                            Console.WriteLine("2. Withdraw");
                            Console.WriteLine("3. Deposit");
                            Console.WriteLine("4. Return my card");
                            string givenCmd = Console.ReadLine();
                            if (IsGivenCommandValid(givenCmd))
                            {
                                int action = int.Parse(givenCmd);
                                if (action == 1)
                                {
                                    Console.WriteLine($"Your current balance is: {currCard.CurrentBalance}");
                                }
                                else if (action == 2)
                                {
                                    Console.WriteLine($"Please enter the amount you want to withdraw!");
                                    int amountToWithdraw = int.Parse(Console.ReadLine());
                                    if (amountToWithdraw > currCard.CurrentBalance)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Not enought money!");
                                    }
                                    else
                                    {
                                        currCard.CurrentBalance -= amountToWithdraw;
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine($"You withdrew the amount of BGN {amountToWithdraw}");
                                        Console.WriteLine($"Your current balance is {currCard.CurrentBalance:F2} BGN");
                                        Console.WriteLine($"Have a nice day!");
                                        continue;
                                    }
                                }
                                else if (action == 3)
                                {
                                    Console.WriteLine($"Please enter the amount you want to deposit!");
                                    int amount = int.Parse(Console.ReadLine());
                                    currCard.CurrentBalance += amount;
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine($"You have successfully deposited the amount of {amount} BGN");
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Incorrect password!");
                            Console.WriteLine("Enter your password again!");
                            PIN = RequestPin();
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Card No.{cardNum} is not registered!");
                        Console.WriteLine($"Do you want to create a new account?");
                        Console.WriteLine("Choose 1 for \"Yes\" and 2 for \"No\"");
                        string cmdOptionAsString = Console.ReadLine();
                        if (cmdOptionAsString == "1" || cmdOptionAsString == "2")
                        {
                            int cmdOptions = int.Parse(cmdOptionAsString);
                            if (cmdOptions == 1)
                            {
                                Console.WriteLine($"Please enter your first and last name, splited by \"space\"!");
                                string[] fullName = Console.ReadLine().Split();
                                string ownerFirstName = fullName[0];
                                string ownerLastName = fullName[1];
                                BankCard currCard = new BankCard(cardNum, ownerFirstName, ownerLastName, PIN);
                                allCards.Add(cardNum, currCard);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine($"Account No.{cardNum} was created successfully!\n");
                            }
                            else
                            {
                                Console.WriteLine("Have a nice day!");
                                break;
                            }
                        }
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
        private static bool IsGivenCommandValid(string givenCmd)
        {
            return givenCmd == "1" || givenCmd == "2" || givenCmd == "3" || givenCmd == "4";
        }
    }
}
