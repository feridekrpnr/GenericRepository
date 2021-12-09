using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Api.Models
{
    public class TokenHandler
    {
        public IConfiguration Configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //token üretecek metod
        public Token CreateToken(UserLogin user)
        {
            Token token = new Token();
            //securitykeyin simetrik yansımasını alır
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:Securitykey"]));
            
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // şifreli kimlik oluşturulur.

            token.Expiration = DateTime.Now.AddMinutes(5); //token süresine 5 dk ekler
                                                           //
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer : Configuration["Token:Issuer"],
                audience:Configuration["Token:Audience"],
                expires:token.Expiration,
                notBefore:DateTime.Now,   //Token üretildikten sonra süre ne zaman devreye girsin 
                signingCredentials: signingCredentials
                );
            //yeni bi access token üretir
            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            token.AccessToken = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            token.RefreshToken = CreateRefreshToken();
            return token;
        
        
        }
        public String CreateRefreshToken()
        {
            byte[] tokenArray = new byte[32];
            using(RandomNumberGenerator randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(tokenArray);
                return Convert.ToBase64String(tokenArray);
            }
                
        }
    }
}
