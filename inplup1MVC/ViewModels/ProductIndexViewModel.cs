using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductIndexViewModel
    {

        public string q { get; set; }
        public List<ProductViewModel> Produkter { get; set; } = new List<ProductViewModel>();

    }
}
