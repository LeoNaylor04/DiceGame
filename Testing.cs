using DiceGame;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;
/// <summary> Class where testing of the other classes occurs </summary>
internal class Testing
{
    private int _amount;
    private int Amount {  get; set; } //amount of tests to be ran
    /// <summary> Constructor method called in Main() </summary>
    /// <param> amount of tests to be ran </param>
    public Testing(int amount) 
    {
        Amount = amount; 
    }
    /// <summary> runs a test on the die class </summary>
    /// <remarks> 
    /// Instantiates a die object, uses Debug.Assert to test
    /// Ends testing after "Amount" trials
    /// </remarks>
    private void DieTest()
    {
        Die testingDie = new Die();
        int count = 0;
        while (count < Amount) 
        {
            testingDie.Roll();
            Debug.Assert(testingDie.Value < 7 && testingDie.Value>0);
            count++;
        }
        Console.WriteLine($"{count} die tests ran with no failure");
        Console.WriteLine("");
    }
    /// <summary> runs a test on the SevensOut class </summary>
    /// <remarks> 
    /// Instantiates a SevensOut object, uses Debug.Assert to test
    /// Plays SevensOut as both players being computers with 0 time delay
    /// Needs RoundScore to not be protected in the parent class for this to work
    /// Needs PlayGame to be public for this to work
    /// Ends testing after "Amount" trials
    /// </remarks>
    private void SumTest()
    {
        SevensOut testingSevens = new SevensOut(true, 0);
        int count = 0;
        while (count < Amount)
        {
            testingSevens.PlayGame(true);
            Debug.Assert(testingSevens.RoundScore == 7);
            count++;
        }
        Console.WriteLine($"{count} sum tests ran with no failure");
        Console.WriteLine("");
    }
    /// <summary> Menu which is brought up for the user to run testing class methods </summary>
    /// <remarks> 
    /// Ran from Main(), Validates input so user is not booted back to Main()
    /// </remarks>
    public void TestMenu()
    {
        string input = "";
        while (true)
        {
            Console.WriteLine("Test Menu");
            Console.WriteLine("1. Run Die Test");
            Console.WriteLine("2. Run Sum Test");
            Console.WriteLine("3. Open Test Log");
            Console.WriteLine("");
            List<string> list = new() { "1", "2", "3"};
            input = Console.ReadLine();
            if (list.Contains(input)) { break; }
            else { Console.WriteLine("Invalid input"); }
        }
        if (input=="1")
        {
            DieTest();
            AddToFile("DieTest");
        }
        if (input=="2")
        {
            SumTest();
            AddToFile("SumTest");
        }
        if (input=="3")
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", "TestLog.txt");
            StreamReader TestLogRead = new StreamReader(filePath);
            int fileLength = File.ReadLines(filePath).Count();
            for (int i=0; i<fileLength; i++)
            {
                Console.WriteLine(TestLogRead.ReadLine());
            }
            Console.WriteLine("");
            TestLogRead.Close();
        }
    }
    /// <summary> Adds the most recent test to the TestLog.txt file </summary>
    /// <param> name of the test ran </param>
    /// <remarks> amount of tests ran is known, file is appended </remarks>
    private void AddToFile(string testName)
    {
        string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", "TestLog.txt");
        File.AppendAllText(filePath, $"{testName} {Amount}" + Environment.NewLine);
    }
}