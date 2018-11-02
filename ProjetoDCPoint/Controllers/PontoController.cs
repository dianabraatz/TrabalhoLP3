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
    public class PontoController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: pontoes
        public ActionResult Index()
        {
            var ponto = db.ponto.Include(p => p.funcionario);
            return View(ponto.ToList());
        }

        // GET: pontoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.ponto.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // GET: pontoes/Create
        public ActionResult Create()
        {
            ViewBag.numRegistro = new SelectList(db.funcionario, "numRegistro", "senha");
            return View();
        }

        // POST: pontoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codPonto,dh_ponto1,dh_ponto2,dh_ponto3,dh_ponto4,numRegistro")] ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.ponto.Add(ponto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.numRegistro = new SelectList(db.funcionario, "numRegistro", "senha", ponto.numRegistro);
            return View(ponto);
        }

        // GET: pontoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.ponto.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            ViewBag.numRegistro = new SelectList(db.funcionario, "numRegistro", "senha", ponto.numRegistro);
            return View(ponto);
        }

        // POST: pontoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codPonto,dh_ponto1,dh_ponto2,dh_ponto3,dh_ponto4,numRegistro")] ponto ponto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ponto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.numRegistro = new SelectList(db.funcionario, "numRegistro", "senha", ponto.numRegistro);
            return View(ponto);
        }

        // GET: pontoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ponto ponto = db.ponto.Find(id);
            if (ponto == null)
            {
                return HttpNotFound();
            }
            return View(ponto);
        }

        // POST: pontoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ponto ponto = db.ponto.Find(id);
            db.ponto.Remove(ponto);
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
