using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(":::::: This is Functions and Methods for Exercise5 Project. :::::::");

        // Call the helper methods in sequence
        DisplayWelcome();

        string name = PromptUserName();

        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        int squared = SquareNumber(number);

        DisplayResult(name, squared);
    }

    // Method to display a welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }

    // Method to prompt the user for their name and return it
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    // Method to square a number and return the result
    static int SquareNumber(int number)
    {
        int squared = number * number;
        Console.WriteLine("The square of the number is: " + squared);
        return squared;
    }

    // Method to display the final result
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine("Hello, " + name + "! the square of your number is " + square);
        Console.WriteLine("");
        Console.WriteLine(":::::::::: Thank you for using the program. Goodbye!::::::::::");
    }
}