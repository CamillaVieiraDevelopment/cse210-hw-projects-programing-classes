using System;
using Homework; // Importa o namespace onde estão Assignment, MathAssignment e WritingAssignment

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! This is the Homework Project.");
            Console.WriteLine();

            // Objeto da classe base
            Assignment a1 = new Assignment("Samuel Bennett", "Multiplication");
            Console.WriteLine(a1.GetSummary());
            Console.WriteLine();

            // Objeto da classe derivada MathAssignment
            MathAssignment m1 = new MathAssignment("Roberto Rodriguez", "Fractions", "7.3", "8-19");
            Console.WriteLine(m1.GetSummary());     // herdado
            Console.WriteLine(m1.GetHomeworkList()); // exclusivo
            Console.WriteLine();

            // Objeto da classe derivada WritingAssignment
            WritingAssignment w1 = new WritingAssignment("Mary Waters", "European History", "The Causes of World War II");
            Console.WriteLine(w1.GetSummary());            // herdado
            Console.WriteLine(w1.GetWritingInformation()); // exclusivo
        }
    }
}
