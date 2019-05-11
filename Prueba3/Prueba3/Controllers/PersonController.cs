using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Prueba3.Models;

namespace Prueba3.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        private Person objSemestre = new Person();
        public ActionResult Index()
        {
            return View(objSemestre.Listar());
        }

        public ActionResult Visualizar(int id)
        {
            return View(objSemestre.Obtener(id));
        }

        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Person()//Agregar un nuevo objeto
                : objSemestre.Obtener(id)//Devuelve un objeto
                );

        }

        public ActionResult Guardar(Person objSemestre)
        {
            if (ModelState.IsValid)
            {
                objSemestre.Guardar();
                return Redirect("~/Person");
            }
            else
            {
                return View("~/Views/Person/AgregarEditar.cshtml");
            }
        }


        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objSemestre.PersonId = id;
            objSemestre.Eliminar();
            return Redirect("~/Person");

        }
    }
}