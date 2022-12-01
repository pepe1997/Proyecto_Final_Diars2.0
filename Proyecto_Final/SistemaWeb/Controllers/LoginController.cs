using entUsuario;
using LogicaNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult VerificarAcceso()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerificarAcceso(FormCollection frm)
        {
            
            try
            {
                String txtUsuario = frm["txtUsuario"];
                String txtPassword = frm["txtPassword"];
                Usuario usu = logUsuario.Instancia.VerificarAcceso(txtUsuario, txtPassword);

                //almacenamos en la sesion el objeto usuario
                Session["usuario"] = usu;
                //nos lleva al menu principal de Intranet
                return RedirectToAction("ListarServicio", "MantenedorServicio");
                //if(usu.tipoUsuario.idTipoUsuario == 2)
                //{
                //    return RedirectToAction("ListarServicio", "MantenedorServicio");
                //}
                //else
                //{
                //    return RedirectToAction("Index", "Home");
                //}

            }
            catch (ApplicationException e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View();
            }
        }
    }
}