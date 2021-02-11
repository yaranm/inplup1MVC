using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductNewViewModel
    {
        [Range(1, 100000, ErrorMessage = "Välj en kategori")]
        public int SelectedCategorieId { get; set; }
        public List<SelectListItem> AllCategory { get; set; } = new List<SelectListItem>();

        [MaxLength(50)]
        public string Namn { get; set; }

        [Range(1, 99999)]
        public int Price { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Comment { get; set; }
    }
}
