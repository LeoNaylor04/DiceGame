﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    internal class SevensOut
    {
        private int _total = 0;
        public int total 
        { 
            get { return _total; } 
            set { _total = value; } 
        }
        public int Roll()
        {
            total = 0;
            Die die = new Die();
            while (true)
            {
                die.value = die.Roll();
                Console.WriteLine($"You rolled a {die.value}");
                int tempTotal = die.value;
                die.value = die.Roll();
                Console.WriteLine($"You rolled a {die.value}");
                if (tempTotal == die.value)
                {
                    Console.WriteLine("You rolled a double! ");
                    total = total + 2 * (tempTotal + die.value);
                }
                else
                {
                    total = total + tempTotal + die.value;
                }
                if (tempTotal + die.value == 7)
                {
                    return total;
                }
                Console.WriteLine("");
                Thread.Sleep(1000);
            }

        }

    }
}
