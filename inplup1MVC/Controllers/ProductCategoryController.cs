using inplup1MVC.Data;
using inplup1MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace inplup1MVC.Controllers
{
    public class ProductCategoryController : BaseController
    {
        private readonly ILogger<ProductCategoryController> _logger;

        public ProductCategoryController(ILogger<ProductCategoryController> logger, ApplicationDbContext dbContext)
           : base(dbContext)
        {
            _logger = logger;
        }

        public IActionResult Index(string q)
        {
            var viewModel = new ProductCategoryIndexViewModel();

            viewModel.ProductCategories = _dbContext.ProductCategories
    .Where(r => q == null || r.Namn.Contains(q))
    .Select(dbVacc => new ProductCategoryViewModel
    {
        Id = dbVacc.Id,
        Name = dbVacc.Namn
    }).ToList();

            return View(viewModel);
        }
        [Authorize(Roles = "PlayerAdmin,Admin")]
        public IActionResult Edit(int Id)
        {
            var viewModel = new ProductCategoryEditViewModel();

            var dbPc = _dbContext.ProductCategories.First(r => r.Id == Id);

            viewModel.Id = dbPc.Id;
            
            viewModel.Namn = dbPc.Namn;
            

            

            return View(viewModel);
        }

        public IActionResult New()
        {
            var viewModel = new ProductCategoryNewViewModel();
            

            return View(viewModel);
        }

        [HttpPost]

        public IActionResult New(ProductCategoryNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbVaccin = new ProductCategory();
                _dbContext.ProductCategories.Add(dbVaccin);
                
                dbVaccin.Namn = viewModel.Namn;
                
             
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(viewModel);
        }


    }
}
