namespace Canvas1;

public partial class Form1 : Form
{
    private System.Drawing.Bitmap efBitmap, esBitmap, ewBitmap;  // declare bitmap members
    private void LoadBitmaps()
    {
        string efPath = "ef32.bmp";
        string esPath = "es32.bmp";
        string ewPath = "ew32.bmp";
        efBitmap = new System.Drawing.Bitmap(efPath);
        esBitmap = new System.Drawing.Bitmap(esPath);
        ewBitmap = new System.Drawing.Bitmap(ewPath);
        // Console.WriteLine(ewBitmap.Size.Width);
        // Console.WriteLine(ewBitmap.Size.Height);
    }
    private void PaintBitmapXY(Graphics g, Bitmap b, int x, int y)
    {
        g.DrawImage(b, x, y);
    }
    public Form1()
    {
        InitializeComponent();
        LoadBitmaps();
    }

    void OnPaint(object? sender, PaintEventArgs e)
    {
        // myBitmap1 = new System.Drawing.Bitmap(
        //     this.ClientRectangle.Width,
        //     this.ClientRectangle.Height,
        //     System.Drawing.Imaging.PixelFormat.Format24bppRgb
        // );
        float ppr=20.0F;
        string st = "0         1         2         3         4         5         6         7         8         9";
        string su = "01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567";
        Graphics g = e.Graphics;
        g.DrawImage(ewBitmap, 128, 128);
        g.DrawImage(esBitmap, 128, 128+32);
        g.DrawImage(efBitmap, 128, 128+64);

        // g.FillRectangle(Brushes.Sienna, 110, 115, 90, 60);
        Font typeface = new Font("Consolas", 12);  // 90x32 chars/canvas?
        SolidBrush typeColor = new SolidBrush(Color.Black);
        StringFormat typeFmt = new StringFormat();
        // g.DrawString(st,typeface,typeColor,0.0F,0.0F,typeFmt);
        // g.DrawString(su,typeface,typeColor,0.0F,ppr,typeFmt);
        // g.DrawString("Howdy",typeface,typeColor,0.0F,ppr*2,typeFmt);
        // g.DrawString("🌊🐟🦈 ~.^",typeface,typeColor,0.0F,ppr*5,typeFmt);
        // g.DrawString(st,typeface,typeColor,0.0F,ppr*23,typeFmt);
        // g.DrawString(su,typeface,typeColor,0.0F,ppr*24,typeFmt);
        // g.DrawString(st,typeface,typeColor,0.0F,ppr*25,typeFmt);
        // g.DrawString(su,typeface,typeColor,0.0F,ppr*26,typeFmt);
        // g.DrawString(st,typeface,typeColor,0.0F,ppr*27,typeFmt);
        g.DrawString(su,typeface,typeColor,0.0F,ppr*28,typeFmt);
        g.DrawString(st,typeface,typeColor,0.0F,ppr*36,typeFmt);
        g.DrawString(su,typeface,typeColor,0.0F,ppr*37,typeFmt);
        typeface.Dispose();
        typeColor.Dispose();
        typeFmt.Dispose();
        g.Dispose();
    }
}
