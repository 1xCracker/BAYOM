
using BAYOM.DAL.Abstract;
using BAYOM.EL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAYOM.DAL.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ModelContext _modelContext;
        public UnitOfWork(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public void Commit()
        {
            _modelContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _modelContext.SaveChangesAsync();
        }
    }
}
