using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("::::::: Guess My Number Game Exercise3 Project ::::::");

        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            Random randomGenerator = new Random();
            int number = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;

            while (guess != number)
            {
                Console.Write("What is the magic number? ");
                string input = Console.ReadLine();
                guess = int.Parse(input);
                guessCount++;

                Console.WriteLine("What is your guess? " + guess);

                if (guess < number)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > number)
                {
                    Console.WriteLine("Lower");
                }
            }

            Console.WriteLine("You guessed it! The magic number was " + number);
            Console.WriteLine("It took you " + guessCount + " guesses.");

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine();
        }

        Console.WriteLine("");
        Console.WriteLine("::::::::Thanks for playing! Goodbye.:::::::::::");
    }
}