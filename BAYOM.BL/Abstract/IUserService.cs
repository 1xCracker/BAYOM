using BAYOM.BL.Dto_s.UserDto_s;
using BAYOM.EL.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Abstract
{
	public interface IUserService
	{
		Task<User> Authenticate(string email, string password);
		Task<bool> Add(User user,Customer customer);
		Task Update(User user);

		
	}
}
