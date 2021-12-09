using GenericRepository.Business.Abstract;
using GenericRepository.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private ICompanyServices _companyServices;

        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }
        [HttpGet("GetAllCompanies")]
        public async Task<ActionResult<IEnumerable<Company>>>GetAllCompanies()
        {
            var company = await _companyServices.GetAllCompanies();
            return Ok(company);
        }

       

    }
}
