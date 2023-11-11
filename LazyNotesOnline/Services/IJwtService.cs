using LazyNotesOnline.Models;

namespace LazyNotesOnline.Services
{
    public interface IJwtService
    {
        string GetJwtToken(string userName, Role role);
    }
}
