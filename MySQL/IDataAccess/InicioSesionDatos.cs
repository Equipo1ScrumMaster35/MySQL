using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class InicioSesionDatos
    {
        public IntegranteValidacionModel ValidarIntegrante(IntegranteValidacionModel Integrante)
        {
            var IntegranteVali = new IntegranteValidacionModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT doc_integrante,contrasena_integrante,fk_codrol,estado_integrante FROM integrante " +
                                   "WHERE doc_integrante = '" + Integrante.doc_integrante + "' AND contrasena_integrante = '"+Integrante.contrasena_integrante+ "' AND estado_integrante = 'Activo';";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    IntegranteVali.doc_integrante = Convert.ToString(Resultado["doc_integrante"]);
                    IntegranteVali.fk_codrol = Convert.ToString(Resultado["fk_codrol"]);
                    IntegranteVali.estado_integrante = Convert.ToString(Resultado["estado_integrante"]);
                };

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }

            return IntegranteVali;
        }

    }
}
