namespace WatorWF;
using System.Drawing;
using System.Windows.Forms;

public partial class Form1 : Form
{
    private System.Drawing.Bitmap _efBitmap, _esBitmap, _ewBitmap;  // image member variables
    private Map? _map = null;
    private Chronon? _chronon = null;
    private Recorder? _recorder = null;
    private Timer _timer;
    private BufferedGraphicsContext _buffCon;
    private BufferedGraphics _grafx;

    private int foo {get; set;}

    public Form1()
    {
        InitializeComponent();
        _buffCon = BufferedGraphicsManager.Current;
        _grafx = _buffCon.Allocate(this.CreateGraphics(), this.DisplayRectangle);
        // load bitmap images of fish, shark, and water wave "emojis" from .bmp files
        string efPath = "ef32.bmp";
        string esPath = "es32.bmp";
        string ewPath = "ew32.bmp";
        _efBitmap = new Bitmap(efPath);
        _esBitmap = new Bitmap(esPath);
        _ewBitmap = new Bitmap(ewPath);
        _timer = new Timer();
        _timer.Interval = 1000; // two seconds
        _timer.Tick += new EventHandler(OnTick);
        _timer.Start();
    }
    public void SetMap(Map map)
    {
        _map = map;
    }
    public void SetChronon(Chronon chronon)
    {
        _chronon = chronon;
    }
    public void SetRecorder(Recorder recorder)
    {
        _recorder = recorder;
    }
    void OnPaint(object? sender, PaintEventArgs e)
    {
        if (_map is null) { return; }
        Graphics gg = _grafx.Graphics;
        Graphics eg = e.Graphics;

        Bitmap? b = null;
        for (uint r = 0; r < _map.GetRowCount(); ++r)
        {
            for (uint c = 0; c < _map.GetColumnCount(); ++c)
            {
                char glyph = _map.GetCoordinate(r,c).GetCell().GetGlyph();
                if (glyph == '.')
                    b = _efBitmap;
                else if (glyph == '^')
                    b = _esBitmap;
                else
                    b = _ewBitmap;
                gg.DrawImage(b, 32F*c,32F*(1+r));
            }
        }
        gg.FillRectangle(Brushes.White, 0, 0, 32*56, 32);
        Font tt = new Font("Calibri", 12);
        SolidBrush tc = new SolidBrush(Color.Black);
        StringFormat tf = new StringFormat();
        gg.DrawString($"{_map.GetFishCount()} fish, {_map.GetSharkCount()} sharks    ",tt,tc,0F,0F,tf);

        _grafx.Render(eg);
        tt.Dispose();
        tc.Dispose();
        tf.Dispose();
        //gg.Dispose();
        eg.Dispose();
    }
    void OnTick(object? sender, EventArgs e)
    {
        if (sender == _timer)
        {
            _chronon.Tick();
            _map.Update();
            // MapViewer.Show(world);
            this.Invalidate();
            _recorder.AddCounts(_map.GetFishCount(), _map.GetSharkCount());
        }
    }
}