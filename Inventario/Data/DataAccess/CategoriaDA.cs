using Inventario.Models.Entidad;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Data.DataAccess
{
    public class CategoriaDA
    {
        public IEnumerable<Categoria> getCategoria()
        {
            var LisCategoria = new List<Categoria>();
            using (var db = new ApplicationDbContext())
            {
                LisCategoria = db.Categoria.ToList();
            }
            return LisCategoria;
        }
        public Categoria GetCategoriaId(int id)
        {
            var resultado = new Categoria();
            using(var db=new ApplicationDbContext())
            {
                resultado = db.Categoria.Where(item => item.idCategoria == id).FirstOrDefault();
            }
            return resultado;
        }
        public  int InsertCategoria(Categoria Entity)
        {
            var resul = 0;
            using(var db=new ApplicationDbContext())
            {
                db.Add(Entity);
                db.SaveChanges();//guardamos la informacion
                resul = Entity.idCategoria;//obtenemos el id del registro guardado
            }
            return resul;
        }
        public Boolean UpdateCategoria(Categoria Entity)
        {
            var resultado = false;
            using (var db = new ApplicationDbContext())
            {
                db.Categoria.Attach(Entity);//referencando a la entidad
                db.Entry(Entity).State = EntityState.Modified;
                resultado = db.SaveChanges() != 0;//se guarda la modificacion en la base de datos
            }
            return resultado;
        }
        public Boolean DeleteCategoria(int id)
        {
            var resul = false;
            using(var db=new ApplicationDbContext())
            {
                var Entidad = new Categoria() { idCategoria = id };
                db.Categoria.Attach(Entidad);//marcamos la fila que vamos a eliminar
                db.Categoria.Remove(Entidad);//eliminamos la fila
                resul = db.SaveChanges() != 0;//se guarda
                
            }
            return resul;//retornamos un valor (TRUE)
        }
    }
}
