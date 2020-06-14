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
    public class UnidadeCurricularCursoViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UnidadeCurricularCursoViewModels
        public async Task<ActionResult> Index()
        {
            var unidadeCurricularCursoViewModels = db.UnidadeCurricularCursoViewModels.Include(u => u.Curso).Include(u => u.UnidadeCurricular);
            return View(await unidadeCurricularCursoViewModels.ToListAsync());
        }

        // GET: UnidadeCurricularCursoViewModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels = await db.UnidadeCurricularCursoViewModels.FindAsync(id);
            if (unidadeCurricularCursoViewModels == null)
            {
                return HttpNotFound();
            }
            return View(unidadeCurricularCursoViewModels);
        }

        // GET: UnidadeCurricularCursoViewModels/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome");
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome");
            return View();
        }

        // POST: UnidadeCurricularCursoViewModels/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CursoId,UnidadeCurricularId")] UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels)
        {
            if (ModelState.IsValid)
            {
                db.UnidadeCurricularCursoViewModels.Add(unidadeCurricularCursoViewModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", unidadeCurricularCursoViewModels.CursoId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", unidadeCurricularCursoViewModels.UnidadeCurricularId);
            return View(unidadeCurricularCursoViewModels);
        }

        // GET: UnidadeCurricularCursoViewModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels = await db.UnidadeCurricularCursoViewModels.FindAsync(id);
            if (unidadeCurricularCursoViewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", unidadeCurricularCursoViewModels.CursoId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", unidadeCurricularCursoViewModels.UnidadeCurricularId);
            return View(unidadeCurricularCursoViewModels);
        }

        // POST: UnidadeCurricularCursoViewModels/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CursoId,UnidadeCurricularId")] UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidadeCurricularCursoViewModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", unidadeCurricularCursoViewModels.CursoId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", unidadeCurricularCursoViewModels.UnidadeCurricularId);
            return View(unidadeCurricularCursoViewModels);
        }

        // GET: UnidadeCurricularCursoViewModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels = await db.UnidadeCurricularCursoViewModels.FindAsync(id);
            if (unidadeCurricularCursoViewModels == null)
            {
                return HttpNotFound();
            }
            return View(unidadeCurricularCursoViewModels);
        }

        // POST: UnidadeCurricularCursoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UnidadeCurricularCursoViewModels unidadeCurricularCursoViewModels = await db.UnidadeCurricularCursoViewModels.FindAsync(id);
            db.UnidadeCurricularCursoViewModels.Remove(unidadeCurricularCursoViewModels);
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
