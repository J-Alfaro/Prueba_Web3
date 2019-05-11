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
    }
}