using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtyGeek.Common.Context.Abstraction
{
    public interface ICryptographyContext
    {
        byte[] Hash(byte[] value, byte[] salt);

        /// <summary>
        /// Encodes data value with symmetric algorithm
        /// </summary>
        /// <param name="value">Data value to be encoded</param>
        /// <param name="key">Cryptographic key to encode data value</param>
        /// <returns>Encrypted data</returns>
        byte[] SymmetricEncode(byte[] value, byte[] key, byte[] initializationVector);

        /// <summary>
        /// Generates array of cryptographically strong random bytes
        /// </summary>
        /// <param name="size">Array size. Default is 1024</param>
        byte[] GenerateRandomBytes(int size = 1024);

        /// <summary>
        /// Uses allowedCharacters array to generate strongly randomized password string
        /// </summary>
        /// <param name="allowedCharacters">Password will consist only from these characters</param>
        string GenerateRandomPassword(int length, char[] allowedCharacters);

        /// <summary>
        /// Gets a random object with a cryptographically strong seed.
        /// </summary>
        Random GetStrongRandom();
    }
}
