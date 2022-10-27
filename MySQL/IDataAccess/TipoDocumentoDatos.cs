using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;


namespace MySQL.IDataAccess
{
    public class TipoDocumentoDatos
    {

        public List<TipoDocumentoModel> Listar()
        {
            var Lista = new List<TipoDocumentoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM tipodocumento";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new TipoDocumentoModel()
                    {
                        cod_tipodocumento = Convert.ToString(Resultado["cod_tipodocumento"]),
                        nom_tipodocumento = Convert.ToString(Resultado["nom_tipodocumento"])
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

        public TipoDocumentoModel Obtener(int cod_tipodocumento)
        {
            var TipoDocumento = new TipoDocumentoModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT * FROM tipodocumento WHERE cod_tipodocumento = '" + cod_tipodocumento + "'";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    TipoDocumento.cod_tipodocumento = Convert.ToString(Resultado["cod_tipodocumento"]);
                    TipoDocumento.nom_tipodocumento = Convert.ToString(Resultado["nom_tipodocumento"]);
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

            return TipoDocumento;
        }

        public bool Guardar(TipoDocumentoModel TipoDocumento)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO tipodocumento(nom_tipodocumento) VALUES ('" + TipoDocumento.nom_tipodocumento + "')";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Conn.Open();
                Comand.ExecuteNonQuery();

                rpta = true;

            }
            catch (Exception ex)
            {
                throw ex;
                rpta = false;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }
            return rpta;
        }

        public bool Editar(TipoDocumentoModel TipoDocumento)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE tipodocumento SET nom_tipodocumento = '" + TipoDocumento.nom_tipodocumento + "' WHERE cod_tipodocumento = '" + TipoDocumento.cod_tipodocumento + "'";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Conn.Open();
                Comand.ExecuteNonQuery();

                rpta = true;

            }
            catch (Exception ex)
            {
                throw ex;
                rpta = false;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }
            return rpta;
        }

        public bool Eliminar(TipoDocumentoModel TipoDocumento)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "DELETE FROM tipodocumento WHERE cod_tipodocumento = '" + TipoDocumento.cod_tipodocumento + "' ";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Conn.Open();
                Comand.ExecuteNonQuery();

                rpta = true;

            }
            catch (Exception ex)
            {
                throw ex;
                rpta = false;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }
            return rpta;
        }
    }
}
