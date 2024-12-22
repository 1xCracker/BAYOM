using BAYOM.DAL.Abstract;
using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;


namespace BAYOM.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ModelContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(ModelContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

		public async Task AddAsync(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
        {
            _dbSet.Remove(entity);
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

        public void Update(T entity)
        {
            _dbSet.Update(entity);  
        }
    }
}
