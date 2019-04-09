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
    public class permisoesController : Controller
    {
        private RecursosFinalEntities db = new RecursosFinalEntities();

        // GET: permisoes
        public ActionResult Index()
        {
            var permiso = db.permiso.Include(p => p.empleado);
            return View(permiso.ToList());
        }

        // GET: permisoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // GET: permisoes/Create
        public ActionResult Create()
        {
            ViewBag.codigo_empleado3 = new SelectList(db.empleado, "codigo_empleado", "nombre");
            return View();
        }

        // POST: permisoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_permiso,codigo_empleado3,desde,hasta,comentarios")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.permiso.Add(permiso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_empleado3 = new SelectList(db.empleado, "codigo_empleado", "nombre", permiso.codigo_empleado3);
            return View(permiso);
        }

        // GET: permisoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_empleado3 = new SelectList(db.empleado, "codigo_empleado", "nombre", permiso.codigo_empleado3);
            return View(permiso);
        }

        // POST: permisoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_permiso,codigo_empleado3,desde,hasta,comentarios")] permiso permiso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permiso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_empleado3 = new SelectList(db.empleado, "codigo_empleado", "nombre", permiso.codigo_empleado3);
            return View(permiso);
        }

        // GET: permisoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            permiso permiso = db.permiso.Find(id);
            if (permiso == null)
            {
                return HttpNotFound();
            }
            return View(permiso);
        }

        // POST: permisoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            permiso permiso = db.permiso.Find(id);
            db.permiso.Remove(permiso);
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
