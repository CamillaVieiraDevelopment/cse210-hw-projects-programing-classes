public class Comment
{
    // Public read-only properties
    public string Name { get; }
    public string Text { get; }

    // Constructor
    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }

    // String representation
    public override string ToString()
    {
        return $"{Name}: {Text}";
    }
}
