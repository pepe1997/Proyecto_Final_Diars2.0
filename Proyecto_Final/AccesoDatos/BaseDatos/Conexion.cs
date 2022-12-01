using System.Data.SqlClient;

namespace AccesoDatos.BaseDatos
{
    public class Conexion
    {
        #region singleton
        private static readonly Conexion UnicaInstancia = new Conexion();
        public static Conexion Instancia
        {
            get
            {
                return Conexion.UnicaInstancia;
            }
        }
        #endregion singleton
        #region métodos

        public SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = "Data Source=LAPTOP-CLR629GA\\SQLEXPRESS;Initial Catalog = PROYECTO_DIARS;" + "Integrated Security = true";
            //cn.ConnectionString = "Data Source=DESKTOP-4MBU90P;initial Catalog=PROYECTO_DIARS;" + "Integrated Security=true";

            return cn;
        }
        #endregion métodos
    }
}
