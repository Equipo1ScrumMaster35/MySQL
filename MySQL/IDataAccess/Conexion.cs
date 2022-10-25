using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System.Linq.Expressions;

namespace MySQL.Data
{
    public class Conexion
    {
        private MySqlConnection conexion;
        private string cadenaMySQL = String.Empty;
        private readonly IConfiguration Configuration;

        public Conexion(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Conexion()
        {
            cadenaMySQL = Configuration["CadenaMySQL"];
        }

        public MySqlConnection GetConnection()
        {
            try{
                conexion = new MySqlConnection(cadenaMySQL);

                if(conexion.State != System.Data.ConnectionState.Open)
                {
                    conexion.Open();
                }
              
               
            }
            catch(Exception ex)
            {
                string error = ex.Message;

            }

            return conexion;
        }
    }
}
