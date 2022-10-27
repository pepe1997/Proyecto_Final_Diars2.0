using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.BaseDatos;
using entEstadoHabitacion;
namespace AccesoDatos.DaoEntidades
{
    public class datEstadoHabitacion
    {
        #region singleton
        private static readonly datEstadoHabitacion UnicaInstancia = new datEstadoHabitacion();
        public static datEstadoHabitacion Instancia
        {
            get
            {
                return datEstadoHabitacion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<EstadoHabitacion> ListarEstadoHabitacion()
        {
            SqlCommand cmd = null;
            List<EstadoHabitacion> lista = new List<EstadoHabitacion>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaEstHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoHabitacion tc = new EstadoHabitacion();

                    tc.idEstHabitacion = Convert.ToInt32(dr["idEstHabitacion"]);
                    tc.desEsTHabitacion = dr["desEsTHabitacion"].ToString();
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
        /////////////////////////InsertaHabitacion
        public Boolean InsertarEstadoHabitacion(EstadoHabitacion eh)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarEstHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desEsTHabitacion", eh.desEsTHabitacion);



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


        //////////////////////////////////EditaHabitacion
        public Boolean EditarEstadoCliente(EstadoHabitacion eh)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaEstadoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstHabitacion", eh.idEstHabitacion);
                cmd.Parameters.AddWithValue("@desEsTHabitacion", eh.desEsTHabitacion);

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


        public EstadoHabitacion BuscarEstadoHabitacion(int idEstadoHabitacion)
        {
            SqlCommand cmd = null;
            EstadoHabitacion c = new EstadoHabitacion();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarEstadoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEstadoHabitacion", idEstadoHabitacion);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idEstHabitacion = Convert.ToInt32(dr["idEstHabitacion"]);
                    c.desEsTHabitacion = dr["desEsTHabitacion"].ToString();

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
