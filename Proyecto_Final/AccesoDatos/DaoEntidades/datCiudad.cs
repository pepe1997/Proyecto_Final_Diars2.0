using AccesoDatos.BaseDatos;
using entCiudad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.DaoEntidades
{
    public class datCiudad
    {
        #region singleton
        private static readonly datCiudad UnicaInstancia = new datCiudad();
        public static datCiudad Instancia
        {
            get
            {
                return datCiudad.UnicaInstancia;
            }
        }
        #endregion singleton

        #region metodos
        public List<Ciudad> ListarCiudad()
        {
            SqlCommand cmd = null;
            List<Ciudad> lista = new List<Ciudad>();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spListaCiudad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Ciudad tc = new Ciudad();

                    tc.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    tc.desCiudad = dr["desCiudad"].ToString();
                    tc.estCiudad = Convert.ToBoolean(dr["estCiudad"]);
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
        public Boolean InsertarCiudad(Ciudad Cli)
        {
            SqlCommand cmd = null;
            Boolean inserta = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spInsertarCiudad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@desCiudad", Cli.desCiudad);
                cmd.Parameters.AddWithValue("@estCiudad", Cli.estCiudad);



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
        public Boolean EditarCiudad(Ciudad Cli)
        {
            SqlCommand cmd = null;
            Boolean edita = false;
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar();
                cmd = new SqlCommand("spEditaCiudad", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCiudad", Cli.idCiudad);
                cmd.Parameters.AddWithValue("@desCiudad", Cli.desCiudad);
                cmd.Parameters.AddWithValue("@estCiudad", Cli.estCiudad);

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


        public Ciudad BuscarCiudad(int idCiudad)
        {
            SqlCommand cmd = null;
            Ciudad c = new Ciudad();
            try
            {
                SqlConnection cn = Conexion.Instancia.Conectar(); //singleton
                cmd = new SqlCommand("spBuscarCiudad", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@idCiudad", idCiudad);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    c.idCiudad = Convert.ToInt32(dr["idCiudad"]);
                    c.desCiudad = dr["desCiudad"].ToString();
                    c.estCiudad = Convert.ToBoolean(dr["estCiudad"]);

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
