using System;
using Common.Repository;
using Common.Math;

namespace MonGenerator.Type
{
    public class MonType : IEntity
    {
        private string _speciesName;
        private int _attack;
        private int _hp;
        private int _speed;
        public string SpeciesName { get => _speciesName; set => _speciesName = value; }
        public int Attack { get => _attack; set => _attack = value; }
        public int Hp { get => _hp; set => _hp = value; }
        public int Speed { get => _speed; set => _speed = value; }
        public int StatSum => Attack + Hp + Speed;
        public MonType() { }
        public MonType(string speciesName, int id, int attack, int hp, int speed)
        {
            SpeciesName = speciesName;
            Id = id;
            Attack = attack;
            Hp = hp;
            Speed = speed;
        }
        public override bool Validate()
        {
            var idValid = (Id >= 0);
            var speciesNameValid = !String.IsNullOrWhiteSpace(SpeciesName);
            var hpValid = Hp.IsBetweenII((int)MonTypeRanges.hpMin, (int)MonTypeRanges.hpMax);
            var attackValid = Attack.IsBetweenII((int)MonTypeRanges.attackMin, (int)MonTypeRanges.attackMax);
            var speedValid = Speed.IsBetweenII((int)MonTypeRanges.speedMin, (int)MonTypeRanges.speedMax);
            var totalStatsValid = StatSum.IsBetweenII((int)MonTypeRanges.statTotalMin, (int)MonTypeRanges.statTotalMax);
            var ret = idValid && hpValid && attackValid && speedValid && totalStatsValid && speciesNameValid;
            return ret;
        }
    }
}