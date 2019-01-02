using Common.Repository;

namespace MonGenerator.Repository
{
    public class MonGeneratorRepository<T> : DictionaryRepository<T> where T : IEntity
    {

    }
}