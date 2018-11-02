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
    public class StatusOcorrenciaController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: StatusOcorrencia
        public ActionResult Index()
        {
            return View(db.statusOcorrencia.ToList());
        }

        // GET: StatusOcorrencia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statusOcorrencia statusOcorrencia = db.statusOcorrencia.Find(id);
            if (statusOcorrencia == null)
            {
                return HttpNotFound();
            }
            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StatusOcorrencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStatus,descricao")] statusOcorrencia statusOcorrencia)
        {
            if (ModelState.IsValid)
            {
                db.statusOcorrencia.Add(statusOcorrencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statusOcorrencia statusOcorrencia = db.statusOcorrencia.Find(id);
            if (statusOcorrencia == null)
            {
                return HttpNotFound();
            }
            return View(statusOcorrencia);
        }

        // POST: StatusOcorrencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStatus,descricao")] statusOcorrencia statusOcorrencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(statusOcorrencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(statusOcorrencia);
        }

        // GET: StatusOcorrencia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            statusOcorrencia statusOcorrencia = db.statusOcorrencia.Find(id);
            if (statusOcorrencia == null)
            {
                return HttpNotFound();
            }
            return View(statusOcorrencia);
        }

        // POST: StatusOcorrencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            statusOcorrencia statusOcorrencia = db.statusOcorrencia.Find(id);
            db.statusOcorrencia.Remove(statusOcorrencia);
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
