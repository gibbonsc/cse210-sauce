//
public class Job {
    // member data
    public string _company;
    public string _jobTitle;
    public int _startYear;
    public int _endYear;

    // methods
    public void Display(){
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
}