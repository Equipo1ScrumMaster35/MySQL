using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class ProyectoDatos
    {
        public List<ProyectoModel> Listar()
        {   
            var Lista = new List<ProyectoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM proyecto";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new ProyectoModel()
                    {
                        cod_proyecto = Convert.ToString(Resultado["cod_proyecto"]),
                        nom_proyecto = Convert.ToString(Resultado["nom_proyecto"]),
                        descripcion_proyecto = Convert.ToString(Resultado["descripcion_proyecto"]),
                        estado_proyecto = Convert.ToString(Resultado["estado_proyecto"])
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

        public ProyectoModel Obtener(int cod_proyecto)
        {
            var Proyecto = new ProyectoModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT * FROM proyecto WHERE cod_proyecto = '" + cod_proyecto + "'";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Proyecto.cod_proyecto = Convert.ToString(Resultado["cod_proyecto"]);
                    Proyecto.nom_proyecto = Convert.ToString(Resultado["nom_proyecto"]);
                    Proyecto.descripcion_proyecto = Convert.ToString(Resultado["descripcion_proyecto"]);
                    Proyecto.estado_proyecto = Convert.ToString(Resultado["estado_proyecto"]);
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

            return Proyecto;
        }

        public bool Guardar(ProyectoModel Proyecto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO proyecto(cod_proyecto,nom_proyecto,descripcion_proyecto,estado_proyecto) VALUES ('" + Proyecto.cod_proyecto + "','" + Proyecto.nom_proyecto + "','" + Proyecto.descripcion_proyecto + "','" + Proyecto.estado_proyecto + "')";
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

        public bool Editar(ProyectoModel Proyecto)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE proyecto SET nom_proyecto = '" + Proyecto.nom_proyecto + "', descripcion_proyecto='" + Proyecto.descripcion_proyecto + "', estado_proyecto= '" + Proyecto.estado_proyecto + "' WHERE cod_proyecto = '" + Proyecto.cod_proyecto + "';";
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
