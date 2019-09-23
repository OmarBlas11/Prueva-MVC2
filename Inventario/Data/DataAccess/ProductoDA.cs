using Inventario.Models.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.DataAccess
{
    public class ProductoDA
    {
        public IEnumerable<Producto> getProducto()
        {
            var Lproducto = new List<Producto>();
            using (var db = new ApplicationDbContext())
            {
                Lproducto = db.Producto.Include(Item => Item.Categoria).ToList();
            }
            return Lproducto;
        }

        public Producto GetProductoId(int id)
        {
            var resultado = new Producto();
            using(var db=new ApplicationDbContext())
            {
                resultado = db.Producto.Where(item => item.idProducto == id).FirstOrDefault();
            }
            return resultado;
        }
        public int InsertProducto(Producto Entity)
        {
            var resultado = 0;
            using(var db=new ApplicationDbContext())
            {
                db.Add(Entity);
                db.SaveChanges();
                resultado = Entity.idProducto;
            }
            return resultado;
        }
        public Boolean UpdateProducto(Producto Entity)
        {
            var resultado = false;
            using(var db=new ApplicationDbContext())
            {
                db.Producto.Attach(Entity);//referencando a la entidad
                db.Entry(Entity).State = EntityState.Modified;
                db.Entry(Entity).Property(Item => Item.FehaCreacion).IsModified = false;//no se modifica la fechacreacion
                resultado = db.SaveChanges() != 0;//se guarda la modificacion en la base de datos
            }
            return resultado;
        }
        public Boolean DeleteProducto(int id)
        {
            var resul = false;
            using (var db = new ApplicationDbContext())
            {
                var Entidad = new Producto() { idProducto = id };
                db.Producto.Attach(Entidad);
                db.Remove(Entidad);
                resul = db.SaveChanges() != 0;
                
            }
            return resul;
        }
    }
}
