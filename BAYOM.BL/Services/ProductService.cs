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
	public class ProductService :Service<Product> ,IProductService
	{

		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;
		public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork):base(productRepository, unitOfWork)
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

        public async Task<IEnumerable<Product>> GetProductWithName()
        {
            var product =await _productRepository.GetProductsWithNameAsync();
			return product;
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
			var product = await  _productRepository.GetById(id);
			if (product == null) 
			{
				return false;
			}
			var delete =   _productRepository.Delete(product);
			if (!delete)
			{
				return false;
			}
			_unitOfWork.Commit();
			return delete;


        }
    }
}
