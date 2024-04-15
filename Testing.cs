using DiceGame;

internal class Testing
{
    private static void Main(string[] args)
    {
        SevensOut dog = new SevensOut();
        Console.WriteLine($"Sevens Out finished with a total of {dog.Roll()}");
        Console.ReadLine();
    }
}