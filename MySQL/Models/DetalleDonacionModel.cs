namespace MySQL.Models
{
    public class DetalleDonacionModel
    {
        public string? cod_detalle { get; set; }
        public string? cantidad { get; set; }
        public string? fk_codproducto { get; set; }
        public string? fk_codunidad { get; set; }
        public string? fk_coddonacion { get; set; }
    }
}
