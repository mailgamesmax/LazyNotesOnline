using LazyNotesOnline.Models;

namespace LazyNotesOnline.Repositores
{
    public interface INoteCategoryRepository
    {
        public NoteCategory CreateNoteCategory(string userName, string newCategoryTitle);
        public NoteCategory RenameNoteCategory(string userName, string newCategoryTitle);
        public NoteCategory DeleteNoteCategory(string userName, string newCategoryTitle);
    }
}
