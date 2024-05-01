namespace Flowers;

class Program
{
    static void DisplayTitle()
    {
        Console.WriteLine("");
        Console.WriteLine("=== Selected Flower Arrangement ===");
    }
    static void BuildAndShowAvailableFlowers(List<string> carnationList, List<string> peonyList)
    {
        carnationList.Add("White Carnation");
        carnationList.Add("Yellow Carnation");
        carnationList.Add("Pink Carnation");

        peonyList.Add("Red Peony");
        peonyList.Add("Orange Peony");
        peonyList.Add("Coral Peony");

        Console.WriteLine("Available Flowers:");
        DisplayGroupedArrangement(carnationList, peonyList);
    }

    static string SelectionPrompt()
    {
        string result;
        Console.WriteLine();
        Console.Write("Do you prefer the flowers grouped (g) or mixed (m)? ");
        string response = Console.ReadLine();
        return response;
    }

    static void DisplayGroupedArrangement(List<string> flowerList1, List<string> flowerList2)
    {
        foreach (string flower in flowerList1) {
            Console.WriteLine(flower);
        }
        foreach (string flower in flowerList2) {
            Console.WriteLine(flower);
        }
    }

    static void DisplayMixedArrangement(List<string> flowerList1, List<string> flowerList2)
    {
        for (int i=0; i < flowerList1.Count; i++)
        {
            Console.WriteLine(flowerList1[i]);
            Console.WriteLine(flowerList2[i]);
        }
    }

    static void Main(string[] args)
    {
        List<string> carnations = new List<string>();
        List<string> peonies = new List<string>();
        BuildAndShowAvailableFlowers(carnations, peonies);
        string choice = SelectionPrompt();
        if (choice == "g")
        {
            DisplayTitle();
            DisplayGroupedArrangement(carnations, peonies);
        }
        else if (choice == "m")
        {
            DisplayTitle();
            DisplayMixedArrangement(carnations, peonies);
        }
        else
        {
            Console.WriteLine("Unexpected input. Aborting.");
        }
    }
}
