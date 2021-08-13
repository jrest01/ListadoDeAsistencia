using Cofradia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cofradia.Controllers
{
    public class ReunionController : Controller
    {
        // GET: Reunion
        public ActionResult Index()
        {
            try
            {
                using (ReunionesContext db = new ReunionesContext())
                {
                    List<Reuniones> listaReuniones = db.Reuniones.ToList();
                    return View(listaReuniones);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Reuniones nuevaReunion)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (ReunionesContext db = new ReunionesContext())
                {
                    db.Reuniones.Add(nuevaReunion);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error al agregar reunion. ", ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (ReunionesContext db = new ReunionesContext())
                {
                    Reuniones reunionEditar = db.Reuniones.Find(id);
                    return View(reunionEditar);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(Reuniones reunion)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (ReunionesContext db = new ReunionesContext())
                {
                    Reuniones reunionEditar = db.Reuniones.Find(reunion.idReunion);
                    reunionEditar.fechaReunion = reunion.fechaReunion;
                    reunionEditar.temaReunion = reunion.temaReunion;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Details(int id)
        {
            using (ReunionesContext db=new ReunionesContext())
            {
                Reuniones reunionDetalle = db.Reuniones.Find(id);
                return View(reunionDetalle);
            }
        }

        public ActionResult Delete(int id)
        {
            using (ReunionesContext db=new ReunionesContext())
            {
                Reuniones reunionEliminar = db.Reuniones.Find(id);
                db.Reuniones.Remove(reunionEliminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}