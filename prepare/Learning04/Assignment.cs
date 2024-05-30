public class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string nameP, string topicP)
    {
        _studentName = nameP;
        _topic = topicP;
    }
    public string GetSummary()
    {
        return _studentName + " - " + _topic;
    }

    public string GetStudentName()
    {
        return _studentName;
    }
}