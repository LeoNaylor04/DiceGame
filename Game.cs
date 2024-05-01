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
            int playerScore1 = sevensOutPlayer.Roll(false, 1000);
            Console.WriteLine($"Player 1 finished Sevens Out with a score of {playerScore1}");
            Console.WriteLine("");
            Console.WriteLine($"{player2}'s Turn");
            int playerScore2 = 0;
            if (player2 == "Computer")
            {
                playerScore2 = sevensOutPlayer.Roll(true, 1000);
            }
            else if (player2 == "Player 2")
            {
                playerScore2 = sevensOutPlayer.Roll(false, 1000);
            }
            Console.WriteLine($"{player2} finished Sevens Out with a score of {playerScore2}");
            Console.WriteLine("");
            if (playerScore1 > playerScore2)
            {
                SevensOutWinMessage(gameStatistics, "Player 1", playerScore1);
            }
            else if (playerScore2 > playerScore1)
            {
                SevensOutWinMessage(gameStatistics, player2, playerScore2);
            }
            else
            {
                Console.WriteLine("Tie Game");
                gameStatistics.sevensOut[0] = gameStatistics.sevensOut[0] + playerScore1;
                gameStatistics.sevensOut[1]++;
                Console.WriteLine("");
            }
        }
        private static void SevensOutWinMessage(Statistics gameStatistics, string identity, int score)
        {
            Console.WriteLine($"{identity} wins with a score of {score}!");
            gameStatistics.sevensOut[0] = gameStatistics.sevensOut[0] + score;
            gameStatistics.sevensOut[1]++;
            if (identity != "Computer")
            {
                while (true)
                {
                    Console.WriteLine("Enter your name to be added to the leaderboard");
                    string name = Console.ReadLine();
                    if (name != "")
                    {
                        string[] nameArray = name.Split(" ");
                        if (nameArray.Length != 1)
                        {
                            Console.WriteLine("Name must be one word");
                        }
                        else
                        {
                            gameStatistics.AddToLeaderboard("SevensOutLeaderboard.txt", name, score);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a name");
                    }
                }
            }
            Console.WriteLine("");
        }
        private static void ThreeOrMorePlay(Statistics gameStatistics, ThreeOrMore threeOrMorePlayer, string player2)
        {
            int playerScore2 = 0;
            int playerScore1 = 0;
            int tempScore = 0;
            while (true)
            {
                Console.WriteLine("Player 1's Turn");
                tempScore = threeOrMorePlayer.Play(false, 200);
                Console.WriteLine($"Player 1 finished their turn with a score of {tempScore}");
                playerScore1 += tempScore;
                if (playerScore2 >= 20)
                {
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine($"{player2}'s Turn");

                if (player2 == "Computer")
                {
                    tempScore = threeOrMorePlayer.Play(true, 200);
                }
                else if (player2 == "Player 2")
                {
                    tempScore = threeOrMorePlayer.Play(false, 200);
                }
                Console.WriteLine($"{player2} finished their turn with a score of {tempScore}");
                playerScore2+= tempScore;
                if (playerScore2 >= 20)
                {
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine($"Current score is Player 1: {playerScore1} {player2}:{playerScore2}");
                Console.WriteLine("");
            }
            if (playerScore1 > playerScore2)
            {
                ThreeOrMoreWinMessage(gameStatistics, "Player 1", playerScore1);
            }
            else if (playerScore2 > playerScore1)
            {
                ThreeOrMoreWinMessage(gameStatistics, player2, playerScore2);
            }
            else
            {
                Console.WriteLine("Tie Game!");
                gameStatistics.threeOrMore[0] = gameStatistics.threeOrMore[0] + playerScore1;
                gameStatistics.threeOrMore[1]++;
                Console.WriteLine("");
            }
        }
        private static void ThreeOrMoreWinMessage(Statistics gameStatistics, string identity, int score)
        {
            Console.WriteLine($"{identity} wins with a score of {score}!");
            gameStatistics.threeOrMore[0] = gameStatistics.threeOrMore[0] + score;
            gameStatistics.threeOrMore[1]++;
            if (identity != "Computer")
            {
                while (true)
                {
                    Console.WriteLine("Enter your name to be added to the leaderboard");
                    string name = Console.ReadLine();
                    if (name != "")
                    {
                        string[] nameArray = name.Split(" ");
                        if (nameArray.Length != 1)
                        {
                            Console.WriteLine("Name must be one word");
                        }
                        else
                        {
                            gameStatistics.AddToLeaderboard("ThreeOrMoreLeaderboard.txt", name, score);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a name");
                    }
                }
            }
            Console.WriteLine("");
        }
        private static void Main(string[] args)
        {
            Statistics gameStatistics = new Statistics();
            gameStatistics.OpenFile();
            SevensOut sevensOutPlayer = new SevensOut("die", false, 3);
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
                    gameTesting.TestSevensOut(1000);
                    gameTesting.TestThreeOrMore(1000);
                }
            }
        }
    }
}
