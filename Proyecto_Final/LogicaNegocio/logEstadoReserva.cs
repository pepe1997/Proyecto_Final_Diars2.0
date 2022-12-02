using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entEstadoReserva;
using AccesoDatos.DatReserva;

namespace LogicaNegocio
{
    public class logEstadoReserva
    {
        #region singleton
        private static readonly logEstadoReserva UnicaInstancia = new logEstadoReserva();
        public static logEstadoReserva Instancia
        {
            get
            {
                return logEstadoReserva.UnicaInstancia;
            }
        }

        #endregion singleton
        #region metodos
        public List<EstadoReserva> ListarEstReserva()
        {
            try
            {
                List<EstadoReserva> lista = datEstadoReserva.Instancia.ListarEstadoReserva();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarEstReserva(EstadoReserva Ser)
        {
            try
            {
                return datEstadoReserva.Instancia.InsertarEstadoReserva(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaEstadoReserva(EstadoReserva Ser)
        {
            try
            {
                return datEstadoReserva.Instancia.EditarEstadoReserva(Ser);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public EstadoReserva BuscarEstadoReserva(int idEstReserva)
        {
            try
            {
                return datEstadoReserva.Instancia.BuscarEstadoReserva(idEstReserva);
            }
            catch (Exception e)
            { throw e; }

        }
        #endregion metodos
    }
}
