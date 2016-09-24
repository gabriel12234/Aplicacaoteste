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
    public class ReceitaController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /Receita/
        public ActionResult Index()
        {
            var receitas = db.RECEITAS.Include(r => r.PACIENTE);
            return View(receitas.ToList());
        }

        // GET: /Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEITAS receitas = db.RECEITAS.Find(id);
            if (receitas == null)
            {
                return HttpNotFound();
            }
            return View(receitas);
        }

        // GET: /Receita/Create
        public ActionResult Create()
        {
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /Receita/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_RECEITA,TITULO,CATEGORIA,MODO_PREPARO,INGREDIENTES,FOTO_RECEITA,ID_PACIENTE")] RECEITAS receitas)
        {
            if (ModelState.IsValid)
            {
                db.RECEITAS.Add(receitas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", receitas.ID_PACIENTE);
            return View(receitas);
        }

        // GET: /Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEITAS receitas = db.RECEITAS.Find(id);
            if (receitas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", receitas.ID_PACIENTE);
            return View(receitas);
        }

        // POST: /Receita/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_RECEITA,TITULO,CATEGORIA,MODO_PREPARO,INGREDIENTES,FOTO_RECEITA,ID_PACIENTE")] RECEITAS receitas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receitas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", receitas.ID_PACIENTE);
            return View(receitas);
        }

        // GET: /Receita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RECEITAS receitas = db.RECEITAS.Find(id);
            if (receitas == null)
            {
                return HttpNotFound();
            }
            return View(receitas);
        }

        // POST: /Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RECEITAS receitas = db.RECEITAS.Find(id);
            db.RECEITAS.Remove(receitas);
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
