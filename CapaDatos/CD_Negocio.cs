using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using CapaDatos;
using System.Data.SqlClient;
using System.Runtime.Remoting.Messaging;

namespace CapaDatos
{
    public class CD_Negocio
    {
        public Negocio ObtenerDatos() 
        {
           Negocio obj = new Negocio();

            try
            {
                using(SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();

                    string query = "SELECT IdNegocio,RazonSocial,RFC,Direccion,Telefono FROM NEGOCIO WHERE IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Negocio()
                            {
                                IdNegocio = int.Parse(dr["IdNegocio"].ToString()),
                                RazonSocial = dr["RazonSocial"].ToString(),
                                RFC = dr["RFC"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString()
                            };

                        }
                    }

                }
            }
            catch
            {
                obj = new Negocio();
            }

            return obj;
        }


        public bool GuardarDatos(Negocio objeto,out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();


                    

                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET RazonSocial = @RazonSocial,");
                    query.AppendLine("RFC = @RFC,");
                    query.AppendLine("Direccion = @Direccion,");
                    query.AppendLine("Telefono = @Telefono");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@RazonSocial", objeto.RazonSocial);
                    cmd.Parameters.AddWithValue("@RFC", objeto.RFC);
                    cmd.Parameters.AddWithValue("@Direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("@Telefono", objeto.Telefono);
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo guardar los datos";
                        respuesta = false;
                    }

                }
            }
            catch(Exception ex)
            {
               respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }

        public byte[] ObtenerLogo(out bool obtenido)
        {
            obtenido = true;
            byte[] LogoBytes = new byte[0];

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();




                    string query = "SELECT Logo FROM NEGOCIO WHERE IdNegocio = 1";
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            LogoBytes = (byte[])dr["Logo"];
                        }
                    }

                }
            }
            catch (Exception)
            {
                obtenido = false;
                LogoBytes = new byte[0];
            }
            return LogoBytes;
        }
        
        public bool ActualizarLogo(byte[] imagen, out string mensaje)
        {
            mensaje = string.Empty;
            bool respuesta = true;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cadena))
                {
                    conexion.Open();




                    StringBuilder query = new StringBuilder();
                    query.AppendLine("UPDATE NEGOCIO SET Logo = @imagen");
                    query.AppendLine("WHERE IdNegocio = 1;");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@Imagen", imagen);
                    cmd.CommandType = System.Data.CommandType.Text;

                    if (cmd.ExecuteNonQuery() < 1)
                    {
                        mensaje = "No se pudo actualizar el logo";
                        respuesta = false;
                    }

                }
            }
            catch (Exception ex)
            {
                respuesta = false;
                mensaje = ex.Message;
            }
            return respuesta;
        }



    }
}
