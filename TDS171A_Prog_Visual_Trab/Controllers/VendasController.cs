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
                context.Vendas.Add(venda);
                context.SaveChanges();
                return RedirectToAction("Index");
            } catch {
                return View(venda);
            }
        }
    }
}