using System;

class Program
{
    static void Main(string[] args)
    {
        // Display the title of the game when the program starts
        Console.WriteLine("::::::: Guess My Number Game Exercise3 Project ::::::");

        // Variable to control whether the user wants to play again
        string playAgain = "yes";

        // Outer loop: keeps running the game as long as the user types "yes"
        while (playAgain.ToLower() == "yes")
        {
            // Create a random number generator
            Random randomGenerator = new Random();

            // Generate a random number between 1 and 100 (inclusive)
            int number = randomGenerator.Next(1, 101);

            // Initialize guess variable with a value that is not equal to the number
            int guess = -1;

            // Counter to track how many guesses the user makes
            int guessCount = 0;

            // Inner loop: runs until the user guesses the correct number
            while (guess != number)
            {
                // Prompt the user to enter a guess
                Console.Write("What is the magic number? ");
                string input = Console.ReadLine();

                // Convert the user's input from string to integer
                guess = int.Parse(input);

                // Increase the guess counter each time the user makes a guess
                guessCount++;

                // Display the user's guess
                Console.WriteLine("What is your guess? " + guess);

                // Provide hints based on the guess
                if (guess < number)
                {
                    Console.WriteLine("Higher"); // Tell the user to guess higher
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower"); // Tell the user to guess lower
                }
            }

            // When the user guesses correctly, display the result
            Console.WriteLine("You guessed it! The magic number was " + number);

            // Inform the user how many guesses it took
            Console.WriteLine("It took you " + guessCount + " guesses.");

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        // End message when the user decides not to play again
        Console.WriteLine("");
        Console.WriteLine("::::::::::::Thanks for playing! Goodbye.::::::::::::::::");
    }
}