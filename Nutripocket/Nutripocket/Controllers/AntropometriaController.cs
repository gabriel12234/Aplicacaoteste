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
    public class AntropometriaController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Antropometria/
        public ActionResult Index()
        {
            var antropometria = db.ANTROPOMETRIA.Include(a => a.PACIENTE);
            return View(antropometria.ToList());
        }

        // GET: /Antropometria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTROPOMETRIA antropometria = db.ANTROPOMETRIA.Find(id);
            if (antropometria == null)
            {
                return HttpNotFound();
            }
            return View(antropometria);
        }

        // GET: /Antropometria/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /Antropometria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_ANTRO,ID_PACIENTE,PESO_ATUAL,PESO_HABITUAL,PORC_ADEQUADO,ALTURA,IMC,CLASSIFICACAO")] ANTROPOMETRIA antropometria)
        {
            if (ModelState.IsValid)
            {
                db.ANTROPOMETRIA.Add(antropometria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antropometria.ID_PACIENTE);
            return View(antropometria);
        }

        // GET: /Antropometria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTROPOMETRIA antropometria = db.ANTROPOMETRIA.Find(id);
            if (antropometria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antropometria.ID_PACIENTE);
            return View(antropometria);
        }

        // POST: /Antropometria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_ANTRO,ID_PACIENTE,PESO_ATUAL,PESO_HABITUAL,PORC_ADEQUADO,ALTURA,IMC,CLASSIFICACAO")] ANTROPOMETRIA antropometria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(antropometria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", antropometria.ID_PACIENTE);
            return View(antropometria);
        }

        // GET: /Antropometria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ANTROPOMETRIA antropometria = db.ANTROPOMETRIA.Find(id);
            if (antropometria == null)
            {
                return HttpNotFound();
            }
            return View(antropometria);
        }

        // POST: /Antropometria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ANTROPOMETRIA antropometria = db.ANTROPOMETRIA.Find(id);
            db.ANTROPOMETRIA.Remove(antropometria);
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
