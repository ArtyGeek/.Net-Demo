using ArtyGeek.Common.Context.Abstraction;
using ArtyGeek.DataModel.Models;
using ArtyGeek.DataModel.Repositories;
using ArtyGeek.Operations.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Operations.Implementation
{
    public class AuthenticationOperations : IAuthenticationOperations
    {
        private readonly IUserRepository _userRepository;
        private readonly ICryptographyContext _cryptographyContext;
        private readonly IPasswordContext _passwordContext;

        public AuthenticationOperations(IUserRepository userRepository, ICryptographyContext cryptographyContext, IPasswordContext passwordContext)
        {
            _userRepository = userRepository;
            _cryptographyContext = cryptographyContext;
            _passwordContext = passwordContext;
        }

        public void RegisterUser(AuthenticationModel user)
        {
            if (_userRepository.Get(user.Email) != null)
            {
                throw new InvalidOperationException("User already exists");
            }

            byte[] salt = _cryptographyContext.GenerateRandomBytes();
            byte[] encode = _passwordContext.EncodePassword(user.Password, salt);

            _userRepository.Insert(new UserModel
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = Convert.ToBase64String(encode),
                Salt = Convert.ToBase64String(salt)
            });
        }

        public bool IsValid(string email, string password)
        {
            var user = _userRepository.Get(email);
            if (user == null)
                return false;
            return _passwordContext.ArePasswordsEqual(password, user.Password, user.Salt);
        }

        public UserModel FindUser(string email, string password)
        {
            var user = _userRepository.Get(email);
            if (user == null || _passwordContext.ArePasswordsEqual(password, user.Password, user.Salt))
                return user;
            return null;
        }
    }
}
