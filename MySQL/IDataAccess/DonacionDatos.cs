using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class DonacionDatos
    {//Ajustar con la tabla entrega_donacion
        public List<PuntoFisicoModel> ListarPuntoFisico()
        {
            var Lista = new List<PuntoFisicoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT pto_fisico.cod_ptofisico, pto_fisico.nom_ptofisico, pto_fisico.direccion_ptofisico, ciudad.nom_ciudad, campana.nom_campana, campana.fechafin_campana, campana.estado_campana " +
                                  "FROM pto_fisico " +
                                  "INNER JOIN ciudad " +
                                  "ON pto_fisico.fk_codciudad = ciudad.cod_ciudad " +
                                  "INNER JOIN campana " +
                                  "ON pto_fisico.fk_codcampana = campana.cod_campana " +
                                  "WHERE campana.estado_campana = 'Activa' AND campana.fk_codtipocampana = 2 AND campana.fechafin_campana >= (select CURDATE());";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new PuntoFisicoModel()
                    {
                        cod_ptofisico = Convert.ToString(Resultado["cod_ptofisico"]),
                        nom_ptofisico = Convert.ToString(Resultado["nom_ptofisico"]),
                        direccion_ptofisico = Convert.ToString(Resultado["direccion_ptofisico"]),
                        fk_codciudad = Convert.ToString(Resultado["nom_ciudad"]),
                        fk_codcampana = Convert.ToString(Resultado["nom_campana"])
                    });

                }

                return Lista;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }

        }


    }
}
