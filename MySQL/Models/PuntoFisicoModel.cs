using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class PuntoFisicoModel
    {

        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_ptofisico { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? nom_ptofisico { get; set; }
        [Required(ErrorMessage = "El campo dirección es obligatorio")]
        public string? direccion_ptofisico { get; set; }
        [Required(ErrorMessage = "El campo estado es obligatorio")]
        public string? estado_ptofisico { get; set; }
        [Required(ErrorMessage = "El campo responsable es obligatorio")]
        public string? fk_docintegrante { get; set; }
        [Required(ErrorMessage = "El campo campaña es obligatorio")]
        public string? fk_codcampana { get; set; }
        [Required(ErrorMessage = "El campo ciudad es obligatorio")]
        public string? fk_codciudad { get; set; }

    }
}
