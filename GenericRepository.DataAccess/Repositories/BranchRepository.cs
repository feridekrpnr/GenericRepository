using GenericRepository.Entities.Model;
using GenericRepository.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DataAccess.Repositories
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        public BranchRepository(GenericDBContext context) : base(context) { }

        public async Task<Branch> GetWithCompanyByIdAsync(int id)
        {
            return await GenericDBContext.Branches.Include(w => w.Company).SingleOrDefaultAsync(w => w.BranchId == id);
        }
        
        public async Task<IEnumerable<Branch>> GetAllWithCompanyAsync()
        {
                return await GenericDBContext.Branches.ToListAsync();
        }

        private GenericDBContext GenericDBContext
        {
            get { return Context as GenericDBContext; }
        }
    }
}
