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
            this.Add(new MonType(speciesName: "base", id: 0, attack: 0, hp: 0));
            this.Add(new MonType(speciesName: "attacker", id: 1, attack: 100, hp: 0));
            this.Add(new MonType(speciesName: "tank", id: 2, attack: 0, hp: 100));
            this.Add(new MonType(speciesName: "glasscannon", id: 2, attack: 100, hp: -100));
        }
    }
}