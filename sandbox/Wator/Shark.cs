namespace Wator;

class Shark : Fish
{
    // This value sets the max energy of a shark.
    // Each chronon its energy decreases by one.
    // If a shark runs out of energy, it dies.
    // Each time a shark eats, its energy returns to this max value.
    static private uint satedEnergy = 6;
    // A shark takes longer to reproduce.
    // The C# "new" keyword lets this value be different
    // from the value specified in the base class.
    static uint gestation = 12;

    // each individual sharks' energy counter
    private uint _energy;

    public Shark(Coordinate coord) : base(coord)
    {
        _energy = satedEnergy;

        // even though the base constructor sets this,
        // this derived class has a different gestation value.
        _gestationCounter = gestation;
    }

    public override void Swim()
    {
        List<Coordinate> availableCoords = new List<Coordinate>();
        List<Coordinate> potentialDestinations = _currentCoordinate.GetNeighbors();
        foreach (Coordinate targetCoord in potentialDestinations)
        {
            Fish? candidate = targetCoord.GetCell().GetOccupant();
            // check whether neighbor cell has a fish
            if (candidate is Fish && candidate is not Shark)
            {
                availableCoords.Add(targetCoord);
            }
        }
        // if there's a nearby fish: select one and eat it
        if (availableCoords.Count > 0)
        {
            int choiceIndex = prng.Next(availableCoords.Count);
            Coordinate selection = availableCoords[choiceIndex];
            selection.GetCell().GetOccupant().Expire();  // crunch!
            _energy = satedEnergy;  // yummy!

            // check reproduction counter
            if ((--_gestationCounter) > 0)
            {
                // vacate current coordinate
                _currentCoordinate.GetCell().SetOccupant(null);
            }
            else
            {
                // or repopulate current location with baby shark
                _currentCoordinate.GetCell().SetOccupant(Reproduce(_currentCoordinate));
                _gestationCounter = gestation;
            }
            // move to where the consumed fish used to be
            selection.GetCell().SetOccupant(this);
            _currentCoordinate = selection;
        }
        else
        {
            // otherwise, get hungry
            --_energy;

            if (_energy == 0)
            {
                Expire();  // starved
                _currentCoordinate.GetCell().SetOccupant(null);
            }
            else
            {
                // try to swim
                foreach (Coordinate targetCoord in potentialDestinations)
                {
                    // check whether neighbor cell is vacant
                    if (targetCoord.GetCell().GetOccupant() is null)
                    {
                        availableCoords.Add(targetCoord);
                    }
                }

                if (availableCoords.Count > 0)
                {
                    // if there's a vacant neighbor, select one
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
                        // otherwise, repopulate current corrdinate cell with a baby shark
                        _currentCoordinate.GetCell().SetOccupant(Reproduce(_currentCoordinate));
                        _gestationCounter = gestation;
                    }
                    // move to new coordinate cell
                    selection.GetCell().SetOccupant(this);
                    _currentCoordinate = selection;
                }
            }
        }
    }

    public Shark Reproduce(Coordinate coord)
    {
        Shark spawn = new Shark(coord);
        coord.GetCell().SetOccupant(spawn);
        Coordinate.GetMap().AddShark(spawn);
        return spawn;
    }

}