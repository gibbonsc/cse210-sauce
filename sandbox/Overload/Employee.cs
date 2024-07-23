class Employee
{
    protected string _name;
    protected int _id;
    private double _salary;

    public Employee(string name, int id, double salary)
    {
        _name = name; _id = id; _salary = salary;
    }
    public Employee(string serialParams):this(
        serialParams.Split(';')[0],
        int.Parse(serialParams.Split(';')[1]),
        double.Parse(serialParams.Split(';')[2])
        ) {}
    public override string ToString()
    {
        return $"{this._name};{this._id};{this._salary}";
    }
}

class HourlyEmployee:Employee
{
    private float _rate;
    private float _hours;
    public HourlyEmployee(string name, int id, float rate, float hours):base(name,id,0.0)
    {
        _rate = rate; _hours = hours;
    }
    public HourlyEmployee(string serialParams):base(serialParams)
    {
        _rate = float.Parse(serialParams.Split(";")[2]);
        _hours = float.Parse(serialParams.Split(";")[3]);
    }
    public override string ToString()
    {
        return $"{this._name};{this._id};{this._rate};{this._hours}";
    }
}
