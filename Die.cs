namespace DiceGame
{     internal class Die
    {
        private int _value = 0;
        public int value 
        { 
            get { return _value; } 
            set {  _value = value; } 
        }
        public int Roll()
        {
            Random random = new Random();
            return random.Next(1,7);
        }
    }
}
