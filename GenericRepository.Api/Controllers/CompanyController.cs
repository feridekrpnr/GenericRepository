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
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyServices _companyServices;


        private readonly GenericDBContext _context;
        //private readonly IConfiguration _configuration;
        //private readonly GenericHelperMethods _genericHelperMethods;

        //public CompanyController(ICompanyServices companyServices)
        //{
        //    this._companyServices = companyServices;
        //}


        public CompanyController(ICompanyServices companyServices)
        {
            _companyServices = companyServices;
        }


        //[HttpPost("[action]")]
        //public async Task<bool> CreateCompany([FromBody] Company company)
        //{
        //    _context.Companies.Add(company);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
        //[HttpPost("[action]")]
        //public async Task<<Response<Company>>Create(Company company)
        //{
        //    await _companyServices.CreateCompany(company);
        //    return company;
        //}


        //url/api/company/getallcompanies
        //[HttpGet("[action]")]
        //public async Task<ActionResult<IEnumerable<Company>>>GetAllCompanies()
        //{
        //    var company = await _companyServices.GetAllCompanies();

        //    return Ok(company);
        //}

        [HttpPost("GetAllCompanies")]
        public async Task<IActionResult> GetAllCompanies()
        {

            try
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;
                var companies = await _companyServices.GetAllCompanies();
                var customerData = (from tempcustomer in companies select tempcustomer);
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                {
                    customerData = customerData.OrderBy(s => s.CompanyName == (sortColumn + " " + sortColumnDirection));
                }
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.CompanyName.Contains(searchValue)
                                                        || m.Adress.Contains(searchValue)
                                                        || m.IsActive.ToString().Contains(searchValue));
                }

                recordsTotal = customerData.Count();
                var data = customerData.Skip(skip).Take(pageSize).ToList(); //skip sonraki sayfayı verir take ise pagesize kadar eleman verir
                var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                //  return new Response<IEnumerable<Company>>().Ok(recordsTotal, data);
                return Ok(jsonData); //data yerine customerdata olsaydı orjinal datanın hepsi dönerdi
            }
            catch (Exception)
            {
                throw;
            }

            //var company = await _companyServices.GetAllCompanies();
            
            //return Ok(company);

        }
        [HttpGet("GetAll")]
        public async Task <Response<IEnumerable<Company>>> GetAll()
        {
            var companies = await _companyServices.GetAllCompanies();
            if (!companies.Any())
            {
                return new Response<IEnumerable<Company>>().NoContent();
            }
            //List olsaydı .count parantez yazmamız dpğru olmazdı.
            return new Response<IEnumerable<Company>>().Ok(companies.Count(), companies);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] Company company)
        {
            await _companyServices.CreateCompany(company);

            return Ok();
        }
        //[HttpPost("[action]")]
        //public async Task<Response<Company>> CreateUpdate(Company company)
        //{

        //    try
        //    {
        //        if (company.CompanyId == 0)
        //            await _companyServices.CreateCompany(company);
        //        else await _companyServices.UpdateCompany(company);
        //        return new Response<Company>().Ok(1, company);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new Response<Company>().Error(1, company, ex.ToString());
        //    }
        //}
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _context.Companies.FindAsync(id);
            if (result == null)
            {
                return new JsonResult(new { success = false, message = "Error while deleting" });
            }
            _context.Companies.Remove(result);
            await _context.SaveChangesAsync();
            return new JsonResult(new { success = true, error = "Deleted Successfully" });
        }

        //[HttpPost("[action]/{id}")]
        //public async Task Delete(int id)
        //{
        //    if (id != 0)
        //    {
        //        var deleteData = await _companyServices.GetCompanyById(id);

        //        await _companyServices.DeleteCompany(deleteData);
        //    }
        //}

        //[Route("books")]
        //public String Index()
        //{
        //    return "sasasaas";
        //}


    }
}