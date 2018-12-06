using System.Collections.Generic;
using Repository;

namespace MonGenerator
{
    public class MonTypeDictionaryRepository : IRepository<MonType>
    {
        private Dictionary<int, MonType> _repository;

        public MonTypeDictionaryRepository()
        {
            _repository = new Dictionary<int, MonType>();
        }
        public MonTypeDictionaryRepository(List<MonType> repository)
        {
            _repository = new Dictionary<int, MonType>();
            for (int i = 0; i < repository.Count; i++)
            {
                _repository.Add(i,repository[i]);
            }
        }

        public IEnumerable<MonType> List => _repository.Values;
        public void Add(MonType entity)
        {
            _repository.Add(entity.Id, entity);
        }
        public void Delete(MonType entity)
        {
            _repository.Remove(entity.Id);
        }
        public MonType FindById(int Id)
        {
            return _repository[Id];
        }
        public void Update(MonType entity)
        {
            _repository[entity.Id] = entity;
        }
    }
}