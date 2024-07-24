class GlyphSet
{
    private string _glyphs;
    private List<string> _glyphSources = new List<string>() {"0123456789ABCDEF", "vx^v^\\/", "]}[{", "_-=", ".:"};
    
    public GlyphSet(int difficulty)
    {
        _glyphs = _glyphSources[difficulty];
    }

    public char GetRandomGlyph()
    {
        Random random = new Random();
        int index = random.Next(0,_glyphs.Length);
        return _glyphs[index];
    }
}