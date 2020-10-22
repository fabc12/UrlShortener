using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Utilities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        public bool AddUser(string email, string password);
        public string GetShortLink(string email, string originalLink);
        public string GetOriginalLink(string email, string shortLink);
        public IList<LinkMapper> GetLinks(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddUser(string email, string password)
        {
            var user = _dbContext.User.Find(email);
            if (user != null) return false;
            _dbContext.User.Add(new User
            {
                Email = email,
                Password = password
            });
            _dbContext.SaveChanges();
            return true;
        }

        public string GetShortLink(string email, string originalLink)
        {
            var user = _dbContext.User.Find(email);
            if (user == null) return null;
            var obj = _dbContext.LinkMapper
                .FirstOrDefault(l => l.Email == email && l.OriginalLink == originalLink);
            if (obj != null) return obj.ShortLink;
            // Generate Key 
            var keyGenerator = new KeyGenerator(_dbContext.LinkMapper.Select(s => s.ShortLink).ToList());
            var shortLink = keyGenerator.GenerateKey(6);
            _dbContext.LinkMapper.Add(new LinkMapper
            {
                Email = email,
                OriginalLink = originalLink,
                ShortLink = shortLink
            });
            _dbContext.SaveChanges();
            return shortLink;
        }

        public string GetOriginalLink(string email, string shortLink)
        {
            var user = _dbContext.User.Find(email);
            if (user == null) return null;
            var obj = _dbContext.LinkMapper
                .FirstOrDefault(l => l.Email == email && l.ShortLink == shortLink);
            return (obj != null) ? obj.OriginalLink : null;
        }

        public IList<LinkMapper> GetLinks(string email, string password)
        {
            var user = _dbContext.User.Find(email);
            if (user == null || user.Password != password) return null;
            var obj = _dbContext.LinkMapper.Where(l => l.Email == email);
            return obj.ToList();
        }
    }
}