using AccesoDatos.DatUsuario;
using entUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class logUsuario
    {
        #region singleton
        private static readonly logUsuario _instancia = new logUsuario();
        public static logUsuario Instancia
        {
            get { return logUsuario._instancia; }
        }
        #endregion singleton

        #region metodos

        public Usuario VerificarAcceso(String Usuario, String Password)
        {
            try
            {
                //if (DateTime.Now.Hour > 23)
                //{
                //    throw new ApplicationException("No puede ingresar a esta hora");
                //}
                Usuario u = datUsuario.Instancia.VerificarAcceso(Usuario, Password);
                if (u != null)
                {
                    if (!u.estadoUsuario)
                    {
                        throw new ApplicationException("Usuario ha sido dado de baja");
                    }

                }
                else
                {
                    throw new ApplicationException("Usuario o Password no Valido");
                }
                return u;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        #endregion metodos
    }
}

