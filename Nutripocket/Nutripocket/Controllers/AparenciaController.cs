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
    public class AparenciaController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Aparencia/
        public ActionResult Index()
        {
            var aparencia = db.APARENCIA.Include(a => a.PACIENTE);
            return View(aparencia.ToList());
        }

        // GET: /Aparencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARENCIA aparencia = db.APARENCIA.Find(id);
            if (aparencia == null)
            {
                return HttpNotFound();
            }
            return View(aparencia);
        }

        // GET: /Aparencia/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /Aparencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_APARENCIA,ID_PACIENTE,AP_FACE,AP_LABIOS,AP_LINGUA,AP_GENGIVA,AP_PELE,AP_CABELOS,AP_MUSCULOS,AP_TRONCO,AP_MEMBROS,AP_UNHAS,AP_SIST_NERVOSO,AP_PESCOCO,Attribute145")] APARENCIA aparencia)
        {
            if (ModelState.IsValid)
            {
                db.APARENCIA.Add(aparencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", aparencia.ID_PACIENTE);
            return View(aparencia);
        }

        // GET: /Aparencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARENCIA aparencia = db.APARENCIA.Find(id);
            if (aparencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", aparencia.ID_PACIENTE);
            return View(aparencia);
        }

        // POST: /Aparencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_APARENCIA,ID_PACIENTE,AP_FACE,AP_LABIOS,AP_LINGUA,AP_GENGIVA,AP_PELE,AP_CABELOS,AP_MUSCULOS,AP_TRONCO,AP_MEMBROS,AP_UNHAS,AP_SIST_NERVOSO,AP_PESCOCO,Attribute145")] APARENCIA aparencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aparencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", aparencia.ID_PACIENTE);
            return View(aparencia);
        }

        // GET: /Aparencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APARENCIA aparencia = db.APARENCIA.Find(id);
            if (aparencia == null)
            {
                return HttpNotFound();
            }
            return View(aparencia);
        }

        // POST: /Aparencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APARENCIA aparencia = db.APARENCIA.Find(id);
            db.APARENCIA.Remove(aparencia);
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
