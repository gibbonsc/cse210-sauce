class Strip
{
    private char[] _pattern;
    private GlyphSet _glyphSet;

    public Strip()
    {
        _glyphSet = new GlyphSet(Program.DIFFICULTY);
        _pattern = new char[Program.MAX_WIDTH];
        for (int i=0; i<_pattern.Length; i++)
        {
            _pattern[i] = _glyphSet.GetRandomGlyph();
        }
    }

    public string GetClip(int left)
    {
        int leftIndex = left % Program.MAX_WIDTH;
        string result = new string(_pattern[leftIndex],1);
        for (int i=1; i<Program.WINDOW_SIZE; i++)
        {
            result += _pattern[leftIndex + i];
        }
        return result;
    }
}