using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class CampanaDatos
    {
        public List<CampanaModel> Listar()
        {
            var Lista = new List<CampanaModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "SELECT campana.cod_campana, campana.nom_campana, campana.motivo_campana, campana.fechainicio_campana, campana.fechafin_campana, campana.estado_campana, proyecto.nom_proyecto, tipo_campana.nom_tipocampana FROM campana INNER JOIN proyecto ON campana.fk_codproyecto = proyecto.cod_proyecto INNER JOIN tipo_campana ON campana.fk_codtipocampana = tipo_campana.cod_tipocampana ORDER BY campana.cod_campana;";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new CampanaModel()
                    {
                        cod_campana = Convert.ToString(Resultado["cod_campana"]),
                        nom_campana = Convert.ToString(Resultado["nom_campana"]),
                        motivo_campana = Convert.ToString(Resultado["motivo_campana"]),
                        fechainicio_campana = Convert.ToString(Resultado["fechainicio_campana"]),
                        fechafin_campana = Convert.ToString(Resultado["fechafin_campana"]),
                        estado_campana = Convert.ToString(Resultado["estado_campana"]),
                        fk_codproyecto = Convert.ToString(Resultado["nom_proyecto"]),
                        fk_codtipocampana = Convert.ToString(Resultado["nom_tipocampana"])
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

        public CampanaModel Obtener(int cod_campana)
        {
            var Campana = new CampanaModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT campana.cod_campana, campana.nom_campana, campana.motivo_campana, campana.fechainicio_campana, campana.fechafin_campana, campana.estado_campana, proyecto.nom_proyecto, tipo_campana.nom_tipocampana FROM campana INNER JOIN proyecto ON campana.fk_codproyecto = proyecto.cod_proyecto INNER JOIN tipo_campana ON campana.fk_codtipocampana = tipo_campana.cod_tipocampana  WHERE cod_campana = '" + cod_campana + "' ORDER BY campana.cod_campana;";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Campana.cod_campana = Convert.ToString(Resultado["cod_campana"]);
                    Campana.nom_campana = Convert.ToString(Resultado["nom_campana"]);
                    Campana.motivo_campana = Convert.ToString(Resultado["motivo_campana"]);
                    Campana.fechainicio_campana = Convert.ToString(Resultado["fechainicio_campana"]);
                    Campana.fechafin_campana = Convert.ToString(Resultado["fechafin_campana"]);
                    Campana.estado_campana = Convert.ToString(Resultado["estado_campana"]);
                    Campana.fk_codproyecto = Convert.ToString(Resultado["nom_proyecto"]);
                    Campana.fk_codtipocampana = Convert.ToString(Resultado["nom_tipocampana"]);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open) Conn.Close();
            }

            return Campana;
        }

        public bool Guardar(CampanaModel Campana)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO campana(nom_campana,motivo_campana,fechainicio_campana,fechafin_campana,estado_campana,fk_codproyecto,fk_codtipocampana) VALUES ('" + Campana.nom_campana + "','" + Campana.motivo_campana + "','" + Campana.fechainicio_campana + "','" + Campana.fechafin_campana + "','Activa','" + Campana.fk_codproyecto + "','" + Campana.fk_codtipocampana + "')";
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

        public bool Editar(CampanaModel Campana)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE campana SET nom_campana = '" + Campana.nom_campana + "' WHERE cod_campana = '" + Campana.cod_campana + "'";
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

        public List<ProyectoModel> ListarProyecto()
        {
            var Lista = new List<ProyectoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_proyecto, nom_proyecto FROM proyecto;";
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
        public List<TipoCampanaModel> ListarTipoCampana()
        {
            var Lista = new List<TipoCampanaModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_tipocampana, nom_tipocampana FROM tipo_campana;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new TipoCampanaModel()
                    {
                        cod_tipocampana = Convert.ToString(Resultado["cod_tipocampana"]),
                        nom_tipocampana = Convert.ToString(Resultado["nom_tipocampana"]),
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

    }
}
