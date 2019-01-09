using System;

namespace ConsoleApp
{
    public class Dice
    {
        private Random rand = new Random();
        public string SavingThrow(int needed)
        {
            int diceRoll = Roll();
            var ret = $"You roll a {diceRoll}";
            Program.LogThis(this, ret);
            if (diceRoll < needed)
            {
                var ex = new YouLoseException($"{ret}, you die");
                throw ex;
            }
            else
            {
                Program.LogThis(this, "You win the saving throw, you now have root");
            }
            return ret;
        }
        public int Roll()
        {
            return rand.Next(20) + 1;
        }
    }
}