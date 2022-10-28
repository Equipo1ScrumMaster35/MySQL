using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class ProyectoModel
    {
        [Required(ErrorMessage = "El campo código proyecto es obligatorio")]
        public string? cod_proyecto { get; set; }
        [Required(ErrorMessage = "El campo nombre proyecto es obligatorio")]
        public string? nom_proyecto { get; set; }
        [Required(ErrorMessage = "El campo descripción de proyecto es obligatorio")]
        public string? descripcion_proyecto { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string? estado_proyecto { get; set; }
    }
}
