using AccesoDatos.DatServicio;
using entServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logServicio
    {
        #region singleton
        private static readonly logServicio UnicaInstancia = new logServicio();
        public static logServicio Instancia
        {
            get
            {
                return logServicio.UnicaInstancia;
            }
        }

        #endregion singleton

        #region metodos
        public List<Servicio> ListarServicio()
        {
            try
            {
                List<Servicio> lista = datServicio.Instancia.ListarServicio();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarServicio(Servicio Ser)
        {
            try
            {
                return datServicio.Instancia.InsertarServicio(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaServicio(Servicio Ser)
        {
            try
            {
                return datServicio.Instancia.EditarServicio(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Servicio BuscarServicio(int idServicio)
        {
            try
            {
                return datServicio.Instancia.BuscarServicio(idServicio);
            }
            catch (Exception e)
            { throw e; }

        }
        public Boolean EliminarServicio(Servicio Ser)
        {
            try
            {
                return datServicio.Instancia.EliminarServicio(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }

}

