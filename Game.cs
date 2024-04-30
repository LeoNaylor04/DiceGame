using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.WriteLine("4. Exit");
            return Console.ReadLine(); 
        }
        private static void Main(string[] args)
        {
            while (true)
            {
                Statistics gameStatistics = new Statistics();
                gameStatistics.OpenFile();
                int score;
                string selection = ChooseGame();
                if (selection=="1")
                {
                    gameStatistics.OutputStats();
                }
                if (selection == "2")
                {
                    SevensOut gameSevensOut = new SevensOut();
                    score = gameSevensOut.Roll();
                    Console.WriteLine($"Sevens Out Finished with a score of {score}");
                    gameStatistics.sevensOut[0] = gameStatistics.sevensOut[0] + score;
                    gameStatistics.sevensOut[1]++;
                    if (score > gameStatistics.sevensOut[2])
                    {
                        gameStatistics.sevensOut[2] = score;
                    }
                }
                if (selection == "3")
                {
                    ThreeOrMore gameThreeOrMore = new ThreeOrMore();
                    score = gameThreeOrMore.Play();
                    Console.WriteLine($"Three or More Finished with a score of {score}");
                    gameStatistics.threeOrMore[0] = gameStatistics.threeOrMore[0] + score;
                    gameStatistics.threeOrMore[1]++;
                    if (score > gameStatistics.threeOrMore[2])
                    {
                        gameStatistics.threeOrMore[2] = score;
                    }
                }
                if (selection == "4")
                {
                    break;
                }
            }
        }
    }
}
