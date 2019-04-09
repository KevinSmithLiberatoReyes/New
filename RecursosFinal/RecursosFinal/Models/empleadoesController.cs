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
    public class empleadoesController : Controller
    {
        private RecursosFinalEntities db = new RecursosFinalEntities();

        // GET: empleadoes
        public ActionResult Index(string searchBy, string search)
        {


            if (searchBy == "Gender")
            {
                return View(db.empleado.Where(x => x.estatus.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(db.empleado.Where(x => x.fecha_ingreso.StartsWith(search) || search == null).ToList());

            }
        }
        public ActionResult EmpleadosActivos(String Nombre, String Departamento)
        {
            var provider = from s in db.empleado select s;

            if (!String.IsNullOrEmpty(Nombre))
            {
                provider = provider.Where(j => j.nombre.Contains(Nombre)).Where(e => e.estatus == "A");
            }
            else if (!String.IsNullOrEmpty(Departamento))
            {
                provider = provider.Where(x => x.departamento.nombre.Contains(Departamento)).Where(e => e.estatus == "A");
            }
            else
            {
                provider = provider.Where(e => e.estatus == "A");
            }
            return View(provider.ToList());
        }
        // GET: empleadoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // GET: empleadoes/Create
        public ActionResult Create()
        {
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "cargo1");
            ViewBag.id_departamento = new SelectList(db.departamento, "id_departamento", "nombre");
            return View();
        }

        // POST: empleadoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_empleado,codigo_empleado,nombre,apellido,teléfono,id_departamento,id_cargo,fecha_ingreso,salario,estatus")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.empleado.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "cargo1", empleado.id_cargo);
            ViewBag.id_departamento = new SelectList(db.departamento, "id_departamento", "nombre", empleado.id_departamento);
            return View(empleado);
        }

        // GET: empleadoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "cargo1", empleado.id_cargo);
            ViewBag.id_departamento = new SelectList(db.departamento, "id_departamento", "nombre", empleado.id_departamento);
            return View(empleado);
        }

        // POST: empleadoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_empleado,codigo_empleado,nombre,apellido,teléfono,id_departamento,id_cargo,fecha_ingreso,salario,estatus")] empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cargo = new SelectList(db.cargo, "id_cargo", "cargo1", empleado.id_cargo);
            ViewBag.id_departamento = new SelectList(db.departamento, "id_departamento", "nombre", empleado.id_departamento);
            return View(empleado);
        }

        // GET: empleadoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empleado empleado = db.empleado.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return View(empleado);
        }

        // POST: empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            empleado empleado = db.empleado.Find(id);
            db.empleado.Remove(empleado);
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
