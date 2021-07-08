using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPeriferia.Models;

namespace ProyectoPeriferia.Controllers
{
    public class analistaController : Controller
    {
        // GET: analista
        public ActionResult Index()
        {
            using (var db = new clienteperiferiaitEntities())
            {
                return View();
            }
               
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(analista analista)
        {
            if (!ModelState.IsValid)
                return View();
            try
             {
                using (var db = new clienteperiferiaitEntities())
                {
                    db.analista.Add(analista);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new clienteperiferiaitEntities())
            {
                analista analista = db.analista.Find(id);
                return View(analista);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new clienteperiferiaitEntities())
                {
                    analista analista =db.analista.Where(a => a.id == id).FirstOrDefault();
                    return View(analista);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(analista analistaEdit)
        {
            try
            {
                using (var db = new clienteperiferiaitEntities())
                {
                    var analista = db.analista.Find(analistaEdit.id);
                        analista.ID_ANALISTA = analistaEdit.ID_ANALISTA;
                        analista.NOMBRE_ANALISTA = analistaEdit.NOMBRE_ANALISTA;
                        analista.N_CASO = analistaEdit.N_CASO;
                        analista.TICKET = analistaEdit.TICKET;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            using (var db = new clienteperiferiaitEntities())
            {
                var analistaDel = db.analista.Find(id);
                db.analista.Remove(analistaDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}