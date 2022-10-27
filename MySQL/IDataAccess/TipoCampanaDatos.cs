using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class TipoCampanaDatos
    {
        public List<TipoCampanaModel> Listar()
        {
            var Lista = new List<TipoCampanaModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM tipo_campana";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new TipoCampanaModel()
                    {
                        cod_tipocampana = Convert.ToString(Resultado["cod_tipocampana"]),
                        nom_tipocampana = Convert.ToString(Resultado["nom_tipocampana"])
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

        public TipoCampanaModel Obtener(int cod_tipocampana)
        {
            var TipoCampana = new TipoCampanaModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT * FROM tipo_campana WHERE cod_tipocampana = '" + cod_tipocampana + "'";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    TipoCampana.cod_tipocampana = Convert.ToString(Resultado["cod_tipocampana"]);
                    TipoCampana.nom_tipocampana = Convert.ToString(Resultado["nom_tipocampana"]);
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

            return TipoCampana;
        }

        public bool Guardar(TipoCampanaModel TipoCampana)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO tipo_campana(nom_tipocampana) VALUES ('" + TipoCampana.nom_tipocampana + "')";
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

        public bool Editar(TipoCampanaModel TipoCampana)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE tipo_campana SET nom_tipocampana = '" + TipoCampana.nom_tipocampana + "' WHERE cod_tipocampana = '" + TipoCampana.cod_tipocampana + "'";
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

        public bool Eliminar(TipoCampanaModel TipoCampana)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "DELETE FROM tipo_campana WHERE cod_tipocampana = '" + TipoCampana.cod_tipocampana + "' ";
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
