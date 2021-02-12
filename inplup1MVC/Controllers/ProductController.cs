using inplup1MVC.Data;
using inplup1MVC.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController(ApplicationDbContext dbContext)
            : base(dbContext)
        {
        }

        public IActionResult SearchResult(string q)
        {
            var viewModel = new ProductSearchResultViewModel();

            viewModel.Produkter = _dbContext.Produkter.Include(r => r.ProductCategory)
                .Where(r => q == null || r.Name.Contains(q) || r.ProductCategory.Namn.Contains(q))
                .Select(dbProd => new ProductViewModel

                {
                    Id = dbProd.Id,
                    Namn = dbProd.Name,
                    Pris = dbProd.Price,
                    ProductCategory = dbProd.ProductCategory.Namn
                }).ToList();

            return View(viewModel);
        }



        public IActionResult Index(string q)
        {
            var viewModel = new ProductIndexViewModel();

            viewModel.Produkter = _dbContext.Produkter.Include(r => r.ProductCategory)
                .Where(r => q == null || r.Name.Contains(q) || r.ProductCategory.Namn.Contains(q))
                .Select(dbProd => new ProductViewModel

                {
                    Id = dbProd.Id,
                    Namn = dbProd.Name,
                    Pris = dbProd.Price,
                    Description = dbProd.Description,
                    ProductCategory = dbProd.ProductCategory.Namn


                }).ToList();

            return View(viewModel);
        }

        [Authorize(Roles = "Admin, ProductManager")]
        public IActionResult New()
        {
            var viewModel = new ProductNewViewModel();
            viewModel.AllCategory = GetCategorySelectListItems();

            return View(viewModel);

        }
        [Authorize(Roles = "Admin, ProductManager")]
        [HttpPost]
        public IActionResult New(ProductNewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = new Product();
                dbProduct.ProductCategory = _dbContext.ProductCategories.First(r => r.Id == viewModel.SelectedCategorieId);
                dbProduct.Name = viewModel.Namn;
                dbProduct.Price = viewModel.Price;
                dbProduct.Description = viewModel.Comment;
                _dbContext.Produkter.Add(dbProduct);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.AllCategory = GetCategorySelectListItems();
            return View(viewModel);
        }

        [Authorize(Roles = "Admin, ProductManager")]
        public IActionResult Edit(int Id)
        {
            var viewModel = new ProductEditViewModel();

            var dbProduct = _dbContext.Produkter.Include(p => p.ProductCategory).First(r => r.Id == Id);

            viewModel.Id = dbProduct.Id;
            viewModel.SelectedProductCategoryId = dbProduct.ProductCategory.Id;
            viewModel.AllProductCategory = GetCategorySelectListItems();
            viewModel.Namn = dbProduct.Name;
            viewModel.Pris = dbProduct.Price;
            viewModel.Comment = dbProduct.Description;

            viewModel.AllProductCategory = GetCategorySelectListItems();
            

            return View(viewModel);
        }
        private List<SelectListItem> GetNamnSelectListItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "Välj något" });

            list.AddRange(_dbContext.ProductCategories.Select(r => new SelectListItem
            {
                Text = r.Namn,
                Value = r.Id.ToString()
            }));
            return list;
        }

        [Authorize(Roles = "Admin, ProductManager")]
        [HttpPost]
        public IActionResult Edit(int Id, ProductEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var dbProduct = _dbContext.Produkter.Include(p => p.ProductCategory).First(r => r.Id == Id);
                dbProduct.ProductCategory = _dbContext.ProductCategories.First(r => r.Id == viewModel.SelectedProductCategoryId);
                dbProduct.Name = viewModel.Namn;
                dbProduct.Price = viewModel.Pris;
                dbProduct.Description = viewModel.Comment;
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            viewModel.AllProductCategory = GetCategorySelectListItems();
            return View(viewModel);
        }


        List<SelectListItem> GetCategorySelectListItems()
        {
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem("Laddare", "5"));
            list.Add(new SelectListItem("Möss", "4"));
            list.Add(new SelectListItem("Skärmar", "3"));
            list.Add(new SelectListItem("Datorer", "2"));
            list.Add(new SelectListItem("Kablar", "1"));
            return list;
        }
    }
}
