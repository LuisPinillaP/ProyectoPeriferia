using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProyectoPeriferia.Models;

namespace ProyectoPeriferia.Controllers
{
    public class clienteexternoController : Controller
    {
        // GET: clienteexterno
        public ActionResult Index()
        {
            using (var db = new clienteperiferiaitEntities())
            {
                return View(db.cliente_externo.ToList());
            }
                
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(cliente_externo clienteExterno)
        {
            if (!ModelState.IsValid)
                return View();
            try
            {
                using (var db = new clienteperiferiaitEntities())
                {
                    db.cliente_externo.Add(clienteExterno);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new clienteperiferiaitEntities())
            {
                cliente_externo clienteExterno = db.cliente_externo.Find(id);
                return View(clienteExterno);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new clienteperiferiaitEntities())
                {
                    cliente_externo clienteExterno = db.cliente_externo.Where(a => a.id == id).FirstOrDefault();
                    return View(clienteExterno);
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(cliente_externo clienteExternoedit)
        {
            try
            {
                using (var db = new clienteperiferiaitEntities())
                {
                    var cliente_externo = db.cliente_externo.Find(clienteExternoedit);
                    cliente_externo.CORREO = clienteExternoedit.CORREO;
                    cliente_externo.DIRECCION = clienteExternoedit.DIRECCION;
                    cliente_externo.ID_CLIENTE = clienteExternoedit.ID_CLIENTE;
                    cliente_externo.NOMBRE_CLIENTE = clienteExternoedit.NOMBRE_CLIENTE;
                    cliente_externo.N_CASO = clienteExternoedit.N_CASO;
                    cliente_externo.TELEFONO = clienteExternoedit.TELEFONO;

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
                var clienteexternoDel = db.cliente_externo.Find(id);
                db.cliente_externo.Remove(clienteexternoDel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}