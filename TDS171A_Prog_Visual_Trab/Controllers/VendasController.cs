﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TDS171A_Prog_Visual_Trab.Contexts;
using TDS171A_Prog_Visual_Trab.Models;

namespace TDS171A_Prog_Visual_Trab.Controllers
{
    public class VendasController : Controller {

        private EFContext context = new EFContext();

        // GET: Vendas
        public ActionResult Index()
        {
            return View(context.Vendas.OrderBy(c => c.VendaId));
        }

        // GET: Vendas/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venda venda = context.Vendas.Where(p => p.VendaId == id).Include(c => c.VendaItems.Select(vi => vi.Produto)).First();

            if (venda == null) {
                return HttpNotFound();
            }

            return View(venda);            
        }

        // GET: Vendas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Venda venda)
        {
            try {
                venda.Data = DateTime.Now;
                venda.Total = 0;
                context.Vendas.Add(venda);
                context.SaveChanges();
                return RedirectToAction("Edit", new { id = venda.VendaId });
            } catch {
                return View(venda);
            }
        }

        // GET: Vendas/Edit/5        
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas
                .Include(v => v.VendaItems)
                .FirstOrDefault(v => v.VendaId == id.Value);

            if (venda == null)
            {
                return HttpNotFound();
            }

            ViewBag.ProdutoId = new SelectList(context.Produtos, "ProdutoId", "Nome");
            ViewBag.VendaId = new SelectList(context.Vendas, "VendaId", "NumeroNota");
            return View(venda);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaId,NumeroNota,Data,NomeComprador,CpfComprador,TelefoneComprador,Total")] Venda venda)
        {
            if (ModelState.IsValid)
            {
                context.Entry(venda).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venda);
        }

        // GET: Vendas/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venda venda = context.Vendas.Find(id);
            if (venda == null)
            {
                return HttpNotFound();
            }
            return View(venda);
        }

        // POST: Vendas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Venda venda = context.Vendas.Find(id);
            context.Vendas.Remove(venda);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}