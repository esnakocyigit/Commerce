using System.Collections.Generic;
using System.Linq;
using Commerce.Entity;

namespace Commerce.IServices
{
    public interface IRepository<T> where T : IEntity
    {
         IQueryable<T> GetList();
         T Detail(int id);
         T Add(T _entity);
        void Update(T _entity);
        void Delete(int id);
    }
}