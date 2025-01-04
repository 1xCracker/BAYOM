using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Abstract
{
    public interface IServices<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(int id);
       
        Task<bool> AddAsync(T entity);
        Task<bool> RemoveAsync(T entity);
      
        Task<bool> UpdateAsync(T entity);


    }
}
