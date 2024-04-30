using DiceGame;
using System.Diagnostics;

internal class Testing
{
    public void TestSevensOut(int amount)
    {
        SevensOut testSevens = new SevensOut();
        for (int i = 0; i < amount; i++)
        {
            Debug.Assert(testSevens.Roll(true, 0)>=7);
        }
    }
    public void TestThreeOrMore(int amount)
    {
        ThreeOrMore testThree = new ThreeOrMore();

    }
}