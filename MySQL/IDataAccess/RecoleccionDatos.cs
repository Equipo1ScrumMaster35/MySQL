using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class RecoleccionDatos
    {//Tabla donacion
        public List<PuntoFisicoModel> ListarPuntoFisico()
        {
            var Lista = new List<PuntoFisicoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT pto_fisico.cod_ptofisico, pto_fisico.nom_ptofisico, pto_fisico.direccion_ptofisico, ciudad.nom_ciudad, campana.nom_campana, campana.fechafin_campana, campana.estado_campana " +
                                  "FROM pto_fisico " +
                                  "INNER JOIN ciudad " +
                                  "ON pto_fisico.fk_codciudad = ciudad.cod_ciudad " +
                                  "INNER JOIN campana " +
                                  "ON pto_fisico.fk_codcampana = campana.cod_campana " +
                                  "WHERE campana.estado_campana = 'Activa' AND campana.fk_codtipocampana = 1 AND campana.fechafin_campana >= (select CURDATE());";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new PuntoFisicoModel()
                    {
                        cod_ptofisico = Convert.ToString(Resultado["cod_ptofisico"]),
                        nom_ptofisico = Convert.ToString(Resultado["nom_ptofisico"]),
                        direccion_ptofisico = Convert.ToString(Resultado["direccion_ptofisico"]),
                        fk_codciudad = Convert.ToString(Resultado["nom_ciudad"]),
                        fk_codcampana = Convert.ToString(Resultado["nom_campana"])
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

        public bool ValidarPersona(PersonaModel Persona)
        {
            bool rpta;
            var Lista = new List<PersonaModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM persona WHERE doc_persona = '" + Persona.doc_persona + "' ";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new PersonaModel()
                    {
                        doc_persona = Convert.ToString(Resultado["doc_persona"]),
                        nombrecompleto_persona = Convert.ToString(Resultado["nombrecompleto_persona"]),
                        fk_codtipodocumento = Convert.ToString(Resultado["fk_codtipodocumento"]),
                    });
                }

                if (Lista.Count == 0)
                {
                    rpta = false;
                }
                else
                {
                    rpta = true;
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

            return rpta;

        }

        public bool GuardarPersona(PersonaModel Persona, bool vali)
        {//Agregar la validacion
            bool rpta;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                if(vali == false)
                {
                    string consulta2 = "insert into persona(doc_persona,nombrecompleto_persona,fk_codtipodocumento) values ('" + Persona.doc_persona + "','" + Persona.nombrecompleto_persona + "','" + Persona.fk_codtipodocumento + "')";
                    Conn = Conexion.getConexion().CrearConexion();
                    MySqlCommand comand2 = new MySqlCommand(consulta2, Conn);
                    Conn.Open();
                    comand2.ExecuteNonQuery();
                    rpta = true;
                }
                else
                {
                    rpta = false; 
                }

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

        public List<TipoDocumentoModel> ListarTipoDoc()
        {
            var ListaTipo = new List<TipoDocumentoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_tipodocumento, nom_tipodocumento FROM tipodocumento;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    ListaTipo.Add(new TipoDocumentoModel()
                    {
                        cod_tipodocumento = Convert.ToString(Resultado["cod_tipodocumento"]),
                        nom_tipodocumento = Convert.ToString(Resultado["nom_tipodocumento"]),
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

        public List<ProductoModel> ListarProducto()
        {
            var Lista = new List<ProductoModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_producto, nom_producto FROM producto;";
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

        public List<TipoUnidadModel> ListarUnidad()
        {
            var Lista = new List<TipoUnidadModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT * FROM unidad;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new TipoUnidadModel()
                    {
                        cod_tipounidad = Convert.ToString(Resultado["cod_unidad"]),
                        nom_tipounidad = Convert.ToString(Resultado["nom_unidad"]),
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
