using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Common.Context.Abstraction
{
    public interface IPasswordContext
    {
        byte[] EncodePassword(string password, byte[] salt);

        bool ArePasswordsEqual(string password, string encodedPassword, string salt);

        byte[] GenerateSalt(int size);
    }
}
