using Common.Repository;
using Common.Math;

namespace MonGenerator
{
    public class Mon : IEntity
    {
        private int monTypeId;
        private MonTypeRepository monTypeRepository;
        public Mon()
        {
            monTypeRepository = new MonTypeRepository();
            monTypeId = 0;
        }
        public Mon(int MonTypeId)
        {
            monTypeRepository = new MonTypeRepository();
            monTypeId = MonTypeId;
        }
        public MonType MonType { get => monTypeRepository.FindById(monTypeId); set => monTypeId = value.Id; }
        public int BetweenTest(int a, int b, int c)
        {
            return a.InBetweenII(b, c);
        }
    }
}