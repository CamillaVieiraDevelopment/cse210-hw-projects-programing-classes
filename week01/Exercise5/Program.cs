using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise5 Project.");

        {
            static void DisplayMessage()
            {
                Console.WriteLine("Welcome to the Program!");
            }

            static void DisplayPersonalMessage(string userName)
            {
                Console.WriteLine("Please enter your favorite number: ");
            }

            static int SquareNumber(int favoriteNumber)
            {
                int squareNumber = favoriteNumber * favoriteNumber;
                return squareNumber;
            }

            static void DisplayResult(string userName, int favoriteNumber)
            {
                Console.WriteLine($"Dear {userName}, the square of your number is {favoriteNumber}");
            }

            {
                DisplayMessage();

                Console.Write("Enter your name: ");
                string userName = Console.ReadLine();

                DisplayPersonalMessage(userName);

                int favoriteNumber = int.Parse(Console.ReadLine());

                int result = SquareNumber(favoriteNumber);

                DisplayResult(userName, result);
            }
        }

    }
}
