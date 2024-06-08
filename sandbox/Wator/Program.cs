namespace Wator;

class Program
{
    static Map world;
    static Recorder log;
    static Chronon ticker;

    static void Main(string[] args)
    {
        uint tickerSetting = 1000/25;  // chronon delay between each update "tick"
        uint tickerLimit = tickerSetting * 30;  // total number of "ticks"
        uint initialFish = 111;
        uint initialSharks = 29;

        ticker = new Chronon(tickerSetting);
        log = new Recorder();

        Console.Clear();
        // figure out the size of the terminal console
        uint bh = (uint)(Console.BufferHeight);
        uint bw = (uint)(Console.BufferWidth);
        // size the map to fit in the terminal
        uint bh1 = bh - 1 - 1;
        uint bw2 = bw - 2 - 1;
        world = new Map(bh1, bw2);

        MapViewer.Populate(world,initialFish,initialSharks);
        MapViewer.Show(world);
        // simulate and collect data up to the tickerLimit
        for (int t=0; !world.IsFinished() && t<tickerLimit; t++)
        {
            ticker.Tick();
            world.Update();
            MapViewer.Show(world);
            log.AddCounts(world.GetFishCount(), world.GetSharkCount());
        }
        // after the tickerLimit is reached,
        // prompt for a file name and save the log
        log.SaveAsCsv();
    }
}
