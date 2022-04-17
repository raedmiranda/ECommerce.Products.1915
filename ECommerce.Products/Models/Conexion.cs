using System.Data.SqlClient;

namespace ECommerce.Products.Models
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion _instancia = new Conexion();
        public static Conexion Instancia { get { return _instancia;  } }
        #endregion singleton

        public SqlConnection conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=IBLAPELIMC00703\\SQLEXPRESS;Initial Catalog=ECommerce;Integrated Security=True";
            return cn;
        }
    }
}
