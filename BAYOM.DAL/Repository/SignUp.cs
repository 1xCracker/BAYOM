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
    public class SignUp : ISignUp
    {
        private readonly ModelContext _modelContext;
       
        public SignUp(ModelContext modelContext)
        {
            _modelContext = modelContext;
        
        }

        public async Task<bool> SignUpAsync(Customer customer, User user)
        {
            using (var transection = _modelContext.Database.BeginTransaction())
            {

                try
                {
                    await _modelContext.AddAsync(customer);
                    await _modelContext.SaveChangesAsync();

                    user.Customerid = customer.Customerid;
                   
                    await _modelContext.AddAsync(user);
                    await _modelContext.SaveChangesAsync();
                    transection.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transection.Rollback();
                    return false;
                }

            }
        }
    }
}
