using static System.Console;

class Entry {
    public string _givenPrompt = "";
    public string _entryText = "";
    public string _entryDateTime;

    public Entry() {}  // default constructor

    // handy constructor to initialize an Entry all at one go
    public Entry(string promptParam, string textParam, string dtParam)
    {
        _givenPrompt = promptParam;
        _entryText = textParam;
        _entryDateTime = dtParam;
    }

    public void Display()
    {
        WriteLine($"Entry Date and time: {_entryDateTime}");
        WriteLine($"Entry Prompt: {_givenPrompt}");
        WriteLine(new string('-',40));
        WriteLine(_entryText);
        WriteLine(new string('=',40));
    }
}