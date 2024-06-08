namespace Wator;

class Fish
{
    // a source of randomness to affect a fish's behavior
    static protected Random prng = new Random();
    // how many chronons before a fish spawns another fish?
    static private uint gestation = 7;

    private bool _alive = true;
    protected uint _gestationCounter = gestation;
    protected Coordinate _currentCoordinate;

    public Fish(Coordinate coord)
    {
        _currentCoordinate = coord;
        _gestationCounter = gestation;
    }

    // here's the behavior simulator for a fish:
    // try to swim to a different adjacent location, and
    // perhaps spawn another fish to the current location.
    public virtual void Swim()
    {
        List<Coordinate> availableCoords = new List<Coordinate>();
        List<Coordinate> potentialDestinations = _currentCoordinate.GetNeighbors();
        foreach (Coordinate targetCoord in potentialDestinations)
        {
            // check whether neighbor cell is vacant
            if (targetCoord.GetCell().GetOccupant() is null)
            {
                availableCoords.Add(targetCoord);
            }
        }
        // if there's a vacant neighbor, select one
        if (availableCoords.Count > 0)
        {
            int choiceIndex = prng.Next(availableCoords.Count);
            Coordinate selection = availableCoords[choiceIndex];
            // check reproduction counter
            if ((--_gestationCounter) > 0)
            {
                // if still gestating, vacate current coordinate cell
                _currentCoordinate.GetCell().SetOccupant(null);
            }
            else
            {
                // otherwise, repopulate current corrdinate cell
                _currentCoordinate.GetCell().SetOccupant(Reproduce(_currentCoordinate));
                _gestationCounter = gestation;
            }
            // move to new coordinate cell
            selection.GetCell().SetOccupant(this);
            _currentCoordinate = selection;
        }
    }

    // when a new fish appears, it must occupy a location,
    // and it must also be tracked in the map's fish list
    // so that the map can Update() it at each chronon.
    public Fish Reproduce(Coordinate coord)
    {
        Fish spawn = new Fish(coord);
        coord.GetCell().SetOccupant(spawn);
        Coordinate.GetMap().AddFish(spawn);
        return spawn;
    }

    // setter and getter,
    // used to kill a fish and detect a dead fish, respectively
    public void Expire() { _alive = false; }
    public bool IsDead() { return !_alive; }
}