using AccesoDatos.BaseDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entServicio;

namespace AccesoDatos.DatServicio
{
    public class datServicio
    {
        #region singleton
        private static readonly datServicio UnicaInstancia = new datServicio();
        public static datServicio Instancia
        {
            get
            {
                return datServicio.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<Servicio> ListarServicio()
        {
            SqlCommand cmd = null;
            List<Servicio> lista = new List<Servicio>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Servicio Ser = new Servicio();
                    TipoServicio ts = new TipoServicio();
                    EstadoServicio es = new EstadoServicio();

                    Ser.idServicio = Convert.ToInt32(dr["idServicio"]);
                    Ser.nombre_servicio = dr["nombre_servicio"].ToString();
                    Ser.precio = Convert.ToInt32(dr["precio"]);
                    Ser.descripcion = dr["descripcion"].ToString();
                    ts.idTipoServicio = Convert.ToInt32(dr["idTipoServicio"]);
                    ts.nombreTipo = dr["nombreTipo"].ToString();
                    Ser.idTipoServicio = ts;
                    es.nombreEst = dr["nombreEst"].ToString();
                    Ser.idEstServicio = es;
                    //Ser.idTipoServicio = Convert.ToInt32(dr["idTipoServicio"]);
                    //Ser.idEstServicio = Convert.ToInt32(dr["idEstServicio"]);
                    lista.Add(Ser);
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

        public Boolean InsertarServicio(Servicio Ser)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombre_servicio", Ser.nombre_servicio);
                cmd.Parameters.AddWithValue("@precio", Ser.precio);
                cmd.Parameters.AddWithValue("@descripcion", Ser.descripcion);
                cmd.Parameters.AddWithValue("@idTipoServicio", Ser.idTipoServicio.idTipoServicio);
                cmd.Parameters.AddWithValue("@idEstServicio", Ser.idEstServicio.idEstServicio);

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


        public Boolean EditarServicio(Servicio Ser)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idServicio", Ser.idServicio);
                cmd.Parameters.AddWithValue("@nombre_servicio", Ser.nombre_servicio);
                cmd.Parameters.AddWithValue("@precio", Ser.precio);
                cmd.Parameters.AddWithValue("@descripcion", Ser.descripcion);
                cmd.Parameters.AddWithValue("@idTipoServicio", Ser.idTipoServicio.idTipoServicio);
                cmd.Parameters.AddWithValue("@idEstServicio", Ser.idEstServicio.idEstServicio);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
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

        public Servicio BuscarServicio(int idServicio)
        {
            SqlCommand cmd = null;
            Servicio Ser = new Servicio();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idServicio", idServicio);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoServicio ts = new TipoServicio();
                    EstadoServicio es = new EstadoServicio();

                    Ser.idServicio = Convert.ToInt32(dr["idServicio"]);
                    Ser.nombre_servicio = dr["nombre_servicio"].ToString();
                    Ser.precio = Convert.ToInt32(dr["precio"]);
                    Ser.descripcion = dr["descripcion"].ToString();
                    ts.idTipoServicio = Convert.ToInt32(dr["idTipoServicio"]);
                    Ser.idTipoServicio = ts;
                    es.idEstServicio = Convert.ToInt32(dr["idEstServicio"]);
                    Ser.idEstServicio = es;
                    //Ser.idTipoServicio = Convert.ToInt32(dr["idTipoServicio"]);
                    //Ser.idEstServicio = Convert.ToInt32(dr["idEstServicio"]);
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
            return Ser;
        }

        public Boolean EliminarServicio(Servicio Ser)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarServicio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idServicio", Ser.idServicio);
                cmd.Parameters.AddWithValue("@idEstServicio", Ser.idEstServicio);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i >= 0)
                { elimina = true; }
            }
            catch (Exception e)
            { throw e; }
            finally { cmd.Connection.Close(); }
            return elimina;
        }

        #endregion metodos
    }
}
