using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class CiudadModel
    {
        //[Required(ErrorMessage = "El campo código ciudad es obligatorio")]
        public string? cod_ciudad { get; set; }
        [Required(ErrorMessage = "El campo nombre ciudad es obligatorio")]
        public string? nom_ciudad { get; set; }
        [Required(ErrorMessage = "El campo coordinador ciudad es obligatorio")]
        public string? coordinador_ciudad { get; set; }
        [Required(ErrorMessage = "El campo país es obligatorio")]
        public string? fk_codpais { get; set; }
    }
}
