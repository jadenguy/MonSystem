// using System.Collections.Generic;
// using Repository;

// namespace MonGenerator
// {
//     public class DictionaryRepository<T> : IRepository<T> where T : IEntity
//     {
//         private Dictionary<int, T> _repository;

//         public DictionaryRepository()
//         {
//             _repository = new Dictionary<int, T>();
//         }
//         // public DictionaryRepository(List<T> repository)
//         // {
//         //     _repository = new Dictionary<int, T>();
//         //     for (int i = 0; i < repository.Count; i++)
//         //     {
//         //         this.Add(repository[i]);
//         //     }
//         // }
//         public IEnumerable<T> List => _repository.Values;
//         public void Add(T entity)
//         {
//             // if (entity.Validate())
//             // {
//                 _repository.Add(entity.Id, entity);
//             // }
//             // else
//             // {
//                 System.Console.WriteLine($"Add failed to {entity.ToString()}");
//             // }
//         }
//         public void Delete(T entity)
//         {
//             _repository.Remove(entity.Id);
//         }
//         public T FindById(int Id)
//         {
//             return _repository[Id];
//         }
//         public void Update(T entity)
//         {
//             _repository[entity.Id] = entity;
//         }

//     }
// }