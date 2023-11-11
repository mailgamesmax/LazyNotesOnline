namespace LazyNotesOnline.Models.DTOs
{
    public record UserStatusDTO(bool IsUserExist, Role? Role = null);
}
