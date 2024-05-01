namespace DiceGame
{     
    /// <summary> Very basic class which functions as a six sided die </summary>
    internal class Die
    {
        private int _value = 0;
        public int Value 
        { 
            get { return _value; } 
            set {  _value = value; } 
        } // holds the value of the roll
        /// <summary> Rolls the die and stores the value to a field </summary>
        /// <returns> The value of the Roll </returns>
        public int Roll()
        {
            Random random = new Random();
            Value = random.Next(1, 7);
            return Value;
        }
    }
}
