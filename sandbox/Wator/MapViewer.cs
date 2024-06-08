namespace Wator;

class MapViewer
{
    static private Random prng = new Random();

    // output the world map to the terminal console
    public static void Show(Map map)
    {
        string output = "";
        for (uint r=0; r<map.GetRowCount(); r++)
        {
            for (uint c=0; c<map.GetColumnCount(); c++)
            {
                output += map.GetCoordinate(r,c).GetCell().GetGlyph();
            }
            output += '\n';
        }
        // overwrite (rather than clear) the console terminal
        Console.CursorLeft = Console.CursorTop = 0;
        Console.Write(output); 
        Console.Write($"{map.GetFishCount()} fish, {map.GetSharkCount()} sharks    ");
    }

    // initialize aquatic creatures into the world map at random locations
    public static void Populate(Map m, uint numFish, uint numSharks)
    {
        Coordinate coord;
        int randr, randc;
        int rowCount = (int)m.GetRowCount();
        int columnCount = (int)m.GetColumnCount();
        for (int i=0; i<numFish; i++)
        {
            // find an empty location
            do {
                randr = prng.Next(rowCount);
                randc = prng.Next(columnCount);
                coord = m.GetCoordinate((uint)randr,(uint)randc);
            } while (!(coord.GetCell().GetOccupant() is null));
            // add a prey to the map, occupying the determined location
            Fish f = new Fish(coord);
            m.AddFish(f);
            coord.GetCell().SetOccupant(f);
        }
        for (int i=0; i<numSharks; i++)
        {
            do {
                randr = prng.Next(rowCount);
                randc = prng.Next(columnCount);
                coord = m.GetCoordinate((uint)randr,(uint)randc);
            } while (!(coord.GetCell().GetOccupant() is null));
            // add a predator to the map, occupying the determined location
            Shark s = new Shark(coord);
            m.AddShark(s);
            coord.GetCell().SetOccupant(s);
        }
    }
}