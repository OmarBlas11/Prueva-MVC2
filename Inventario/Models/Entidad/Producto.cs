using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models.Entidad
{
    public class Producto
    {
        [Key]
        public int idProducto { get; set; }
        [Display(Name = "Nombres")]
        [Required]
        [MaxLength(25, ErrorMessage = "El campo no debe contener mas de 25 caracteres")]
        public String Nombre { get; set; }
        [Display(Name = "codigo rapido")]
        [Required]
        [MaxLength(10, ErrorMessage = "el campo no debe tener mas de 10 carateres ")]
        public String CodigoRapido { get; set; }
        [Display(Name = "Unidad Medida")]
        [Required]
        [MaxLength(10, ErrorMessage = "El campo no debe tener mas de 10 caracteres")]
        public String UM { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public decimal Stock { get; set; }
        public DateTime FehaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
