using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entReserva;
using AccesoDatos.DatReserva;

namespace LogicaNegocio
{
    public class logReserva
    {
        #region singleton
        private static readonly logReserva UnicaInstancia = new logReserva();
        public static logReserva Instancia
        {
            get
            {
                return logReserva.UnicaInstancia;
            }
        }

        #endregion singleton

        #region metodos
        public List<Reserva> ListarReserva()
        {
            try
            {
                List<Reserva> lista = datReserva.Instancia.ListarReserva();
                return lista;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public Boolean InsertarReserva(Reserva re)
        {
            try
            {
                return datReserva.Instancia.InsertarReserva(re);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Boolean EditaReserva(Reserva re)
        {
            try
            {
                return datReserva.Instancia.EditarReserva(re);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Reserva BuscarReserva(int idReserva)
        {
            try
            {
                return datReserva.Instancia.BuscarReserva(idReserva);
            }
            catch (Exception e)
            { throw e; }

        }
        public Boolean EliminarReserva(Reserva c)
        {
            try
            {
                return datReserva.Instancia.EliminarReserva(c);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion metodos
    }
}
