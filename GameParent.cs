using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class GameParent
    {
        private int _score1 = 0;
        private int _score2 = 0;
        private int _roundScore;
        private bool _auto;
        private int _timer;
        protected int Score1 { get; set; }
        protected int Score2 { get; set; }
        protected int RoundScore { get; set; }
        public bool Auto { get; set; }
        protected int Timer { get; set; }
        public GameParent(bool auto, int timer)
        {
            Auto = auto;
            Timer = timer;
        }
        protected List<int> DiceRoll(int dieAmount)
        {
            Die die = new Die();
            List<int> diceRolls = new List<int>();
            for (int i = 0; i<dieAmount; i++)
            {
                diceRolls.Add(die.Roll());
            }
            return diceRolls;
        }
        protected bool UserRolled()
        {
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Roll...");
            Console.ReadLine();
            return true;
        }
    }
}
