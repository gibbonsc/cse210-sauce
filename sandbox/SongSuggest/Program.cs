namespace SongSuggest;

class Program
{
    static void Main(string[] args)
    {
        string resultCG;
        Console.Write("How old are you? ");
        string enteredAgeCG = Console.ReadLine();
        int ageCG = int.Parse(enteredAgeCG);
        if (ageCG <= 4)
        {
            resultCG = "Jesus Wants Me For a Sunbeam";
        }
        else if (ageCG <= 11)
        {
            resultCG = "I Am a Child of God";
        }
        else if (ageCG <= 19)
        {
            resultCG = "As Zion's Youth in Latter Days";
        }
        else
        {
            resultCG = "Come, Come, Ye Saints";
        }
        Console.WriteLine(resultCG);
    }
}
