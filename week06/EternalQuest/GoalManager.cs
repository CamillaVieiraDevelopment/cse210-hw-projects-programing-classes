using System;
using System.Collections.Generic;
using System.IO;

/// <summary>
/// GoalManager class is responsible for handling all interactions with goals.
/// It demonstrates abstraction (hiding menu logic), encapsulation (private fields), 
/// and uses polymorphism to call different goal methods (RecordEvent, GetDetailsString, etc.)
/// </summary>
public class GoalManager
{
    private List<Goal> _goals;  // Encapsulation: private list of goals
    private int _score;         // Encapsulation: private player score

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Main menu loop (Abstraction: hides the implementation details from Program.cs)
    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals  (Files are always saved in your Downloads folder)");
            Console.WriteLine("4. Load Goals  (Files must be placed on your Desktop before loading)");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("Select a choice from the menu: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("❌ Invalid input. Please enter a number between 1 and 6.");
                continue;
            }

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoalDetails(); break;
                case 3: SaveGoals(); break;
                case 4: LoadGoals(); break;
                case 5: RecordEvent(); break;
                case 6: Console.WriteLine("Exiting..."); break;
            }
        }
    }

    // Create a new goal (demonstrates polymorphism: SimpleGoal, EternalGoal, ChecklistGoal)
    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? (enter 1, 2 or 3): ");
        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice)) return;

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        int points;
        while (true)
        {
            Console.Write("Enter points awarded for a single completion (integer): ");
            if (int.TryParse(Console.ReadLine(), out points)) break;
            Console.WriteLine("❌ Please enter a valid integer.");
        }

        switch (choice)
        {
            case 1:
                _goals.Add(new SimpleGoal(name, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(name, description, points));
                break;
            case 3:
                int target;
                while (true)
                {
                    Console.Write("How many times does this goal need to be accomplished for a bonus? (integer): ");
                    if (int.TryParse(Console.ReadLine(), out target)) break;
                    Console.WriteLine("❌ Please enter a valid integer.");
                }

                int bonus;
                while (true)
                {
                    Console.Write("What is the bonus (points) for accomplishing it that many times? (integer): ");
                    if (int.TryParse(Console.ReadLine(), out bonus)) break;
                    Console.WriteLine("❌ Please enter a valid integer.");
                }

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;
        }

        Console.WriteLine("Goal created successfully.");
    }

    // List details of all goals (uses polymorphism via GetDetailsString override)
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        int i = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
    }

    // Record completion of a goal (calls RecordEvent polymorphically)
    public void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        ListGoalNames();

        int choice;
        while (true)
        {
            Console.Write("Enter the number of the goal: ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice > 0 && choice <= _goals.Count)
                break;
            Console.WriteLine("❌ Invalid input. Please enter a valid goal number.");
        }

        int points = _goals[choice - 1].RecordEvent();
        _score += points;
        Console.WriteLine($"🎉 Congratulations! You have earned {points} points.");
        DisplayPlayerInfo();
    }

    // List only names of goals (helper method)
    private void ListGoalNames()
    {
        int i = 1;
        foreach (var goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetName()}");
            i++;
        }
    }

    // Show current player score
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }

    // Save goals to Downloads
    public void SaveGoals()
    {
        Console.Write("Enter the filename (without path, will be saved in Downloads): ");
        string filename = Console.ReadLine();

        string downloadsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        if (!Directory.Exists(downloadsPath))
        {
            Directory.CreateDirectory(downloadsPath);
        }

        string fullPath = Path.Combine(downloadsPath, filename);

        try
        {
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                writer.WriteLine(_score);
                foreach (var goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"✅ Goals saved successfully in: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    // Load goals from Desktop
    public void LoadGoals()
    {
        Console.Write("Enter the filename (file must be in your Desktop): ");
        string filename = Console.ReadLine();

        string desktopPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), filename);
        if (!File.Exists(desktopPath))
        {
            Console.WriteLine($"❌ File not found in Desktop: {desktopPath}");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(desktopPath);
            if (lines.Length == 0)
            {
                Console.WriteLine("File is empty.");
                return;
            }

            if (!int.TryParse(lines[0], out _score))
            {
                Console.WriteLine("Invalid file format (score).");
                return;
            }

            _goals.Clear();

            for (int i = 1; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split('|');
                string type = parts[0];

                if (type == "SimpleGoal")
                {
                    var goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (parts.Length >= 5 && int.TryParse(parts[4], out int times))
                        goal.SetTimesCompleted(times);
                    _goals.Add(goal);
                }
                else if (type == "EternalGoal")
                {
                    var goal = new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
                    if (parts.Length >= 5 && int.TryParse(parts[4], out int times))
                        goal.SetTimesCompleted(times);
                    _goals.Add(goal);
                }
                else if (type == "ChecklistGoal")
                {
                    var goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                    if (parts.Length >= 7 && int.TryParse(parts[6], out int amount))
                        goal.SetTimesCompleted(amount);
                    _goals.Add(goal);
                }
            }

            Console.WriteLine($"✅ Goals loaded successfully from: {desktopPath}");
            DisplayPlayerInfo();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }
}
