using Common.Repository;
using Common.Math;
using Mon.Type;
using Mon.Stats;

namespace Mon
{
    public class MonEntity : IEntity
    {
        private int _monTypeId;
        private MonTypeRepository _monTypeRepository;
        public MonEntity() => _monTypeRepository = new MonTypeRepository();
        public MonType MonType { get => _monTypeRepository.FindById(_monTypeId); private set => _monTypeId = value.Id; }
        public override bool Validate()
        {
            var ret = true;
            ret = ret && base.Validate();
            ret = ret && MonType.Validate();
            return ret;
        }
    }
}