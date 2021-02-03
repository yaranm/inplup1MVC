using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace inplup1MVC.Data
{


    public class ProductCategory
    {
        public int Id { get; set; }

        


        [MaxLength(50)]
        public string Namn { get; set; }
       


     
    }
}