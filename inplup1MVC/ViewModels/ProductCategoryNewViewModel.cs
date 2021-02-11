using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductCategoryNewViewModel
    {
        [Required]
        [MaxLength(50)]
        public string Namn { get; set; }

        [Required]
        public string Comment { get; set; }
    }
}
