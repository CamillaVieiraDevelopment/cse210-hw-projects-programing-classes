using System;

/// <summary>
/// Abstract base class that defines the common interface for all goals.
/// 
/// OOP PRINCIPLES:
/// - Abstraction: provides a high-level interface for different goal types (RecordEvent, IsComplete, GetDetailsString, GetStringRepresentation)
/// - Encapsulation: protected fields hide implementation details; derived classes manage their specific state.
/// - Polymorphism: abstract methods are overridden by subclasses to provide type-specific behavior.
/// </summary>
public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    // Track how many times this goal's event was recorded.
    // For SimpleGoal this will be 0 or 1; for EternalGoal it can grow; for ChecklistGoal we use a separate field but this is a shared counter too.
    protected int _timesCompleted;

    protected Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _timesCompleted = 0;
    }

    // Polymorphism: each subclass provides its own implementation.
    public abstract int RecordEvent();
    public abstract bool IsComplete();

    // Default detail view. Derived classes may override to show additional info.
    public virtual string GetDetailsString()
    {
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        int totalPoints = CalculateTotalPoints();
        return $"{checkBox} {_shortName} ({_description}) (Total points: {totalPoints})";
    }

    // Returns a string representation for saving to file; must be parseable by Load.
    public abstract string GetStringRepresentation();

    public string GetName() => _shortName;

    // Helper to compute total points earned for this goal (base implementation).
    // Derived classes override or extend this logic if necessary (e.g., Checklist includes bonus).
    protected virtual int CalculateTotalPoints()
    {
        return _timesCompleted * _points;
    }

    // Methods used when loading from storage to restore persisted counters.
    // Derived classes provide appropriate implementations.
    public virtual void SetTimesCompleted(int times)
    {
        _timesCompleted = times;
    }
}
