
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Entities.Models
{
    //Role olduğu için IdentityRole yazıyoruz
   public class Role :IdentityRole<int>
    {
    }
}
