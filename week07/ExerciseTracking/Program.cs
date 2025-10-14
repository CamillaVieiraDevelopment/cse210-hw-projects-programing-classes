using System;
using System.Collections.Generic;
// Tracking Program for Running, Cycling, and Swimming activities
class Program
{
    static void Main(string[] args)
    {
        // List of base type Activity
        // Polymorphism: the list can store different derived types
        List<Activity> activities = new List<Activity>()
        {
            new Running("08 Feb 2025", 20, 4.1),   // Running object
            new Cycling("09 Feb 2025", 25, 22.0), // Cycling object
            new Swimming("10 Feb 2025", 35, 30)   // Swimming object
        };

        // Polymorphism: although we call GetSummary() on Activity,
        // the overridden methods in Running, Cycling, and Swimming are executed.
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary()); // Polymorphic behavior
        }
    }
}
