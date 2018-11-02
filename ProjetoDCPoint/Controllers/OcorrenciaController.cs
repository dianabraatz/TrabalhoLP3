using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoDCPoint.Models;

namespace ProjetoDCPoint.Controllers
{
    public class OcorrenciaController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: Ocorrencia
        public ActionResult Index()
        {
            var ocorrencia = db.ocorrencia.Include(o => o.ponto).Include(o => o.statusOcorrencia);
            return View(ocorrencia.ToList());
        }

        // GET: Ocorrencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ocorrencia ocorrencia = db.ocorrencia.Find(id);
            if (ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(ocorrencia);
        }

        // GET: Ocorrencia/Create
        public ActionResult Create()
        {
            ViewBag.codPonto = new SelectList(db.ponto, "codPonto", "codPonto");
            ViewBag.status = new SelectList(db.statusOcorrencia, "idStatus", "descricao");
            return View();
        }

        // POST: Ocorrencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codOcorrencia_,justificativa,status,codPonto")] ocorrencia ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.ocorrencia.Add(ocorrencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codPonto = new SelectList(db.ponto, "codPonto", "codPonto", ocorrencia.codPonto);
            ViewBag.status = new SelectList(db.statusOcorrencia, "idStatus", "descricao", ocorrencia.status);
            return View(ocorrencia);
        }

        // GET: Ocorrencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ocorrencia ocorrencia = db.ocorrencia.Find(id);
            if (ocorrencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.codPonto = new SelectList(db.ponto, "codPonto", "codPonto", ocorrencia.codPonto);
            ViewBag.status = new SelectList(db.statusOcorrencia, "idStatus", "descricao", ocorrencia.status);
            return View(ocorrencia);
        }

        // POST: Ocorrencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codOcorrencia_,justificativa,status,codPonto")] ocorrencia ocorrencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocorrencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codPonto = new SelectList(db.ponto, "codPonto", "codPonto", ocorrencia.codPonto);
            ViewBag.status = new SelectList(db.statusOcorrencia, "idStatus", "descricao", ocorrencia.status);
            return View(ocorrencia);
        }

        // GET: Ocorrencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ocorrencia ocorrencia = db.ocorrencia.Find(id);
            if (ocorrencia == null)
            {
                return HttpNotFound();
            }
            return View(ocorrencia);
        }

        // POST: Ocorrencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ocorrencia ocorrencia = db.ocorrencia.Find(id);
            db.ocorrencia.Remove(ocorrencia);
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
