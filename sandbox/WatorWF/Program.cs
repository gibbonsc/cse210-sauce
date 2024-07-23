namespace WatorWF;

class Program
{
    public static Map world;
    static Recorder log;
    static Chronon ticker;

    [STAThread]  // (single-thread apartment)
    static void Main(string[] args)
    {
        //uint tickerSetting = 1000/25;  // chronon delay between each update "tick"
        //uint tickerLimit = tickerSetting * 30;  // total number of "ticks"
        uint tickerSetting = 0;
        uint tickerLimit = 1200 * 3;
        uint initialFish = 231;
        uint initialSharks = 35;

        ticker = new Chronon(tickerSetting);
        log = new Recorder();

        // Console.Clear();
        // // figure out the size of the terminal console
        // uint bh = (uint)(Console.BufferHeight);
        // uint bw = (uint)(Console.BufferWidth);
        // // size the map to fit in the terminal
        // uint bh1 = bh - 1 - 1;
        // uint bw2 = bw - 2 - 1;
        uint bh1 = 31, bw2 = 56;  // the WinForm is 56*32 by 32*32 pixels
        world = new Map(bh1, bw2);

        ApplicationConfiguration.Initialize();
        MapViewer.Populate(world,initialFish,initialSharks);
        // MapViewer.Show(world);
        Form1 watorWF = new Form1();
        watorWF.SetMap(world);
        watorWF.SetChronon(ticker);
        watorWF.SetRecorder(log);
        Application.Run(watorWF);

        // control now passed to handler methods in the Form1 class
        // simulate and collect data up to the tickerLimit
        // for (int t=0; !world.IsFinished() && t<tickerLimit; t++)
    }
}
