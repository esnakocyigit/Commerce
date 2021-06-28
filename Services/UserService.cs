using System.Collections.Generic;
using System.Linq;
using Commerce.Context;
using Commerce.Entity;

namespace Commerce.Services
{
    public class UserService
    {
        private readonly CommerceDbContext _tContext;

        public UserService(CommerceDbContext commerceDbContext)
        {
            _tContext = commerceDbContext; 
        }

        ///User listesini db'den çeker
        public List<User> GetList()
        {
            List<User> users = new List<User>();
            users = _tContext.Users.OrderByDescending(x=>x.Id).ToList();
            return users;
        }
        
        /// <sumamry>
        /// User ekleme işlemi
        /// </summary>
        public User Add(User user)
        {
             // user eklemek için ne lazım bize?
             // değer döndürmek gerekiyor mu?
             // işlem sonucunda db'ye kayıt atılması için ne yapmamız gerek
            User newUser = user;
            _tContext.Users.Add(newUser);
            _tContext.SaveChanges();

            return newUser;
        }
    }
}