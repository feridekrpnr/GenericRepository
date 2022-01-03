using GenericRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Entities.Repositories
{
    public interface IBranchRepository: IRepository<Branch>
    {
        Task<Branch>GetWithCompanyByIdAsync(int id);

        Task<IEnumerable<Branch>> GetAllWithCompanyAsync();
     
        }
}
