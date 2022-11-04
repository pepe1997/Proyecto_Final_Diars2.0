using AccesoDatos.BaseDatos;
using entEstadoCliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DaoEntidades
{
    public class datEstadoCliente
    {
        #region singleton
        private static readonly datEstadoCliente UnicaInstancia = new datEstadoCliente();
        public static datEstadoCliente Instancia
        {
            get
            {
                return datEstadoCliente.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<EstadoCliente> ListarEstadoCliente()
        {
            SqlCommand cmd = null;
            List<EstadoCliente> lista = new List<EstadoCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaEstCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    EstadoCliente tc = new EstadoCliente();

                    tc.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    tc.desEstCliente = dr["desEsTCliente"].ToString();
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
        /////////////////////////InsertaCliente
        public Boolean InsertarEstadoCliente(EstadoCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarEstCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desEsTCliente", Cli.desEstCliente);



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
        public Boolean EditarEstadoCliente(EstadoCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaEstadoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEstCliente", Cli.idEstCliente);
                cmd.Parameters.AddWithValue("@desEsTCliente", Cli.desEstCliente);

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


        public EstadoCliente BuscarEstadoCliente(int idEstCliente)
        {
            SqlCommand cmd = null;
            EstadoCliente c = new EstadoCliente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarEstadoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idEstCliente", idEstCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    c.desEstCliente = dr["desEsTCliente"].ToString();

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
