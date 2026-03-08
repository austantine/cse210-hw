using System;
using System.Collections.Generic;
using System.Linq; // Needed for helpful list operations like Min, Max, and Average

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(":::::: This is Learning about LIST Exercise4 Project ::::::");

        // Create a list to store the numbers entered by the user
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished: ");

        // Input loop: keep asking for numbers until the user enters 0
        while (true)
        {
            string input = Console.ReadLine();
            int number = int.Parse(input);

            if (number == 0)
            {
                // Stop when user enters 0 (do not add 0 to the list)
                break;
            }

            // Add the entered number to the list
            numbers.Add(number);
        }

        // Display the numbers entered
        Console.WriteLine("The numbers you entered are: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // Compute the sum of the numbers
        int sum = numbers.Sum();
        Console.WriteLine("The sum is: " + sum);

        // Compute the average of the numbers
        double average = numbers.Average();
        Console.WriteLine("The average is: " + average);

        // Find the maximum number
        int max = numbers.Max();
        Console.WriteLine("The largest number is: " + max);

        // Find the smallest positive number (closest to zero but > 0)
        int smallestPositive = numbers.Where(n => n > 0).Min();
        Console.WriteLine("The smallest positive number is: " + smallestPositive);

        // Sort the list
        numbers.Sort();
        Console.WriteLine("The sorted list is: ");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
        Console.WriteLine(" ");
        Console.WriteLine(":::::::::Thank you for using the program. Goodbye!::::::::");
    }
}