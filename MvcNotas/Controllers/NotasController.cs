using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcNotas.Models;

namespace MvcNotas.Controllers
{
    public class NotasController : Controller
    {
        private NotasDBContext db = new NotasDBContext();

        // GET: Notas
        public ActionResult Index(string buscarString, string estadoNotas)
        {
            var notas = from p in db.Notas
                            select p;

            var EstadoLst = new List<string>();
            var EstadoQry = from d in db.Notas
                            orderby d.Estado
                            select d.Estado;
            EstadoLst.AddRange(EstadoQry.Distinct());
            ViewBag.estadoNotas = new SelectList(EstadoLst);

            if (!String.IsNullOrEmpty(buscarString))
            {
                notas = notas.Where(s => s.Nombre.Contains(buscarString));
            }

            if (!string.IsNullOrEmpty(estadoNotas))
            {
                notas = notas.Where(x => x.Estado == estadoNotas);
            }
            return View(notas);
        }

        // GET: Notas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // GET: Notas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nombre,Apellidos,Materia,Nota1,Nota2,Nota3,Promedio,Estado")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Notas.Add(notas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notas);
        }

        // GET: Notas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: Notas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nombre,Apellidos,Materia,Nota1,Nota2,Nota3,Promedio,Estado")] Notas notas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notas);
        }

        // GET: Notas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Notas notas = db.Notas.Find(id);
            if (notas == null)
            {
                return HttpNotFound();
            }
            return View(notas);
        }

        // POST: Notas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Notas notas = db.Notas.Find(id);
            db.Notas.Remove(notas);
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
