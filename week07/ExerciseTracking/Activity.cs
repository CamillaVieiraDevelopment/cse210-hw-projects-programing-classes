using System;

/// Acitivity is the base abstract class for all activities 
public abstract class Activity
{
    // Encapsulation: private fields
    private string _date;
    private int _lengthMinutes;

    public Activity(string date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    // Encapsulation: public read-only properties
    public string Date => _date;
    public int LengthMinutes => _lengthMinutes;

    // Abstraction + Polymorphism: abstract methods (must be overridden in derived classes)
    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in km/h
    public abstract double GetPace();     // in min/km

    // Polymorphism: this virtual method calls abstract methods that behave differently depending on the derived class
    public virtual string GetSummary()
    {
        return $"{Date} {GetType().Name} ({LengthMinutes} min) - " +
               $"Distance {GetDistance():0.0} km, " +   // Polymorphic call
               $"Speed {GetSpeed():0.0} kph, " +        // Polymorphic call
               $"Pace: {GetPace():0.00} min per km";    // Polymorphic call
    }
}
