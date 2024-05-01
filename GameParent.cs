using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    /// <summary> Interface which shows that all child game classes will be playable </summary>
    /// <remarks> Shows playing games will return an int (winning score)</remarks>
    /// <param> Shows that cames can be played with computer opponent or not </param>
    interface IPlayable
    {
        public int PlayGame(bool computer);
    }
    /// <summary>
    /// GameParent is an abstract class which is a framework for the other two game classes to be inherited from
    /// </summary>
    internal abstract class GameParent
    {
        private int _score1 = 0;
        private int _score2 = 0;
        private int _roundScore;
        private bool _auto;
        private int _timer;
        protected int Score1 { get; set; } //holds player 1s score
        protected int Score2 { get; set; } //holds player 2s score
        public int RoundScore { get; set; } //holds the score gained in one turn
        public bool Auto { get; set; } //holds whether player 2 should be automated or not
        protected int Timer { get; set; } //holds length of the automated turn

        /// <summary> Parent class constructor </summary>
        /// <param> Timer length and True/False for Computer play </param>
        public GameParent(bool auto, int timer)
        {
            Auto = auto;
            Timer = timer;
        }
        /// <summary> Rolls a specified mumber of die objects </summary>
        /// <remarks> Function is inherited in both child game classes </remarks>
        /// <param> The amount of die objects to be rolled </param>
        /// <returns> List contain multiple die rolls (1-6) </returns>
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
        /// <summary> Function for user interaction in die games </summary>
        /// <remarks> Function is inherited in both child die games </remarks>
        /// <returns> Always returns true </returns>
        protected bool UserRolled()
        {
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Roll...");
            Console.ReadLine();
            return true;
        }
        /// <summary> Displays a welcome message </summary>
        /// <remarks> Abstract method which is overriden in child classes </remarks>
        public abstract void WelcomeMessage();
    }
}
