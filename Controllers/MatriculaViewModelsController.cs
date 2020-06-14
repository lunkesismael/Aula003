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
    public class MatriculaViewModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MatriculaViewModels
        public async Task<ActionResult> Index()
        {
            var matriculaViewModels = db.MatriculaViewModels.Include(m => m.Aluno).Include(m => m.Curso);
            return View(await matriculaViewModels.ToListAsync());
        }

        // GET: MatriculaViewModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaViewModels matriculaViewModels = await db.MatriculaViewModels.FindAsync(id);
            if (matriculaViewModels == null)
            {
                return HttpNotFound();
            }
            return View(matriculaViewModels);
        }

        // GET: MatriculaViewModels/Create
        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Alunoes, "Id", "Nome");
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome");
            return View();
        }

        // POST: MatriculaViewModels/Create
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Numero,AlunoId,CursoId")] MatriculaViewModels matriculaViewModels)
        {
            if (ModelState.IsValid)
            {
                db.MatriculaViewModels.Add(matriculaViewModels);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunoes, "Id", "Nome", matriculaViewModels.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", matriculaViewModels.CursoId);
            return View(matriculaViewModels);
        }

        // GET: MatriculaViewModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaViewModels matriculaViewModels = await db.MatriculaViewModels.FindAsync(id);
            if (matriculaViewModels == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Alunoes, "Id", "Nome", matriculaViewModels.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", matriculaViewModels.CursoId);
            return View(matriculaViewModels);
        }

        // POST: MatriculaViewModels/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Numero,AlunoId,CursoId")] MatriculaViewModels matriculaViewModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matriculaViewModels).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Alunoes, "Id", "Nome", matriculaViewModels.AlunoId);
            ViewBag.CursoId = new SelectList(db.Cursoes, "Id", "Nome", matriculaViewModels.CursoId);
            return View(matriculaViewModels);
        }

        // GET: MatriculaViewModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MatriculaViewModels matriculaViewModels = await db.MatriculaViewModels.FindAsync(id);
            if (matriculaViewModels == null)
            {
                return HttpNotFound();
            }
            return View(matriculaViewModels);
        }

        // POST: MatriculaViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MatriculaViewModels matriculaViewModels = await db.MatriculaViewModels.FindAsync(id);
            db.MatriculaViewModels.Remove(matriculaViewModels);
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
