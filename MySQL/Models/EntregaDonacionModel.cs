namespace MySQL.Models
{
    public class EntregaDonacionModel
    {
        //Atributos de la tabla entrega_donacion
        public string? cod_entregadonacion { get; set; }
        public string? fecha_entregadonacion { get; set; }
        public string? observacion { get; set; }
        public string? estado { get; set; }
        public string? fk_codptofisico { get; set; }
        public string? fk_docpersona { get; set; }

        //Atributos de la tabla detalle_entregadonacion
        public string? cantidad { get; set; }
        public string? fk_codentregadonacion { get; set; }
        public string? fk_codproducto { get; set; }

    }
}
