namespace MySQL.Models
{
    public class RolModel
    {
        //[Required(ErrorMessage = "El campo código es obligatorio")]
        public string? cod_rol { get; set; }
        //[Required(ErrorMessage = "El campo nombre es obligatorio")]
        public string? rol_integrante { get; set; }
    }
}
