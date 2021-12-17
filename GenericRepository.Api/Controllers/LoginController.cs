using GenericRepository.Api.Controllers.Helpers;
using GenericRepository.Api.Models;
using GenericRepository.DataAccess;
using GenericRepository.Entities.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //readonly interface ve classları static yapmamızı sağlar.
        private readonly GenericDBContext _context;
        private readonly IConfiguration _configuration;
        private readonly GenericHelperMethods _genericHelperMethods;
       

        public LoginController(GenericDBContext context, IConfiguration configuration, GenericHelperMethods genericHelperMethods)
        {
            _context = context;
            _configuration = configuration;
            _genericHelperMethods = genericHelperMethods;

        }
        [HttpPost("[action]")]
        public async Task<bool> Create([FromBody] User user)
        {         
            _context.User.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }
        [HttpPost("[action]")]
        public async Task<Token> Login([FromBody] UserLogin userLogin)
        {
            User user = await _context.User.FirstOrDefaultAsync(w => w.Email == userLogin.Email && w.Password == userLogin.Password);
            if (user != null)
            {
                return  await _genericHelperMethods.CreateRefreshToken(user, _context, _configuration);
              
            }
            return null;
        }
      
        [HttpPost("[action]")]
        public async Task<Token> RefreshTokenLogin([FromForm] string refreshToken)
        {
            User user = await _context.User.FirstOrDefaultAsync(w => w.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.Now)
            {
                GenericHelperMethods createToken = new GenericHelperMethods();
                return await _genericHelperMethods.CreateRefreshToken(user, _context, _configuration);
            }
            return null;
        }

    }


}
