using static System.Console;

class Journal
{
    public List<Entry> _entryList;

    public void Initialize()
    {
        _entryList = new List<Entry>();
    }

    public void AppendEntry(Entry eParam)
    {
        _entryList.Add(eParam);
    }

    public void Display()
    {
        WriteLine("JOURNAL CONTENTS:");
        WriteLine();
        foreach (Entry e in _entryList) {
            e.Display();
        }
    }
}