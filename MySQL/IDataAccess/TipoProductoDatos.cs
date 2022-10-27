using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class TipoProductoDatos
    {
        public List<TipoProductoModel> Listar()
        {
            var Lista = new List<TipoProductoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM tipo_producto";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new TipoProductoModel()
                    {
                        cod_tipoproducto = Convert.ToString(Resultado["cod_tipoproducto"]),
                        nom_tipoproducto = Convert.ToString(Resultado["nom_tipoproducto"])
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

        public TipoProductoModel Obtener(int cod_tipoproducto)
        {
            var TipoProducto = new TipoProductoModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT * FROM tipo_producto WHERE cod_tipoproducto = '" + cod_tipoproducto + "'";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    TipoProducto.cod_tipoproducto = Convert.ToString(Resultado["cod_tipoproducto"]);
                    TipoProducto.nom_tipoproducto = Convert.ToString(Resultado["nom_tipoproducto"]);
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

            return TipoProducto;
        }

        public bool Guardar(TipoProductoModel TipoProducto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO tipo_producto(nom_tipoproducto) VALUES ('" + TipoProducto.nom_tipoproducto + "')";
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

        public bool Editar(TipoProductoModel TipoProducto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE tipo_producto SET nom_tipoproducto = '" + TipoProducto.nom_tipoproducto + "' WHERE cod_tipoproducto = '" + TipoProducto.cod_tipoproducto + "'";
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

        public bool Eliminar(TipoProductoModel TipoProducto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "DELETE FROM tipo_producto WHERE cod_tipoproducto = '" + TipoProducto.cod_tipoproducto + "' ";
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
