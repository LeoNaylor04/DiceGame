using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    /// <summary>
    /// Class is a child of GameParent and has the IPlayable interface
    /// Check GameParent for more info on some properties
    ///</summary>
    internal class SevensOut : GameParent, IPlayable
    {
        public SevensOut(bool auto, int timer) : base(auto, timer) { } //inherits constructor
        /// <summary>
        /// Welcome message from GameParent overriden for SevensOut
        /// </summary>
        public override void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Sevens Out");
            Console.WriteLine("");
        }
        /// <summary> Main function where the game is played </summary>
        /// <remarks> 
        /// Follows IPlayable interface, Executes all class methods, Contains user interaction
        /// Game is not played simultaneously so have to be two loops 
        /// </remarks>
        /// <param> Shows if there is a computer opponent or not</param>
        /// <returns> The winners score </returns>
        public int PlayGame(bool computer)
        {
            WelcomeMessage();
            Score1 = 0;
            Score2 = 0;
            while (true)
            {
                RoundScore = 0;
                if (computer)
                {
                    if (Auto) { Thread.Sleep(Timer); Console.WriteLine(""); }
                    else if (UserRolled()) { }
                }
                else { UserRolled(); }
                RoundScore = GameTurn();
                Score1 += RoundScore;
                Console.WriteLine($"Player 1's score is {Score1}");
                if (RoundScore == 7)
                {
                    Console.WriteLine($"Player 1 is out with a score of {Score1}");
                    break;
                }
            }
            while (true)
            {
                RoundScore = 0;
                if (Auto) { Thread.Sleep(Timer); Console.WriteLine(""); }
                else if (UserRolled()) { }
                RoundScore = GameTurn();
                Score2 += RoundScore;
                Console.WriteLine($"Player 2's score is {Score2}");
                if (RoundScore == 7)
                {
                    Console.WriteLine($"Player 2 is out with a score of {Score2}");
                    break;
                }
            }
            if (Score1>=Score2)
            {
                return Score1;
            }
            else
            {
                return Score2;
            }
        }
        /// <summary> Contains the main functionality of the game </summary>
        /// <returns> Score gained that round </returns>
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
            if (total - roll[0] == roll[0])
            {
                Console.WriteLine("You rolled a double! ");
                return total * 2;
            }
            return total;
        }
    }
}
