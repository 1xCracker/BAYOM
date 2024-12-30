using AutoMapper;
using BAYOM.BL.Abstract;
using BAYOM.BL.Concrete.Token;
using BAYOM.BL.Dto_s.UserDto_s;
using BAYOM.EL.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYOM.Web.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly JwtTokenGenerator _jwtTokenGenerator;
		private readonly IUserService _userService;
		private readonly IMapper _mapper;
		public UsersController(IUserService userService,JwtTokenGenerator jwtTokenGenerator, IMapper mapper)
		{
			_userService = userService;
			_jwtTokenGenerator = jwtTokenGenerator;
			_mapper = mapper;
		}

		[HttpPost("authenticate")]
		public async Task<ActionResult> Authenticate(string email, string password)
		{
			var user = await _userService.Authenticate(email, password);
			
			if (user == null)
			{
				return Unauthorized("Kullanıcı Adı Veya Şifre Yanlış");
			}
		return Ok(new { token = _jwtTokenGenerator.GenerateJWT(user) });
		}
		[HttpPost("SignUp")]
		public async Task<ActionResult> SignUp(UserSignUpDto userSignUpDto)
		{
			if (userSignUpDto == null)
			{
				return NotFound();
			}
			var user = _mapper.Map<User>(userSignUpDto);
			var customer = _mapper.Map<Customer>(userSignUpDto);
			 var isok =await _userService.Add(user, customer);
			if (isok)
			{
				return Ok("Success");
			}
			return BadRequest();
		}
	}
}
