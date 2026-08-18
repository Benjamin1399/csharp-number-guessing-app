using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public static class GuessingLibrary
    {
        public static void WelcomeToGame()
        {
            Console.WriteLine("Welcome to the Number Guessing Game!");
            Console.WriteLine("====================================");
        }

        public static string GetUserInput()
        {
            string input = Console.ReadLine();

            if (String.IsNullOrEmpty(input) == true)
            {
                return "";
            }
            else
            {
                return input;
            }
        }
        public static int GetDifficultyChoice()
        {
            Console.WriteLine("Enter difficulty choice (1-easy, 2-normal 3-difficult): ");
            string difficulty = GetUserInput();

            if (String.IsNullOrEmpty(difficulty) == false)
            {
                if (int.TryParse(difficulty, out int choice) == true)
                {
                    return choice;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        public static (int range, int numberOfTries, int chosenNumber) SetupGame(int choice)
        {
            Random random = new Random();
            if (choice > 0)
            {
                switch (choice)
                {
                    case 1:
                        return (10, 5, random.Next(10));
                    case 2:
                        return (100, 3, random.Next(100));
                    case 3:
                        return (1000, 2, random.Next(1000));
                    default:
                        return (-1, -1, -1);
                }
            }
            else
            {
                return (-1, -1, -1);
            }
        }

        public static int GetGuess(int range, int numberOfTries)
        {
            Console.WriteLine($"Enter a number between {0} and {range} ({numberOfTries} tries remaining)");
            string guess = GetUserInput();

            if (int.TryParse(guess, out int number) == true)
            {
                return number;
            }
            else
            {
                return -1;
            }
        }

        public static string GetVarianceMessage(int guess, int chosenNumber)
        {
            if (guess > chosenNumber)
            {
                return "Too High";
            }
            else
            {
                return "Too Low";
            }
        }

        public static void PlayGame(int range, int numberOfTries, int chosenNumber)
        {
            do
            {
                int guess = GetGuess(range, numberOfTries);

                if (guess == chosenNumber)
                {
                    Console.WriteLine("You won!!!");
                    break;
                }
                else
                {
                    string varianceMessage = GetVarianceMessage(guess, chosenNumber);
                    Console.WriteLine($"Your guess is {varianceMessage}");
                    numberOfTries--;
                }

                Console.WriteLine(); // line break;

            } while (numberOfTries != 0);

            if (numberOfTries == 0)
            {
                Console.WriteLine($"The number chosen was {chosenNumber}");
            }
        }
    }
}
