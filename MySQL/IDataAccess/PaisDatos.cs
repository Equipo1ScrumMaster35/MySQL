using MySQL.Data;
using MySQL.Models;
using MySqlConnector;

namespace MySQL.IDataAccess
{
    public class PaisDatos
    {
        private Conexion conn;

        public PaisDatos()
        {
            conn = new Conexion();
        }
        public List<PaisModel> Listar()
        {
            var Lista = new List<PaisModel>();
            string consulta = "SELECT * FROM pais";
            MySqlDataReader mReader = null;

            try{
                MySqlCommand mComand = new MySqlCommand(consulta);
                mComand.Connection = conn.GetConnection();
                mReader = mComand.ExecuteReader();

                while (mReader.Read())
                {
                    Lista.Add(new PaisModel()
                    {
                        cod_pais = Convert.ToString(mReader["cod_pais"]),
                        nom_pais = Convert.ToString(mReader["nom_pais"])
                    });

                }
                mReader.Close();
            }
            catch(Exception)
            {
                throw;
            }

            return Lista;
        }
    }
        
}
