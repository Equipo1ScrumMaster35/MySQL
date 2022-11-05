namespace MySQL.Models
{
    public class DonacionModel
    {   //Ajustar con la tabla entrega_donacion
        public string? cod_donacion { get; set; }
        public string? fecha_donacion { get; set; }
        public string? observacion_donacion { get; set; }
        public string? estado_donacion { get; set; }
        public string? fk_docpersona { get; set; }
        public string? fk_codptofisico { get; set; }
        //Datos de la tabla detalle_donacion
        public string? cantidad { get; set; }
        public string? fk_codproducto { get; set; }
        public string? fk_codunidad { get; set; }
        public string? fk_coddonacion { get; set; }

    }
}
