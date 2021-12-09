using GenericRepository.Business.Abstract;
using GenericRepository.Entities.Model;
using GenericRepository.Entities.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Business.Concrete
{
    public class BranchServices : IBranchServices
    {
        private IUnitOfWork _unitOfWork;
        public BranchServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Branch> CreateBranch(Branch branch)
        {
            await _unitOfWork.Branches.AddAsync(branch);
            return branch;
        }

        public async Task DeleteBranch(Branch branch)
        {
            _unitOfWork.Branches.Remove(branch);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Branch>> GetAllWithCompany()
        {
            //Branche ait olan 
            return await _unitOfWork.Branches.GetAllWithCompanyAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _unitOfWork.Branches.GetByIdAsync(id);
        }

        public async Task<Branch> GetBranchesByCompanyId(int id)
        {
            return await _unitOfWork.Branches.GetWithCompanyByIdAsync(id);
        }

        public async Task UpdateBranch(Branch branchToBeUpdated, Branch branch)
        {
            branchToBeUpdated.Name = branch.Name;
            branchToBeUpdated.CompanyId = branch.CompanyId;
            await _unitOfWork.CommitAsync();
        }

       
    }
}
