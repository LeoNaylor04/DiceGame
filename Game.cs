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
            string input = "";
            while (true)
            {
                Console.WriteLine("Would you like to play against the computer (C) or another player (P) ?");
                Console.WriteLine("");
                List<string> list = new() { "c", "C", "p", "P" };
                input = Console.ReadLine();
                if (list.Contains(input)) { break; }
                else { Console.WriteLine("Invalid input"); }
            }
            return input;
        }
        private static void Main(string[] args)
        {
            SevensOut sevensOutPlayer = new SevensOut(false, 1000);
            ThreeOrMore threeOrMorePlayer = new ThreeOrMore(false, 1000);
            Statistics gameStatistics = new Statistics();
            gameStatistics.OpenFile();
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
                    if (playerChoice == "C") { sevensOutPlayer.Auto=true; }
                    else if (playerChoice == "P") { sevensOutPlayer.Auto=false; }
                    gameStatistics.AddSevens(sevensOutPlayer.PlayGame(false));
                }
                if (selection == "3")
                {
                    string playerChoice = ChooseOpponent();
                    if (playerChoice == "C") { threeOrMorePlayer.Auto = true; }
                    else if (playerChoice == "P") { threeOrMorePlayer.Auto = false; }
                    gameStatistics.AddThree(threeOrMorePlayer.PlayGame(threeOrMorePlayer.Auto));
                }
                if (selection == "4")
                {
                    gameStatistics.SaveStats();
                    break;
                }
                if (selection == "5")
                {
                    Console.WriteLine("How many tests would you like to run? (note more tests take longer)");
                    try 
                    { 
                        int number = int.Parse(Console.ReadLine()); 
                        if (number > 0)
                        {
                            Testing gameTesting = new Testing(number);
                            gameTesting.TestMenu();
                        }
                    } 
                    catch { Console.WriteLine("Entry must be a number"); }
                }
            }
        }
    }
}
