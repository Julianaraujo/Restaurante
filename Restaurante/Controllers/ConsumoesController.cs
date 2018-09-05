using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Restaurante.Models;

namespace Restaurante.Controllers
{
    public class ConsumoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Consumoes
        public ActionResult Index()
        {
            var consumo = db.Consumo.Include(c => c.Cliente);
            return View(consumo.ToList());
        }

        // GET: Consumoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // GET: Consumoes/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Cpf");
            return View();
        }

        // POST: Consumoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsumoId,Data,ClienteId,SubTotal")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.Consumo.Add(consumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Cpf", consumo.ClienteId);
            return View(consumo);
        }

        // GET: Consumoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Cpf", consumo.ClienteId);
            return View(consumo);
        }

        // POST: Consumoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsumoId,Data,ClienteId,SubTotal")] Consumo consumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Cpf", consumo.ClienteId);
            return View(consumo);
        }

        // GET: Consumoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consumo consumo = db.Consumo.Find(id);
            if (consumo == null)
            {
                return HttpNotFound();
            }
            return View(consumo);
        }

        // POST: Consumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consumo consumo = db.Consumo.Find(id);
            db.Consumo.Remove(consumo);
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
