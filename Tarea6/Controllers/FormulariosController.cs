using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tarea6.DAL;
using Tarea6.Models;

namespace Tarea6.Controllers
{
    public class FormulariosController : Controller
    {
        private FormularioContext db = new FormularioContext();

        // GET: Formularios
        public ActionResult Index()
        {
            return View(db.Formularios.ToList());
        }

        
        // GET: Formularios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            return View(formulario);
        }

        // GET: Formularios/Create
        public ActionResult Create()
        {
            var model = new Formulario
            {
                HobbiesDisponibles = GetHobbies()
            };
            return View(model);
        }

        // POST: Formularios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Cedula,Nombre,Apellido,Edad,Telefono,Correo,Genero,EstadoCivil,HobbiesSeleccionados")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                var hobbies = string.Join(", ", formulario.HobbiesSeleccionados);
                formulario.Hobbies = hobbies;
                db.Formularios.Add(formulario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            formulario.HobbiesDisponibles = GetHobbies();
            return View(formulario);
        }
        
        private IList<SelectListItem> GetHobbies()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{ Text = "Peliculas", Value = "Peliculas"},
                new SelectListItem{ Text = "Deportes", Value = "Deportes"},
                new SelectListItem{ Text = "Musica", Value = "Musica"},
                new SelectListItem{ Text = "Coleccionar", Value = "Coleccionar"},
            };
        }

        // GET: Formularios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            return View(formulario);
        }

        // POST: Formularios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Cedula,Nombre,Apellido,Edad,Telefono,Correo,Genero,EstadoCivil")] Formulario formulario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formulario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(formulario);
        }

        // GET: Formularios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Formulario formulario = db.Formularios.Find(id);
            if (formulario == null)
            {
                return HttpNotFound();
            }
            return View(formulario);
        }

        // POST: Formularios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Formulario formulario = db.Formularios.Find(id);
            db.Formularios.Remove(formulario);
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
