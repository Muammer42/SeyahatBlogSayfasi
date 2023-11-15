using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class HakkimizdasController : Controller
    {
        private Context db = new Context();

        // GET: Hakkimizdas
        public ActionResult Index()
        {
            return View(db.Hakkimizdas.ToList());
        }

        // GET: Hakkimizdas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizdas.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // GET: Hakkimizdas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hakkimizdas/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FotoUrl,Aciklama")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Hakkimizdas.Add(hakkimizda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }

        // GET: Hakkimizdas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizdas.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Hakkimizdas/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FotoUrl,Aciklama")] Hakkimizda hakkimizda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hakkimizda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hakkimizda);
        }

        // GET: Hakkimizdas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hakkimizda hakkimizda = db.Hakkimizdas.Find(id);
            if (hakkimizda == null)
            {
                return HttpNotFound();
            }
            return View(hakkimizda);
        }

        // POST: Hakkimizdas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hakkimizda hakkimizda = db.Hakkimizdas.Find(id);
            db.Hakkimizdas.Remove(hakkimizda);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
