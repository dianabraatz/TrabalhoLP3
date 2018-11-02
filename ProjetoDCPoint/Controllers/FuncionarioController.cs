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
    public class FuncionarioController : Controller
    {
        private DCPointContext db = new DCPointContext();

        // GET: Funcionario
        public ActionResult Index()
        {
            var funcionario = db.funcionario.Include(f => f.funcao).Include(f => f.setor);
            return View(funcionario.ToList());
        }

        // GET: Funcionario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionario/Create
        public ActionResult Create()
        {
            ViewBag.codFuncao = new SelectList(db.funcao, "codFuncao", "nome");
            ViewBag.codSetor = new SelectList(db.setor, "codSetor", "nome");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "numRegistro,senha,dataNascimento,nome,rg,cpf,cnh,dataAdmissao,ctps,codFuncao,codSetor")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codFuncao = new SelectList(db.funcao, "codFuncao", "nome", funcionario.codFuncao);
            ViewBag.codSetor = new SelectList(db.setor, "codSetor", "nome", funcionario.codSetor);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.codFuncao = new SelectList(db.funcao, "codFuncao", "nome", funcionario.codFuncao);
            ViewBag.codSetor = new SelectList(db.setor, "codSetor", "nome", funcionario.codSetor);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "numRegistro,senha,dataNascimento,nome,rg,cpf,cnh,dataAdmissao,ctps,codFuncao,codSetor")] funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codFuncao = new SelectList(db.funcao, "codFuncao", "nome", funcionario.codFuncao);
            ViewBag.codSetor = new SelectList(db.setor, "codSetor", "nome", funcionario.codSetor);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            funcionario funcionario = db.funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            funcionario funcionario = db.funcionario.Find(id);
            db.funcionario.Remove(funcionario);
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
