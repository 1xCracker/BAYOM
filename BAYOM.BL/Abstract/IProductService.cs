using BAYOM.DAL.Abstract;
using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Abstract
{
	public interface IProductService
	{
		Task<IEnumerable<Product>> GetProductsLastestAsync();
		

	}
}
