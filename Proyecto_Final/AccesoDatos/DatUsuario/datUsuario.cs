using AccesoDatos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entUsuario;
using entCliente;

namespace AccesoDatos.DatUsuario
{
    public class datUsuario
    {
        #region singleton
        private static readonly datUsuario _instancia = new datUsuario();
        public static datUsuario Instancia
        {
            get { return datUsuario._instancia; }
        }
        #endregion singleton

        #region metodos
        public Usuario VerificarAcceso(String Usuario, String Password)
        {
            SqlCommand cmd = null;
            Usuario u = null;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spVerificarAcceso", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@prmstrUsuario", Usuario);
                cmd.Parameters.AddWithValue("@prmstrPassword", Password);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    u = new Usuario();
                    u.idUsuario = Convert.ToInt16(dr["idUsuario"]);
                    u.fecCreacion = Convert.ToDateTime(dr["fecCreacion"]);
                    u.userName = dr["userName"].ToString();
                    u.estadoUsuario = Convert.ToBoolean(dr["estadoUsuario"]);
                    Cliente c = new Cliente();
                    c.dni = dr["dni"].ToString();
                    c.nombCliente = dr["nombCliente"].ToString();
                    u.idCliente = c;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return u;
        }

        #endregion metodos
    }
}
