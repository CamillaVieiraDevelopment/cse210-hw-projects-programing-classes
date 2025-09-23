using System;

/// Represents a scripture reference (book, chapter, start verse, optional end verse).
/// This class provides multiple constructors to support single verses and verse ranges,
/// and it formats the reference for display.
public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int? VerseEnd { get; }

    /// Constructor for a single verse reference.
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    /// Constructor for a reference that spans multiple verses.
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    /// Parses a reference from a string in the form "Book Chapter:Verse[-Verse]".
    /// Example: "Proverbs 3:5-6" or "John 3:16".
    /// Note: this parser expects the book and chapter:verse to be separated by a space.
    public Reference(string fullReference)
    {
        // Example input: "Proverbs 3:5-6"
        var spaceSplit = fullReference.Split(' ');
        Book = spaceSplit[0];
        var chapterVerse = spaceSplit[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]);

        var verseParts = chapterVerse[1].Split('-');
        VerseStart = int.Parse(verseParts[0]);
        if (verseParts.Length > 1)
            VerseEnd = int.Parse(verseParts[1]);
    }

    /// Return a formatted string representation of the reference.
    public override string ToString()
    {
        if (VerseEnd.HasValue)
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        return $"{Book} {Chapter}:{VerseStart}";
    }
}
