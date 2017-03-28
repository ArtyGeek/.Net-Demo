using ArtyGeek.DataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Operations.Abstraction
{
    public interface IAuthenticationOperations
    {
        bool IsValid(string username, string password);

        void RegisterUser(AuthenticationModel user);

        UserModel FindUser(string username, string password);
    }
}
