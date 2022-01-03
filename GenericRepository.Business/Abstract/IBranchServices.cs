using GenericRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Business.Abstract
{
    public interface IBranchServices
    {
        Task<IEnumerable<Branch>> GetAllWithCompany();
        Task<Branch> GetBranchById(int id);
        Task<Branch> CreateBranch(Branch branch);
       // Task<IEnumerable<Branch>> GetBranchesByCompanyId(int id);
        Task UpdateBranch(Branch branchToBeUpdated, Branch branch);
        Task DeleteBranch(Branch branch);
    }
}
