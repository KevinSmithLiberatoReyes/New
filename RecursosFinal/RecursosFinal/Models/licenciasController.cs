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
    public class licenciasController : Controller
    {
        private RecursosFinalEntities db = new RecursosFinalEntities();

        // GET: licencias
        public ActionResult Index()
        {
            var licencia = db.licencia.Include(l => l.empleado);
            return View(licencia.ToList());
        }

        // GET: licencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // GET: licencias/Create
        public ActionResult Create()
        {
            ViewBag.codigo_empleado4 = new SelectList(db.empleado, "codigo_empleado", "nombre");
            return View();
        }

        // POST: licencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_licecia,codigo_empleado4,desde,hasta,motivo,comentarios")] licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.licencia.Add(licencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigo_empleado4 = new SelectList(db.empleado, "codigo_empleado", "nombre", licencia.codigo_empleado4);
            return View(licencia);
        }

        // GET: licencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigo_empleado4 = new SelectList(db.empleado, "codigo_empleado", "nombre", licencia.codigo_empleado4);
            return View(licencia);
        }

        // POST: licencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_licecia,codigo_empleado4,desde,hasta,motivo,comentarios")] licencia licencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigo_empleado4 = new SelectList(db.empleado, "codigo_empleado", "nombre", licencia.codigo_empleado4);
            return View(licencia);
        }

        // GET: licencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            licencia licencia = db.licencia.Find(id);
            if (licencia == null)
            {
                return HttpNotFound();
            }
            return View(licencia);
        }

        // POST: licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            licencia licencia = db.licencia.Find(id);
            db.licencia.Remove(licencia);
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
