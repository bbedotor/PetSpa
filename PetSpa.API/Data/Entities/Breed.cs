﻿using System.ComponentModel.DataAnnotations;

namespace PetSpa.API.Data.Entities
{
    public class Breed
    {
        public int Id { get; set; }

        [Display(Name = "Raza")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Description { get; set; }
    }
}
