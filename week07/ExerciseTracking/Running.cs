/// Running Activity
public class Running : Activity   // Inheritance: Running IS-A Activity
{
    private double _distanceKm;

    public Running(string date, int lengthMinutes, double distanceKm)
        : base(date, lengthMinutes) // Inheritance: calls base class constructor
    {
        _distanceKm = distanceKm;
    }

    // Polymorphism: this method overrides the abstract definition in Activity
    public override double GetDistance()
    {
        return _distanceKm;
    }

    // Polymorphism: Running-specific implementation
    public override double GetSpeed()
    {
        return (GetDistance() / LengthMinutes) * 60;
    }

    // Polymorphism: Running-specific implementation
    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }
}
