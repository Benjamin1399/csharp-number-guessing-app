using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            /* 
             Get difficultly level choice from user

            Based on difficultly, set number to be guessed and set number of tries

            let user know how many tries

            do
	            Get number from user
	            convert to int
            while less than tries
             */

            GuessingLibrary.WelcomeToGame();

            int difficultyLevel = GuessingLibrary.GetDifficultyChoice();

            if (difficultyLevel > 0)
            {
                var (range, numberOfTries, chosenNumber) = GuessingLibrary.SetupGame(difficultyLevel);
                if (range > 0 && numberOfTries > 0 && chosenNumber > 0)
                {
                    GuessingLibrary.PlayGame(range, numberOfTries, chosenNumber);
                }
            }
            else
            {
                Console.WriteLine("Invalid level selected");
            }

        }
    }
}
