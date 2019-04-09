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
    public class salida_empleadoController : Controller
    {
        private RecursosFinalEntities db = new RecursosFinalEntities();

        // GET: salida_empleado
        public ActionResult Index()
        {
            var salida_empleado = db.salida_empleado.Include(s => s.empleado);
            return View(salida_empleado.ToList());
        }

        // GET: salida_empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_empleado salida_empleado = db.salida_empleado.Find(id);
            if (salida_empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_empleado);
        }

        // GET: salida_empleado/Create
        public ActionResult Create()
        {
            ViewBag.codigo_empleado1 = new SelectList(db.empleado, "codigo_empleado", "nombre");
            return View();
        }

        // POST: salida_empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_salida_empleado,codigo_empleado1,tipo_salida,motivo,fecha_salida")] salida_empleado salida_empleado)
        {
            if (ModelState.IsValid)
            {
                db.salida_empleado.Add(salida_empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_empleado1 = new SelectList(db.empleado, "codigo_empleado", "nombre", salida_empleado.codigo_empleado1);
            return View(salida_empleado);
        }

        // GET: salida_empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_empleado salida_empleado = db.salida_empleado.Find(id);
            if (salida_empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_empleado1 = new SelectList(db.empleado, "codigo_empleado", "nombre", salida_empleado.codigo_empleado1);
            return View(salida_empleado);
        }

        // POST: salida_empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_salida_empleado,codigo_empleado1,tipo_salida,motivo,fecha_salida")] salida_empleado salida_empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salida_empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_empleado1 = new SelectList(db.empleado, "codigo_empleado", "nombre", salida_empleado.codigo_empleado1);
            return View(salida_empleado);
        }

        // GET: salida_empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salida_empleado salida_empleado = db.salida_empleado.Find(id);
            if (salida_empleado == null)
            {
                return HttpNotFound();
            }
            return View(salida_empleado);
        }

        // POST: salida_empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salida_empleado salida_empleado = db.salida_empleado.Find(id);
            db.salida_empleado.Remove(salida_empleado);
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
