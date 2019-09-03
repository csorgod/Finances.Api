using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;

namespace Finances.Common.Helpers
{
    public class CryptoHelper
    {
        private int _degreeOfParallelism = 2;
        private int _iterations = 16;
        private int _memorySize = 1024;
        private int _hashLength = 128;
        private int _saltByteSize = 24;

        private string GenerateSalt()
        {
            var cryptoProvider = new RNGCryptoServiceProvider();
            var salt = new byte[_saltByteSize];
            cryptoProvider.GetBytes(salt);
            return Convert.ToBase64String(salt);
        }

        private string GenerateArgon2idHash(string password, string salt)
        {
            var saltBytes = Encoding.UTF8.GetBytes(salt);
            var passwordBytes = Encoding.UTF8.GetBytes(password);

            var argon2id = new Argon2id(passwordBytes);
            argon2id.DegreeOfParallelism = _degreeOfParallelism;
            argon2id.Iterations = _iterations;
            argon2id.MemorySize = _memorySize;
            argon2id.Salt = saltBytes;

            var hash = argon2id.GetBytes(_hashLength);
            return Convert.ToBase64String(hash);
        }

        public string Encrypt(string password, string salt = "")
        {
            // TODO: return tuple (salt, password) instead of splitable string
            salt = GenerateSalt();
            return $"{salt}:{GenerateArgon2idHash(password, salt)}";
        }

        // TODO: Change database so we can stop using the "split" logic and can receive salt directly as a parameter
        public bool IsValid(string passwordFromInput, string hashedPasswordFromDB, string salt = "")
        {
            var saltAndPasswordHash = hashedPasswordFromDB.Split(':');
            salt = saltAndPasswordHash[0];
            hashedPasswordFromDB = saltAndPasswordHash[1];

            return hashedPasswordFromDB == GenerateArgon2idHash(passwordFromInput, salt);
        }
    }
}
