using LazyNotesOnline.Models;

namespace LazyNotesOnline.Repositores
{
    public interface INoteCategoryRepository
    {
        Task<NoteCategory> CreateNoteCategory(User user, string newCategoryTitle);
        //public NoteCategory RenameNoteCategory(string nickName, string newCategoryTitle);
        //public NoteCategory DeleteNoteCategory(string nickName, string newCategoryTitle);
    }
}
