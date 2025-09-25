using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating videos
        Video video1 = new Video("Learning C#", "Camilla", 700);
        Video video2 = new Video("Python Exercises", "John", 900);
        Video video3 = new Video("Java Fundamentals", "Mary", 455);

        // Adding comments
        video1.AddComment(new Comment("Soraya", "Grateful!"));
        video1.AddComment(new Comment("Molly", "I loved this video."));
        video1.AddComment(new Comment("Eduard", "Very clear!"));

        video2.AddComment(new Comment("Samuel", "Thank you for clarifications!."));
        video2.AddComment(new Comment("Edward", "I am a beginner in this area, this is very usefull!."));
        video2.AddComment(new Comment("James", "Excellent content!"));

        video3.AddComment(new Comment("Clara", "Very good!!!!!."));
        video3.AddComment(new Comment("Kaline", "Thank you!."));
        video3.AddComment(new Comment("Bob", "Good!!!"));

        // List of videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Displaying video information
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Duration: {video.Duration} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");
            foreach (var comment in video.GetComments())
            {
                Console.WriteLine($"- {comment}");
            }
            Console.WriteLine();
        }
    }
}
