using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Equipo
    {
        public List<Equipo> Listar()
        {
            List<Equipo> lista = new List<Equipo>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT e.IdEquipo,e.IdCliente, c.NombreCompleto[Cliente], e.Tipo, e.IdMarca, m.NombreMarca[Marca],e.Modelo,e.Almacenamiento,");
                    query.AppendLine("e.Ram,e.Procesador,e.NumeroSerie,e.Descripcion,e.IdSO,s.NombreSO[SistemaOperativo], e.TipoDisco");
                    query.AppendLine("FROM EQUIPO e ");
                    query.AppendLine("INNER JOIN CLIENTE c on c.IdCliente = e.IdCliente");
                    query.AppendLine("INNER JOIN MARCA m on m.IdMarca = e.IdMarca");
                    query.AppendLine("INNER JOIN SO s on s.IdSO = e.IdSO");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Equipo()
                            {
                                IdEquipo = Convert.ToInt32(dr["IdEquipo"]),
                                oCliente = new Cliente()
                                {
                                    IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                    NombreCompleto = dr["Cliente"].ToString()
                                },
                                Tipo = dr["Tipo"].ToString(),
                                oMarca = new Marca()
                                {
                                    IdMarca = Convert.ToInt32(dr["IdMarca"]),
                                    NombreMarca = dr["Marca"].ToString()
                                },
                                Modelo = dr["Modelo"].ToString(),
                                Almacenamiento = dr["Almacenamiento"].ToString(),
                                Ram = dr["Ram"].ToString(),
                                Procesador = dr["Procesador"].ToString(),
                                NumeroSerie = dr["NumeroSerie"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oOS = new SO()
                                {
                                    IdSO = Convert.ToInt32(dr["IdSO"]),
                                    NombreSO = dr["SistemaOperativo"].ToString()
                                },
                                TipoDisco = dr["TipoDisco"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Listar: " + ex.Message);
                lista = new List<Equipo>();
            }
            return lista;
        }

        public int Registrar(Equipo objequipo, out string Mensaje)
        {
            int idEquipogenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistarEquipo", oconexion);
                    cmd.Parameters.AddWithValue("IdEquipo", objequipo.IdEquipo);
                    cmd.Parameters.AddWithValue("IdCliente", objequipo.oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("IdMarca", objequipo.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("Tipo", objequipo.Tipo);
                    cmd.Parameters.AddWithValue("Modelo", objequipo.Modelo);
                    cmd.Parameters.AddWithValue("Almacenamiento", objequipo.Almacenamiento);
                    cmd.Parameters.AddWithValue("TipoDisco", objequipo.TipoDisco);
                    cmd.Parameters.AddWithValue("Ram", objequipo.Ram);
                    cmd.Parameters.AddWithValue("Procesador", objequipo.Procesador);
                    cmd.Parameters.AddWithValue("NumeroSerie", objequipo.NumeroSerie);
                    cmd.Parameters.AddWithValue("Descripcion", objequipo.Descripcion);
                    cmd.Parameters.AddWithValue("IdSO", objequipo.oOS.IdSO);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idEquipogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idEquipogenerado = 0;
                Mensaje = ex.Message;
            }
            return idEquipogenerado;
        }

        public bool Editar(Equipo objequipo, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarEquipo", oconexion);
                    cmd.Parameters.AddWithValue("IdEquipo", objequipo.IdEquipo);
                    cmd.Parameters.AddWithValue("IdCliente", objequipo.oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("IdMarca", objequipo.oMarca.IdMarca);
                    cmd.Parameters.AddWithValue("Tipo", objequipo.Tipo);
                    cmd.Parameters.AddWithValue("Modelo", objequipo.Modelo);
                    cmd.Parameters.AddWithValue("Almacenamiento", objequipo.Almacenamiento);
                    cmd.Parameters.AddWithValue("TipoDisco", objequipo.TipoDisco);
                    cmd.Parameters.AddWithValue("Ram", objequipo.Ram);
                    cmd.Parameters.AddWithValue("Procesador", objequipo.Procesador);
                    cmd.Parameters.AddWithValue("NumeroSerie", objequipo.NumeroSerie);
                    cmd.Parameters.AddWithValue("Descripcion", objequipo.Descripcion);
                    cmd.Parameters.AddWithValue("IdSO", objequipo.oOS.IdSO);

                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }

        public bool Eliminar(Equipo objequipo, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarEquipo", oconexion);

                    cmd.Parameters.AddWithValue("IdEquipo", objequipo.IdEquipo);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                respuesta = false;
                Mensaje = ex.Message;
            }
            return respuesta;
        }


    }
}

