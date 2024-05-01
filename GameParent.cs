using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class GameParent
    {
        private int _score = 0;
        private string _name;
        private bool _auto;
        private int _timer;
        public int score { get { return _score; } set { _score = value; }  }
        public string name { get { return _name; } set { _name = value; } }
        public bool auto { get { return _auto; } set { _auto = value; } }
        public int timer { get { return _timer; } set { _timer = value; } }
        public GameParent(string givenName, bool givenAuto, int givenTimer)
        {
            _name = givenName;
            _auto = givenAuto;
            _timer = givenTimer;
        }
        public List<int> DiceRoll(int dieAmount)
        {
            Die die = new Die();
            List<int> diceRolls = new List<int>();
            for (int i = 0; i<dieAmount; i++)
            {
                diceRolls.Add(die.Roll());
            }
            return diceRolls;
        }
        public bool UserRolled()
        {
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Roll...");
            Console.ReadLine();
            return true;
        }
    }
}
