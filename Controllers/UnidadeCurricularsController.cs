using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApp005.Models;

namespace WebApp005.Controllers
{
    public class UnidadeCurricularsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UnidadeCurriculars
        public async Task<ActionResult> Index()
        {
            return View(await db.UnidadeCurriculars.ToListAsync());
        }

        // GET: UnidadeCurriculars/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricular unidadeCurricular = await db.UnidadeCurriculars.FindAsync(id);
            if (unidadeCurricular == null)
            {
                return HttpNotFound();
            }
            return View(unidadeCurricular);
        }

        // GET: UnidadeCurriculars/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UnidadeCurriculars/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,CargaHoraria")] UnidadeCurricular unidadeCurricular)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeCurriculars.Add(unidadeCurricular);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(unidadeCurricular);
        }

        // GET: UnidadeCurriculars/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricular unidadeCurricular = await db.UnidadeCurriculars.FindAsync(id);
            if (unidadeCurricular == null)
            {
                return HttpNotFound();
            }
            return View(unidadeCurricular);
        }

        // POST: UnidadeCurriculars/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,CargaHoraria")] UnidadeCurricular unidadeCurricular)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeCurricular).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(unidadeCurricular);
        }

        // GET: UnidadeCurriculars/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricular unidadeCurricular = await db.UnidadeCurriculars.FindAsync(id);
            if (unidadeCurricular == null)
            {
                return HttpNotFound();
            }
            return View(unidadeCurricular);
        }

        // POST: UnidadeCurriculars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UnidadeCurricular unidadeCurricular = await db.UnidadeCurriculars.FindAsync(id);
            db.UnidadeCurriculars.Remove(unidadeCurricular);
            await db.SaveChangesAsync();
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
