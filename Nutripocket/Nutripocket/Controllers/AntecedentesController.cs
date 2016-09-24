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
    public class AntecedentesController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Antecedentes/
        public ActionResult Index()
        {
            var antecedentes_familiares = db.ANTECEDENTES_FAMILIARES.Include(a => a.PACIENTE);
            return View(antecedentes_familiares.ToList());
        }

        // GET: /Antecedentes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTECEDENTES_FAMILIARES antecedentes_familiares = db.ANTECEDENTES_FAMILIARES.Find(id);
            if (antecedentes_familiares == null)
            {
                return HttpNotFound();
            }
            return View(antecedentes_familiares);
        }

        // GET: /Antecedentes/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /Antecedentes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_ANTECEDENTES,ID_PACIENTE,HIPERTENSAO,OBESIDADE,CANCER,DIABETES,DCV,DISLIPIDEMIA,AVC,ANEMIA,OUTROS")] ANTECEDENTES_FAMILIARES antecedentes_familiares)
        {
            if (ModelState.IsValid)
            {
                db.ANTECEDENTES_FAMILIARES.Add(antecedentes_familiares);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antecedentes_familiares.ID_PACIENTE);
            return View(antecedentes_familiares);
        }

        // GET: /Antecedentes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTECEDENTES_FAMILIARES antecedentes_familiares = db.ANTECEDENTES_FAMILIARES.Find(id);
            if (antecedentes_familiares == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antecedentes_familiares.ID_PACIENTE);
            return View(antecedentes_familiares);
        }

        // POST: /Antecedentes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_ANTECEDENTES,ID_PACIENTE,HIPERTENSAO,OBESIDADE,CANCER,DIABETES,DCV,DISLIPIDEMIA,AVC,ANEMIA,OUTROS")] ANTECEDENTES_FAMILIARES antecedentes_familiares)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antecedentes_familiares).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antecedentes_familiares.ID_PACIENTE);
            return View(antecedentes_familiares);
        }

        // GET: /Antecedentes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTECEDENTES_FAMILIARES antecedentes_familiares = db.ANTECEDENTES_FAMILIARES.Find(id);
            if (antecedentes_familiares == null)
            {
                return HttpNotFound();
            }
            return View(antecedentes_familiares);
        }

        // POST: /Antecedentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANTECEDENTES_FAMILIARES antecedentes_familiares = db.ANTECEDENTES_FAMILIARES.Find(id);
            db.ANTECEDENTES_FAMILIARES.Remove(antecedentes_familiares);
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
