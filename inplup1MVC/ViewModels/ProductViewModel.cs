using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public string ProductCategory { get; set; }
        public int Pris { get; set; }
        public string Description { get; set; }
    }
}
