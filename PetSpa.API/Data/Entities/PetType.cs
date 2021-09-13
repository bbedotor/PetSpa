using System.ComponentModel.DataAnnotations;

namespace PetSpa.API.Data.Entities
{
    public class PetType
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de Mascota")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }
    }
}
