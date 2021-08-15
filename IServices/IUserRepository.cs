using System.Collections.Generic;
using Commerce.Entity;

namespace Commerce.IServices
{
    public interface IUserRepository<User> : IRepository<User> where User : IEntity
    {    

    }
}     