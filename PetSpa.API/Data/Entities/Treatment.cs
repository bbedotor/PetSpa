using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetSpa.API.Data.Entities
{
    public class Treatment
    {
        public int Id { get; set; }

        [Display(Name = "Tratamientos")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}")]//formato de 2 decimales
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public decimal price { get; set; }
    }
}
