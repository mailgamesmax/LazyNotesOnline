using LazyNotesOnline.Models;
using LazyNotesOnline.Models.DTOs;

namespace LazyNotesOnline.Services
{
    public interface IUserLoginAndCreateService
    {
        UserStatusDTO UserLogin(string newNickName, string password); //1
        Task<(bool, User)> SignupNewUser(string userName, string newNickName, string password); //2
//        User SignupNewUser(string userName, string newNickName, string password); //2

    }
}
