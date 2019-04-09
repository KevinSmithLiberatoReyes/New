using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecursosFinal.Models
{
    public class vacacionesController : Controller
    {
        private RecursosFinalEntities db = new RecursosFinalEntities();

        // GET: vacaciones
        public ActionResult Index()
        {
            var vacaciones = db.vacaciones.Include(v => v.empleado);
            return View(vacaciones.ToList());
        }

        // GET: vacaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // GET: vacaciones/Create
        public ActionResult Create()
        {
            ViewBag.codigo_empleado2 = new SelectList(db.empleado, "codigo_empleado", "nombre");
            return View();
        }

        // POST: vacaciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_vacaciones,codigo_empleado2,desde,hasta,correspondiente,comentario")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.vacaciones.Add(vacaciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_empleado2 = new SelectList(db.empleado, "codigo_empleado", "nombre", vacaciones.codigo_empleado2);
            return View(vacaciones);
        }

        // GET: vacaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_empleado2 = new SelectList(db.empleado, "codigo_empleado", "nombre", vacaciones.codigo_empleado2);
            return View(vacaciones);
        }

        // POST: vacaciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_vacaciones,codigo_empleado2,desde,hasta,correspondiente,comentario")] vacaciones vacaciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vacaciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_empleado2 = new SelectList(db.empleado, "codigo_empleado", "nombre", vacaciones.codigo_empleado2);
            return View(vacaciones);
        }

        // GET: vacaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vacaciones vacaciones = db.vacaciones.Find(id);
            if (vacaciones == null)
            {
                return HttpNotFound();
            }
            return View(vacaciones);
        }

        // POST: vacaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vacaciones vacaciones = db.vacaciones.Find(id);
            db.vacaciones.Remove(vacaciones);
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
