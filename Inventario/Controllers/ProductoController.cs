using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Data.DataAccess;
using Inventario.Models.Entidad;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
   
    public class ProductoController : Controller
    {
        [Route("DPrincipal")]
        public IActionResult Index()
        {
            var producto = new ProductoDA();
            var resul = producto.getProducto();
            return View(resul);
        }
        public IActionResult Create()
        {
            var CategoriaCat = new CategoriaDA();
            ViewBag.Categoria = CategoriaCat.getCategoria();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto Entidad)
        {
            Entidad.idProducto = 0;
            Entidad.FehaCreacion = DateTime.Now;
            var resultado = new ProductoDA();
            var model = resultado.InsertProducto(Entidad);
            if (model> 0)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(Entidad);
            }
        }
        public IActionResult Edit(int id)
        {
            var catDA = new CategoriaDA();
            ViewBag.Categoria = catDA.getCategoria();

            var proDA = new ProductoDA();
            var model = proDA.GetProductoId(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Producto product)
        {
            product.FechaModificacion = DateTime.Now;
            var prodDA = new ProductoDA();
            var listado = prodDA.UpdateProducto(product);
            if (listado)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
        public IActionResult Details(int id)
        {
            var detalle = new ProductoDA();
            var model = detalle.GetProductoId(id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var delete = new ProductoDA();
            var resultado = delete.DeleteProducto(id);
            return RedirectToAction("Index");
        }
        
    }
}