using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class SevensOut : GameParent
    {
        public SevensOut(bool auto, int timer) : base(auto, timer) { }
        public int PlayGame()
        {
            while (true)
            {
                RoundScore = 0;
                if (Auto)
                {
                    Console.WriteLine("");
                    Thread.Sleep(Timer);
                }
                else if (UserRolled()) { }
                RoundScore = GameTurn();
                Score += RoundScore;
                if (RoundScore == 7)
                {
                    break;
                }
            }
            return Score;
        }
        private int GameTurn()
        {
            List<int> roll = DiceRoll(2);
            IEnumerable<int> output = roll;
            int total = 0;
            foreach (int i in output)
            {
                Console.WriteLine($"You rolled a {i}");
                total += i;
            }
            if (total - roll[0] == roll[1])
            {
                Console.WriteLine("You rolled a double! ");
                return total * 2;
            }
            return total;
        }
    }
}
