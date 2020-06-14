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
    public class ProfessorUnidadeCurricularViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ProfessorUnidadeCurricularViewModels
        public async Task<ActionResult> Index()
        {
            var professorUnidadeCurricularViewModels = db.ProfessorUnidadeCurricularViewModels.Include(p => p.Professor).Include(p => p.UnidadeCurricular);
            return View(await professorUnidadeCurricularViewModels.ToListAsync());
        }

        // GET: ProfessorUnidadeCurricularViewModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels = await db.ProfessorUnidadeCurricularViewModels.FindAsync(id);
            if (professorUnidadeCurricularViewModels == null)
            {
                return HttpNotFound();
            }
            return View(professorUnidadeCurricularViewModels);
        }

        // GET: ProfessorUnidadeCurricularViewModels/Create
        public ActionResult Create()
        {
            ViewBag.ProfessorId = new SelectList(db.Professors, "Id", "Nome");
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome");
            return View();
        }

        // POST: ProfessorUnidadeCurricularViewModels/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,UnidadeCurricularId,ProfessorId")] ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels)
        {
            if (ModelState.IsValid)
            {
                db.ProfessorUnidadeCurricularViewModels.Add(professorUnidadeCurricularViewModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ProfessorId = new SelectList(db.Professors, "Id", "Nome", professorUnidadeCurricularViewModels.ProfessorId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", professorUnidadeCurricularViewModels.UnidadeCurricularId);
            return View(professorUnidadeCurricularViewModels);
        }

        // GET: ProfessorUnidadeCurricularViewModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels = await db.ProfessorUnidadeCurricularViewModels.FindAsync(id);
            if (professorUnidadeCurricularViewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProfessorId = new SelectList(db.Professors, "Id", "Nome", professorUnidadeCurricularViewModels.ProfessorId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", professorUnidadeCurricularViewModels.UnidadeCurricularId);
            return View(professorUnidadeCurricularViewModels);
        }

        // POST: ProfessorUnidadeCurricularViewModels/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UnidadeCurricularId,ProfessorId")] ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professorUnidadeCurricularViewModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ProfessorId = new SelectList(db.Professors, "Id", "Nome", professorUnidadeCurricularViewModels.ProfessorId);
            ViewBag.UnidadeCurricularId = new SelectList(db.UnidadeCurriculars, "Id", "Nome", professorUnidadeCurricularViewModels.UnidadeCurricularId);
            return View(professorUnidadeCurricularViewModels);
        }

        // GET: ProfessorUnidadeCurricularViewModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels = await db.ProfessorUnidadeCurricularViewModels.FindAsync(id);
            if (professorUnidadeCurricularViewModels == null)
            {
                return HttpNotFound();
            }
            return View(professorUnidadeCurricularViewModels);
        }

        // POST: ProfessorUnidadeCurricularViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProfessorUnidadeCurricularViewModels professorUnidadeCurricularViewModels = await db.ProfessorUnidadeCurricularViewModels.FindAsync(id);
            db.ProfessorUnidadeCurricularViewModels.Remove(professorUnidadeCurricularViewModels);
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
