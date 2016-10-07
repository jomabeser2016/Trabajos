using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RecursosHumanos.Controllers
{
    public class EstructuraController : Controller
    {
        // GET: Estructura
        public ActionResult _Cabecera()
        {
            RecursosHumanos.Models.Usuario usuario = new RecursosHumanos.Models.Usuario();

            string clientMachineName;
            clientMachineName = (Dns.GetHostEntry(Request.ServerVariables["remote_host"]).HostName);

            usuario.Terminal = clientMachineName.ToUpper();

            return PartialView("Parciales/_Cabecera", usuario);
        }

        public ActionResult _SideBarIzquierdo()
        {
            return PartialView("Parciales/_SideBarIzquierdo");
        }

        public ActionResult _PiePagina()
        {
            return PartialView("Parciales/_PiePagina");
        }

        public ActionResult _SideBarDerecho()
        {
            return PartialView("Parciales/_SideBarDerecho");
        } 
    }
}