using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise2 Project.");

        Console.WriteLine("What is your grade percentage?");
        string grade = Console.ReadLine();
        int percent = int.Parse(grade);

        Console.WriteLine($"Your grade is: {percent}");

        if (percent >= 90)
        {
            Console.WriteLine("Your grade is A! Congratulations! You are approved!");
        }
        else if (percent >= 80)
        {
            Console.WriteLine("Your grade is B!Congratulations! You are approved!");
        }
        else if (percent >= 70)
        {
            Console.WriteLine("Your grade is C!Congratulations! You are approved!");
        }
        else if (percent >= 60)
        {
            Console.WriteLine("Your grade is D! Oh, so sorry! You are disapproved!");
        }
        else
        {
            Console.WriteLine("Oh, so sorry, your grade is F! You are disapproved!");

        }
    }
}