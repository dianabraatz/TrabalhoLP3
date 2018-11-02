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
    public class SetorController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: Setor
        public ActionResult Index()
        {
            return View(db.setor.ToList());
        }

        // GET: Setor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            setor setor = db.setor.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // GET: Setor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codSetor,nome")] setor setor)
        {
            if (ModelState.IsValid)
            {
                db.setor.Add(setor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            setor setor = db.setor.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codSetor,nome")] setor setor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setor);
        }

        // GET: Setor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            setor setor = db.setor.Find(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            setor setor = db.setor.Find(id);
            db.setor.Remove(setor);
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
