using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Fractions Project.\n");

        // Testando frações com os três construtores
        Fraction f1 = new Fraction(); // 1/1
        DisplayFraction(f1);

        Fraction f2 = new Fraction(5); // 5/1
        DisplayFraction(f2);

        Fraction f3 = new Fraction(3, 4); // 3/4
        DisplayFraction(f3);

        Fraction f4 = new Fraction(1, 3); // 1/3
        DisplayFraction(f4);
    }

    // Método auxiliar para mostrar fração e valor decimal
    static void DisplayFraction(Fraction fraction)
    {
        Console.WriteLine(fraction.GetFractionString());
        Console.WriteLine(fraction.GetDecimalValue());
        Console.WriteLine(); // linha em branco para separar os testes
    }
}

public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor geral (1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constroctor with only numerator (n/1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constroctor with numerator and denominator (n/d)
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}
