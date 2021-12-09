using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.Entities.Model
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Image { get; set; }
        public int CompanyId { get; set; }

        //Hangi tabloyla ilişki kuracak
        public Company Company{ get; set; }
        public int Id { get; set; }


    }
}
