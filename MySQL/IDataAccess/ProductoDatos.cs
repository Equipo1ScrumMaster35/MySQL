using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class ProductoDatos
    {
        public List<ProductoModel> Listar()
        {
            var Lista = new List<ProductoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT producto.cod_producto, producto.nom_producto, tipo_producto.nom_tipoproducto FROM producto INNER JOIN tipo_producto ON producto.fk_codtipoproducto = tipo_producto.cod_tipoproducto ORDER BY producto.cod_producto;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new ProductoModel()
                    {
                        cod_producto = Convert.ToString(Resultado["cod_producto"]),
                        nom_producto = Convert.ToString(Resultado["nom_producto"]),
                        fk_codtipoproducto = Convert.ToString(Resultado["nom_tipoproducto"])
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

        public ProductoModel Obtener(int cod_producto)
        {
            var Producto = new ProductoModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT producto.cod_producto, producto.nom_producto, tipo_producto.nom_tipoproducto FROM producto INNER JOIN tipo_producto ON producto.fk_codtipoproducto = tipo_producto.cod_tipoproducto WHERE producto.cod_producto = '"+Producto.cod_producto+"' ORDER BY producto.cod_producto;";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Producto.cod_producto = Convert.ToString(Resultado["cod_producto"]);
                    Producto.nom_producto = Convert.ToString(Resultado["nom_producto"]);
                    Producto.fk_codtipoproducto = Convert.ToString(Resultado["nom_tipoproducto"]);
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

            return Producto;
        }

        public bool Guardar(ProductoModel Producto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO producto(nom_producto,fk_codtipoproducto) VALUES ('" + Producto.nom_producto + "','" + Producto.fk_codtipoproducto + "')";
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

        public bool Editar(ProductoModel Producto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE producto SET nom_producto = '" + Producto.nom_producto + "', fk_codtipoproducto= '" + Producto.fk_codtipoproducto + "' WHERE cod_producto = '" + Producto.cod_producto + "';";
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

        public List<TipoProductoModel> ListarTipoProducto()
        {
            var ListaTipo = new List<TipoProductoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_tipoproducto, nom_tipoproducto FROM tipo_producto;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    ListaTipo.Add(new TipoProductoModel()
                    {
                        cod_tipoproducto = Convert.ToString(Resultado["cod_tipoproducto"]),
                        nom_tipoproducto = Convert.ToString(Resultado["nom_tipoproducto"]),
                    });

                }

                return ListaTipo;

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