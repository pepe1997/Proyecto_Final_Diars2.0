using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entHabitacion;
using entCliente;
using entEstadoReserva;
using entReserva;
using System.Data.SqlClient;
using AccesoDatos.BaseDatos;
using System.Data;

namespace AccesoDatos.DatReserva
{
    public class datReserva
    {
        #region singleton
        private static readonly datReserva UnicaInstancia = new datReserva();
        public static datReserva Instancia
        {
            get
            {
                return datReserva.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<Reserva> ListarReserva()
        {
            SqlCommand cmd = null;
            List<Reserva> lista = new List<Reserva>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Reserva re = new Reserva();
                    Habitacion ha = new Habitacion();
                    Cliente cl = new Cliente();
                    EstadoReserva er = new EstadoReserva();

                    re.idRserva = Convert.ToInt32(dr["idRserva"]);
                    re.fecIngReseva = dr["fecIngReseva"].ToString();
                    re.numPerReserva = Convert.ToInt32(dr["numPerReserva"].ToString());
                    re.fecSalReserva = dr["fecSalReserva"].ToString();

                    ha.numHabitacion = Convert.ToInt32(dr["numHabitacion"].ToString());
                    re.idHabitacion = ha;
                    cl.idCliente = Convert.ToInt32(dr["idCliente"]);
                    cl.nombCliente = dr["nombCliente"].ToString();
                    re.idCliente = cl;
                    er.idEstRserva = Convert.ToInt32(dr["idEstRserva"]);
                    er.desEsTReserva = dr["desEsTReserva"].ToString();
                    re.idEstRserva= er;
                    lista.Add(re);
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
        /////////////////////////InsertaCliente
        public Boolean InsertarReserva(Reserva re)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fecIngReseva", re.fecIngReseva);
                cmd.Parameters.AddWithValue("@numPerReserva", re.numPerReserva);
                cmd.Parameters.AddWithValue("@direcCliente", re.fecSalReserva);

                cmd.Parameters.AddWithValue("@idEstRserva", re.idEstRserva.idEstRserva);
                cmd.Parameters.AddWithValue("@idCliente", re.idCliente.idCliente);
                cmd.Parameters.AddWithValue("@idHabitacion", re.idHabitacion.idHabitacion);


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


        //////////////////////////////////EditaCliente
        public Boolean EditarReserva(Reserva re)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idRserva", re.idRserva);
                cmd.Parameters.AddWithValue("@fecIngReseva", re.fecIngReseva);
                cmd.Parameters.AddWithValue("@numPerReserva", re.numPerReserva);
                cmd.Parameters.AddWithValue("@direcCliente", re.fecSalReserva);

                cmd.Parameters.AddWithValue("@idEstRserva", re.idEstRserva.idEstRserva);
                cmd.Parameters.AddWithValue("@idCliente", re.idCliente.idCliente);
                cmd.Parameters.AddWithValue("@idHabitacion", re.idHabitacion.idHabitacion);

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

       
        public Reserva BuscarReserva(int idReserva)
        {
            SqlCommand cmd = null;
            Reserva re = new Reserva();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idRserva", idReserva);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Habitacion ha = new Habitacion();
                    Cliente cl = new Cliente();
                    EstadoReserva er = new EstadoReserva();

                    re.idRserva = Convert.ToInt32(dr["idRserva"]);
                    re.fecIngReseva = dr["fecIngReseva"].ToString();
                    re.numPerReserva = Convert.ToInt32(dr["numPerReserva"].ToString());
                    re.fecSalReserva = dr["fecSalReserva"].ToString();

                    ha.idHabitacion = Convert.ToInt32(dr["idHabitacion"]);
                    re.idHabitacion = ha;
                    cl.idCliente = Convert.ToInt32(dr["idCliente"]);
                    re.idCliente = cl;

                    er.idEstRserva = Convert.ToInt32(dr["idEstRserva"]);
                    re.idEstRserva = er;
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
            return re;
        }

        public Boolean EliminarReserva(Reserva c)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarReserva", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idRserva", c.idRserva);

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
