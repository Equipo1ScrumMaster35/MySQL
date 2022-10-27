using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class TipoCampanaModel
    {
        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_tipocampana { get; set; }
        [Required(ErrorMessage = "El campo nombre tipo campaña es obligatorio")]
        public string? nom_tipocampana { get; set; }
    }
}
