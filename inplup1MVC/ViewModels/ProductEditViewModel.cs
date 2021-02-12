using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductEditViewModel
    {

        public int Id { get; set; }

        

        public int SelectedProductCategoryId { get; set; }
        public List<SelectListItem> AllProductCategory { get; set; } = new List<SelectListItem>();

        [MaxLength(50)]
        public string Namn { get; set; }

        [Range(1, 99999)]
        public int Pris { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
