using System.ComponentModel.DataAnnotations;

namespace MySQL.Models
{
    public class PersonaModel
    {
        [Required(ErrorMessage = "El campo número documento es obligatorio")]
        public string? doc_persona { get; set; }
        [Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? nombrecompleto_persona { get; set; }
        [Required(ErrorMessage = "El campo tipo documento es obligatorio")]
        public string? fk_codtipodocumento { get; set; }
    }
}
