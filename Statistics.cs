using System.Reflection;

namespace DiceGame
{
    internal class Statistics
    {
        private int[] _threeOrMore = {0, 0, 0};
        public int[] threeOrMore
        {
            get { return _threeOrMore; }
            set { _threeOrMore = value; }
        }
        
        private int[] _sevensOut = {0, 0, 0};
        public int[] sevensOut
        {
            get { return _sevensOut; }
            set { _sevensOut = value; }
        }

        public void OpenFile()
        {
            string filePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("bin\\Debug\\net8.0","Stats.txt");
            StreamReader statsFile = new StreamReader(filePath);
            string statsLine = statsFile.ReadLine();
            string[] statsArray = statsLine.Split(" ");
            int[] statsData = new int[6];
            for (int i = 0; i < 3; i++)
            {
                threeOrMore[i] = int.Parse(statsArray[i]);
            }
            for (int i = 0; i < 3; i++)
            {
                sevensOut[i] = int.Parse(statsArray[i]);
            }
            statsFile.Close();


        }
        public void OutputStats()
        {
            Console.WriteLine("What game would you like to see the statistics for");
            Console.WriteLine("1. Sevens Out");
            Console.WriteLine("2. Three or More");
            string gameName = Console.ReadLine();
            if (gameName == "1")
            {
                Console.WriteLine($"The Number of Plays is {sevensOut[1]}");
                Console.WriteLine($"The Highest Score is {sevensOut[2]}");
                if (sevensOut[1] == 0)
                {
                    sevensOut[1] = 1;
                }
                Console.WriteLine($"The Average Score is {sevensOut[0] / sevensOut[1]}");
            }
            if (gameName == "2")
            {
                Console.WriteLine($"The Number of Plays is {threeOrMore[1]}");
                Console.WriteLine($"The Highest Score is {threeOrMore[2]}");
                if (threeOrMore[1] == 0)
                {
                    threeOrMore[1] = 1;
                }
                Console.WriteLine($"The Average Score is {threeOrMore[0] / threeOrMore[1]}");
            }
        }
    }
}
