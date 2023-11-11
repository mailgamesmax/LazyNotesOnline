using LazyNotesOnline.Models;

namespace LazyNotesOnline.Repositores
{
    public interface INoteCategoryRepository
    {
        public NoteCategory CreateNoteCategory(string userName, string newCategoryTitle);
    }
}
