using ArtyGeek.Common.ConfigSections;
using ArtyGeek.Common.Context.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Common.Context.Implementation
{
    public class PasswordContext : IPasswordContext
    {
        private readonly ICryptographyContext _cryptographyContext;

        public PasswordContext(ICryptographyContext cryptographyContext)
        {
            _cryptographyContext = cryptographyContext;
        }

        public byte[] EncodePassword(string password, byte[] salt)
        {
            string constSalt = CreateBase64String(SecurityConfigurationSection.Instance.ConstantSalt);
            string constInitVector = CreateBase64String(SecurityConfigurationSection.Instance.ConstantInitializationVector);
            byte[] hash = _cryptographyContext.Hash(Encoding.UTF8.GetBytes(password), salt);
            byte[] encode = _cryptographyContext.SymmetricEncode(hash, Convert.FromBase64String(constSalt), Convert.FromBase64String(constInitVector));

            return encode;
        }

        private string CreateBase64String(string line)
        {
            int mod4 = line.Length % 4;
            if (mod4 > 0)
            {
                line += new string('=', 4 - mod4);
            }
            return line;
        }

        public byte[] GenerateSalt(int size)
        {
            return _cryptographyContext.GenerateRandomBytes(size);
        }

        public bool ArePasswordsEqual(string password, string encodedPassword, string salt)
        {
            byte[] storedEncryptedPassword = Convert.FromBase64String(encodedPassword);
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] passwordHash = _cryptographyContext.Hash(passwordBytes, saltBytes);
            byte[] constantSalt = Convert.FromBase64String(SecurityConfigurationSection.Instance.ConstantSalt);
            byte[] constantIV = Convert.FromBase64String(SecurityConfigurationSection.Instance.ConstantInitializationVector);
            byte[] encryptedPassword = _cryptographyContext.SymmetricEncode(passwordHash, constantSalt, constantIV);

            if (storedEncryptedPassword.SequenceEqual(encryptedPassword))
            {
                return true;
            }

            return false;
        }
    }
}
