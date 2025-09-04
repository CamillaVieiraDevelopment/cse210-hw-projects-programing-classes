using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Exercise4 Project.");


        List<int> numbers = new List<int>();
        int userNumber = -1;

        Console.WriteLine("Enter a list of numbers. Type 0 when finished.");

        // Loop para coletar números até o usuário digitar 0
        while (userNumber != 0)
        {
            Console.Write("Number: ");
            string userResponse = Console.ReadLine();

            // Tenta converter a entrada para inteiro
            if (!int.TryParse(userResponse, out userNumber))
            {
                Console.WriteLine("Please enter a valid integer.");
                continue;
            }

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Verifica se houve números digitados
        if (numbers.Count > 0)
        {
            // Soma
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            Console.WriteLine($"The sum is: {sum}");

            // Média
            double average = (double)sum / numbers.Count;
            Console.WriteLine($"The average is: {average}");

            // Máximo
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            Console.WriteLine($"The max is: {max}");
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}
