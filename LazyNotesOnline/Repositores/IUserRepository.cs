using LazyNotesOnline.Models;
using System.Security.Cryptography;

namespace LazyNotesOnline.Repositores
{
    public interface IUserRepository
    {
        public User CreateUser(string newUserName, string newNickName, string password);

        public Task<User> UserById(Guid id);
    }
}
