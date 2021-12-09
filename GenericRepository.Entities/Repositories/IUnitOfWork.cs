using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Entities.Repositories
{
   public  interface IUnitOfWork: IDisposable
    {
        ICompanyRepository Companies { get; }
        IBranchRepository Branches { get;  }
        Task<int> CommitAsync();
    }
}
