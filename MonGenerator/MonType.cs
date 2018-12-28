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
        public int StatSum => Attack + Hp;
        public MonType(string speciesName, int id, int attack, int hp)
        {
            SpeciesName = speciesName;
            Id = id;
            Attack = attack;
            Hp = hp;
        }
        public bool Validate()
        {
            var idValid = (Id >= 0);
            var speciesNameValid = !String.IsNullOrWhiteSpace(SpeciesName);
            var hpValid = (Hp <= 100 && Hp >= -100);
            var attackValid = (Attack <= 100 && Attack >= -100);
            var totalStatsValid = (StatSum<= 100);
            var ret = idValid && hpValid && attackValid && totalStatsValid && speciesNameValid;
            return ret;
        }
    }
}