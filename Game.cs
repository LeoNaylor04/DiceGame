using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DiceGame
{
    internal class Game
    {
        private static string ChooseGame()
        {
            Console.WriteLine("Would you like to choose");
            Console.WriteLine("1. Statistics");
            Console.WriteLine("2. Sevens Out");
            Console.WriteLine("3. Three or More");
            Console.WriteLine("4. Save and Exit");
            Console.WriteLine("5. Testing");
            Console.WriteLine("");
            return Console.ReadLine(); 
        }
        private static string ChooseOpponent()
        {
            Console.WriteLine("Would you like to play against the computer (C) or another player (P) ?");
            Console.WriteLine("");
            return Console.ReadLine();
        }
        private static void SevensOutPlay(Statistics gameStatistics, SevensOut sevensOutPlayer, string player2)
        {
            Console.WriteLine("Player 1's Turn");
            int playerScore1 = sevensOutPlayer.Roll();
            Console.WriteLine($"Player 1 finished Sevens Out with a score of {playerScore1}");
            Console.WriteLine("");
            Console.WriteLine($"{player2}'s Turn");
            int playerScore2 = sevensOutPlayer.Roll();
            Console.WriteLine($"{player2} finished Sevens Out with a score of {playerScore2}");
            Console.WriteLine("");
            if (playerScore1 > playerScore2)
            {
                SevensOutWinMessage(gameStatistics, "Player 1", playerScore1);
            }
            else if (playerScore1 > playerScore2)
            {
                SevensOutWinMessage(gameStatistics, player2, playerScore2);
            }
        }
        private static void SevensOutWinMessage(Statistics gameStatistics, string identity, int score)
        {
            Console.WriteLine($"{identity} wins with a score of {score}!");
            gameStatistics.sevensOut[0] = gameStatistics.sevensOut[0] + score;
            gameStatistics.sevensOut[1]++;
            if (score > gameStatistics.sevensOut[2])
            {
                gameStatistics.sevensOut[2] = score;
            }
            Console.WriteLine("");
        }
        private static void ThreeOrMorePlay(Statistics gameStatistics, ThreeOrMore threeOrMorePlayer, string player2)
        {
            Console.WriteLine("Player 1's Turn");
            int playerScore1 = threeOrMorePlayer.Play();
            Console.WriteLine($"Player 1 finished Sevens Out with a score of {playerScore1}");
            Console.WriteLine("");
            Console.WriteLine($"{player2}'s Turn");
            int playerScore2 = threeOrMorePlayer.Play();
            Console.WriteLine($"{player2} finished Sevens Out with a score of {playerScore2}");
            Console.WriteLine("");
            if (playerScore1 > playerScore2)
            {
                ThreeOrMoreWinMessage(gameStatistics, "Player 1", playerScore1);
            }
            else if (playerScore1 > playerScore2)
            {
                ThreeOrMoreWinMessage(gameStatistics, player2, playerScore2);
            }
        }
        private static void ThreeOrMoreWinMessage(Statistics gameStatistics, string identity, int score)
        {
            Console.WriteLine($"{identity} wins with a score of {score}!");
            gameStatistics.threeOrMore[0] = gameStatistics.threeOrMore[0] + score;
            gameStatistics.threeOrMore[1]++;
            if (score > gameStatistics.threeOrMore[2])
            {
                gameStatistics.threeOrMore[2] = score;
            }
            Console.WriteLine("");
        }
        private static void Main(string[] args)
        {
            Statistics gameStatistics = new Statistics();
            gameStatistics.OpenFile();
            SevensOut sevensOutPlayer = new SevensOut();
            ThreeOrMore threeOrMorePlayer = new ThreeOrMore();
            Testing gameTesting = new Testing();
            while (true)
            {
                string selection = ChooseGame();
                if (selection=="1")
                {
                    gameStatistics.OutputStats();
                }
                if (selection == "2")
                {
                    string playerChoice = ChooseOpponent();
                    if (playerChoice == "C")
                    {
                        SevensOutPlay(gameStatistics, sevensOutPlayer, "Computer");
                    }
                    else if (playerChoice == "P")
                    {
                        SevensOutPlay(gameStatistics, sevensOutPlayer, "Player 2");
                    }
                }
                if (selection == "3")
                {
                    string playerChoice = ChooseOpponent();
                    if (playerChoice == "C")
                    {
                        ThreeOrMorePlay(gameStatistics, threeOrMorePlayer, "Computer");
                    }
                    else if (playerChoice == "P")
                    {
                        ThreeOrMorePlay(gameStatistics, threeOrMorePlayer, "Player 2");
                    }
                }
                if (selection == "4")
                {
                    gameStatistics.SaveStats();
                    break;
                }
                if (selection == "5")
                {

                }
            }
        }
    }
}
