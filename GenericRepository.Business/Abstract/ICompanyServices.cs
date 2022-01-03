using GenericRepository.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Business.Abstract
{
    public interface ICompanyServices
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> CreateCompany(Company company);
        Task UpdateCompany(Company companyToBeUpdate, Company company);
        Task DeleteCompany(Company company);

    }
}
