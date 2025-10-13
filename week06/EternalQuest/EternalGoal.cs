using System;

/// <summary>
/// Eternal goal: never 'complete' but can be recorded many times for repeated points.
/// 
/// OOP PRINCIPLES:
/// - Inheritance: extends Goal.
/// - Encapsulation: internal counter _timesCompleted maintained here.
/// - Polymorphism: RecordEvent and IsComplete behave differently (IsComplete always false).
/// </summary>
public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _timesCompleted = 0;
    }

    // Each time is recorded, increment counter and award points.
    public override int RecordEvent()
    {
        _timesCompleted++;
        return _points;
    }

    // Eternal goals never considered complete.
    public override bool IsComplete() => false;

    // Improvement aplied: displaying how many times it has been completed and total points gained.
    public override string GetDetailsString()
    {
        int totalPoints = CalculateTotalPoints();
        return $"Eternal Goal: {_shortName} ({_description}) - Completed {_timesCompleted} time(s) (Total points: {totalPoints})";
    }

    public override string GetStringRepresentation()
    {
        // Format: EternalGoal|name|description|points|timesCompleted
        return $"EternalGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }

    // Calculates total points as timesCompleted * points.
    protected override int CalculateTotalPoints()
    {
        return _timesCompleted * _points;
    }

    // Allow loading the persisted counter
    public override void SetTimesCompleted(int times)
    {
        _timesCompleted = times;
    }
}
