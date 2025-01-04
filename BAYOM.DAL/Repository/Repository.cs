using BAYOM.DAL.Abstract;
using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;


namespace BAYOM.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelContext _context;
        protected readonly DbSet<T> _dbSet;
        public Repository(ModelContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            bool productExists = await _dbSet.AnyAsync(expression);
            return productExists;
        }

        public  bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception) 
            {
                return false;
            }

          
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public IQueryable<T> GetByQuery(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public  bool Update(T entity)
        {
            try
            {
                _dbSet.Update(entity);
            return true;
        }
            catch (Exception) 
            {
                return false;
            }
}

      
    }
}
