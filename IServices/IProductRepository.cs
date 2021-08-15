using System.Collections.Generic;
using Commerce.Entity;

namespace Commerce.IServices
{
    public interface IProductRepository<Product> : IRepository<Product> where Product : IEntity
    {
        
    }
}