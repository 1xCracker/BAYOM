using BAYOM.DAL.Abstract;
using BAYOM.EL.Concrete;
using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Repository
{
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        public ProductRepository(ModelContext context) : base(context)
        {
        }
  
     public async Task<IEnumerable<Product>> GetProductsWithNameAsync()
    {
        return await _dbSet.Include(p => p.Category).Include(p=>p.Productbrand).Include(p=>p.Topcategory).ToListAsync();
    }
    
    }
   
}
