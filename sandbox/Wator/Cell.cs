namespace Wator;
class Cell
{
    private Fish? _occupant;

    public Cell()
    {
        _occupant=null;
    }

    public void SetOccupant(Fish? fishy)
    {
        _occupant = fishy;
    }
    public Fish? GetOccupant() { return _occupant; }

    // select character to represent occupant in the terminal's console output
    public char GetGlyph()
    {
        if (_occupant is null)
        {
            // no occupant. Just a wave of water?
            return '~';
        }
        else if (_occupant is Shark)
        {
            // a shark fin?
            return '^';
        }
        {
            // a shadow of a fish under the water?
            return '.';
        }
    }
}