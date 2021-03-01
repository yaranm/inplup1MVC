using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductCategoryIndexViewModel
    {
        public string q { get; set; }
        public List<ProductCategoryViewModel> ProductCategories { get; set; } = new List<ProductCategoryViewModel>();

       
    }
    
}
