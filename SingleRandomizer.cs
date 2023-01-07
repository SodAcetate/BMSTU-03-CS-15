namespace Lab_15_3
{
    class SingleRandomizer
    {
        private static SingleRandomizer instance;
        private Random random;
        private SingleRandomizer()
        {
            random = new();
        }
        public static SingleRandomizer Instance()
        {
            if (instance == null) instance = new SingleRandomizer();
            return instance;
        }
        public int Next(){
            return random.Next();
        }
    }
}