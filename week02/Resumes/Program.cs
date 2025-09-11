using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Resumes Project.");
        Resume myResume = new Resume();

        // Ask for the user's name
        Console.Write("Enter your name: ");
        myResume._name = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("\n--- New Job ---");

            Job job = new Job();

            Console.Write("Job Title: ");
            job._jobTitle = Console.ReadLine();

            Console.Write("Company: ");
            job._company = Console.ReadLine();

            Console.Write("Start Year: ");
            job._startYear = int.Parse(Console.ReadLine());

            Console.Write("End Year: ");
            job._endYear = int.Parse(Console.ReadLine());

            // Add job to resume
            myResume._jobs.Add(job);

            // Ask if the user wants to continue
            Console.Write("\nDo you want to add another job? (y/n): ");
            string answer = Console.ReadLine().Trim().ToLower();

            if (answer == "n" || answer == "no")
            {
                break; // exit the loop
            }
        }

        // Show final result
        myResume.Display();
    }
}
    


public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine($"\nName: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}

public class Job
{
    public string _jobTitle;
    public string _company;
    public int _startYear;
    public int _endYear;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}
