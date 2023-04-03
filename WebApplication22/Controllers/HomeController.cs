using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace WebApplication22.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductList(int? page, int? pageSize)
        {
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            //Ddefault size is 5 otherwise take pageSize value  
            int defaSize = (pageSize ?? 5);

            ViewBag.psize = defaSize;

            //Dropdownlist code for PageSize selection  
            //In View Attach this  
            ViewBag.PageSize = new List<SelectListItem>()
    {

        new SelectListItem() { Value="10", Text= "10" },
        new SelectListItem() { Value="15", Text= "15" },
        new SelectListItem() { Value="25", Text= "25" },
        new SelectListItem() { Value="50", Text= "50" },
     };

            //Create a instance of our DataContext  
            ProductModel _dbContext = new ProductModel();
            IPagedList<tblProduct1> involst = null;

            //Alloting nos. of records as per pagesize and page index.  
            involst = _dbContext.tblProduct1.OrderBy(x => x.ProductId).ToPagedList(pageIndex, defaSize);

            return View(involst);
        }
    }
}