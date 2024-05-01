using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DiceGame
{
    /// <summary>
    /// Class is a child of GameParent and has the IPlayable interface
    /// Check GameParent for more info on some properties
    ///</summary>
    internal class ThreeOrMore : GameParent, IPlayable
    {
        public ThreeOrMore(bool Auto, int Timer) : base(Auto, Timer) { } //inherits constructor
        /// <summary>
        /// Welcome message from GameParent overriden for ThreeOrMore
        /// </summary>
        public override void WelcomeMessage()
        {
            Console.WriteLine("Welcome to Three or more!");
            Console.WriteLine("");
        }
        /// <summary> Main function where the game is played </summary>
        /// <remarks> Follows IPlayable interface, Executes all class methods </remarks>
        /// <param> Shows if there is a computer opponent or not</param>
        /// <returns> The winners score </returns>
        public int PlayGame(bool computer)
        {
            WelcomeMessage();
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
        /// <summary> The dice rolling part of the game </summary>
        /// <remarks> Is either automated or asked for user interaction </remarks>
        /// <param> The amount of die to be rolled as it does vary </param>
        /// <returns> A tally of which faces were rolled </returns>
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
        /// <summary> Counts the tally to check what score the player should gain </summary>
        /// <param> Takes the tally as needs to count it </param>
        /// <remarks> There is a user choice to roll 3 or 5 die if function repeats and computer will always roll 3 </remarks>
        /// <returns> The score for the round OR Runs turn from the begining </returns>
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
                        return GameTurnTally(GameTurn(5)); //runs the game again
                    }
                    else if (rollChoice == "R")
                    {
                        List<int> newTally = GameTurn(3);
                        newTally[maximumIndex] = newTally[maximumIndex] + 2;
                        return GameTurnTally(newTally); //runs the game again with 3 random die and a pre-existing 2 of a kind
                    }
                    else
                    {
                        Console.WriteLine("Roll fumbled"); //decided it would be funnier to not validate this error
                    }
                }
                else
                {
                    List<int> newTally = GameTurn(3);
                    newTally[maximumIndex] = newTally[maximumIndex] + 2;
                    return GameTurnTally(newTally); //runs the game again with 3 random die and a pre-existing 2 of a kind
                }
            }
            return RoundScore;
        }
    }
}
