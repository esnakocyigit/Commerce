using System.Collections.Generic;
using System.Linq;
using Commerce.Context;
using Commerce.Entity;
using Commerce.IServices;

namespace Commerce.Services
{
    public class UserService : IUserRepository<User>
    {
        private readonly CommerceDbContext _tContext;

        public UserService(CommerceDbContext commerceDbContext)
        {
            _tContext = commerceDbContext;
        }

        //User listesini db'den çeker
        public IQueryable<User> GetList()
        {
            IQueryable<User> users = _tContext.Users.Where(x => !x.IsDeleted).OrderByDescending(x => x.Id).AsQueryable();
            return users;
        }

        ///User listesini db'den çeker
        public User Detail(int id)
        {
            User user = _tContext.Users.FirstOrDefault(x => x.Id == id);
            return user;
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

        public void Update(User user)
        {
            User updateUser  = _tContext.Users.FirstOrDefault(x => x.Id == user.Id);
            updateUser.Name = user.Name;
            updateUser.Surname   = user.Surname;

            _tContext.Users.Update(updateUser);
            _tContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User updateUser = _tContext.Users.FirstOrDefault(x => x.Id == id);
            updateUser.IsDeleted = true;
            _tContext.Users.Update(updateUser);
            _tContext.SaveChanges();
        } 
    }
}