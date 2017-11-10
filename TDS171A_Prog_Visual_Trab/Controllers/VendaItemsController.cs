using System;
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
    public class VendaItemsController : Controller
    {
        private EFContext context = new EFContext();

        // GET: VendaItems
        public ActionResult Index()
        {
            var vendaItems = context.VendaItems.Include(v => v.Produto).Include(v => v.Venda);
            return View(context.VendaItems.OrderBy(v => v.VendaItemId));
        }

        // GET: VendaItems/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = context.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            //return View(vendaItem);
            return View(context.VendaItems.OrderBy(v => v.VendaItemId));
        }

        // GET: Vendas/Create
        public ActionResult Create(long? id)
        {
            ViewBag.ProdutoId = new SelectList(context.Produtos, "ProdutoId", "Name");
            
            ViewBag.VendaId = new SelectList(context.Vendas, "VendaId", "NumeroNota");
            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaItemId,Quantidade,Valor,ProdutoId,VendaId,Total")] VendaItem vendaItem)
        {
            if (ModelState.IsValid)
            {
                context.VendaItems.Add(vendaItem);
                var venda = context.Vendas.Find(vendaItem.VendaId);
                venda.Total += vendaItem.Quantidade * vendaItem.Valor;
                context.Entry(venda).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Edit", "Vendas", new { id = vendaItem.VendaId });
            }
            return RedirectToAction("Edit", "Vendas", new { id = vendaItem.VendaId });            
        }

       

        // GET: VendaItems/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = context.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(context.Produtos, "ProdutoId", "Name", vendaItem.ProdutoId);
            ViewBag.VendaId = new SelectList(context.Vendas, "VendaId", "NumeroNota", vendaItem.VendaId);
            return View(vendaItem);
        }

        // POST: VendaItems/Edit/5        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaItemId,Quantidade,Valor,ProdutoId,VendaId")] VendaItem vendaItem)
        {
            if (ModelState.IsValid)
            {
                context.Entry(vendaItem).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(context.Produtos, "ProdutoId", "Name", vendaItem.ProdutoId);
            ViewBag.VendaId = new SelectList(context.Vendas, "VendaId", "NumeroNota", vendaItem.VendaId);
            return View(vendaItem);
        }

        // GET: VendaItems/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaItem vendaItem = context.VendaItems.Find(id);
            if (vendaItem == null)
            {
                return HttpNotFound();
            }
            return View(vendaItem);
        }

        // POST: VendaItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            VendaItem vendaItem = context.VendaItems.Find(id);
            context.VendaItems.Remove(vendaItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProduto(long? id)
        {
            VendaItem vendaItem = context.VendaItems.Find(id);
            context.VendaItems.Remove(vendaItem);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}