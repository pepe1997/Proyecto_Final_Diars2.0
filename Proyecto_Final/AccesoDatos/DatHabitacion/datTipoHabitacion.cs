using AccesoDatos.BaseDatos;
using entTipoHabitacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DaoEntidades
{
    public class datTipoHabitacion
    {
        #region singleton
        private static readonly datTipoHabitacion UnicaInstancia = new datTipoHabitacion();
        public static datTipoHabitacion Instancia
        {
            get
            {
                return datTipoHabitacion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<TipoHabitacion> ListarTipoHabitacion()
        {
            SqlCommand cmd = null;
            List<TipoHabitacion> lista = new List<TipoHabitacion>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaTipoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoHabitacion tc = new TipoHabitacion();

                    tc.idTipoHabitacion = Convert.ToInt32(dr["idTipoHabitacion"]);
                    tc.nombTipoHabitacion = dr["nombTipoHabitacion"].ToString();
                    tc.precTipoHabitacion = Convert.ToDouble(dr["precTipoHabitacion"]);
                    tc.detalle = dr["detalle"].ToString();
                    lista.Add(tc);
                }

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return lista;
        }
        /////////////////////////InsertaTipoHabitacion
        public Boolean InsertarTipoHabitaion(TipoHabitacion th)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTipoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombTipoHabitacion", th.nombTipoHabitacion);
                cmd.Parameters.AddWithValue("@precTipoHabitacion", th.precTipoHabitacion);
                cmd.Parameters.AddWithValue("@detalle", th.detalle);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    inserta = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return inserta;
        }


        //////////////////////////////////EditaTipoHabitacion
        public Boolean EditarTipoHabitacion(TipoHabitacion th)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaTipoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipCliente", th.idTipoHabitacion);
                cmd.Parameters.AddWithValue("@nombTipoHabitacion", th.nombTipoHabitacion);
                cmd.Parameters.AddWithValue("@precTipoHabitacion", th.precTipoHabitacion);
                cmd.Parameters.AddWithValue("@detalle", th.detalle);

                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                {
                    edita = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return edita;
        }


        public TipoHabitacion BuscarTipoHabitacion(int idTipoHabitacion)
        {
            SqlCommand cmd = null;
            TipoHabitacion c = new TipoHabitacion();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarTipoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipoHabitacion", idTipoHabitacion);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idTipoHabitacion = Convert.ToInt32(dr["idTipoHabitacion"]);
                    c.nombTipoHabitacion = dr["nombTipoHabitacion"].ToString();
                    c.precTipoHabitacion = Convert.ToDouble(dr["precTipoHabitacion"]);
                    c.detalle = dr["detalle"].ToString();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmd.Connection.Close();
            }
            return c;
        }



        #endregion metodos
    }
}
