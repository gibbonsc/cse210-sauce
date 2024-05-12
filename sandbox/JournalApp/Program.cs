using System;
using System.IO;
using static System.Console;

class Program
{
    public static Journal workingJournal;

    static void MenuLoop()
    {
        Entry journalEntry;
        string choice="";
        while (choice != "0")
        {
            WriteLine("JOURNAL APP!");
            WriteLine("0: Quit");
            WriteLine("1: Write a new entry");
            WriteLine("2: Display journal");
            WriteLine("3: Save journal to a file");
            WriteLine("4: Load a journal from a file");
            Write("Your selection: ");
            choice = ReadLine();
            switch (choice) {
                case "1":
                    journalEntry = WriteNewEntry();
                    workingJournal.AppendEntry(journalEntry);
                    break;
                case "2":
                    workingJournal.Display();
                    break;
                case "3":
                    Write("Saving... ");
                    SaveJournalFile();
                    WriteLine("Journal Saved.");
                    break;
                case "4":
                    Write("Loading... ");
                    LoadJournalFile();
                    WriteLine("Journal Loaded.");
                    break;
                case "0":
                    Write("All done. ");
                    break;
                default:
                    Write("Couldn't understand that selection. ");
                    WriteLine("Please enter the number of your selected choice (0 through 4).");
                    break;
            }
        }
        WriteLine("Stopping the JOURNAL APP! program.");
    }

    static Entry WriteNewEntry() {
        Prompt prompter = new Prompt();
        string newPrompt = prompter.GeneratePrompt();
        WriteLine(newPrompt);
        Write("Your entry: ");
        string response = ReadLine();
        DateTime rightNow = DateTime.Now;
        string rightNowText = $"{rightNow.ToShortDateString()} {rightNow.ToShortTimeString()}";

        Entry newEntry = new Entry();
        newEntry._entryDateTime = rightNowText;
        newEntry._givenPrompt = newPrompt;
        newEntry._entryText = response;
        WriteLine("\nHere's your new journal entry: \n");
        newEntry.Display();

        return newEntry;
    }

    static void SaveJournalFile()
    {
        string entryRow;
        WriteLine("Please provide a file name:");
        string fileName = ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in workingJournal._entryList)
            {
                entryRow = "";
                //entryRow += '\"' + e._entryDateTime + '\:' + ',';
                //entryRow += '\"' + e._givenPrompt + '\"' + ',';
                //entryRow += '\"' + e._entryText + '\"';
                entryRow += e._entryDateTime + "~|~";
                entryRow += e._givenPrompt + "~|~";
                entryRow += e._entryText;
                //WriteLine(entryRow);
                outputFile.WriteLine(entryRow);
            }
        }
    }

    static void LoadJournalFile()
    {
        workingJournal.Initialize();
        WriteLine("Please provide a file name:");
        string fileName = ReadLine();
        string[] lines = File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            string[] fields = line.Split("~|~");
            Entry e = new Entry();
            e._entryDateTime = fields[0];
            e._givenPrompt = fields[1];
            e._entryText = fields[2];
            workingJournal.AppendEntry(e);
        }
    }

    static void Main(string[] args)
    {
        workingJournal = new Journal();
        workingJournal.Initialize();
        MenuLoop();
    }
}