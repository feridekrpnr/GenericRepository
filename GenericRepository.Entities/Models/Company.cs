using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace GenericRepository.Entities.Model
{
    public class Company
    { 
        public Company()
        {
            Branches = new Collection<Branch>();
        }
        public int CompanyId { get; set; }
     
        public string CompanyName { get; set; }

        public string Adress { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
}
