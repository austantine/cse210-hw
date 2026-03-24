public class Word
{
    private string _text;     // private field, hidden from outside
    private bool _hidden;     // private field, hidden from outside

    public Word(string text)
    {
        _text = text;
        _hidden = false; // words start visible
    }

    public void Hide() => _hidden = true;          // controlled method to change state
    public bool IsHidden() => _hidden;             // controlled method to check state
    public string GetText() => _text;              // controlled method to access data
    public string GetDisplayText()
    {
        return _hidden ? new string('_', _text.Length) : _text;
    }
}