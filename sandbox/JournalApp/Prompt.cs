class Prompt
{
    public Random _randomProducer = new Random();
    public List<string> _promptList = [
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
    ];
    public int _selectedPromptIndex;

    // method
    public string GeneratePrompt() {
        _selectedPromptIndex = _randomProducer.Next(0, _promptList.Count);
        return _promptList[_selectedPromptIndex];
    }
}