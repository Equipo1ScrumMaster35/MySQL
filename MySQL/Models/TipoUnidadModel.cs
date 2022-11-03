using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
   public class TipoUnidadModel
    {
        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_tipounidad { get; set; }
        [Required(ErrorMessage = "El campo nombre unidad es obligatorio")]
        public string? nom_tipounidad { get; set; }
    }
}
