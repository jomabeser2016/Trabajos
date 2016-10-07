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
using System.Text.RegularExpressions;
using SAT.Libreria.Seguridad.Encriptacion;


namespace RecursosHumanos.Controllers
{
    public class RegistroConceptoController : Controller
    {
        // GET: RegistroConcepto
        public ActionResult RegistroConcepto(string sTip,string sDato)
        {
            RegistroConcepto obj = new RegistroConcepto();
            List<ListaConceptoSolicitud> lst = new List<ListaConceptoSolicitud>();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            try
            {
                sTip = AES.Desencriptar(sTip);
                if (sTip == "1")
                {
                    sDato = AES.Desencriptar(sDato);
                    lst = jss.Deserialize<List<ListaConceptoSolicitud>>(sDato);
                    obj.sCodConcepto = lst[0].CODI_PARAM_DFI;
                    obj.sTipoConcepto = lst[0].TIPO_PARAM_DFI.ToString();
                    obj.sConcepto = lst[0].NOM_PARAM_DFI;
                    obj.sQueryConcepto = lst[0].QRY_PARAM_DFI;
                    obj.sMensajeConcepto = lst[0].MSJ_PARAM_DFI;
                    obj.sEstado = lst[0].ESTA_PARAM_DFI.ToString();
                    obj.sUsuRegistro = lst[0].LOGI_REG_PARAM_DFI;
                    obj.sUsuActualizar = lst[0].LOGI_ACT_PARAM_DFI;
                    obj.sFehRegistro = lst[0].FECH_REG_PARAM_DFI.ToShortDateString();
                    obj.sFehActualizar = lst[0].FECH_ACT_PARAM_DFI.ToShortDateString();
                    obj.sAccion = sTip;
                    ViewBag.isChecked = Convert.ToBoolean(Convert.ToInt32(obj.sEstado));                    
                }
                else
                { ViewBag.isChecked = true; }
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }
            return View(obj);
        }

        [HttpPost]
        public JsonResult RegistrarConceptoSolicitud(string lsConcepto)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<ConceptoSolicitud> lstConceptoSolicitud = new List<ConceptoSolicitud>();
            ConceptoSolicitud objConceptoSolicitud = new ConceptoSolicitud();
            int iResult = 0;
            try
            {
                lstConceptoSolicitud = jss.Deserialize<List<ConceptoSolicitud>>(lsConcepto);
                objConceptoSolicitud = lstConceptoSolicitud[0];
                new RecursosHumanosServicio().RegistrarConceptoSolicitud(objConceptoSolicitud);
                iResult = 1;
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(iResult);
        }

        [HttpPost]
        public JsonResult ActualizarConceptoSolicitud(string lsConcepto)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<ConceptoSolicitud> lstConceptoSolicitud = new List<ConceptoSolicitud>();
            ConceptoSolicitud objConceptoSolicitud = new ConceptoSolicitud();
            int iResult = 0;
            try
            {
                lstConceptoSolicitud = jss.Deserialize<List<ConceptoSolicitud>>(lsConcepto);
                objConceptoSolicitud = lstConceptoSolicitud[0];
                objConceptoSolicitud.QRY_PARAM_DFI = Regex.Replace(objConceptoSolicitud.QRY_PARAM_DFI, @"[\u0027]", "'");//objConceptoSolicitud.QRY_PARAM_DFI.Replace("\u0027", "'"); 
                new RecursosHumanosServicio().ActualizarConceptoSolicitud(objConceptoSolicitud);
                iResult = 1;
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(iResult);
        }
    }
}