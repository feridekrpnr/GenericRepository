using GenericRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Entities.Repositories
{
    public interface ICompanyRepository: IRepository<Company>
    {
        //tüm kullanıcıları listelemek istersem
        Task<IEnumerable<Company>> GetAllWithBranchAsync();

    }
}
