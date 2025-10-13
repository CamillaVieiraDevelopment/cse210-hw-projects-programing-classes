using System;

/// <summary>
/// Simple goal: can be completed once.
/// 
/// OOP PRINCIPLES:
/// - Inheritance: inherits from Goal.
/// - Encapsulation: _isComplete state is private and managed through methods.
/// - Polymorphism: overrides RecordEvent, IsComplete and GetStringRepresentation.
/// </summary>
public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
        _timesCompleted = 0;
    }

    // When recorded, mark complete only once and increment times completed.
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            _timesCompleted = 1;
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    public override string GetStringRepresentation()
    {
        // Format: SimpleGoal|name|description|points|timesCompleted
        return $"SimpleGoal|{_shortName}|{_description}|{_points}|{_timesCompleted}";
    }

    // When listing details, show checkbox and total points (which is points if completed, else 0).
    public override string GetDetailsString()
    {
        int totalPoints = CalculateTotalPoints();
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} ({_description}) (Total points: {totalPoints})";
    }

    // Allow loading state from file
    public override void SetTimesCompleted(int times)
    {
        _timesCompleted = times;
        _isComplete = (_timesCompleted > 0);
    }
}
