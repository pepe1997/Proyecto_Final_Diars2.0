using AccesoDatos.BaseDatos;
using entTipoCliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DaoEntidades
{
    public class datTipoCliente
    {
        #region singleton
        private static readonly datTipoCliente UnicaInstancia = new datTipoCliente();
        public static datTipoCliente Instancia
        {
            get
            {
                return datTipoCliente.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<TipoCliente> ListarTipoCliente()
        {
            SqlCommand cmd = null;
            List<TipoCliente> lista = new List<TipoCliente>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoCliente tc = new TipoCliente();

                    tc.idTipCliente = Convert.ToInt32(dr["idTipCliente"]);
                    tc.desTipCliente = dr["desTipCliente"].ToString();
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
        public Boolean InsertarTipoCliente(TipoCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desTipCliente", Cli.desTipCliente);



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
        public Boolean EditarTipoCliente(TipoCliente Cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idTipCliente", Cli.idTipCliente);
                cmd.Parameters.AddWithValue("@desTipCliente", Cli.desTipCliente);

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


        public TipoCliente BuscarTipoCliente(int idTipCliente)
        {
            SqlCommand cmd = null;
            TipoCliente c = new TipoCliente();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarTipoCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idTipCliente", idTipCliente);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idTipCliente = Convert.ToInt32(dr["idTipCliente"]);
                    c.desTipCliente = dr["desTipCliente"].ToString();

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
