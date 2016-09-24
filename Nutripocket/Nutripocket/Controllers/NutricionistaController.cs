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
    public class NutricionistaController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Nutricionista/
        public ActionResult Index()
        {
            return View(db.NUTRICIONISTA.ToList());
        }

        // GET: /Nutricionista/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nutricionista = db.NUTRICIONISTA.Find(id);
            if (nutricionista == null)
            {
                return HttpNotFound();
            }
            return View(nutricionista);
        }

        // GET: /Nutricionista/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Nutricionista/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_NUTRICIONISTA,NUT_NOME,NUT_SEXO,NUT_EMAIL,NUT_CRN,AREA_ATUACAO")] NUTRICIONISTA nutricionista)
        {
            if (ModelState.IsValid)
            {
                db.NUTRICIONISTA.Add(nutricionista);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nutricionista);
        }

        // GET: /Nutricionista/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nutricionista = db.NUTRICIONISTA.Find(id);
            if (nutricionista == null)
            {
                return HttpNotFound();
            }
            return View(nutricionista);
        }

        // POST: /Nutricionista/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_NUTRICIONISTA,NUT_NOME,NUT_SEXO,NUT_EMAIL,NUT_CRN,AREA_ATUACAO")] NUTRICIONISTA nutricionista)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nutricionista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nutricionista);
        }

        // GET: /Nutricionista/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NUTRICIONISTA nutricionista = db.NUTRICIONISTA.Find(id);
            if (nutricionista == null)
            {
                return HttpNotFound();
            }
            return View(nutricionista);
        }

        // POST: /Nutricionista/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NUTRICIONISTA nutricionista = db.NUTRICIONISTA.Find(id);
            db.NUTRICIONISTA.Remove(nutricionista);
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
