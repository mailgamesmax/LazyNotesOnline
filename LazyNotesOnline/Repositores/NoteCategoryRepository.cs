using LazyNotesOnline.Models;

namespace LazyNotesOnline.Repositores
{
    public class NoteCategoryRepository : INoteCategoryRepository
    {
        NoteCategory INoteCategoryRepository.CreateNoteCategory(string userName, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }
        NoteCategory INoteCategoryRepository.RenameNoteCategory(string userName, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }

        NoteCategory INoteCategoryRepository.DeleteNoteCategory(string userName, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }

    }
}
