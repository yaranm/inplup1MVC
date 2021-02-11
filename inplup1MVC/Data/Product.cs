using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.Data
{
    public class Product
    {
        public int Id { get; set; }

        public ProductCategory ProductCategory { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public int Price { get; set; }
        public int CategorieId { get; set; }
       
        
    }

    //Product (id, namn, beskrivning, pris, category_id) 
}
