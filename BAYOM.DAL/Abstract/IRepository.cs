using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Abstract
{
    public interface IRepository<T> where T : class 
    {

        IQueryable<T> GetAll();
        IQueryable<T> GetByQuery(Expression<Func<T, bool>> expression);
        Task<T> GetById(int id);
        Task AddAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        void Delete(T entity);
        void Update(T entity);


    }
}
