using System;

/// <summary>
/// Checklist goal: requires multiple completions; awards bonus when target reached.
/// 
/// OOP PRINCIPLES:
/// - Inheritance: extends Goal.
/// - Encapsulation: _amountCompleted, _target and _bonus are private and manipulated through methods.
/// - Polymorphism: overrides RecordEvent, IsComplete, GetDetailsString and string representation.
/// </summary>
public class ChecklistGoal : Goal
{
    private int _amountCompleted; // how many times user has completed the checklist task
    private int _target;          // how many times needed to complete
    private int _bonus;           // bonus points when target reached

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
        _timesCompleted = 0; // for consistency; we will keep _timesCompleted equal to _amountCompleted
    }

    // Record progress: increment amountCompleted and timesCompleted; award points and bonus when target reached.
    public override int RecordEvent()
    {
        _amountCompleted++;
        _timesCompleted = _amountCompleted;

        if (_amountCompleted == _target)
        {
            // If this call completed the checklist, return points + bonus
            return _points + _bonus;
        }

        // Otherwise, return normal points
        return _points;
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDetailsString()
    {
        int totalPoints = CalculateTotalPoints(); //*Improvement Aplied:It is the sum of the total points to make it easier for the user to check.
        string checkBox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkBox} {_shortName} ({_description}) -- Completed: {_amountCompleted}/{_target} (Total points: {totalPoints})";
    }

    public override string GetStringRepresentation()
    {
        // Format: ChecklistGoal|name|description|points|target|bonus|amountCompleted
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_target}|{_bonus}|{_amountCompleted}";
    }

    // Calculate total points including bonus if target reached.
    protected override int CalculateTotalPoints()
    {
        if (_amountCompleted >= _target)
        {
            // full points for each completion plus bonus once
            return (_amountCompleted * _points) + _bonus;
        }
        else
        {
            return _amountCompleted * _points;
        }
    }

    // Allow loading state from file
    public override void SetTimesCompleted(int times)
    {
        _amountCompleted = times;
        _timesCompleted = times;
    }
}
