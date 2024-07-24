class Arrangement
{
    public static Strip? _strip;
    private List<int> _positions;

    public static void InitStrip()
    {
        _strip = new Strip();
    }

    public Arrangement()
    {
        _positions = new List<int>();
        Random random = new Random();
        for (int i=0; i<Program.MAX_STRIPS; i++)
        {
            _positions.Add(random.Next(0,Program.MAX_WIDTH-Program.WINDOW_SIZE));
        }
    }

    public void MoveLeft(int row)
    {
        int currentPos = _positions[row];
        if (currentPos > 0)
        {
            _positions[row]--;
        }
    }

    public void MoveRight(int row)
    {
        int currentPos = _positions[row];
        if (currentPos < Program.MAX_WIDTH-Program.WINDOW_SIZE-1)
        {
            _positions[row]++;
        }
    }

    public bool IsMatched(Arrangement comparison)
    {
        bool result = true;
        for (int i=0; i<Program.MAX_STRIPS; i++)
        {
            if (comparison._positions[i] != _positions[i])
            {
                result = false;
                break;
            }
        }
        return result;
    }

    public string GetRowClip(int row)
    {
        if (_strip is not null)
        {
            int rowPosition = _positions[row];
            return _strip.GetClip(rowPosition);
        }
        else
        {
            return "";
        }
    }
}