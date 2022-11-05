using Microsoft.Extensions.Configuration;
using MySqlConnector;
using NuGet.Protocol.Plugins;
using System.Linq.Expressions;

namespace MySQL.Data
{
    public class Conexion
    {
        private static Conexion Conn = null; 

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena;

            try
            {
                var configurationBuilder = new ConfigurationBuilder();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
                configurationBuilder.AddJsonFile(path, false);

                var root = configurationBuilder.Build();

                Cadena = new MySqlConnection(root.GetConnectionString("CadenaMySQL"));
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