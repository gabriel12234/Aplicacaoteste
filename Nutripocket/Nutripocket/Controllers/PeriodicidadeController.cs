using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Nutripocket.Models;

namespace Nutripocket.Controllers
{
    public class PeriodicidadeController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Periodicidade/
        public ActionResult Index()
        {
            var periodicidade = db.PERIODICIDADE.Include(p => p.RECOR_ALIMENTACAO);
            return View(periodicidade.ToList());
        }

        // GET: /Periodicidade/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDADE periodicidade = db.PERIODICIDADE.Find(id);
            if (periodicidade == null)
            {
                return HttpNotFound();
            }
            return View(periodicidade);
        }

        // GET: /Periodicidade/Create
        public ActionResult Create()
        {
            ViewBag.ID_PERIODO = new SelectList(db.RECOR_ALIMENTACAO, "ID_PERIODO", "DESC_ALIMENTO");
            return View();
        }

        // POST: /Periodicidade/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_PERIODO,DESC_PERIODO")] PERIODICIDADE periodicidade)
        {
            if (ModelState.IsValid)
            {
                db.PERIODICIDADE.Add(periodicidade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PERIODO = new SelectList(db.RECOR_ALIMENTACAO, "ID_PERIODO", "DESC_ALIMENTO", periodicidade.ID_PERIODO);
            return View(periodicidade);
        }

        // GET: /Periodicidade/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDADE periodicidade = db.PERIODICIDADE.Find(id);
            if (periodicidade == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PERIODO = new SelectList(db.RECOR_ALIMENTACAO, "ID_PERIODO", "DESC_ALIMENTO", periodicidade.ID_PERIODO);
            return View(periodicidade);
        }

        // POST: /Periodicidade/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_PERIODO,DESC_PERIODO")] PERIODICIDADE periodicidade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periodicidade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PERIODO = new SelectList(db.RECOR_ALIMENTACAO, "ID_PERIODO", "DESC_ALIMENTO", periodicidade.ID_PERIODO);
            return View(periodicidade);
        }

        // GET: /Periodicidade/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PERIODICIDADE periodicidade = db.PERIODICIDADE.Find(id);
            if (periodicidade == null)
            {
                return HttpNotFound();
            }
            return View(periodicidade);
        }

        // POST: /Periodicidade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PERIODICIDADE periodicidade = db.PERIODICIDADE.Find(id);
            db.PERIODICIDADE.Remove(periodicidade);
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
