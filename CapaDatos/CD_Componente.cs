using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
using System.Collections;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public class CD_Componente
    {
        public List<Componente> Listar()
        {
            List<Componente> lista = new List<Componente>();

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT c.IdComponente, c.Codigo, c.Nombre, c.IdCategoria, ca.Descripcion[DescripcionCategoria], c.Descripcion, c.Stock, ");
                    query.AppendLine("c.PrecioCompra, c.PrecioVenta, c.Estado  FROM COMPONENTE c inner join CATEGORIA ca on ca.IdCategoria = c.IdCategoria");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);

                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Componente()
                            { 
                                IdComponente = Convert.ToInt32(dr["IdComponente"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                
                                oCategoria = new Categoria()
                                {
                                    IdCategoria = Convert.ToInt32(dr["IdCategoria"]),
                                    Descripcion = dr["DescripcionCategoria"].ToString()
                                },
                                Stock = Convert.ToInt32(dr["Stock"]),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en Listar: " + ex.Message);
                lista = new List<Componente>();
            }
            return lista;
        }

        public int Registrar(Componente objcomponente, out string Mensaje)
        {
            int idComponentegenerado = 0;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistarComponente", oconexion);
                    cmd.Parameters.AddWithValue("Codigo", objcomponente.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", objcomponente.Nombre);
                    cmd.Parameters.AddWithValue("IdCategoria", objcomponente.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", objcomponente.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", objcomponente.Estado);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oconexion.Open();

                    cmd.ExecuteNonQuery();

                    idComponentegenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }

            }
            catch (Exception ex)
            {
                idComponentegenerado = 0;
                Mensaje = ex.Message;
            }
            return idComponentegenerado;
        }

        public bool Editar(Componente objcomponente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarComponente", oconexion);
                    cmd.Parameters.AddWithValue("IdComponente", objcomponente.IdComponente);
                    cmd.Parameters.AddWithValue("Codigo", objcomponente.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", objcomponente.Nombre);
                    cmd.Parameters.AddWithValue("IdCategoria", objcomponente.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("Descripcion", objcomponente.Descripcion);
                    cmd.Parameters.AddWithValue("Estado", objcomponente.Estado);
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

        public bool Eliminar(Componente objcomponente, out string Mensaje)
        {
            bool respuesta = false;
            Mensaje = string.Empty;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarComponente", oconexion);

                    cmd.Parameters.AddWithValue("IdComponente", objcomponente.IdComponente);
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
