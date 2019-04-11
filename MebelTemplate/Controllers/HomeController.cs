using MebelTemplate.DAL;
using MebelTemplate.Models.HomeVM;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MebelTemplate.Controllers
{
    public class HomeController : Controller
    {
        public readonly Db db;
        public HomeController()
        {
            db = new Db();
        }
        public async Task<ActionResult> Index()
        {
            HomeVM vm = new HomeVM
            {
                GetHomes=await db.Homes.Take(2).ToListAsync(),
                GetServices=await db.Services.ToListAsync(),
                GetCategories=await db.Categories.ToListAsync(),
                GetBanners=await db.Banners.ToListAsync()
            };
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}