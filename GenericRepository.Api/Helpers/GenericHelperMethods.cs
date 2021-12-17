using GenericRepository.Api.Models;
using GenericRepository.DataAccess;
using GenericRepository.Entities.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepository.Api.Controllers.Helpers
{
    public class GenericHelperMethods
    {
        public GenericHelperMethods()
        {

        }
        public async Task<Token> CreateRefreshToken(User user, GenericDBContext _context, IConfiguration _configuration)
        {
            //user için token üretiliyor
            TokenHandler tokenHandler = new TokenHandler(_configuration);
            Token token = tokenHandler.CreateAccessToken(user);
            //refresh token kullanıcı tablosuna işleniyor.
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenEndDate = token.Expiration.AddMinutes(5);
            await _context.SaveChangesAsync();
            return token;
        }
    }
}