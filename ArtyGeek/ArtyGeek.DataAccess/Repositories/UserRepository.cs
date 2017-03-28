using ArtyGeek.DataAccess.Contexts;
using ArtyGeek.DataAccess.Entities;
using ArtyGeek.DataModel.Models;
using ArtyGeek.DataModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ArtyGeekContext _dbContext;

        public UserRepository(ArtyGeekContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserModel Get(string email)
        {
            return _dbContext.Users.Where(x => x.Email == email).Select(user => new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                ImageId = user.ImageId,
                Salt = user.Salt
            }).FirstOrDefault();
        }

        public IReadOnlyList<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UserModel Get(int id)
        {
            return _dbContext.Users.Where(x => x.Id == id).Select(user => new UserModel
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Password = user.Password,
                Salt = user.Salt
            }).FirstOrDefault();
        }

        public UserModel Insert(UserModel item)
        {
            var user = new UserEntity
            {
                FirstName = item.FirstName,
                LastName = item.LastName,
                Email = item.Email,
                Password = item.Password,
                Salt = item.Salt,
                ImageId = item.ImageId,
                IsDeleted = false,
                Role = item.Role.ToString()
            };
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            item.Id = user.Id;
            return item;
        }

        public UserModel Update(UserModel item)
        {
            var edit = _dbContext.Users.Where(x => x.Id == item.Id).FirstOrDefault();
            edit.FirstName = item.FirstName;
            edit.LastName = item.LastName;
            edit.Email = item.Email;
            edit.Password = item.Password;
            edit.Salt = item.Salt;
            edit.ImageId = item.ImageId;
            _dbContext.SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            var remove = _dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
            remove.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}
