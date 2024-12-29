using BAYOM.BL.Abstract;
using BAYOM.BL.Dto_s.ProductDto_s;
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
		private readonly IUnitOfWork _unitOfWork;
		public ProductService(IRepository<Product> productRepository, IUnitOfWork unitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = unitOfWork;
		}

        public async Task<bool> AnyAsync(int id)
        {
            var product =await _productRepository.AnyAsync(x=> x.Productid == id);
			return product;
        }

        public async Task<IEnumerable<Product>> GetProductsLastestAsync()
		{
			var entity =await _productRepository.GetAll().ToListAsync();
			var siralanmis =entity.OrderByDescending(x => x.Productid).Take(10);
			return siralanmis;
		}

		
    }
}
