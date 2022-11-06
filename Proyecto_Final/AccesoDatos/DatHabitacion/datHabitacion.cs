using AccesoDatos.BaseDatos;
using entEstadoHabitacion;
using entHabitacion;
using entTipoHabitacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DaoEntidades
{
    public class datHabitacion
    {
        #region singleton
        private static readonly datHabitacion UnicaInstancia = new datHabitacion();
        public static datHabitacion Instancia
        {
            get
            {
                return datHabitacion.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<Habitacion> Listarhabitacion()
        {
            SqlCommand cmd = null;
            List<Habitacion> lista = new List<Habitacion>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Habitacion hab = new Habitacion();
                    TipoHabitacion ti = new TipoHabitacion();
                    EstadoHabitacion es = new EstadoHabitacion();

                    hab.idHabitacion = Convert.ToInt32(dr["idHabitacion"]);
                    hab.numHabitacion = Convert.ToInt32(dr["numHabitacion"]);
                    hab.numPisoHabitacion = Convert.ToInt32(dr["numPisoHabitacion"]);

                    ti.nombTipoHabitacion = dr["nombTipoHabitacion"].ToString();
                    hab.idTipoHabitacion = ti;
                    
                    es.idEstHabitacion = Convert.ToInt32(dr["idEstHabitacion"]);
                    es.desEsTHabitacion = dr["desEsTHabitacion"].ToString();
                    hab.idEstHabitacion = es;

                    lista.Add(hab);
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
        public Boolean InsertarHabitacion(Habitacion hab)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@numHabitacion", hab.numHabitacion);
                cmd.Parameters.AddWithValue("@numPisoHabitacion", hab.numPisoHabitacion);
                cmd.Parameters.AddWithValue("@idTipoHabitacion", hab.idTipoHabitacion.idTipoHabitacion);
                cmd.Parameters.AddWithValue("@idEstHabitacion", hab.idEstHabitacion.idEstHabitacion);



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
        public Boolean EditarHabitacion(Habitacion hab)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHabitacion", hab.idHabitacion);
                cmd.Parameters.AddWithValue("@numHabitacion", hab.numHabitacion);
                cmd.Parameters.AddWithValue("@numPisoHabitacion", hab.numPisoHabitacion);
                cmd.Parameters.AddWithValue("@idTipoHabitacion", hab.idTipoHabitacion.idTipoHabitacion);
                cmd.Parameters.AddWithValue("@idEstHabitacion", hab.idEstHabitacion.idEstHabitacion);

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


        public Habitacion BuscarHabitacion(int idHabitacion)
        {
            SqlCommand cmd = null;
            Habitacion c = new Habitacion();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idHabitacion", idHabitacion);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    TipoHabitacion tc = new TipoHabitacion();
                    EstadoHabitacion ec = new EstadoHabitacion();

                    c.idHabitacion = Convert.ToInt32(dr["idHabitacion"]);
                    c.numHabitacion = Convert.ToInt32(dr["numHabitacion"]);
                    c.numPisoHabitacion = Convert.ToInt32(dr["numPisoHabitacion"]);


                    tc.idTipoHabitacion = Convert.ToInt32(dr["idTipoHabitacion"]);
                    c.idTipoHabitacion = tc;
                    ec.idEstHabitacion = Convert.ToInt32(dr["idEstHabitacion"]);
                    c.idEstHabitacion = ec;
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

        public Boolean CambiarEstDadoHabitacion(Habitacion c)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spCambiarEstadoHabitacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idHabitacion", c.idHabitacion);

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
