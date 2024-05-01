using DiceGame;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Reflection;

internal class Testing
{
    private int _amount;
    private int Amount {  get; set; }
    public Testing(int amount)
    {
        Amount = amount;
    }
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
    private void AddToFile(string testName)
    {
        string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", "TestLog.txt");
        File.AppendAllText(filePath, $"{testName} {Amount}" + Environment.NewLine);
    }
}