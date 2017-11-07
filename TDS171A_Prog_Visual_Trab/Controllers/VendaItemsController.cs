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
            return HttpNotFound();
            //return View();
        }

        // GET: Vendas/Create
        public ActionResult Create(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Venda venda = context.Vendas.Where(p => p.VendaId == id).First();

            if (venda == null) {
                return HttpNotFound();
            }

            ViewBag.VendaId = id;
            ViewBag.ProdutoId = new SelectList(context.Produtos.OrderBy(b => b.Nome), "ProdutoId", "Nome");

            return View();
        }

        // POST: Vendas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VendaItem vendaItem)
        {
            try {
                context.VendaItems.Add(vendaItem);
                context.SaveChanges();
                return RedirectToAction("Details", "Vendas", new { id = vendaItem.VendaId });
            } catch {
                return View(vendaItem);
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            VendaItem vendaItem = context.VendaItems.Where(p => p.VendaItemId == id).Include(p => p.Produto).First();

            if (vendaItem == null) {
                return HttpNotFound();
            }

            return View(vendaItem);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            try {
                VendaItem vendaItem = context.VendaItems.Find(id);
                context.Entry(vendaItem).State = EntityState.Modified;
                context.VendaItems.Remove(vendaItem);
                context.SaveChanges();
                //TempData["Message"] = "Produto " + vendaItem.Nome.ToUpper() + " foi removido.";

                return RedirectToAction("Details", "Vendas", new { id = vendaItem.VendaId });
            } catch {
                return View();
            }
        }
    }
}