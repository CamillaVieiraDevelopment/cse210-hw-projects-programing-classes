/// Swimming Activity
public class Swimming : Activity   // Inheritance
{
    private int _laps;

    public Swimming(string date, int lengthMinutes, int laps)
        : base(date, lengthMinutes) // Inheritance: calls base constructor
    {
        _laps = laps;
    }

    // Polymorphism: overrides abstract method with Swimming-specific calculation
    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // Each lap is 50 meters converted to km
    }

    // Polymorphism: Swimming-specific speed calculation
    public override double GetSpeed()
    {
        return (GetDistance() / LengthMinutes) * 60;
    }

    // Polymorphism: Swimming-specific pace calculation
    public override double GetPace()
    {
        return LengthMinutes / GetDistance();
    }
}
