using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DiceGame
{
    internal class ThreeOrMore : GameParent
    {
        public ThreeOrMore(bool Auto, int Timer) : base(Auto, Timer) { }
        public int PlayGame(bool computer)
        {
            Score1 = 0;
            Score2 = 0;
            while (true)
            {
                Auto = false;
                Score1 += GameTurnTally(GameTurn(5));
                Console.WriteLine($"Player 1's score is {Score1}");
                if (computer) { Auto  = true; }
                Score2 += GameTurnTally(GameTurn(5));
                Console.WriteLine($"Player 2's score is {Score2}");
                if (Score1>19)
                {
                    Console.WriteLine($"Player 1 Wins with a score of {Score1}!");
                    return Score1;
                }
                if (Score2 > 19)
                {
                    Console.WriteLine($"Player 2 Wins with a score of {Score2}!");
                    return Score2;
                }
            }
        }
        private List<int> GameTurn(int dieAmount)
        {
            if (Auto) { Thread.Sleep(Timer); Console.WriteLine(""); }
            else if (UserRolled()) { }
            List<int> roll = DiceRoll(dieAmount);
            IEnumerable<int> output = roll;
            List<int> tally = new() { 0, 0, 0, 0, 0, 0 };
            foreach (int i in output)
            {
                tally[i - 1]++;
            }
            return tally;
        }
        private int GameTurnTally(List<int> tally)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine($"You have {tally[i]} {i+1}'s");
            }
            RoundScore = 0;
            int maximum = tally.Max();
            int maximumIndex = tally.IndexOf(maximum);
            Console.WriteLine($"You rolled a {maximum} of a kind");
            if (maximum == 5) { RoundScore = 12; }
            if (maximum == 4) { RoundScore = 6; }
            if (maximum == 3) { RoundScore = 3; }
            if (maximum == 2)
            {
                if (!Auto)
                {
                    Console.WriteLine("");
                    Console.WriteLine("You only rolled a 2 of a kind, would you like to re-roll all (A) or all remaining (R) die?");
                    Console.WriteLine("");
                    string rollChoice = Console.ReadLine();
                    if (rollChoice == "A")
                    {
                        return GameTurnTally(GameTurn(5));
                    }
                    else if (rollChoice == "R")
                    {
                        List<int> newTally = GameTurn(3);
                        newTally[maximumIndex] = newTally[maximumIndex] + 2;
                        return GameTurnTally(newTally);
                    }
                    else
                    {
                        Console.WriteLine("Roll fumbled");
                    }
                }
                else
                {
                    List<int> newTally = GameTurn(3);
                    newTally[maximumIndex] = newTally[maximumIndex] + 2;
                    return GameTurnTally(newTally);
                }
            }
            return RoundScore;
        }
    }
}
