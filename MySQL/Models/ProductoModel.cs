using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class ProductoModel
    {
        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_producto { get; set; }
        [Required(ErrorMessage = "El campo nombre producto es obligatorio")]
        public string? nom_producto { get; set; }
        [Required(ErrorMessage = "El campo tipo producto es obligatorio")]
        public string? fk_codtipoproducto { get; set; }
    }
}
