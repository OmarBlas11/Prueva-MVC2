using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models.Entidad
{
    public class Categoria
    {
        [Key]
        public int idCategoria { get; set; }
        [Display(Name = "Nombre de Categoria")]
        [Required]
        [MaxLength(25, ErrorMessage = "El campo no debe mas de 25 carcateres")]
        public String Nombre { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
    }
}
