using System;

// Child Class inheriting from Activity
public class BreathingActivity : Activity
{
    public BreathingActivity() 
        : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        int time = Duration;
        while (time > 0)
        {
            Console.Write("\nBreathe in... ");
            ShowCountDown(4);
            time -= 4;

            if (time <= 0) break;

            Console.Write("Now breathe out... ");
            ShowCountDown(4);
            time -= 4;
        }

        DisplayEndingMessage();
    }
}
