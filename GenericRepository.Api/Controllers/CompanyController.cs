using GenericRepository.Api.Controllers.Helpers;
using GenericRepository.Business.Abstract;
using GenericRepository.DataAccess;
using GenericRepository.Entities.Models;
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
        //private readonly GenericDBContext _context;
        //private readonly IConfiguration _configuration;
        //private readonly GenericHelperMethods _genericHelperMethods;
        //public CompanyController(ICompanyServices companyServices)
        //{
        //    this._companyServices = companyServices;
        //}

        public CompanyController(ICompanyServices companyServices)
        {
            //_context = context;
            //_configuration = configuration;
            //_genericHelperMethods = genericHelperMethods;
            _companyServices = companyServices;
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] Company company)
        {
            await _companyServices.CreateCompany(company);
            return Ok();
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
        public async Task <Response<IEnumerable<Company>>> GetAll()
        {
            var companies = await _companyServices.GetAllCompanies();
            if (!companies.Any())
            {
                return new Response<IEnumerable<Company>>().NoContent();
            }
            //List olsaydı .count parantez yazmamız dpğru değil.
            return new Response<IEnumerable<Company>>().Ok(companies.Count(), companies);
        }
        //[Route("books")]
        //public String Index()
        //{
        //    return "sasasaas";
        //}


    }
}