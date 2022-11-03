using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class IntegranteDatos
    {
        public List<IntegranteModel> Listar()
        {
            var Lista = new List<IntegranteModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT integrante.doc_integrante, integrante.nom_integrante, integrante.estado_integrante,integrante.fechanacimiento_integrante,integrante.telefono_integrante,integrante.direccion_integrante,integrante.contrasena_integrante,rol_integrante.rol_integrante,ciudad.nom_ciudad " +
                                  "FROM integrante " +
                                  "INNER JOIN rol_integrante " +
                                  "ON integrante.fk_codrol = rol_integrante.cod_rol " +
                                  "INNER JOIN ciudad " +
                                  "ON integrante.fk_codciudad = ciudad.cod_ciudad " +
                                  "ORDER BY integrante.doc_integrante; ";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Lista.Add(new IntegranteModel()
                    {
                        doc_integrante = Convert.ToString(Resultado["doc_integrante"]),
                        nom_integrante = Convert.ToString(Resultado["nom_integrante"]),
                        fechanacimiento_integrante = Convert.ToString(Resultado["fechanacimiento_integrante"]),
                        telefono_integrante = Convert.ToString(Resultado["telefono_integrante"]),
                        direccion_integrante = Convert.ToString(Resultado["direccion_integrante"]),
                        estado_integrante = Convert.ToString(Resultado["estado_integrante"]),
                        fk_codrol = Convert.ToString(Resultado["rol_integrante"]),
                        fk_codciudad = Convert.ToString(Resultado["nom_ciudad"]),
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

        public IntegranteModel Obtener(int doc_integrante)
        {
            var Integrante = new IntegranteModel();
            MySqlConnection Conn = new MySqlConnection();
            MySqlDataReader Resultado;
            try
            {
                string consulta = "SELECT integrante.doc_integrante, integrante.nom_integrante, integrante.estado_integrante,integrante.fechanacimiento_integrante,integrante.telefono_integrante,integrante.direccion_integrante,integrante.contrasena_integrante,rol_integrante.rol_integrante,ciudad.nom_ciudad " +
                                  "FROM integrante " +
                                  "INNER JOIN rol_integrante " +
                                  "ON integrante.fk_codrol = rol_integrante.cod_rol " +
                                  "INNER JOIN ciudad " +
                                  "ON integrante.fk_codciudad = ciudad.cod_ciudad " +
                                  "WHERE integrante.doc_integrante = '"+Integrante.doc_integrante+"' "+
                                  "ORDER BY integrante.doc_integrante; ";
                Conn = Conexion.getConexion().CrearConexion();
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    Integrante.doc_integrante = Convert.ToString(Resultado["doc_integrante"]);
                    Integrante.nom_integrante = Convert.ToString(Resultado["nom_integrante"]);
                    Integrante.estado_integrante = Convert.ToString(Resultado["estado_integrante"]);
                    Integrante.fechanacimiento_integrante = Convert.ToString(Resultado["fechanacimiento_integrante"]);
                    Integrante.telefono_integrante = Convert.ToString(Resultado["telefono_integrante"]);
                    Integrante.direccion_integrante = Convert.ToString(Resultado["direccion_integrante"]);
                    Integrante.contrasena_integrante = Convert.ToString(Resultado["contrasena_integrante"]);
                    Integrante.fk_codrol = Convert.ToString(Resultado["rol_integrante"]);
                    Integrante.fk_codciudad = Convert.ToString(Resultado["nom_ciudad"]);

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

            return Integrante;
        }

        public bool Guardar(IntegranteModel Integrante)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "INSERT INTO integrante(doc_integrante,nom_integrante,estado_integrante,fechanacimiento_integrante,telefono_integrante,direccion_integrante,contrasena_integrante,fk_codrol,fk_codciudad)" +
                                  "VALUES ('" + Integrante.doc_integrante + "','" + Integrante.nom_integrante + "','" + Integrante.estado_integrante + "','" + Integrante.fechanacimiento_integrante + "','" + Integrante.telefono_integrante + "','" + Integrante.direccion_integrante + "','" + Integrante.contrasena_integrante + "','" + Integrante.fk_codrol + "','" + Integrante.fk_codciudad + "');";
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
    
        public bool Editar(IntegranteModel Integrante)
        {
            bool rpta;

            MySqlConnection Conn = new MySqlConnection();

            try
            {
                string consulta = "UPDATE integrante SET nom_integrante = '" + Integrante.nom_integrante + "', estado_integrante = '" + Integrante.estado_integrante + "', fechanacimiento_integrante = '" + Integrante.fechanacimiento_integrante + "', telefono_integrante = '" + Integrante.telefono_integrante + "', direccion_integrante = '" + Integrante.direccion_integrante + "', fk_codrol = '" + Integrante.fk_codrol + "', fk_codciudad = '"+Integrante.fk_codciudad+"' " +
                                  "WHERE doc_integrante = '" + Integrante.doc_integrante + "'; ";
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

        public List<RolModel> ListarRol()
        {
            var ListaRol = new List<RolModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_rol, rol_integrante FROM rol_integrante;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    ListaRol.Add(new RolModel()
                    {
                        cod_rol = Convert.ToString(Resultado["cod_rol"]),
                        rol_integrante = Convert.ToString(Resultado["rol_integrante"])
                    });

                }

                return ListaRol;

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
        public List<CiudadModel> ListarCiudad()
        {
            var ListaCiudad = new List<CiudadModel>();
            MySqlDataReader Resultado;
            MySqlConnection Conn = new MySqlConnection();

            try
            {
                Conn = Conexion.getConexion().CrearConexion();
                string consulta = "SELECT cod_ciudad, nom_ciudad FROM ciudad;";
                MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                Comand.CommandTimeout = 60;
                Conn.Open();
                Resultado = Comand.ExecuteReader();

                while (Resultado.Read())
                {
                    ListaCiudad.Add(new CiudadModel()
                    {
                        cod_ciudad = Convert.ToString(Resultado["cod_ciudad"]),
                        nom_ciudad = Convert.ToString(Resultado["nom_ciudad"])
                    });

                }

                return ListaCiudad;

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
