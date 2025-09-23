using System;

public class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int VerseStart { get; }
    public int? VerseEnd { get; }

    // Construtor básico (um único versículo)
    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = null;
    }

    // Construtor para intervalo de versículos
    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    // Construtor que aceita string no formato "Book Chapter:Verse[-Verse]"
    public Reference(string fullReference)
    {
        // Ex: "Proverbs 3:5-6"
        var spaceSplit = fullReference.Split(' ');
        Book = spaceSplit[0];
        var chapterVerse = spaceSplit[1].Split(':');
        Chapter = int.Parse(chapterVerse[0]);

        var verseParts = chapterVerse[1].Split('-');
        VerseStart = int.Parse(verseParts[0]);
        if (verseParts.Length > 1)
            VerseEnd = int.Parse(verseParts[1]);
    }

    public override string ToString()
    {
        if (VerseEnd.HasValue)
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        return $"{Book} {Chapter}:{VerseStart}";
    }
}
