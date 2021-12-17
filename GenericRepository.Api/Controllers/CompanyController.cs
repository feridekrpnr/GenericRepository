using GenericRepository.Api.Controllers.Helpers;
using GenericRepository.Business.Abstract;
using GenericRepository.DataAccess;
using GenericRepository.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
       
         private readonly ICompanyServices _companyServices;
        private readonly GenericDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly GenericHelperMethods _genericHelperMethods;
        //public CompanyController(ICompanyServices companyServices)
        //{
        //    this._companyServices = companyServices;
        //}

        public CompanyController(GenericDBContext context, IConfiguration configuration, GenericHelperMethods genericHelperMethods, ICompanyServices companyServices)
        {
            _context = context;
            _configuration = configuration;
            _genericHelperMethods = genericHelperMethods;
            this._companyServices = companyServices;
        }

        [HttpPost("[action]")]
        public async Task<bool> Create([FromBody] Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
            return true;
        }

        //[HttpPost("[action]")]
        //public async Task<Company> Create(Company company)
        //{
        //    await _companyServices.CreateCompany(company);
        //    return company;
        //}
      

        //url/api/company/getallcompanies
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Company>>>GetAllCompanies()
        {
            var company = await _companyServices.GetAllCompanies();
            return Ok(company);
        }
       
        [HttpGet("GetAll")]
        public async Task <ActionResult<IEnumerable<Company>>> GetAll()
        {
            var categories = await _companyServices.GetAllCompanies();
            return Ok(categories);
        }
    }
}