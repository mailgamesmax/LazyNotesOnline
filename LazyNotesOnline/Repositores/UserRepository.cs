using LazyNotesOnline.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace LazyNotesOnline.Repositores
{
    public class UserRepository : IUserRepository
    {
        public User CreateUser(string newUserName, string newNickName, string password)
        {
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            var acc = new User
            {
                Name = newUserName,
                NickName = newNickName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Role = Role.DefaultUser
            };
            return acc;
        }
        public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public async Task<User> UserById(Guid id)
        {
            return await _appDbContext.Users.SingleAsync(a => a.Id == id);
        }


        //
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }

        public UserRepository() { }
    }
}
