class Program
{
    public static int DIFFICULTY = 0;
    public static int MAX_WIDTH = 24;
    public static int WINDOW_SIZE = 7;
    public static int MAX_STRIPS = 7;

    public static void Main(string[] args)
    {
        string ckey;
        string diffInput = "";
        Console.WriteLine("Slider Game!");
        while (diffInput != "1" && diffInput != "2" && diffInput != "3" && diffInput != "4" && diffInput != "5")
        {
            Console.Write("Difficulty? (1, 2, 3, 4, or 5): ");
            diffInput = Console.ReadLine();
        }
        DIFFICULTY = int.Parse(diffInput)-1;

        Timer timer = new Timer();
        Cursor cursor = new Cursor();
        Arrangement.InitStrip();
        Arrangement playField = new Arrangement();
        Arrangement target = new Arrangement();

        Console.Clear();
        DisplayArrangements(playField, target, cursor);

        timer.Start();
        do
        {
            ckey = Console.ReadKey().Key.ToString();
            switch(ckey)
            {
                case "UpArrow":
                    cursor.MoveUp();
                    break;
                case "DownArrow":
                    cursor.MoveDown();
                    break;
                case "LeftArrow":
                    playField.MoveLeft(cursor.GetRow());
                    break;
                case "RightArrow":
                    playField.MoveRight(cursor.GetRow());
                    break;
                case "Escape":
                    ckey = "Q";
                    break;
                default:
                    break;
            }
            DisplayArrangements(playField, target, cursor);
            Console.WriteLine(timer.GetElapsedTime());
        } while (ckey != "Q" && !playField.IsMatched(target));
    }

    public static void DisplayArrangements(Arrangement p, Arrangement t, Cursor c)
    {
        Console.CursorTop = Console.CursorLeft = 0;
        Console.WriteLine(@"Using the arrow keys, slide the rows in the pattern on the left
to make them match the pattern on the right. (Tap [Q] to abort.)
-------------------");

        for (int i = 0; i < MAX_STRIPS; i++)
        {
            string pRow = p.GetRowClip(i);
            string tRow = t.GetRowClip(i);
            Console.Write(pRow);
            if (c.GetRow() == i)
            {
                Console.Write(" <=> ");
            }
            else
            {
                Console.Write("     ");
            }
            Console.WriteLine(tRow);
        }
        Console.WriteLine(@"-------------------");
    }
}
