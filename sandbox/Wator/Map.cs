namespace Wator;

class Map
{
    private uint _rowCount;  // number of rows in this map
    private uint _columnCount;  // number of columns in this map
    private List<List<Coordinate>> _grid = new List<List<Coordinate>>();
    private List<Fish> _fishes;
    private List<Shark> _sharks;

    public Map(uint numRows, uint numCols)
    {
        Coordinate.SetMap(this);

        _rowCount = numRows;
        _columnCount = numCols;

        // build a grid of coordinate objects
        for (uint r = 0; r < _rowCount; r++)
        {
            List<Coordinate> gridRow = new List<Coordinate>();
            for (uint c = 0; c < _columnCount; c++)
            {
                gridRow.Add(new Coordinate(r, c));
            }
            _grid.Add(gridRow);
        }

        // a new map doesn't yet have any creatures in it
        //  (the MapViewer class holds the method to do that)
        _fishes = new List<Fish>();
        _sharks = new List<Shark>();
    }

    public uint GetRowCount() { return _rowCount; }
    public uint GetColumnCount() { return _columnCount; }

    // accessor to get a particular location from the map grid
    public Coordinate GetCoordinate(uint r, uint c)
    {
        return _grid[(int)r][(int)c];
    }

    // keep track of a fish
    //  (fish are created by methods in the MapViewer and Fish classes)
    public void AddFish(Fish f)
    {
        _fishes.Add(f);
    }

    public int GetFishCount()
    {
        if (!(_fishes is null))
        {
            return _fishes.Count;
        }
        else
        {
            return 0;
        }
    }

    // keep track of a shark
    //  (sharks are created by methods in the MapViewer and Shark classes)
    public void AddShark(Shark s)
    {
        _sharks.Add(s);    
    }

    public int GetSharkCount()
    {
        if (!(_sharks is null))
        {
            return _sharks.Count;
        }
        else
        {
            return 0;
        }
    }

    // iterate through each list of fish and sharks, to let each creature act or die
    public void Update()
    {
        // get a copy of the current list of fish
        List<Fish> adultFish = new List<Fish>();
        foreach (Fish f in _fishes)
        {
            adultFish.Add(f);
        }
        // let them swim or die
        foreach (Fish f in adultFish)
        {
            if (f.IsDead())
                _fishes.Remove(f);
            else
                f.Swim();
        }

        // next, copy the list of sharks
        List<Shark> adultSharks = new List<Shark>();
        foreach (Shark s in _sharks)
        {
            adultSharks.Add(s);
        }
        // let them swim or die
        foreach (Shark s in adultSharks)
        {
            if (s.IsDead())
                _sharks.Remove(s);
            else
                s.Swim();
        }
    }

    public bool IsFinished()
    {
        // report whether the apex predator has gone extinct
        return (GetSharkCount() == 0) ? true : false;
    }
}