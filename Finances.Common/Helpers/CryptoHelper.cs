using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Finances.Common.Helpers
{
    public class CryptoHelper
    {
        public const int SaltByteSize = 24;
        public const int HashByteSize = 512 / 8;
        public const int Pbkdf2Iterations = 10000;

        private byte[] GenerateSalt()
        {
            RNGCryptoServiceProvider cryptoProvider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SaltByteSize];
            cryptoProvider.GetBytes(salt);
            return salt;
        }

        public string Encrypt(string str)
        {
            byte[] salt = this.GenerateSalt();
            byte[] hash = this.GetPbkdf2(str, salt);
            return $"{Convert.ToBase64String(salt)}:{Convert.ToBase64String(hash)}";
        }

        private byte[] GetPbkdf2(string str, byte[] salt)
        {
            byte[] hash = KeyDerivation.Pbkdf2(
                password: str,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: Pbkdf2Iterations,
                numBytesRequested: HashByteSize);
            return hash;
        }

        public bool Valid(string str, string originalHashWithSalt)
        {
            char[] delimiter = { ':' };
            string[] split = originalHashWithSalt.Split(delimiter);
            byte[] salt = Convert.FromBase64String(split[0]);
            byte[] originalHash = Convert.FromBase64String(split[1]);
            byte[] hashTest = this.GetPbkdf2(str, salt);
            return this.SlowEquals(originalHash, hashTest);
        }

        private bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
            {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }
    }
}
