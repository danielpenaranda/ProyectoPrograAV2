using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProyectoPrograAV2.Models;
using System.Data;
using System.Globalization;
using System.Xml.Linq;
using System.Xml;

namespace ProyectoPrograAV2.Controllers
{
    public class CarritoController : Controller
    { 
        private readonly string _conexion = "@\"Server=.\\SQLEXPRESS;Database=proyecto_tienda_G6;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult carrito()
        {
            return View();
        }

        public int Registrar(Carrito oCarrito)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(_conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_InsertarCarrito", oConexion);
                    cmd.Parameters.AddWithValue("@Id_usuario", oCarrito.id_usuario);
                    cmd.Parameters.AddWithValue("@Id_producto", oCarrito.id_producto);
                    cmd.Parameters.AddWithValue("@CantidadProductos", oCarrito.cantidadProductos);
                    cmd.Parameters.AddWithValue("@FechaCompra", oCarrito.fechaCompra);
                    cmd.Parameters.Add("@Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = Convert.ToInt32(cmd.Parameters["@Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    // Manejar la excepción
                }
            }
            return respuesta;
        }

        public int Cantidad(int idUsuario)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(_conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Carrito WHERE id_usuario = @idUsuario", oConexion);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    respuesta = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                }
                catch (Exception ex)
                {
                    respuesta = 0;
                    // Manejar la excepción
                }
            }
            return respuesta;
        }

        public List<Carrito> Obtener(int idUsuario)
        {
            List<Carrito> lst = new List<Carrito>();
            using (SqlConnection oConexion = new SqlConnection(_conexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ObtenerCarrito", oConexion);
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lst.Add(new Carrito()
                            {
                                id_carrito = Convert.ToInt32(dr["id_carrito"]),
                                id_usuario = Convert.ToInt32(dr["id_usuario"]),
                                id_producto = Convert.ToInt32(dr["id_producto"]),
                                cantidadProductos = Convert.ToInt32(dr["cantidadProductos"]),
                                fechaCompra = Convert.ToDateTime(dr["fechaCompra"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                }
            }
            return lst;
        }

        public bool Eliminar(int idCarrito, int idProducto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(_conexion))
            {
                try
                {
                    oConexion.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = oConexion;
                    cmd.CommandText = "DELETE FROM Carrito WHERE id_carrito = @idCarrito; UPDATE Producto SET Stock = Stock + 1 WHERE id_producto = @idProducto";
                    cmd.Parameters.AddWithValue("@idCarrito", idCarrito);
                    cmd.Parameters.AddWithValue("@idProducto", idProducto);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    respuesta = false;
                    // Manejar la excepción
                }
            }
            return respuesta;
        }

        public List<Carrito> ObtenerCompra(int idUsuario)
        {
            List<Carrito> rptDetalleCompra = new List<Carrito>();
            using (SqlConnection oConexion = new SqlConnection(_conexion))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerCompra", oConexion);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                try
                {
                    oConexion.Open();
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("DATA") != null)
                            {
                                rptDetalleCompra = (from c in doc.Element("DATA").Elements("COMPRA")
                                                    select new Carrito()
                                                    {
                                                        id_carrito = Convert.ToInt32(c.Element("IdCarrito").Value),
                                                        id_usuario = Convert.ToInt32(c.Element("IdUsuario").Value),
                                                        id_producto = Convert.ToInt32(c.Element("IdProducto").Value),
                                                        cantidadProductos = Convert.ToInt32(c.Element("CantidadProductos").Value),
                                                        fechaCompra = Convert.ToDateTime(c.Element("FechaCompra").Value),
                                                        // DetalleCompra no está definido en Carrito, tendría que ser una lista de DetalleCompra
                                                        // Puedes modificar la clase Carrito para agregar esta propiedad si es necesario
                                                    }).ToList();
                            }
                            else
                            {
                                rptDetalleCompra = new List<Carrito>();
                            }
                        }

                        dr.Close();
                    }

                    return rptDetalleCompra;
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    return rptDetalleCompra;
                }
            }
        }
    }
}
