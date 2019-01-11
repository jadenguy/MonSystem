using System;

namespace Common.Math
{
    public class Dice
    {
        public event EventHandler<string> LoseEvent;
        public event EventHandler<string> WinEvent;
        private Random _rand = new Random();
        public Dice(int? seed = null)
        {
            int rSeed;
            if (seed == null)
            {
                rSeed = (new Random()).Next();
            }
            else
            {
                rSeed = (int)seed;
            }
            _rand = new Random(rSeed);
        }
        public int Roll()
        {
            return _rand.Next(20) + 1;
        }
        public string SavingThrow(int needed)
        {
            int diceRoll = Roll();
            var ret = $"You roll a {diceRoll}, you needed a {needed}";
            if (diceRoll < needed)
            {
                ret = $"{ret}, you die";
                OnLose(this, ret);
            }
            else
            {
                ret = $"{ret}, you win the saving throw, you now have root";
                OnWin(this, ret);
            }
            return ret;
        }

        private void OnWin(Dice dice, string ret)
        {
            WinEvent?.Invoke(this, ret);
        }

        private void OnLose(Dice dice, string ret)
        {
            LoseEvent?.Invoke(this, ret);
        }
    }
}