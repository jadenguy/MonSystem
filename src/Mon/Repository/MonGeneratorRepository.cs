using Common.Repository;

namespace Mon.Repository
{
    public class MonGeneratorRepository<T> : DictionaryRepository<T> where T : IEntity
    {

    }
}