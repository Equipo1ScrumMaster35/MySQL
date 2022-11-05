namespace MySQL.Models
{
    public class RecoleccionModel
    {
        public string? cod_donacion { get; set; }
        public string? fecha_donacion { get; set; }
        public string? observacion_donacion { get; set; }
        public string? estado_donacion { get; set; }
        public string? fk_docpersona { get; set; }
        public string? fk_codptofisico { get; set; }
    }
}
