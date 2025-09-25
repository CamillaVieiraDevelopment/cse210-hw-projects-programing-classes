using System;
using System.Collections.Generic;

public class Video
{
    // Public read-only properties
    public string Title { get; }
    public string Author { get; }
    public int Duration { get; } // duration in seconds

    // Private list of comments (encapsulated)
    private List<Comment> comments;

    // Constructor
    public Video(string title, string author, int duration)
    {
        Title = title;
        Author = author;
        Duration = duration;
        comments = new List<Comment>();
    }

    // Method to add a comment
    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    // Method to get all comments (read-only)
    public IReadOnlyList<Comment> GetComments()
    {
        return comments.AsReadOnly();
    }

    // Method to return the number of comments
    public int GetNumberOfComments()
    {
        return comments.Count;
    }
}
