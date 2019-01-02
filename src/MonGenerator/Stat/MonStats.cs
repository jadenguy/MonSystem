using System;
using Common.Math;

namespace MonGenerator.Stats
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
                var newValue = InRange(value, MonStatRanges.levelMin, MonStatRanges.levelMax);
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
                var newValue = InRange(value, MonStatRanges.attackMin, MonStatRanges.attackMax);
                if (newValue != _attack)
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
                var newValue = InRange(value, MonStatRanges.hpMin, MonStatRanges.hpMax);
                if (newValue != _hp)
                {
                    _hp = newValue;
                }
                else { } //-- Maybe do something with this later?
            }
        }
        public MonStats(int initialLevel = (int)MonStatRanges.levelMin)
        {
            Level = initialLevel;
            Attack = Level;
            Hp = Level;
        }

        public static int InRange(int value, MonStatRanges minimum, MonStatRanges maximum)
        {
            return value.InBetweenII((int)minimum, (int)maximum);
        }

    }
}
