using System.Collections.Generic;
using System.Reflection;

namespace DiceGame
{
    internal class Statistics
    {
        private int[] _threeOrMore = {0, 0};
        public int[] threeOrMore { get { return _threeOrMore; } set { _threeOrMore = value; } }
        private int[] _sevensOut = {0, 0};
        public int[] sevensOut { get { return _sevensOut; } set {_sevensOut=value; } }
        public void OpenFile()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0","Stats.txt");
            StreamReader statsFile = new StreamReader(filePath);
            string statsLine = statsFile.ReadLine();
            string[] statsArray = statsLine.Split(" ");
            for (int i = 0; i < 2; i++)
            {
                threeOrMore[i] = int.Parse(statsArray[i]);
            }
            for (int i = 0; i < 2; i++)
            {
                sevensOut[i] = int.Parse(statsArray[2+i]);
            }
            statsFile.Close();


        }
        public void OutputStats()
        {
            string gameName = "";
            while (true)
            {
                Console.WriteLine("What game would you like to see the statistics for");
                Console.WriteLine("1. Sevens Out");
                Console.WriteLine("2. Three or More");
                Console.WriteLine("");
                gameName = Console.ReadLine();
                List<string> list = new() {"1", "2" };
                if (list.Contains(gameName)) { break; }
                else { Console.WriteLine("Invalid input"); }
            }

            if (gameName == "1")
            {
                Console.WriteLine($"The Number of Plays is {sevensOut[1]}");
                if (sevensOut[1] == 0)
                {
                    sevensOut[1] = 1;
                    Console.WriteLine($"The Average Score is {sevensOut[0] / sevensOut[1]}");
                    sevensOut[1] = 0;
                }
                else
                {
                    Console.WriteLine($"The Average Score is {sevensOut[0] / sevensOut[1]}");
                }
                Console.WriteLine("");
                Console.WriteLine("High Scores:");
                OutputScoreboard("SevensOutScoreboard.txt");
                Console.WriteLine("");
                
            }
            if (gameName == "2")
            {
                Console.WriteLine($"The Number of Plays is {threeOrMore[1]}");
                if (threeOrMore[1] == 0)
                {
                    threeOrMore[1] = 1;
                    Console.WriteLine($"The Average Score is {threeOrMore[0] / threeOrMore[1]}");
                    threeOrMore[1] = 0;
                }
                else
                {
                    Console.WriteLine($"The Average Score is {threeOrMore[0] / threeOrMore[1]}");
                }
                Console.WriteLine("");
                Console.WriteLine("High Scores:");
                OutputScoreboard("ThreeOrMoreScoreboard.txt");
                Console.WriteLine("");
            }
        }
        public void SaveStats()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", "Stats.txt");
            StreamWriter statsFile = new StreamWriter(filePath);
            string fileLine = $"{threeOrMore[0]} {threeOrMore[1]} {sevensOut[0]} {sevensOut[1]}";
            statsFile.WriteLine(fileLine);
            statsFile.Close();

        }
        public void AddToScoreboard(string boardName, int score)
        {
            string name = "";
            while (true)
            {
                Console.WriteLine("Please enter your name for the Scoreboard");
                name = Console.ReadLine();
                if (name.Split(" ").Length > 1)
                {
                    Console.WriteLine("Name must be one word");
                }
                else if (name != "") { break; }
            }
            int i, j;
            string[] nameArray = new string[10];
            int[] scoreArray = new int[10];
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", boardName);
            StreamReader scoreboard = new StreamReader(filePath);
            for (i = 0; i<10; i++)
            {
                string[] line = scoreboard.ReadLine().Split(" ");
                nameArray[i] = line[0];
                scoreArray[i] = int.Parse(line[1]);
            }
            for (i = 0; i<10; i++)
            {
                if (score > scoreArray[i])
                {
                    for (j=9; j>i; j--)
                    {
                        scoreArray[j] = scoreArray[j - 1];
                        nameArray[j] = nameArray[j - 1];
                    }
                    scoreArray[i] = score;
                    nameArray[i] = name;
                    break;
                }
            }
            scoreboard.Close();
            StreamWriter scoreboardWriting = new StreamWriter(filePath);
            for (i = 0; i<10; i++)
            {
                string line = $"{nameArray[i]} {scoreArray[i]}";
                scoreboardWriting.WriteLine(line);
            }
            scoreboardWriting.Close();
        }
        public void OutputScoreboard(string boardName)
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0", boardName);
            StreamReader leaderboard = new StreamReader(filePath);
            for (int i=0; i<10; i++)
            {
                Console.WriteLine($"{i+1}.{leaderboard.ReadLine()}");
            }
            leaderboard.Close();
        }
        public void AddSevens(int score)
        {
            sevensOut[0] += score;
            sevensOut[1]++;
            AddToScoreboard("SevensOutScoreBoard.txt", score);
        }
        public void AddThree(int score)
        {
            threeOrMore[0] += score;
            threeOrMore[1]++;
            AddToScoreboard("ThreeOrMoreScoreboard.txt", score);
        }
    }
}
