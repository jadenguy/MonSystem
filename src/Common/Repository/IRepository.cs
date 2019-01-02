//-- Based on https://medium.com/falafel-software/implement-step-by-step-generic-repository-pattern-in-c-3422b6da43fd

using System.Collections.Generic;

namespace Common.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int Id);
    }
}