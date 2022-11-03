using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class IntegranteModel
    {
        [Required(ErrorMessage = "El campo número documento es obligatorio")]
        public string? doc_integrante { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? nom_integrante { get; set; }
        [Required(ErrorMessage = "El campo fecha nacimiento es obligatorio")]
        public string? fechanacimiento_integrante { get; set; }
        [Required(ErrorMessage = "El campo teléfono es obligatorio")]
        public string? telefono_integrante { get; set; }
        [Required(ErrorMessage = "El campo dirección es obligatorio")]
        public string? direccion_integrante { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string? contrasena_integrante { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string? estado_integrante { get; set; }
        [Required(ErrorMessage = "El campo rol es obligatorio")]
        public string? fk_codrol { get; set; }
        [Required(ErrorMessage = "El campo ciudad es obligatorio")]
        public string? fk_codciudad { get; set; }
    }
}
