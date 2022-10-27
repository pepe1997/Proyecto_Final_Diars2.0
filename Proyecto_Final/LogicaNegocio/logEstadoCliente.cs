using AccesoDatos.DaoEntidades;
using entEstadoCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logEstadoCliente
    {
        #region singleton
        private static readonly logEstadoCliente UnicaInstancia = new logEstadoCliente();
        public static logEstadoCliente Instancia
        {
            get
            {
                return logEstadoCliente.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<EstadoCliente> ListarEstCliente()
        {
            try
            {
                List<EstadoCliente> lista = datEstadoCliente.Instancia.ListarEstadoCliente();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarEstCliente(EstadoCliente Ser)
        {
            try
            {
                return datEstadoCliente.Instancia.InsertarEstadoCliente(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaEstadoCliente(EstadoCliente Ser)
        {
            try
            {
                return datEstadoCliente.Instancia.EditarEstadoCliente(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EstadoCliente BuscarEstadoCliente(int idEstCliente)
        {
            try
            {
                return datEstadoCliente.Instancia.BuscarEstadoCliente(idEstCliente);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }

}

