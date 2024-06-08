namespace Wator;

// two dimensional coordinate
// row major: row (vertical) comes before column (horizontal)
//   (UNLIKE traditional x,y coordinate)
class Coordinate
{
    static private Map? _map = null;
    private uint _row;
    private uint _column;
    private Cell _cell;

    static public void SetMap(Map m) { _map = m; }
    static public Map? GetMap() { return _map; }
    public Coordinate(uint r, uint c)
    {
        _row = r;
        _column = c;
        _cell = new Cell();
    }

    public Cell GetCell() { return _cell; }

    public List<Coordinate>? GetNeighbors()
    {
        if (!(_map is null))
        {
            List<Coordinate> result = new List<Coordinate>();

            uint numRows = _map.GetRowCount();
            uint numCols = _map.GetColumnCount();

            // at map edges, wrap around to find neighbor coordinate
            uint northRow = _row>0 ? _row-1 : numRows-1;
            uint westCol = _column>0 ? _column-1 : numCols-1;
            uint southRow = _row<numRows-1 ? _row+1 : 0;
            uint eastCol = _column<numCols-1 ? _column+1 : 0;

            result.Add(_map.GetCoordinate(northRow, _column));
            result.Add(_map.GetCoordinate(southRow, _column));
            result.Add(_map.GetCoordinate(_row ,eastCol));
            result.Add(_map.GetCoordinate(_row, westCol));
            return result;
        }
        else
        {
            return null;
        }
    }
}