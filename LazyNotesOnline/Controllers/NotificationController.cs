using LazyNotesOnline.Controllers.Requests;
using LazyNotesOnline.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LazyNotesOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.DefaultUser) + "," + nameof(Role.Admin)))]
    public class NotificationController : ControllerBase
    {
        [HttpPost(template: ("NoteCategoryCreation"))]
        public async Task<IActionResult> CreateNoteCategory([FromBody] NoteCategoryCreationRequest request)
        {
            var newCategory = await _noteCategoryCreationService.CreateNoteCategory(request.UserNickName, request.NewCategoryTitle);
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve
            };

            string jsonString = JsonSerializer.Serialize(newCategory, options);
            return Ok(newCategory);
            
        }

        //
        private readonly ILogger<NotificationController> _logger;

        private readonly INoteCategoryCreationService _noteCategoryCreationService;
        private readonly IJwtService _jwtService;
        public NotificationController(INoteCategoryCreationService noteCategoryCreationService, IJwtService jwtService, ILogger<NotificationController> logger)
        {
            _noteCategoryCreationService = noteCategoryCreationService;
            _jwtService = jwtService;
            _logger = logger;
        }
    }
}
