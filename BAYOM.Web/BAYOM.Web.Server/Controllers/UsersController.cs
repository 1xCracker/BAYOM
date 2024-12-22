using BAYOM.BL.Abstract;
using BAYOM.EL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYOM.Web.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost("authenticate")]
		public async Task<ActionResult> Authenticate(string email, string password)
		{
			var user = await _userService.Authenticate(email, password);
			if (user == null)
			{
				return Unauthorized("Kullanıcı Adı Veya Şifre Yanlış");
			}
		return Ok(new { token = "token" });
		}
	}
}
