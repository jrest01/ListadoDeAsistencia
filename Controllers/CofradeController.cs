using Cofradia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cofradia.Controllers
{
    public class CofradeController : Controller
    {
        // GET: Cofrade
        

        public ActionResult Index()
        {
            using (CofradiaContext1 db = new CofradiaContext1())
            {
                List<Cofrade> listaCofrades = db.Cofrade.ToList();
                return View(listaCofrades);
            }
            
        }

        public ActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Agregar(Cofrade nuevoCofrade)
        {
            if (!ModelState.IsValid)            
                return View();
            try
            {
                using (CofradiaContext1 db= new CofradiaContext1())
                {
                    db.Cofrade.Add(nuevoCofrade);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("Error al agregar el Cofrade",ex);
                return View();
            }
            
        }

        public ActionResult Editar(int id)
        {
            try
            {
                using (CofradiaContext1 db = new CofradiaContext1())
                {
                    //Cofrade cf = db.Cofrade.Where(variable => variable.Id == id).FirstOrDefault();
                    Cofrade cofradeEditar = db.Cofrade.Find(id);
                    return View(cofradeEditar);
                }
            }
            catch (Exception E)
            {

                throw;
            }
            
                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cofrade cofrade)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                using (CofradiaContext1 db=new CofradiaContext1())
                {
                    Cofrade cofradeEditar = db.Cofrade.Find(cofrade.Id);
                    cofradeEditar.Nombre = cofrade.Nombre;
                    cofradeEditar.Apodo = cofrade.Apodo;
                    cofradeEditar.FechaNacimiento = cofrade.FechaNacimiento;
                    cofradeEditar.Sexo = cofrade.Sexo;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                
            }
            catch (Exception Ex)
            {

                throw;
            }
            
        }


        public ActionResult Detalles(int id)
        {
            using (CofradiaContext1 db = new CofradiaContext1()) 
            {
                Cofrade cofradeDetalle = db.Cofrade.Find(id);
                return View(cofradeDetalle);
            }
        }

        public ActionResult Eliminar(int id)
        {
            using (CofradiaContext1 db = new CofradiaContext1())
            {
                Cofrade cofradeEliminar = db.Cofrade.Find(id);
                db.Cofrade.Remove(cofradeEliminar);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}