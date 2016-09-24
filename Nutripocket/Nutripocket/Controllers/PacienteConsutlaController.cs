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
    public class PacienteConsutlaController : Controller
    {
        private NutriPocketEntities db = new NutriPocketEntities();

        // GET: /PacienteConsutla/
        public ActionResult Index()
        {
            var paciente_consulta = db.PACIENTE_CONSULTA.Include(p => p.ANM_CLINICA).Include(p => p.ANM_DADOSGERAIS).Include(p => p.ANTECEDENTES_FAMILIARES).Include(p => p.ANTROPOMETRIA).Include(p => p.APARENCIA).Include(p => p.EX_LABORA).Include(p => p.PACIENTE);
            return View(paciente_consulta.ToList());
        }

        // GET: /PacienteConsutla/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE_CONSULTA paciente_consulta = db.PACIENTE_CONSULTA.Find(id);
            if (paciente_consulta == null)
            {
                return HttpNotFound();
            }
            return View(paciente_consulta);
        }

        // GET: /PacienteConsutla/Create
        public ActionResult Create()
        {
            ViewBag.ID_CLINICA = new SelectList(db.ANM_CLINICA, "ID_CLINICA", "DISFAGIA");
            ViewBag.ID_DADOSGERAIS = new SelectList(db.ANM_DADOSGERAIS, "ID_DADOSGERAIS", "MASTIGACAO");
            ViewBag.ID_ANTECEDENTES = new SelectList(db.ANTECEDENTES_FAMILIARES, "ID_ANTECEDENTES", "HIPERTENSAO");
            ViewBag.ID_ANTRO = new SelectList(db.ANTROPOMETRIA, "ID_ANTRO", "PESO_ATUAL");
            ViewBag.ID_APARENCIA = new SelectList(db.APARENCIA, "ID_APARENCIA", "AP_FACE");
            ViewBag.ID_EX_LABORA = new SelectList(db.EX_LABORA, "ID_EX_LABORA", "HERMOGRAMA");
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME");
            return View();
        }

        // POST: /PacienteConsutla/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID_CONSULTA,ID_PACIENTE,ID_ANTRO,ID_ANTECEDENTES,ID_DADOSGERAIS,ID_CLINICA,ID_APARENCIA,ID_EX_LABORA")] PACIENTE_CONSULTA paciente_consulta)
        {
            if (ModelState.IsValid)
            {
                db.PACIENTE_CONSULTA.Add(paciente_consulta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_CLINICA = new SelectList(db.ANM_CLINICA, "ID_CLINICA", "DISFAGIA", paciente_consulta.ID_CLINICA);
            ViewBag.ID_DADOSGERAIS = new SelectList(db.ANM_DADOSGERAIS, "ID_DADOSGERAIS", "MASTIGACAO", paciente_consulta.ID_DADOSGERAIS);
            ViewBag.ID_ANTECEDENTES = new SelectList(db.ANTECEDENTES_FAMILIARES, "ID_ANTECEDENTES", "HIPERTENSAO", paciente_consulta.ID_ANTECEDENTES);
            ViewBag.ID_ANTRO = new SelectList(db.ANTROPOMETRIA, "ID_ANTRO", "PESO_ATUAL", paciente_consulta.ID_ANTRO);
            ViewBag.ID_APARENCIA = new SelectList(db.APARENCIA, "ID_APARENCIA", "AP_FACE", paciente_consulta.ID_APARENCIA);
            ViewBag.ID_EX_LABORA = new SelectList(db.EX_LABORA, "ID_EX_LABORA", "HERMOGRAMA", paciente_consulta.ID_EX_LABORA);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", paciente_consulta.ID_PACIENTE);
            return View(paciente_consulta);
        }

        // GET: /PacienteConsutla/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE_CONSULTA paciente_consulta = db.PACIENTE_CONSULTA.Find(id);
            if (paciente_consulta == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_CLINICA = new SelectList(db.ANM_CLINICA, "ID_CLINICA", "DISFAGIA", paciente_consulta.ID_CLINICA);
            ViewBag.ID_DADOSGERAIS = new SelectList(db.ANM_DADOSGERAIS, "ID_DADOSGERAIS", "MASTIGACAO", paciente_consulta.ID_DADOSGERAIS);
            ViewBag.ID_ANTECEDENTES = new SelectList(db.ANTECEDENTES_FAMILIARES, "ID_ANTECEDENTES", "HIPERTENSAO", paciente_consulta.ID_ANTECEDENTES);
            ViewBag.ID_ANTRO = new SelectList(db.ANTROPOMETRIA, "ID_ANTRO", "PESO_ATUAL", paciente_consulta.ID_ANTRO);
            ViewBag.ID_APARENCIA = new SelectList(db.APARENCIA, "ID_APARENCIA", "AP_FACE", paciente_consulta.ID_APARENCIA);
            ViewBag.ID_EX_LABORA = new SelectList(db.EX_LABORA, "ID_EX_LABORA", "HERMOGRAMA", paciente_consulta.ID_EX_LABORA);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", paciente_consulta.ID_PACIENTE);
            return View(paciente_consulta);
        }

        // POST: /PacienteConsutla/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID_CONSULTA,ID_PACIENTE,ID_ANTRO,ID_ANTECEDENTES,ID_DADOSGERAIS,ID_CLINICA,ID_APARENCIA,ID_EX_LABORA")] PACIENTE_CONSULTA paciente_consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente_consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_CLINICA = new SelectList(db.ANM_CLINICA, "ID_CLINICA", "DISFAGIA", paciente_consulta.ID_CLINICA);
            ViewBag.ID_DADOSGERAIS = new SelectList(db.ANM_DADOSGERAIS, "ID_DADOSGERAIS", "MASTIGACAO", paciente_consulta.ID_DADOSGERAIS);
            ViewBag.ID_ANTECEDENTES = new SelectList(db.ANTECEDENTES_FAMILIARES, "ID_ANTECEDENTES", "HIPERTENSAO", paciente_consulta.ID_ANTECEDENTES);
            ViewBag.ID_ANTRO = new SelectList(db.ANTROPOMETRIA, "ID_ANTRO", "PESO_ATUAL", paciente_consulta.ID_ANTRO);
            ViewBag.ID_APARENCIA = new SelectList(db.APARENCIA, "ID_APARENCIA", "AP_FACE", paciente_consulta.ID_APARENCIA);
            ViewBag.ID_EX_LABORA = new SelectList(db.EX_LABORA, "ID_EX_LABORA", "HERMOGRAMA", paciente_consulta.ID_EX_LABORA);
            ViewBag.ID_PACIENTE = new SelectList(db.PACIENTE, "ID_PACIENTE", "NOME", paciente_consulta.ID_PACIENTE);
            return View(paciente_consulta);
        }

        // GET: /PacienteConsutla/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PACIENTE_CONSULTA paciente_consulta = db.PACIENTE_CONSULTA.Find(id);
            if (paciente_consulta == null)
            {
                return HttpNotFound();
            }
            return View(paciente_consulta);
        }

        // POST: /PacienteConsutla/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PACIENTE_CONSULTA paciente_consulta = db.PACIENTE_CONSULTA.Find(id);
            db.PACIENTE_CONSULTA.Remove(paciente_consulta);
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
