/// Cycling Activity
public class Cycling : Activity   // Inheritance
{
    private double _speedKph;

    public Cycling(string date, int lengthMinutes, double speedKph)
        : base(date, lengthMinutes) // Inheritance: calls base constructor
    {
        _speedKph = speedKph;
    }

    // Polymorphism: overrides abstract method with Cycling-specific calculation
    public override double GetDistance()
    {
        return (_speedKph * LengthMinutes) / 60;
    }

    // Polymorphism: returns the stored speed
    public override double GetSpeed()
    {
        return _speedKph;
    }

    // Polymorphism: Cycling-specific pace calculation
    public override double GetPace()
    {
        return 60 / _speedKph;
    }
}
