using DiceGame;
using System.Diagnostics;
using System.Diagnostics.Metrics;

internal class Testing
{
    private int _amount;
    private int Amount {  get; set; }
    public Testing(int amount)
    {
        Amount = amount;
    }
    public void DieTest()
    {
        Die testingDie = new Die();
        int count = 0;
        while (count < Amount) 
        {
            testingDie.Roll();
            Debug.Assert(testingDie.Value < 7 && testingDie.Value>0);
            count++;
        }
        Console.WriteLine($"{count} tests ran with no failure");
        Console.WriteLine("");
    }


}