using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //cn.ConnectionString = "Data Source=DESKTOP-4MBU90P;initial Catalog=HOTEL_CENTRAL_WEB;" + "Integrated Security=true";

            return cn;
        }
        #endregion métodos
    }
}
