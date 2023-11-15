using LazyNotesOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace LazyNotesOnline.Repositores
{
    public class NoteCategoryRepository : INoteCategoryRepository
    {
       public async Task<NoteCategory> CreateNoteCategory(User user, string newCategoryTitle)
       {
            var newNoteCategory = new NoteCategory()
            {
                Cat_Title = newCategoryTitle,
            };

            user.UserNoteCategories.Add(newNoteCategory);
            //await _appDbContext.SaveChangesAsync();
            return newNoteCategory;

       }



        NoteCategory RenameNoteCategory(string userName, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }

        NoteCategory DeleteNoteCategory(string userName, string newCategoryTitle)
        {
            throw new NotImplementedException();
        }

        public async Task<NoteCategory> SelectCategoryByTitleAndUserId(Guid userId, string title)
        {
            var actualCategory = await _appDbContext.Categories
                .Where(c => c.User.Id == userId && c.Cat_Title.ToLower() == title.ToLower())
                .FirstOrDefaultAsync();
                 return actualCategory;


            //_appDbContext.Categories.Any(c => c.Cat_Title == title && c.nam))
            //return await _appDbContext.Categories.SingleAsync(c => c.Cat_Title == title);
        }

        //
        private readonly AppDbContext _appDbContext;
        public NoteCategoryRepository(AppDbContext dbContext)
        {
            _appDbContext = dbContext;
        }
        public NoteCategoryRepository() { }

    }
}
