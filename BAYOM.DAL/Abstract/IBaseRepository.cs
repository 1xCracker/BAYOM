using BAYOM.EL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Abstract
{
    public interface IBaseRepository<T> where T : class ,new()
    {
  
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T,bool>>expression);
        Task AddAsync(T entity);
       
        void Update(T entity);
        void Delete(T entity);
        
    }
}
