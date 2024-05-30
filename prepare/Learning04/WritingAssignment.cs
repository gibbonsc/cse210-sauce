
public class WritingAssignment: Assignment
{
    private string _title;

    public WritingAssignment(string nameP, string topP, string titleP): base(nameP, topP)
    {
        _title = titleP;
    }

    public string GetWritingInformation()
    {
        return $"{this._title} by {this.GetStudentName()}";
    }
}