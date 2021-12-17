using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GenericRepository.Entities.Model
{
    public class User :IdentityUser<int>
    {

        [StringLength(50)]
        [Required]
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; } // ? null gelebilir
        
    }
}
