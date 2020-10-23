using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Utilities
{
    public interface IKeyGenerator
    {
        public string GenerateKey(int length);
    }
    public class KeyGenerator : IKeyGenerator
    {
        private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public string GenerateKey(int length)
        {
            var random = new Random();
            return new string(
                Enumerable.Repeat(Chars, length)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
        }
    }
}