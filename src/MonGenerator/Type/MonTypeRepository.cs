using System.Collections.Generic;
using MonGenerator.Repository;
using MonGenerator.Type;

namespace MonGenerator.Type
{
    public class MonTypeRepository : MonGeneratorRepository<MonType>
    {
        public MonTypeRepository()
        {
            //--  Generating test data for now
            this.Add(new MonType(speciesName: "base", id: 0, attack: 0, hp: 0, speed: 0));
            this.Add(new MonType(speciesName: "attacker", id: 1, attack: 50, hp: 0, speed: 0));
            this.Add(new MonType(speciesName: "tank", id: 2, attack: 0, hp: 50, speed: 0));
            this.Add(new MonType(speciesName: "speedy", id: 3, attack: 0, hp: 0, speed: 50));
            this.Add(new MonType(speciesName: "glassCannon", id: 5, attack: 100, hp: -50, speed: 0));
            this.Add(new MonType(speciesName: "glacier", id: 6, attack: 0, hp: 100, speed: -50));
            this.Add(new MonType(speciesName: "lightningGlassCannon", id: 7, attack: 100, hp: -100, speed: 50));
            this.Add(new MonType(speciesName: "fodder", id: -1, attack: -100, hp: -100, speed: -50));
        }
    }
}