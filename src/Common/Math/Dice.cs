using System;

namespace Common.Math
{
    public class Dice
    {
        public event EventHandler LoseEvent;
        public event EventHandler WinEvent;
        private Random _rand = new Random();
        public Dice(int seed)
        {
            _rand = new Random(seed);
        }
        public Dice()
        {
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
                OnLose();
            }
            else
            {
                ret = $"{ret}, you win the saving throw, you now have root";
                OnWin();
            }
            return ret;
        }

        private void OnWin()
        {
            WinEvent?.Invoke(this, EventArgs.Empty);
        }

        private void OnLose()
        {
            LoseEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}