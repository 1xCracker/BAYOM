using BAYOM.EL.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace BAYOM.BL.Concrete.Token
{
	public class JwtTokenGenerator
	{
		private readonly IConfiguration _configuration;
		public  JwtTokenGenerator(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public object GenerateJWT(User user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			var key =Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? "");
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(
					new Claim[]
					{
						new Claim(ClaimTypes.NameIdentifier,user.Userid.ToString()),


					}
					),
				Expires = DateTime.UtcNow.AddDays(1),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);

		}
	}
}
