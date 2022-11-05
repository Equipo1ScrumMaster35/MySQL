using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class CampanaModel
    {
        //[Required(ErrorMessage = "El campo código ciudad es obligatorio")]
        public string? cod_campana { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? nom_campana { get; set; }
        [Required(ErrorMessage = "El campo motivo es obligatorio")]
        public string? motivo_campana { get; set; }
        [Required(ErrorMessage = "El campo fecha inicio es obligatorio")]
        public string? fechainicio_campana { get; set; }
        [Required(ErrorMessage = "El campo fecha fin es obligatorio")]
        public string? fechafin_campana { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string? estado_campana { get; set; }
        [Required(ErrorMessage = "El campo proyecto es obligatorio")]
        public string? fk_codproyecto { get; set; }
        [Required(ErrorMessage = "El campo tipo campaña es obligatorio")]
        public string? fk_codtipocampana { get; set; }
    }
}
