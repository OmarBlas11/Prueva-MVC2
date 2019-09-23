using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class PersonaController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.idPersona = 11;
            ViewBag.Nombre = "OMAR";
            ViewBag.ApellidoPaterno = "BLAS";
            ViewBag.ApellidoMaterno = "LOARTE";
            ViewBag.Edad = 20;
            return View();
        }
    }
}