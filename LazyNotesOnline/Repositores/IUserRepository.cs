using LazyNotesOnline.Models;
using System.Security.Cryptography;

namespace LazyNotesOnline.Repositores
{
    public interface IUserRepository
    {
        User CreateUser(string newUserName, string newNickName, string password);

        //public Task<User> UserById(Guid id);

        Task<Guid> GetUserIdByNickname(string nickName);
        Task<User> GetFullUserByNickname(string nickName);
    }
}
