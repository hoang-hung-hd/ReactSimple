using Backend_Web.Models;
using Backend_Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Web.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : Controller
    {
        private readonly Authentication _authen;

        public UserController(Authentication authen)
        {
            _authen = authen;
        }

		[HttpGet]
		public List<string> Get()
		{
			var users = new List<string>
		{
			"Satinder Singh",
			"Amit Sarna",
			"Davin Jon"
		};

			return users;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("authenticate")]
		public IActionResult Authenticate(Login loginData)
		{
			var token = _authen.Authenticate(loginData);

			if (token == null)
			{
				return Unauthorized();
			}

			return Ok(token);
		}
	}
}
