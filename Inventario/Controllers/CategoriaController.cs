using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Data.DataAccess;
using Inventario.Models.Entidad;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    public class CategoriaController : Controller
    {
        [Route("DSecundario")]
        public IActionResult Index()
        {
            var ListCategoria = new CategoriaDA();
            var resul = ListCategoria.getCategoria();
            return View(resul);
        }
        public IActionResult Create()
        {
            //var datosCategoria = new CategoriaDA();
            //ViewBag.Categoria = datosCategoria.getCategoria();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categoria Entidad)
        {
            var categoriaDB = new CategoriaDA();
            var datos = categoriaDB.InsertCategoria(Entidad);
            if (datos > 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Entidad);
            }
        }

    }
}