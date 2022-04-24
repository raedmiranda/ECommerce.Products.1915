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

        public List<Producto> Listar()
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
                    producto.Precio = Convert.ToDecimal(dr["Precio"]);
                    producto.Estado = Convert.ToBoolean(dr["Estado"]);
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

        internal Producto Devolver(int id)
        {
            SqlCommand cmd = null;
            Producto producto = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spDevolverProducto", cn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    producto = new Producto();
                    producto.Id = Convert.ToInt32(dr["Id"]);
                    producto.Nombre = Convert.ToString(dr["Nombre"]);
                    producto.Descripcion = Convert.ToString(dr["Descripcion"]);
                    producto.Precio = Convert.ToDecimal(dr["Precio"]);
                    producto.Estado = Convert.ToBoolean(dr["Estado"]);
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
            return producto;
        }

        public bool Insertar(Producto producto)
        {
            SqlCommand cmd = null;
            bool creado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spInsertarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                //cmd.Parameters.AddWithValue("@Estado", producto.Estado);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) creado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return creado;
        }

        public bool Eliminar(int id)
        {
            SqlCommand cmd = null;
            bool eliminado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spEliminarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) eliminado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return eliminado;
        }

        public bool Actualizar(Producto producto)
        {
            SqlCommand cmd = null;
            bool editado = false;

            try
            {
                SqlConnection cn = Conexion.Instancia.conectar();
                cmd = new SqlCommand("spActualizarProducto", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", producto.Id);
                cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion);
                cmd.Parameters.AddWithValue("@Precio", producto.Precio);

                cn.Open();

                int nro = cmd.ExecuteNonQuery();
                if (nro > 0) editado = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return editado;
        }
    }
}
