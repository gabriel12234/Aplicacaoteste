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
    public class ExamesLaboratorialController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /ExamesLaboratorial/
        public ActionResult Index()
        {
            var ex_labora = db.EX_LABORA.Include(e => e.PACIENTE);
            return View(ex_labora.ToList());
        }

        // GET: /ExamesLaboratorial/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EX_LABORA ex_labora = db.EX_LABORA.Find(id);
            if (ex_labora == null)
            {
                return HttpNotFound();
            }
            return View(ex_labora);
        }

        // GET: /ExamesLaboratorial/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /ExamesLaboratorial/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_EX_LABORA,ID_PACIENTE,HERMOGRAMA,TRIGLICERIDIOS,PRESSAO_ARTERIAL,GLICEMIA,COLESTEROL,PARASITOLOGICO,CORTISOL,OUTROS")] EX_LABORA ex_labora)
        {
            if (ModelState.IsValid)
            {
                db.EX_LABORA.Add(ex_labora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", ex_labora.ID_PACIENTE);
            return View(ex_labora);
        }

        // GET: /ExamesLaboratorial/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EX_LABORA ex_labora = db.EX_LABORA.Find(id);
            if (ex_labora == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", ex_labora.ID_PACIENTE);
            return View(ex_labora);
        }

        // POST: /ExamesLaboratorial/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_EX_LABORA,ID_PACIENTE,HERMOGRAMA,TRIGLICERIDIOS,PRESSAO_ARTERIAL,GLICEMIA,COLESTEROL,PARASITOLOGICO,CORTISOL,OUTROS")] EX_LABORA ex_labora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ex_labora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", ex_labora.ID_PACIENTE);
            return View(ex_labora);
        }

        // GET: /ExamesLaboratorial/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EX_LABORA ex_labora = db.EX_LABORA.Find(id);
            if (ex_labora == null)
            {
                return HttpNotFound();
            }
            return View(ex_labora);
        }

        // POST: /ExamesLaboratorial/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EX_LABORA ex_labora = db.EX_LABORA.Find(id);
            db.EX_LABORA.Remove(ex_labora);
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
