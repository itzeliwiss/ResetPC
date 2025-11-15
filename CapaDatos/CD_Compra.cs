using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;

namespace CapaDatos
{
    public class CD_Compra
    {

        public int ObtenerCorrelativo()
        {
            int idcorrelativo = 0;

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("SELECT count(*)+1 FROM COMPRA");
                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.CommandType = System.Data.CommandType.Text;


                    oconexion.Open();

                    idcorrelativo = Convert.ToInt32(cmd.ExecuteScalar());



                }
            }
            catch (Exception)
            {
                idcorrelativo = 0;
            }

            return idcorrelativo;
        }

        public bool Registrar(Compra obj, DataTable DetalleCompra, out string Mensaje)
        {
            bool Respuesta = false;
            Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {

                    SqlCommand cmd = new SqlCommand("sp_RegistarCompra", oconexion);
                    cmd.Parameters.AddWithValue("IdProveedor", obj.oProveedor.IdProveedor);
                    cmd.Parameters.AddWithValue("Tipo_Documento", obj.Tipo_Documento);
                    cmd.Parameters.AddWithValue("MontoTotal", obj.MontoTotal);
                    cmd.Parameters.AddWithValue("NumeroDocumento", obj.NumeroDocumento);
                    cmd.Parameters.AddWithValue("Subtotal", obj.Subtotal);
                    cmd.Parameters.AddWithValue("IVATotal", obj.IVATotal);
                    cmd.Parameters.AddWithValue("DetalleCompra", DetalleCompra);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    oconexion.Open();
                    cmd.ExecuteNonQuery();


                    Respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                }
            }
            catch (Exception ex)
            {
                Respuesta = false;
                Mensaje = ex.Message;
            }
            return Respuesta;
        }
        public Compra ObtenerCompra(string numero)
        {
            Compra obj = new Compra();
            using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select c.IdCompra, ");
                    query.AppendLine("pr.RFC,pr.RazonSocial, c.Tipo_Documento,c.NumeroDocumento,c.SubTotal,c.IVATotal,");
                    query.AppendLine("c.MontoTotal,CONVERT(char(10), c.FechaRegistro, 103)[FechaRegistro]");
                    query.AppendLine("from COMPRA c");
                    query.AppendLine("inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor");
                    query.AppendLine("where c.NumeroDocumento = @numero");

                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@numero", numero);
                    oconexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            obj = new Compra()
                            {
                                IdCompra = Convert.ToInt32(dr["IdCompra"]),
                                oProveedor = new Proveedor() 
                                {
                                    RFC = dr["RFC"].ToString(),
                                    RazonSocial = dr["RazonSocial"].ToString()
                                },
                                Tipo_Documento = dr["Tipo_Documento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                Subtotal = Convert.ToDecimal(dr["SubTotal"].ToString()),
                                IVATotal = Convert.ToDecimal(dr["IVATotal"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            };


                        }

                    }
                }

                catch (SqlException ex)
                {
                    
                    Console.WriteLine("Error en Listar: " + ex.Message);
                    obj = new Compra();
                    
                   
                }
            return obj;
        }

        public List<Detalle_Compra> ObtenerDetalleCompra(string idcompra)
        {
            List<Detalle_Compra> oLista = new List<Detalle_Compra>();
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cadena))
                {
                    oconexion.Open();
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select co.Nombre,dc.Cantidad,dc.PrecioUnitario,dc.Subtotal,dc.IVACalculado,dc.MontoTotal,dc.TasaIVA from DETALLE_COMPRA dc");
                    query.AppendLine("inner join COMPONENTE co on co.IdComponente = dc.IdComponente where dc.IdCompra = @idcompra");


                    SqlCommand cmd = new SqlCommand(query.ToString(), oconexion);
                    cmd.Parameters.AddWithValue("@idcompra", idcompra); 
                    cmd.CommandType = System.Data.CommandType.Text;


                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            oLista.Add(new Detalle_Compra()
                            {
                                oComponente = new Componente()
                                {
                                    Nombre = dr["Nombre"].ToString()
                                },
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"].ToString()),
                                Subtotal = Convert.ToDecimal(dr["Subtotal"].ToString()),
                                IVACalculado = Convert.ToDecimal(dr["IVACalculado"].ToString()),
                                MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString()),
                                TasaIVA  = Convert.ToDecimal(dr["TasaIVA"].ToString())

                            });


                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener detalle de compra: " + ex.Message);
                oLista = new List<Detalle_Compra> ();
            }
            return oLista;
        }



    }

}
    
