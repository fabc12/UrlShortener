using System.Linq;
using Domain.Entities;
using Infrastructure.Persistence;
using Infrastructure.Utilities;
using Application.Dtos;
using AutoMapper;

namespace Infrastructure.Services
{
    public interface IUserService
    {
        public bool AddUser(string email, string password);
        public string GetShortUrl(string email, string originalUrl);
        public string GetOriginalUrl(string email, string shortUrl);
        public GetShortUrlsDto GetShortUrls(string email, string password);
    }

    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IKeyGenerator _keyGenerator;

        public UserService(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _keyGenerator = new KeyGenerator();
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

        public string GetShortUrl(string email, string originalUrl)
        {
            var user = _dbContext.User.Find(email);
            if (user == null) return null;
            var obj = _dbContext.UrlMapper
                .FirstOrDefault(l => l.Email == email && l.OriginalUrl == originalUrl);
            if (obj != null) return obj.ShortUrl;
            // Generate Key
            var shortUrl = _keyGenerator.GenerateKey(6);
            _dbContext.UrlMapper.Add(new UrlMapper
            {
                Email = email,
                OriginalUrl = originalUrl,
                ShortUrl = shortUrl
            });
            _dbContext.SaveChanges();
            return shortUrl;
        }

        public string GetOriginalUrl(string email, string shortUrl)
        {
            var user = _dbContext.User.Find(email);
            if (user == null) return null;
            var obj = _dbContext.UrlMapper
                .FirstOrDefault(l => l.Email == email && l.ShortUrl == shortUrl);
            return obj?.OriginalUrl;
        }

        public GetShortUrlsDto GetShortUrls(string email, string password)
        {
            var user = _dbContext.User.Find(email);
            if (user == null || user.Password != password) return null;
            var obj = _dbContext.UrlMapper.Where(l => l.Email == email).ToList();
            return _mapper.Map<GetShortUrlsDto>(obj);
        }
    }
}