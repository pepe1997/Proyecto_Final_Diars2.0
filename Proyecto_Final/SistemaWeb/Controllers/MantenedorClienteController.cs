using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using entCliente;
using LogicaNegocio;
using entTipoCliente;
using entEstadoCliente;
using entCiudad;

namespace SistemaWeb.Controllers
{
    public class MantenedorClienteController : Controller
    {
        // GET: MantenedorCliente
        public ActionResult ListarCliente()
        {
            List<Cliente> listaCliente = logCliente.Instancia.ListarCliente();
            ViewBag.lista = listaCliente;
            return View(listaCliente);
        }

        [HttpGet]
        public ActionResult InsertarCliente()
        {

            List<TipoCliente> listaTipoCliente = logTipoCliente.Instancia.ListarTipoCliente();
            var lsTipoCliente = new SelectList(listaTipoCliente, "idTipCliente", "desTipCliente");
            ViewBag.listaTipoCliente = lsTipoCliente;

            List<Ciudad> listaCiudad = logCiudad.Instancia.ListarCiudad();
            var lsCiudad = new SelectList(listaCiudad, "idCiudad", "desCiudad");
            ViewBag.listaCiudad = lsCiudad;


            return View();
        }
        [HttpPost]
        public ActionResult InsertarCliente(Cliente Cli, FormCollection frm)
        {
            try
            {

                Cli.idTipoCliente = new TipoCliente();
                Cli.idTipoCliente.idTipCliente = Convert.ToInt32(frm["cboTipoCliente"]);

                Cli.idCiudad = new Ciudad();
                Cli.idCiudad.idCiudad = Convert.ToInt32(frm["cboCiudad"]);

                Boolean inserta = logCliente.Instancia.InsertarCliente(Cli);
                if (inserta)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("InsertarCliente", new { mesjExceptio = ex.Message });
            }
        }

        [HttpGet]
        public ActionResult EditarCliente(int idCliente)
        {

            Cliente Cli = new Cliente();
            Cli = logCliente.Instancia.BuscarCliente(idCliente);

            List<Ciudad> listaCiudad = logCiudad.Instancia.ListarCiudad();
            var lsCiudad = new SelectList(listaCiudad, "idCiudad", "desCiudad", Cli.idCiudad.idCiudad);
            ViewBag.listaCiudad = lsCiudad;
            List<TipoCliente> listaTipoCliente = logTipoCliente.Instancia.ListarTipoCliente();
            var lsTipoCliente = new SelectList(listaTipoCliente, "idTipCliente",
           "desTipCliente", Cli.idTipoCliente.idTipCliente);
            ViewBag.listaTipoCliente = lsTipoCliente;

            return View(Cli);
        }
        [HttpPost]
        public ActionResult EditarCliente(Cliente Cli, FormCollection frm)
        {
            Cli.idCiudad = new Ciudad();
            Cli.idCiudad.idCiudad = Convert.ToInt32(frm["cboCiudad"]);

            Cli.idTipoCliente = new TipoCliente();
            Cli.idTipoCliente.idTipCliente = Convert.ToInt32(frm["cboTipoCliente"]);

            try
            {
                Boolean edita = logCliente.Instancia.EditaCliente(Cli);
                if (edita)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EditarCliente", new { mesjExceptio = ex.Message });
            }

        }

        public ActionResult EliminarCliente(int idCliente)
        {

            Cliente Cli = new Cliente();
            Cli = logCliente.Instancia.BuscarCliente(idCliente);
            return View(Cli);
        }
        [HttpPost]
        public ActionResult EliminarCliente(Cliente Cli)
        {

            try
            {
                Boolean elimina = logCliente.Instancia.EliminarCliente(Cli);
                if (elimina)
                {
                    return RedirectToAction("ListarCliente");
                }
                else
                {
                    return View(Cli);
                }
            }

            catch (ApplicationException ex)
            {
                return RedirectToAction("EliminarCliente", new { mesjExceptio = ex.Message });
            }

        }
    }
}