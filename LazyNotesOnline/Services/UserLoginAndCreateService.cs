using LazyNotesOnline.Models;
using LazyNotesOnline.Models.DTOs;

namespace LazyNotesOnline.Services
{
    public interface IUserLoginAndCreateService
    {
        UserStatusDTO UserLogin(string userName, string password); //1
        User SignupNewUser(string userName, string password); //2

    }
}
