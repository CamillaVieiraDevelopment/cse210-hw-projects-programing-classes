using System;
using System.Collections.Generic;
using System.Linq;

/// Encapsulates a scripture passage: its reference and the words that compose its text.
/// This class is responsible for displaying the passage and hiding words for the memorization exercise.
public class Scripture
{
    public Reference Reference { get; }
    private List<Word> _words;

    /// Creates a Scripture instance from a Reference and the full text.
    /// The text is split into Word objects which manage their own shown/hidden state.
    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    /// Returns the formatted reference string.
    public string GetReference()
    {
        return Reference.ToString();
    }

    /// Returns the scripture text for display, with hidden words replaced by underscores.
    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }

    /// Hides a specified number of random visible words.
    /// The method will not attempt to hide more words than are currently visible.
    public void HideRandomWords(int numberToHide)
    {
        Random rand = new Random();
        var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
        int toHide = Math.Min(numberToHide, visibleWords.Count);

        for (int i = 0; i < toHide; i++)
        {
            int index = rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    /// Returns true when all words in the scripture are hidden.
    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden());
    }
}
