using GenericRepository.Entities.Model;
using GenericRepository.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DataAccess.Repositories
{
    public class CompanyRepository:Repository<Company>,ICompanyRepository
    {
        public CompanyRepository(GenericDBContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Company>> GetAllWithBranchAsync()
        {
          return (IEnumerable<Company>)await GenericDBContext.Companies.Include(a => a.Branches).SingleOrDefaultAsync();
        }
        private GenericDBContext GenericDBContext
        {
            get { return Context as GenericDBContext; }
        }
    }
}
