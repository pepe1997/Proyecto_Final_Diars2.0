using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos.BaseDatos;
using entEstadoReserva;

namespace AccesoDatos.DatReserva
{
    public class datEstadoReserva
    {
        #region singleton
        private static readonly datEstadoReserva UnicaInstancia = new datEstadoReserva();
        public static datEstadoReserva Instancia
        {
            get
            {
                return datEstadoReserva.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<EstadoReserva> ListarEstadoReserva()
        {
            SqlCommand cmd = null;
            List<EstadoReserva> lista = new List<EstadoReserva>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaEstReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoReserva tc = new EstadoReserva();

                    tc.idEstRserva = Convert.ToInt32(dr["idEstRserva"]);
                    tc.desEsTReserva = dr["desEsTReserva"].ToString();
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
        public Boolean InsertarEstadoReserva(EstadoReserva eh)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarEstReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desEsTReserva", eh.desEsTReserva);



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
        public Boolean EditarEstadoReserva(EstadoReserva eh)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaEstadoReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstRserva", eh.idEstRserva);
                cmd.Parameters.AddWithValue("@desEsTReserva", eh.desEsTReserva);

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


        public EstadoReserva BuscarEstadoReserva(int idEstadoReserva)
        {
            SqlCommand cmd = null;
            EstadoReserva c = new EstadoReserva();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarEstadoReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEstadoReserva", idEstadoReserva);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idEstRserva = Convert.ToInt32(dr["idEstRserva"]);
                    c.desEsTReserva = dr["desEsTReserva"].ToString();

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
