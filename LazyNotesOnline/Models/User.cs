using System.Data;

namespace LazyNotesOnline.Models
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } //= string.Empty;        

        //+ for JWT
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public Role Role { get; set; }
        
    }
}
