using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Linq.Expressions;

namespace MySQL.Data
{
    public class Conexion
    {
        private static Conexion Conn = null;

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();

            try
            {
                Cadena.ConnectionString = "datasource=localhost;port=3306;username=root;password=123456;Database=donacionWeb";
            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getConexion()
        {
            if (Conn == null)
            {
                Conn = new Conexion();
            }
            return Conn;
        }
    }
}