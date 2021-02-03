using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductCategoryEditViewModel
    {
        public int Id { get; set; }
       
        [Required]
        [MaxLength(50)]
        public string Namn { get; set; }
    }
}
