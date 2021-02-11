using inplup1MVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace inplup1MVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly ApplicationDbContext _dbContext;

        public BaseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
          

            base.OnActionExecuting(context);
        }
    }
}
