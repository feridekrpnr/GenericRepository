using GenericRepository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private GenericDBContext _context;
        private CompanyRepository _companyRepository;
        private BranchRepository _branchRepository;

        public UnitOfWork(GenericDBContext context)//constructor
        {
            this._context = context;
        }
        public ICompanyRepository Companies => _companyRepository = _companyRepository ?? new CompanyRepository(_context);
        public IBranchRepository Branches => _branchRepository = _branchRepository ?? new BranchRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
