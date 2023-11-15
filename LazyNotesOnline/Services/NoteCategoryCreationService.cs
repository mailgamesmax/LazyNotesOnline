using LazyNotesOnline.Models;
using LazyNotesOnline.Repositores;

namespace LazyNotesOnline.Services
{
    public class NoteCategoryCreationService : INoteCategoryCreationService
    {
        public async Task<NoteCategory> CreateNoteCategory(string nickName, string newCategoryTitle) 
        {
            var userOwner = await _userRepository.GetFullUserByNickname(nickName);
            var newCategory = await _categoryRepository.CreateNoteCategory(userOwner, newCategoryTitle);
            _appDbContext.Categories.Add(newCategory);
            await _appDbContext.SaveChangesAsync();
            return newCategory;

        }


        //
        private readonly AppDbContext _appDbContext;

        private readonly INoteCategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public NoteCategoryCreationService(INoteCategoryRepository categoryRepository, IUserRepository userRepository, AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }
    }
}
