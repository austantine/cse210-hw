using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("::::::: Hello World! This is the Exercise1 Project.::::::");

        Console.Write("What is your firsts name? ");
        string fname = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lname = Console.ReadLine();
        Console.WriteLine(" ");
        Console.WriteLine($"Your name is {lname}, {fname} {lname}.");
        Console.WriteLine(" ");

        Console.WriteLine("::::::: Successful Exercise1 Project.::::::");
    }
}