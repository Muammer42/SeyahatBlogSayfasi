using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var value = c.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(value);
        }
        public PartialViewResult Partial2()
        {
            var degerler = c.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(degerler);
        }
        public PartialViewResult Partial3()
        {
            var value = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(value);

        }
    }
}