using BAYOM.BL.Abstract;
using BAYOM.BL.Utilities;
using BAYOM.DAL.Abstract;
using BAYOM.EL.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Services
{
	public class UserService : IUserService
	{
		private readonly IRepository<User> _repositoryUser;
		
		public UserService(IRepository<User> repositoryUser)
		{
			_repositoryUser = repositoryUser;
		}

		public async Task Add(User user)
		{
			user.Userpassword =Encryption.sifreSifrele(user.Userpassword);
			await _repositoryUser.AddAsync(user);
			
		}

		public async Task<User> Authenticate(string email, string password)
		{
			var user = await _repositoryUser.GetByQuery(x => x.Useremail == email).FirstOrDefaultAsync();
			
			if(user == null )
			{
				return null;
			}
			var girilenSifre = Encryption.sifreSifrele(password);
			Console.WriteLine(girilenSifre);
            if (user.Userpassword != girilenSifre)
            {
				return null;
			}
            return user;
		}

		public Task Update(User user)
		{
			throw new NotImplementedException();
		}
	}
}
