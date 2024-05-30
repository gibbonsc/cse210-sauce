public class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string nameP, string topicP, string textP, string probP) : base(nameP, topicP)
    {
        _textbookSection = textP;
        _problems = probP;
    }

    public string GetHomeworkList()
    {
        return $"{this._textbookSection} Problems {this._problems}";
    }
}