using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class ThreeOrMore
    {
        private int _score = 0;
        public int score 
        { 
            get { return _score; } 
            set { _score = value; } 
        }
        private int[] Roll(int dieAmount)
        {
            int[] count = { 0, 0, 0, 0, 0, 0 };
            int i;
            Die die = new Die();
            for (i = 0; i < dieAmount; i++)
            {
                count[die.Roll() - 1]++;
            }
            return count;
        }
        private int RollCount(int[] count, bool automatic, int timer)
        {
            int i;
            int highest = count[0];
            int highestIndex = 0;
            for (i = 0; i < 6; i++)
            {
                Thread.Sleep(timer);
                Console.WriteLine($"You Rolled {count[i]} {i+1}'s");
                if (count[i] > highest)
                {
                    highest = count[i];
                    highestIndex = i;
                }
                if (count[i] == 5)
                {
                    score = score + 12;
                }
                else if (count[i] == 4)
                {
                    score = score + 6;
                }
                else if (count[i] == 3)
                {
                    score = score + 3;
                }
            } // checks for highest count
            if (highest == 2)
            {
                if (!automatic)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Only scored a 2 of a kind, would you like to re-roll all (A) or all remaining (R) die?");
                    Console.WriteLine("");
                    string rollChoice = Console.ReadLine();
                    if (rollChoice == "A")
                    {
                        return RollCount(Roll(5), false, 200);
                    }
                    else if (rollChoice == "R")
                    {
                        int[] tempArray = Roll(3);
                        tempArray[highestIndex] = tempArray[highestIndex] + 2;
                        return RollCount(tempArray, false, 200);
                    }
                }
                else if (automatic)
                {
                    Console.WriteLine("");
                    return RollCount(Roll(5), true, 200);
                }
            }
            return score;
        }
        public int Play(bool automatic, int timer)
        {
            score = 0;
            return RollCount(Roll(5), automatic, timer);
        }
    }
}
