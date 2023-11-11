using LazyNotesOnline.Controllers.Requests;
using LazyNotesOnline.Models;
using LazyNotesOnline.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LazyNotesOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.DefaultUser) + "," + nameof(Role.Admin)))]
        [HttpGet(template: "TouchMeIfYouAreАuthenticated !")]
        public ActionResult<string> BeNiceForAutetified()
        {
            string heyBro = "hey bro!";
            return heyBro;
        }

        [HttpPost(template: ("SignUpNewUser"))]
        public IActionResult SignUpNewClient([FromBody] SignUpNewUserRequest request)
        {
            var newAcc = _loginService.SignupNewUser(request.Username, request.Password);
            return Ok(newAcc);
        }

        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = (nameof(Role.UserClient) + "," + nameof(Role.Admin)))]
        [HttpPost(template: "UserLogin")]
        public IActionResult UserLogin([FromBody] LoginRequest request)
        {
            var response = _loginService.UserLogin(request.Username, request.Password);
            if (!response.IsUserExist)
            {
                return Unauthorized();
            }
            return Ok(_jwtService.GetJwtToken(request.Username, (Role)response.Role));            
        }
        // GET: api/<AuthenticationController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AuthenticationController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AuthenticationController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AuthenticationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AuthenticationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private readonly ILogger<AuthenticationController> _logger;

        private readonly IUserLoginAndCreateService _loginService;
        private readonly IJwtService _jwtService;
        public AuthenticationController(IUserLoginAndCreateService loginService, IJwtService jwtService, ILogger<AuthenticationController> logger)
        {
            _loginService = loginService;
            _jwtService = jwtService;
            _logger = logger;
        }

    }
}
