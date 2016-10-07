using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.IO;

using SAT.Libreria.JavaScript;
using SAT.Libreria.Model;
using SAT.Libreria.Web;
using SAT.Libreria.Log;

using SAT.SAF.App.Servicios.Bus;
using SAT.SAF.Model.GA.RecursosHumanos.DatosSolicitudDescansoFisico;
using SAT.SAF.Model.GA.RecursosHumanos.SolicitudDescansoFisico;
using RecursosHumanos.Models;
using SAT.Libreria.Seguridad.Encriptacion;

namespace RecursosHumanos.Controllers
{
    public class EdicionSolicitudController : Controller
    {
        // GET: EdicionSolicitud
        public ActionResult EdicionSolicitud(string dato,string tip)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            EdicionSolicitud obj = new EdicionSolicitud();
            DetalleSolicitudDescansoFisico DetalleSolicitudDescansoFisico = new DetalleSolicitudDescansoFisico();
            List<SolicitudDescansoFisico> lstSolicitudDescansoFisico = new List<SolicitudDescansoFisico>();
            List<DatosTrabajador> lstDatosTrabajador = new List<DatosTrabajador>();

            try
            {
                dato = AES.Desencriptar(dato);
                tip = AES.Desencriptar(tip);
                DetalleSolicitudDescansoFisico = jss.Deserialize<DetalleSolicitudDescansoFisico>(dato);
                lstDatosTrabajador = DevolverDatosTrabajador(DetalleSolicitudDescansoFisico.CODI_EMPL_PER);
                obj.sTipoUrl = tip;
                obj.sCodTrabajador = lstDatosTrabajador[0].CODI_EMPL_PER;
                obj.sTrabajador = lstDatosTrabajador[0].NOMB_CORT_PER; ;
                obj.sDepencia = lstDatosTrabajador[0].DESC_LARG_TDE; ;
                obj.sCargo = lstDatosTrabajador[0].NOMB_PUES_TNI;
                obj.sCodPlanilla = lstDatosTrabajador[0].TIPO_PLAN_TPL;
                obj.sPlanilla = lstDatosTrabajador[0].DESC_TIPO_TPL;
                obj.sPeriodo = DetalleSolicitudDescansoFisico.ANIO_GENE_DFI;
                obj.iSecPrograma = DetalleSolicitudDescansoFisico.SECU_PROG_DDF;
                obj.sFehIni = DetalleSolicitudDescansoFisico.INIC_PROG_DDF.ToShortDateString();
                obj.sFehFin = DetalleSolicitudDescansoFisico.FINA_PROG_DDF.ToShortDateString();
                obj.sObserv = DetalleSolicitudDescansoFisico.OBSE_REGI_DDF;
                obj.sMotivo = DetalleSolicitudDescansoFisico.OBSE_ACTU_DDF;

                lstSolicitudDescansoFisico = ObtenerDiasporAnio(lstDatosTrabajador[0].TIPO_PLAN_TPL, lstDatosTrabajador[0].CODI_EMPL_PER, DetalleSolicitudDescansoFisico.ANIO_GENE_DFI);
                obj.sDpProgramar = lstSolicitudDescansoFisico[0].DIAS_XPROG_DFI.ToString();
                
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }            
            return View(obj);
        }

        [HttpPost]
        public List<DatosTrabajador> DevolverDatosTrabajador(String CODI_EMPL_PER)
        {
            DatosTrabajador obj = new DatosTrabajador();
            List<DatosTrabajador> lst = new List<DatosTrabajador>();

            try
            {
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverDatosTrabajador(obj);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        [HttpPost]
        public JsonResult ActualizarDetalleDescansoFisico(string lst)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<DetalleSolicitudDescansoFisico> lstDetalleSolicitudDescansoFisico;
            int iResult = 0;
            try
            {
                lstDetalleSolicitudDescansoFisico = jss.Deserialize<List<DetalleSolicitudDescansoFisico>>(lst);                
                new RecursosHumanosServicio().ActualizarDetalleDescansoFisico(lstDetalleSolicitudDescansoFisico);
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
        public List<SolicitudDescansoFisico> ObtenerDiasporAnio(String TIPO_PLAN_TPL, String CODI_EMPL_PER, String PERI_GENE_DFI)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            MantenimientoSolicitud _obj = new MantenimientoSolicitud();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                obj.PERI_GENE_DFI = PERI_GENE_DFI;
                lst = new RecursosHumanosServicio().ObtenerDiasporAnio(obj);

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        [HttpPost]
        public JsonResult ValidarFechasSolicitudDescansoFisico(string dato)
        {
            List<ValidaFecha> objValidaFecha = new List<ValidaFecha>();
            List<ValidaFecha> lst = new List<ValidaFecha>();
            ValidaFecha obj = new ValidaFecha();
            JavaScriptSerializer jss = new JavaScriptSerializer();

            try
            {
                objValidaFecha = jss.Deserialize<List<ValidaFecha>>(dato);
                obj = objValidaFecha[0];
                //obj.FECHA_INI = Convert.ToDateTime(obj.FECHA_INI);
                //obj.FECHA_FIN = Convert.ToDateTime(obj.FECHA_FIN);
                lst = new RecursosHumanosServicio().ValidarFechasSolicitudDescansoFisico(obj);
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }
            return Json(lst);
        }
    }
}