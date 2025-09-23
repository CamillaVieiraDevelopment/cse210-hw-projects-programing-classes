/// Represents a single word in the scripture text.
/// The Word is responsible for tracking its own hidden state and producing its display text.
public class Word
{
    private string _text;
    private bool _isHidden;

    /// Initialize a Word with its textual content. Initially visible.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    /// Mark the word as hidden.
    public void Hide()
    {
        _isHidden = true;
    }

    /// Mark the word as visible.
    public void Show()
    {
        _isHidden = false;
    }

    /// Check if the word is currently hidden.
    public bool IsHidden()
    {
        return _isHidden;
    }

    /// Return the display representation of the word:
    /// either the original text or underscores matching the word length.
    public string GetDisplayText()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}
