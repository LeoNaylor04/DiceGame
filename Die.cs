namespace DiceGame
{     internal class Die
    {
        private int _value = 0;
        public int Value 
        { 
            get { return _value; } 
            set {  _value = value; } 
        }
        public int Roll()
        {
            Random random = new Random();
            Value = random.Next(1, 7);
            return Value;
        }
    }
}
