using BAYOM.BL.Abstract;
using BAYOM.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.BL.Services
{
    public class Service<T> : IServices<T> where T : class
    {
        private readonly IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        public Service (IRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task AddAsync(T entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {   
            
            var entity = await _repository.GetAll().ToListAsync();
            return entity;
        }

        public async Task<T> GetById(int id)
        {  
            var entity =await _repository.GetById(id);
            return entity;
        }

        public async Task RemoveAsync(T entity)
        {
             _repository.Delete(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
           _repository.Update(entity);
            await _unitOfWork.CommitAsync();
        }

 
    }
}
