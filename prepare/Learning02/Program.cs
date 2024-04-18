using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        Job job1 = new Job();
        job1._company = "7-Eleven";
        job1._jobTitle = "Clerk";
        job1._startYear = 1990;
        job1._endYear = 1992;
        job1.Display();

        Job job2 = new Job();
        job2._company = "DU";
        job2._jobTitle = "Teaching Assistant";
        job2._startYear = 1994;
        job2._endYear = 1996;
        job2.Display();

        Resume resume1 = new Resume();
        resume1._name = "C";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);
        //Console.WriteLine($"{resume1._jobs[0]._jobTitle}");
        resume1.Display();
    }
}