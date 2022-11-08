using MySQL.Data;
using MySQL.Models;
using MySqlConnector;
using System.Data;

namespace MySQL.IDataAccess
{
    public class PuntoFisicoDatos
    {
            public List<PuntoFisicoModel> Listar()
            {
                var Lista = new List<PuntoFisicoModel>();
                MySqlDataReader Resultado;
                MySqlConnection Conn = new MySqlConnection();

                try
                {
                    string consulta = "SELECT pto_fisico.cod_ptofisico, pto_fisico.nom_ptofisico, pto_fisico.direccion_ptofisico, pto_fisico.estado_ptofisico, integrante.nom_integrante, campana.nom_campana, ciudad.nom_ciudad FROM pto_fisico INNER JOIN integrante ON pto_fisico.fk_docintegrante = integrante.doc_integrante INNER JOIN campana ON pto_fisico.fk_codcampana = campana.cod_campana INNER JOIN ciudad ON pto_fisico.fk_codciudad = ciudad.cod_ciudad ORDER BY pto_fisico.cod_ptofisico;";
                    Conn = Conexion.getConexion().CrearConexion();
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
                            estado_ptofisico = Convert.ToString(Resultado["estado_ptofisico"]),
                            fk_docintegrante = Convert.ToString(Resultado["nom_integrante"]),
                            fk_codcampana = Convert.ToString(Resultado["nom_campana"]),
                            fk_codciudad = Convert.ToString(Resultado["nom_ciudad"])
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
            public PuntoFisicoModel Obtener(int cod_ptofisico)
            {
                var PuntoFisico = new PuntoFisicoModel();
                MySqlConnection Conn = new MySqlConnection();
                MySqlDataReader Resultado;
                try
                {
                    string consulta = "SELECT pto_fisico.cod_ptofisico, pto_fisico.nom_ptofisico, pto_fisico.direccion_ptofisico, pto_fisico.estado_ptofisico, integrante.nom_integrante, campana.nom_campana, ciudad.nom_ciudad FROM pto_fisico INNER JOIN integrante ON pto_fisico.fk_docintegrante = integrante.doc_integrante INNER JOIN campana ON pto_fisico.fk_codcampana = campana.cod_campana INNER JOIN ciudad ON pto_fisico.fk_codciudad = ciudad.cod_ciudad WHERE cod_ptofisico = '" + cod_ptofisico + "' ORDER BY pto_fisico.cod_ptofisico;";
                    Conn = Conexion.getConexion().CrearConexion();
                    MySqlCommand Comand = new MySqlCommand(consulta, Conn);
                    Comand.CommandTimeout = 60;
                    Conn.Open();
                    Resultado = Comand.ExecuteReader();

                    while (Resultado.Read())
                    {
                        PuntoFisico.cod_ptofisico = Convert.ToString(Resultado["cod_ptofisico"]);
                        PuntoFisico.nom_ptofisico = Convert.ToString(Resultado["nom_ptofisico"]);
                        PuntoFisico.direccion_ptofisico = Convert.ToString(Resultado["direccion_ptofisico"]);
                        PuntoFisico.estado_ptofisico = Convert.ToString(Resultado["estado_ptofisico"]);
                        PuntoFisico.fk_docintegrante = Convert.ToString(Resultado["nom_integrante"]);
                        PuntoFisico.fk_codcampana = Convert.ToString(Resultado["nom_campana"]);
                        PuntoFisico.fk_codciudad = Convert.ToString(Resultado["nom_ciudad"]);
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

                return PuntoFisico;
            }

            public bool Guardar(PuntoFisicoModel PuntoFisico)
            {
                bool rpta;

                MySqlConnection Conn = new MySqlConnection();

                try
                {
                    string consulta = "INSERT INTO pto_fisico(nom_ptofisico,direccion_ptofisico,estado_ptofisico,fk_docintegrante,fk_codcampana,fk_codciudad) VALUES ('" + PuntoFisico.nom_ptofisico + "','" + PuntoFisico.direccion_ptofisico + "','Activo','" + PuntoFisico.fk_docintegrante + "','" + PuntoFisico.fk_codcampana + "','" + PuntoFisico.fk_codciudad + "')";
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

            public bool Editar(PuntoFisicoModel PuntoFisico)
            {
                bool rpta;

                MySqlConnection Conn = new MySqlConnection();

                try
                {
                    string consulta = "UPDATE pto_fisico SET nom_ptofisico = '" + PuntoFisico.nom_ptofisico + "', direccion_ptofisico = '"+PuntoFisico.direccion_ptofisico+"', estado_ptofisico ='"+PuntoFisico.estado_ptofisico+"' , fk_docintegrante = '"+PuntoFisico.fk_docintegrante+"', fk_codcampana = '"+PuntoFisico.fk_codcampana+"', fk_codciudad = '"+PuntoFisico.fk_codciudad+"' WHERE cod_ptofisico = '" + PuntoFisico.cod_ptofisico + "';";
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

            public List<CiudadModel> ListarCiudad()
            {
                var Lista = new List<CiudadModel>();
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
                        Lista.Add(new CiudadModel()
                        {
                            cod_ciudad = Convert.ToString(Resultado["cod_ciudad"]),
                            nom_ciudad = Convert.ToString(Resultado["nom_ciudad"]),
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
            public List<IntegranteModel> ListarIntegrante()
            {
                var Lista = new List<IntegranteModel>();
                MySqlDataReader Resultado;
                MySqlConnection Conn = new MySqlConnection();

                try
                {
                    Conn = Conexion.getConexion().CrearConexion();
                    string consulta = "SELECT doc_integrante, nom_integrante FROM integrante;";
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
            public List<CampanaModel> ListarCampana()
            {
                var Lista = new List<CampanaModel>();
                MySqlDataReader Resultado;
                MySqlConnection Conn = new MySqlConnection();

                try
                {
                    Conn = Conexion.getConexion().CrearConexion();
                    string consulta = "SELECT cod_campana, nom_campana FROM campana;";
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
