using ArtyGeek.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.DataModel.Repositories
{
    public interface IUserRepository : IGenericRepository<UserModel>
    {
        UserModel Get(string email);
    }
}
