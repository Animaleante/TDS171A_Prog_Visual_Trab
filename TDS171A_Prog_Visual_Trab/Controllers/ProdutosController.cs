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
    public class ProdutosController : Controller
    {
        private EFContext context = new EFContext();

        
        // GET: Produtos
        public ActionResult Index()
        {
            var produtos = context.Produtos.Where(p => p.Removido == false).Include(c => c.Categoria).Include(f => f.Fabricante).OrderBy(n => n.Nome);
            return View(produtos);
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Produto produto)
        {

            try
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                PopularViewBag();
                return View(produto);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome", produto.FabricanteId);

            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }

                PopularViewBag(produto);
                return View(produto);
            }
            catch {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).Include(c => c.Categoria).Include(f => f.Fabricante).First();

            if (produto == null)
            {
                return HttpNotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {

            Produto produto = context.Produtos.Find(id);

            if (produto.VendaItems.Where(p => p.ProdutoId == id).ToList().Count == 0)
            {
                produto.Removido = true;
                context.Entry(produto).State = EntityState.Modified;
                //context.Produtos.Remove(produto);
                context.SaveChanges();
                TempData["Message"] = "Produto " + produto.VendaItems.Count + " foi removido.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Messageerro"] = "Produto " + produto.Nome.ToUpper() + " não pode ser removido.";
                return RedirectToAction("Index");
            }

        }

        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null) {
                ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome");
            } else {
                ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId", "Nome", produto.FabricanteId);
            }
        }
    }
}
