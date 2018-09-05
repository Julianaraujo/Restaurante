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
    public class CardapioConsumoesController : Controller
    {
        private Contexto db = new Contexto();

        // GET: CardapioConsumoes
        public ActionResult Index()
        {
            var cardapioConsumo = db.CardapioConsumo.Include(c => c.Cardapio).Include(c => c.Consumo);
            return View(cardapioConsumo.ToList());
        }

        // GET: CardapioConsumoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioConsumo cardapioConsumo = db.CardapioConsumo.Find(id);
            if (cardapioConsumo == null)
            {
                return HttpNotFound();
            }
            return View(cardapioConsumo);
        }

        // GET: CardapioConsumoes/Create
        public ActionResult Create()
        {
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "Nome");
            ViewBag.ConsumoId = new SelectList(db.Consumo, "ConsumoId", "ConsumoId");
            return View();
        }

        // POST: CardapioConsumoes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardapioId,ConsumoId")] CardapioConsumo cardapioConsumo)
        {
            if (ModelState.IsValid)
            {
                db.CardapioConsumo.Add(cardapioConsumo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "Nome", cardapioConsumo.CardapioId);
            ViewBag.ConsumoId = new SelectList(db.Consumo, "ConsumoId", "ConsumoId", cardapioConsumo.ConsumoId);
            return View(cardapioConsumo);
        }

        // GET: CardapioConsumoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioConsumo cardapioConsumo = db.CardapioConsumo.Find(id);
            if (cardapioConsumo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "Nome", cardapioConsumo.CardapioId);
            ViewBag.ConsumoId = new SelectList(db.Consumo, "ConsumoId", "ConsumoId", cardapioConsumo.ConsumoId);
            return View(cardapioConsumo);
        }

        // POST: CardapioConsumoes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardapioId,ConsumoId")] CardapioConsumo cardapioConsumo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cardapioConsumo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardapioId = new SelectList(db.Cardapio, "CardapioId", "Nome", cardapioConsumo.CardapioId);
            ViewBag.ConsumoId = new SelectList(db.Consumo, "ConsumoId", "ConsumoId", cardapioConsumo.ConsumoId);
            return View(cardapioConsumo);
        }

        // GET: CardapioConsumoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CardapioConsumo cardapioConsumo = db.CardapioConsumo.Find(id);
            if (cardapioConsumo == null)
            {
                return HttpNotFound();
            }
            return View(cardapioConsumo);
        }

        // POST: CardapioConsumoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CardapioConsumo cardapioConsumo = db.CardapioConsumo.Find(id);
            db.CardapioConsumo.Remove(cardapioConsumo);
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
