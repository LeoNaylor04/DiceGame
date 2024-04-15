namespace DiceGame
{     internal class Die
    {
        private int _Value = 0;
        public int value 
        { 
            get { return _Value; } 
            set {  _Value = value; } 
        }
        public int Roll()
        {
            Random random = new Random();
            return random.Next(1,7);
        }
    }
}
