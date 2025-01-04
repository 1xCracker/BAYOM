using BAYOM.EL.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Abstract
{
    public interface IProductRepository :IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductsWithNameAsync();
    }
}
