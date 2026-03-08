using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("::::::: Hello World! This is the Exercise2 Project.::::::");
        Console.WriteLine("");
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradeNum = int.Parse(grade);

        string letterGrade = "";
        string sign = "";

        // Determine the letter grade
        if (gradeNum >= 90)
        {
            letterGrade = "A";
        }
        else if (gradeNum >= 80)
        {
            letterGrade = "B";
        }
        else if (gradeNum >= 70)
        {
            letterGrade = "C";
        }
        else if (gradeNum >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        // Determine the sign (+ or -)
        int lastDigit = gradeNum % 10;

        if (letterGrade != "F") // F never has + or -
        {
            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }
        }

        // Special case: No A+
        if (letterGrade == "A" && sign == "+")
        {
            sign = ""; // Remove the plus
        }

        Console.WriteLine($"Your letter grade is: {letterGrade}{sign}");

        if (gradeNum >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class!");
        }
        else
        {
            Console.WriteLine("Sorry, you did not pass the class. Better luck next time!");
        }
        Console.WriteLine("");
        Console.WriteLine("::::::: Successful Exercise2 Project.::::::");
    }
}