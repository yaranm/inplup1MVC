using inplup1MVC.Data;
using inplup1MVC.Models;
using inplup1MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
