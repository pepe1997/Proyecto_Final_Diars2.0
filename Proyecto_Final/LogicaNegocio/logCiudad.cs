using AccesoDatos.DaoEntidades;
using entCiudad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logCiudad
    {
        #region singleton
        private static readonly logCiudad UnicaInstancia = new logCiudad();
        public static logCiudad Instancia
        {
            get
            {
                return logCiudad.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<Ciudad> ListarCiudad()
        {
            try
            {
                List<Ciudad> lista = datCiudad.Instancia.ListarCiudad();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarCiudad(Ciudad Ser)
        {
            try
            {
                return datCiudad.Instancia.InsertarCiudad(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaServicio(Ciudad Ser)
        {
            try
            {
                return datCiudad.Instancia.EditarCiudad(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Ciudad BuscarCiudad(int idCiudad)
        {
            try
            {
                return datCiudad.Instancia.BuscarCiudad(idCiudad);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }

}

