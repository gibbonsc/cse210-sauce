class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction() { _top = _bottom = 1; }
    public Fraction(int n) { _top=n; _bottom=1; }
    public Fraction(int n, int d) { _top=n; _bottom=d; }

    public int GetTop() { return _top; }
    public int GetBottom() { return _bottom; }
    public void SetTop(int n) { _top=n; }
    public void SetBottom(int d) { _bottom=d; }

    public string GetFractionString() { return $"{_top}/{_bottom}"; }
    public double GetDecimalValue() { return (double)_top/_bottom; }
}