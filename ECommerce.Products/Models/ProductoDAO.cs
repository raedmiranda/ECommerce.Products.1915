using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ECommerce.Products.Models
{
    public class ProductoDAO
    {
        #region singleton
        private static readonly ProductoDAO _instancia = new ProductoDAO();
        public static ProductoDAO Instancia { get { return _instancia; } }
        #endregion singleton

        List<Producto> Listar()
        {
            SqlCommand cmd = null;
            List<Producto> list = null;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spListarProductos", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                list = new List<Producto>();
                while (dr.Read())
                {
                    Producto producto = new Producto();
                    producto.Id = Convert.ToInt32(dr["Id"]);
                    producto.Nombre = Convert.ToString(dr["Nombre"]);
                    producto.Descripcion = Convert.ToString(dr["Descripcion"]);
                    //...
                    list.Add(producto);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return list;
        }
    }
}
