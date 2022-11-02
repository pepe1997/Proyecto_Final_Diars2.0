using AccesoDatos.BaseDatos;
using entServicio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DatServicio
{
    public class datEstadoServicio
    {
        #region singleton
        private static readonly datEstadoServicio UnicaInstancia = new datEstadoServicio();
        public static datEstadoServicio Instancia
        {
            get
            {
                return datEstadoServicio.UnicaInstancia;
            }
        }
        #endregion singleton
        #region metodos
        public List<EstadoServicio> ListarEstadoServicio()
        {
            SqlCommand cmd = null;
            List<EstadoServicio> lista = new List<EstadoServicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spListarEstadoServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoServicio es = new EstadoServicio();

                    es.idEstServicio = Convert.ToInt32(dr["idEstServicio"]);
                    es.nombreEst = Convert.ToString(dr["nombreEst"]);

                    lista.Add(es);
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
