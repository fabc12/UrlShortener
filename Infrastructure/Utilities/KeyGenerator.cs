using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;

namespace Infrastructure.Utilities
{
    public class KeyGenerator
    {
        private const string Chars = "abcdefghijklmnopqrstuvwxyz0123456789";
        private readonly IList<string> _list;

        public KeyGenerator(IList<string> list)
        {
            _list = list;
        }
        public string GenerateKey(int length)
        {
            var result = RandomString(length);
            while (_list.Contains(result)) result = RandomString(length);
            return result;
        }

        private string RandomString(int length)
        {
            var random = new Random();
            return new string(
                Enumerable.Repeat(Chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}