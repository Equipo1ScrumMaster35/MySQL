using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class IntegranteValidacionModel
    {   //Requeridos
        [Required(ErrorMessage = "El campo usuario es obligatorio")]
        public string? doc_integrante { get; set; }
        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        public string? contrasena_integrante { get; set; }
        //Validacion
        public string? estado_integrante { get; set; }
        public string? fk_codrol { get; set; }

    }
}
