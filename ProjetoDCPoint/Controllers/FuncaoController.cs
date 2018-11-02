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
    public class FuncaoController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: Funcao
        public ActionResult Index()
        {
            return View(db.funcao.ToList());
        }

        // GET: Funcao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcao funcao = db.funcao.Find(id);
            if (funcao == null)
            {
                return HttpNotFound();
            }
            return View(funcao);
        }

        // GET: Funcao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Funcao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codFuncao,nivelAcesso,nome")] funcao funcao)
        {
            if (ModelState.IsValid)
            {
                db.funcao.Add(funcao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(funcao);
        }

        // GET: Funcao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcao funcao = db.funcao.Find(id);
            if (funcao == null)
            {
                return HttpNotFound();
            }
            return View(funcao);
        }

        // POST: Funcao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codFuncao,nivelAcesso,nome")] funcao funcao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(funcao);
        }

        // GET: Funcao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcao funcao = db.funcao.Find(id);
            if (funcao == null)
            {
                return HttpNotFound();
            }
            return View(funcao);
        }

        // POST: Funcao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcao funcao = db.funcao.Find(id);
            db.funcao.Remove(funcao);
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
