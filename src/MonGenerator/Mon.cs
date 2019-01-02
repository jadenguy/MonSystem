using Repository;

namespace MonGenerator
{
    public class Mon : IEntity
    {
        private int monTypeID;
        private MonTypeDictionaryRepository monTypeDictionaryRepository;

        public MonType MonType { get => monTypeDictionaryRepository.FindById(monTypeID); set => monTypeDictionaryRepository.Update(value); }
    }
}