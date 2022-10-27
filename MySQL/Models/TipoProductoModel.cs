using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class TipoProductoModel
    {
        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_tipoproducto { get; set; }
        [Required(ErrorMessage = "El campo nombre tipo de producto es obligatorio")]
        public string? nom_tipoproducto { get; set; }
    }
}
