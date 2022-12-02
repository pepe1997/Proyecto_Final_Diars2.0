using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entReserva;
using LogicaNegocio;

namespace SistemaWeb.Controllers
{
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult ListarReserva()
        {
           
            return View();
           
        }
    }
}