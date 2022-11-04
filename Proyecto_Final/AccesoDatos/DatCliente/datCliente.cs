using AccesoDatos.BaseDatos;
using entCiudad;
using entCliente;
using entEstadoCliente;
using entTipoCliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.DaoEntidades
{
    public class datCliente
    {
        #region singleton
        private static readonly datCliente UnicaInstancia = new datCliente();
        public static datCliente Instancia
        {
            get
            {
                return datCliente.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<Cliente> ListarCliente()
        {
            SqlCommand cmd = null;
            List<Cliente> lista = new List<Cliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Cliente Cli = new Cliente();
                    Ciudad ci = new Ciudad();
                    TipoCliente tc = new TipoCliente();
                    EstadoCliente ec = new EstadoCliente();

                    Cli.idCliente = Convert.ToInt32(dr["idCliente"]);
                    Cli.nombCliente = dr["nombCliente"].ToString();
                    Cli.apelCliente = dr["apelCliente"].ToString();
                    Cli.direcCliente = dr["direcCliente"].ToString();
                    Cli.celular = dr["celular"].ToString();
                    Cli.dni = dr["dni"].ToString();
                    Cli.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                    /*Cli.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    Cli.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    Cli.idCiudad = Convert.ToInt32(dr["idCiudad"]);*/

                    tc.desTipCliente = dr["desTipCliente"].ToString();
                    Cli.idTipoCliente = tc;
                    ec.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    ec.desEstCliente = dr["desEstCliente"].ToString();
                    Cli.idEstCliente = ec;
                    ci.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    ci.desCiudad = dr["desCiudad"].ToString();
                    Cli.idCiudad = ci;
                    lista.Add(Cli);
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
        public Boolean InsertarCliente(Cliente Cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nombCliente", Cli.nombCliente);
                cmd.Parameters.AddWithValue("@apelCliente", Cli.apelCliente);
                cmd.Parameters.AddWithValue("@direcCliente", Cli.direcCliente);
                cmd.Parameters.AddWithValue("@celular", Cli.celular);
                cmd.Parameters.AddWithValue("@dni", Cli.dni);
                cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
                /*cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", Cli.idEstCliente);
                cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad);*/

                cmd.Parameters.AddWithValue("@idTipCliente", Cli.idTipoCliente.idTipCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", Cli.idEstCliente.idEstCliente);
                cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad.idCiudad);


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
        public Boolean EditarCliente(Cliente Cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", Cli.idCliente);
                cmd.Parameters.AddWithValue("@nombCliente", Cli.nombCliente);
                cmd.Parameters.AddWithValue("@apelCliente", Cli.apelCliente);
                cmd.Parameters.AddWithValue("@direcCliente", Cli.direcCliente);
                cmd.Parameters.AddWithValue("@celular", Cli.celular);
                cmd.Parameters.AddWithValue("@dni", Cli.dni);
                cmd.Parameters.AddWithValue("@fecRegCliente", Cli.fecRegCliente);
                /*cmd.Parameters.AddWithValue("@idTipoCliente", Cli.idTipoCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", Cli.idEstCliente);
                cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad);*/


                cmd.Parameters.AddWithValue("@idTipCliente", Cli.idTipoCliente.idTipCliente);
                cmd.Parameters.AddWithValue("@idEstCliente", Cli.idEstCliente.idEstCliente);
                cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad.idCiudad);

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

        //deshabilitaCliente

        /*public Boolean DeshabilitarCliente(entCliente.Cliente Cli)
        {
            SqlCommand cmd = null;
            Boolean delete = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spDeshabilitarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", Cli.idCliente);
                cn.Open();
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    delete = true;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally { cmd.Connection.Close(); }
            return delete;
        }*/
        public Cliente BuscarCliente(int idCliente)
        {
            SqlCommand cmd = null;
            Cliente c = new Cliente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Ciudad ci = new Ciudad();
                    TipoCliente tc = new TipoCliente();
                    EstadoCliente ec = new EstadoCliente();

                    c.idCliente = Convert.ToInt32(dr["idCliente"]);
                    c.nombCliente = dr["nombCliente"].ToString();
                    c.apelCliente = dr["apelCliente"].ToString();
                    c.direcCliente = dr["direcCliente"].ToString();
                    c.celular = dr["celular"].ToString();
                    c.dni = dr["dni"].ToString();
                    c.fecRegCliente = Convert.ToDateTime(dr["fecRegCliente"]);
                    /*c.idTipoCliente = Convert.ToInt32(dr["idTipoCliente"]);
                    c.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    c.idCiudad = Convert.ToInt32(dr["idCiudad"]);*/

                    tc.idTipCliente = Convert.ToInt32(dr["idTipCliente"]);
                    c.idTipoCliente = tc;
                    ec.idEstCliente = Convert.ToInt32(dr["idEstCliente"]);
                    c.idEstCliente = ec;

                    ci.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    c.idCiudad = ci;
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

        public Boolean EliminarCliente(Cliente c)
        {
            SqlCommand cmd = null;
            Boolean elimina = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEliminarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCliente", c.idCliente);

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
