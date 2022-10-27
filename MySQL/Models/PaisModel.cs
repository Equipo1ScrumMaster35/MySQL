using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class PaisModel
    {
        [Required(ErrorMessage = "El campo código país es obligatorio")]
        public string? cod_pais { get; set; }
        [Required(ErrorMessage = "El campo nombre país es obligatorio")]
        public string? nom_pais { get; set; }
    }
}
