using System;
using Repository;

namespace MonGenerator
{
    public class MonType : IEntity
    {
        private string _speciesName;
        private int _attack;
        private int _hp;
        public string SpeciesName { get => _speciesName; set => _speciesName = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Hp { get => _hp; set => _hp = value; }
        public MonType(string speciesName, int id, int attack, int hp)
        {
            SpeciesName = speciesName;
            Id = id;
            Attack = attack;
            Hp = hp;
        }
        public bool Validate()
        {
            var ret = false;
            if (Id >= 0)
                ret = true;
            return ret;
        }
    }
}