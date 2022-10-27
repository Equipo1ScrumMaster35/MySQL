using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class TipoDocumentoModel
    {
        //[Required(ErrorMessage = "El campo código tipo documento es obligatorio")]
        public string? cod_tipodocumento { get; set; }
        [Required(ErrorMessage = "El campo nombre tipo documento es obligatorio")]
        public string? nom_tipodocumento { get; set; }
    }
}
