using BAYOM.BL.Abstract;
using BAYOM.DAL.Abstract;
using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Services
{
	public class CategoryService : ICategorySercive
	{
		private readonly IRepository<Category> _repository;
		public CategoryService(IRepository<Category> repository)
		{
			_repository = repository;
		}
		public Task<IEnumerable<Category>> GetCategory(int id)
		{
			throw new NotImplementedException();
		}
	}
}
