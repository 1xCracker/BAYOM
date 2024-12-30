using BAYOM.BL.Abstract;
using BAYOM.BL.Dto_s.UserDto_s;
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
        private readonly IRepository<Customer> _repositoryCustomer;
		private readonly ISignUp _signUp;
        public UserService(IRepository<User> repositoryUser, IRepository<Customer> repositoryCustomer, ISignUp signUp)
        {
            _repositoryUser = repositoryUser;
            _repositoryCustomer = repositoryCustomer;
            _signUp = signUp;
        }

        public async Task<bool> Add(User user, Customer customer)
		{
			user.Userpassword =Encryption.sifreSifrele(user.Userpassword);
			user.Userrole = 14;
			var sonuc = _signUp.SignUpAsync(customer,user);
			return await sonuc;
		
			
			
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
