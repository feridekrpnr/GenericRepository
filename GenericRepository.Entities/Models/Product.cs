using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericRepository.Entities.Models
{
    public class Product
    {
        
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public char Keywords { get; set; }
        public string Image { get; set; }
    }
}
