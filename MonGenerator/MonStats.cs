namespace MonGenerator
{
    public class MonStats
    {
        private int _level;
        private int _attack;
        private int _hp;
        public int Level { get => _level; private set => _level = value; }
        public int Attack { get => _attack; private set => _attack = value; }
        public int Hp { get => _hp; private set => _hp = value; }
        public MonStats(int initialLevel)
        {
            _level = initialLevel;
            _attack = initialLevel;
            _hp = initialLevel;

        }
    }
}
