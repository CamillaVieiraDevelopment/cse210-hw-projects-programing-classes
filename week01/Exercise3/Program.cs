using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise3 Project.");
    Console.WriteLine("What is the magic number? ");
int magic_number = int.Parse(Console.ReadLine());


int guess = -1;


while (guess != magic_number)

{
Console.WriteLine("What is your guess? ");
guess = int.Parse(Console.ReadLine());

if (guess == magic_number)
{
    Console.WriteLine("You guessed it!");
}
else if (guess  > magic_number)
{
    Console.WriteLine("The magic number is lower");
}
else
    Console.WriteLine("The magic number is higher");
}
}
}
