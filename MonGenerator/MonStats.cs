using System;

namespace MonGenerator
{
    public class MonStats
    {
        private int _level;
        private int _attack;
        private int _hp;
        public int Level
        {
            get => _level; private set
            {
                var newValue = IntBetween(value, 1, 100);
                if (newValue != _level)
                {
                    _level = newValue;
                }
                else { }
            }
        }
        public int Attack
        {
            get => _attack; private set
            {
                var newValue = IntBetween(value, 1, 255);
                if (newValue != _level)
                {
                    _attack = newValue;
                }
                else { }
            }
        }
        public int Hp
        {
            get => _hp; private set
            {
                var newValue = IntBetween(value, 1, 255);
                if (newValue != _level)
                {
                    _hp = newValue;
                }
                else { } //-- Maybe do something with this later?
            }
        }
        public MonStats(int initialLevel)
        {
            Level = initialLevel;
            Attack = Level;
            Hp = Level;
        }
        public static int IntBetween(int value, int minimum, int maximum, bool inclusive = true)
        {
            int ret;
            int buffer = 0;
            if (!inclusive) buffer = 1;
            if (value > maximum - buffer) ret = maximum - buffer;
            else if (value < minimum + buffer) ret = minimum + buffer;
            else ret = value;
            return ret;
        }
    }
}
