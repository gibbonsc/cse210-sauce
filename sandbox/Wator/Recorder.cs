namespace Wator;

class Recorder
{
    // lists for traking simulated population data
    private List<int> _fishCount;
    private List<int> _sharkCount;

    public Recorder()
    {
        _fishCount = new List<int>();
        _sharkCount = new List<int>();
    }

    public void AddCounts(int numFish, int numSharks)
    {
        _fishCount.Add(numFish);
        _sharkCount.Add(numSharks);
    }

    // prompt for a file name (or [CTRL]+[C] to skip saving collected data)
    // create a two-column spreadsheet file
    //   (the file can be used to quickly make a nifty line chart in Excel)
    public void SaveAsCsv()
    {
        string entryRow;
        Console.WriteLine("\nPlease provide a file name:");
        string filename = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine("Fish,Sharks");
            for (int i=0; i<_fishCount.Count; i++)
            {
                entryRow = $"{_fishCount[i]},{_sharkCount[i]}";
                outputFile.WriteLine(entryRow);
            }
        }
    }
}