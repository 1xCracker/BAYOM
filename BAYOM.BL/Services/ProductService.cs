using BAYOM.BL.Abstract;
using BAYOM.DAL.Abstract;
using BAYOM.EL.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Services
{
	public class ProductService : IProductService
	{
		private readonly IRepository<Product> _productRepository;
		public ProductService(IRepository<Product> productRepository)
		{
			_productRepository = productRepository;
		}
	
		public async Task<IEnumerable<Product>> GetProductsLastestAsync()
		{
			var entity =await _productRepository.GetAll().ToListAsync();
			var siralanmis =entity.OrderByDescending(x => x.Productid).Take(5);
			return siralanmis;
		}
	}
}
