using AccesoDatos.BaseDatos;
using entServicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DatServicio
{
    public class datTipoServicio
    {
        #region singleton
        private static readonly datTipoServicio UnicaInstancia = new datTipoServicio();
        public static datTipoServicio Instancia
        {
            get
            {
                return datTipoServicio.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<TipoServicio> ListarTipoServicio()
        {
            SqlCommand cmd = null;
            List<TipoServicio> lista = new List<TipoServicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarTipoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoServicio ts = new TipoServicio();

                    ts.idTipoServicio = Convert.ToInt32(dr["idTipoServicio"]);
                    ts.nombreTipo = Convert.ToString(dr["nombreTipo"]);

                    lista.Add(ts);
                }
            }
            catch (SqlException e)
            { throw e; }
            finally
            { cmd.Connection.Close(); }
            return lista;
        }
        #endregion metodos
    }
}
