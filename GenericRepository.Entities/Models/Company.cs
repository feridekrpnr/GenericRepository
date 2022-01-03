﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericRepository.Entities.Models
{
    public class Company
    { 
        public Company()
        {
            Branches = new Collection<Branch>();
        }
        [Key]
        public int CompanyId { get; set; }
     
        public string CompanyName { get; set; }

        public string Adress { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
