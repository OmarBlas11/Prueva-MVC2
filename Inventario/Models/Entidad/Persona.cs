using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Inventario.Models.Entidad
{
    public class Persona
    {
        [Key]
        public int idPersona { get; set; }
        [Display(Name = "NombrePersona")]
        [Required]
        [MaxLength(25, ErrorMessage = "Este Campo solo debe tener 25 caracteres")]
        public String Nombre { get; set; }
        [Display(Name = "ApellidoPaterno")]
        [Required]
        [MaxLength(25, ErrorMessage = "Este Campo solo debe tener 25 caracteres")]
        public String ApellidoPaterno { get; set; }
        [Display(Name = "ApellidoMaterno")]
        [Required]
        [MaxLength(25, ErrorMessage = "Este Campo solo debe tener 25 caracteres")]
        public String ApellidoMaterno { get; set; }
        [Display(Name = "Edad")]
        [Required]
        public int Edad { get; set; }
    }
}
