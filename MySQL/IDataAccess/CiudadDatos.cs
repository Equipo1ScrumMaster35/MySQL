using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class CiudadDatos
    {
        public List<CiudadModel> Listar()
        {
            var Lista = new List<CiudadModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT ciudad.cod_ciudad, ciudad.nom_ciudad, ciudad.coordinador_ciudad, pais.nom_pais FROM ciudad INNER JOIN pais ON ciudad.fk_codpais = pais.cod_pais ORDER BY ciudad.cod_ciudad;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new CiudadModel()
                    {
                        cod_ciudad = Convert.ToString(Resultado["cod_ciudad"]),
                        nom_ciudad = Convert.ToString(Resultado["nom_ciudad"]),
                        coordinador_ciudad = Convert.ToString(Resultado["coordinador_ciudad"]),
                        fk_codpais = Convert.ToString(Resultado["nom_pais"])
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

        public CiudadModel Obtener(int cod_ciudad)
        {
            var Ciudad = new CiudadModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT ciudad.cod_ciudad, ciudad.nom_ciudad, ciudad.coordinador_ciudad, pais.nom_pais FROM ciudad INNER JOIN pais ON ciudad.fk_codpais = pais.cod_pais WHERE cod_ciudad = '" + cod_ciudad + "' ORDER BY ciudad.cod_ciudad;";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Ciudad.cod_ciudad = Convert.ToString(Resultado["cod_ciudad"]);
                    Ciudad.nom_ciudad = Convert.ToString(Resultado["nom_ciudad"]);
                    Ciudad.coordinador_ciudad = Convert.ToString(Resultado["coordinador_ciudad"]);
                    Ciudad.fk_codpais = Convert.ToString(Resultado["nom_pais"]);
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

            return Ciudad;
        }

        public bool Guardar(CiudadModel Ciudad)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO ciudad(cod_ciudad,nom_ciudad,coordinador_ciudad,fk_codpais) VALUES ('" + Ciudad.cod_ciudad + "','" + Ciudad.nom_ciudad + "','" + Ciudad.coordinador_ciudad + "','" + Ciudad.fk_codpais + "')";
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

        public List<PaisModel> ListarPais()
        {
            var ListaPais = new List<PaisModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_pais, nom_pais FROM pais;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    ListaPais.Add(new PaisModel()
                    {
                        cod_pais = Convert.ToString(Resultado["cod_pais"]),
                        nom_pais = Convert.ToString(Resultado["nom_pais"]),
                    });

                }

                return ListaPais;

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
        //Aqui voy
        public bool Editar(CiudadModel Ciudad)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE proyecto SET nom_proyecto = '" + Ciudad.cod_ciudad + "', descripcion_proyecto='" + Ciudad.cod_ciudad + "', estado_proyecto= '" + Ciudad.cod_ciudad + "' WHERE cod_proyecto = '" + Ciudad.cod_ciudad + "';";
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
