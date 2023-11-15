using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var degerler = c.Blogs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var values = c.Blogs.Find(id);
            c.Blogs.Remove(values);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var values = c.Blogs.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateBlog(Blog p)
        {
            var x = c.Blogs.Find(p.ID);
            x.Baslik = p.Baslik;
            x.Aciklama = p.Aciklama;
            x.BlogImage = p.BlogImage;
            x.Tarih = p.Tarih;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}