using BAYOM.DAL.Abstract;
using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Repository
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class, new()
    {
        private readonly ModelContext? _modelContext;
        private readonly DbSet<T>? _dbSet;
        public BaseRepository(ModelContext db)
        {
            this._modelContext = db;
            this._dbSet = db.Set<T>();
        }
        public ModelContext? modelContext { get => this._modelContext; }
        public DbSet<T>? dbSet { get => this._dbSet; }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return dbSet.AnyAsync(expression);
        }

        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<T> GetAll()
        {
           return dbSet.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public void Update(T entity)
        {
            dbSet.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                return GetAll();
           return dbSet.Where(expression); 
        }
    }
}
