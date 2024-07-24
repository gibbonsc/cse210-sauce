public class Cursor
{
    int _row = 0;

    public void MoveUp()
    {
        if (_row > 0)
        {
            _row--;
        }
    }

    public void MoveDown()
    {
        if (_row < Program.MAX_STRIPS - 1)
        {
            _row++;
        }
    }

    public int GetRow() { return _row; }
}
