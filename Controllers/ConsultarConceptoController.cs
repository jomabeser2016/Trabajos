using RecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

using SAT.Libreria.JavaScript;
using SAT.Libreria.Model;
using SAT.Libreria.Web;
using SAT.SAF.App.Servicios.Bus;
using SAT.SAF.Model.GA.RecursosHumanos.DatosSolicitudDescansoFisico;
using SAT.SAF.Model.GA.RecursosHumanos.SolicitudDescansoFisico;
using System.IO;
using SAT.SAF.Model.GA.RecursosHumanos.Consultas;
using SAT.Libreria.Log;
using RecursosHumanos.App_Start;
using SAT.Libreria.Seguridad.Encriptacion;


namespace RecursosHumanos.Controllers
{
    public class ConsultarConceptoController : Controller
    {
        // GET: ConsultarConcepto
        [Authorize]
        public ActionResult ConsultarConcepto()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDatosSolicitudConcepto()
        {
            JQGrid objGrid = new JQGrid();
            try
            {
                objGrid = new RecursosHumanosServicio().DevolverDatosSolicitudConcepto();
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(objGrid, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult EncriptarDatosEditar(string dato, string tipo)
        {
            List<String> lst = new List<String>();
            string cadena = "";
            JsonResult obj = new JsonResult();

            try
            {
                cadena = AES.Encriptar(dato);
                lst.Add(cadena);

                cadena = AES.Encriptar(tipo);
                lst.Add(cadena);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult EncriptarDatosNuevo(string dato)
        {
            List<String> lst = new List<String>();
            string cadena = "";
            JsonResult obj = new JsonResult();

            try
            {
                cadena = AES.Encriptar(dato);
                lst.Add(cadena);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }
    }
}