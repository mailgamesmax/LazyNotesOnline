using LazyNotesOnline.Models;

namespace LazyNotesOnline.Services
{
    public interface INoteCategoryCreationService
    {
        Task<NoteCategory> CreateNoteCategory(string nickName, string newCategoryTitle);

    }
}
