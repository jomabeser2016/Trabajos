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
using SAT.Libreria.Log;
using System.Web.Security;
using System.Configuration;
using System.Text;
using SAT.Libreria.Seguridad.Encriptacion;
using SAT.SAF.Model.SE.Seguridad;
using RecursosHumanos.App_Start;

namespace RecursosHumanos.Controllers
{
    public class ConsultaSolicitudController : Controller
    {
        // GET: ConsultaSolicitud
        [Authorize]
        public ActionResult ConsultaSolicitud(string idOpcion)
        {

            string codEmpl = Session["codEmp"].ToString();

            //var llave = AES.ObtenerKey(ConfigurationManager.AppSettings.Get("AplicativoLogin"));
            //byte[] keyByte = UTF8Encoding.UTF8.GetBytes(llave);

            //codEmpl = AES.Desencriptar(codEmpl, keyByte).Trim();

            String CODI_EMPL_PER;

            CODI_EMPL_PER = codEmpl;

            ConsultaSolicitud obj = new ConsultaSolicitud();            

            try
            {
                if (String.IsNullOrEmpty(idOpcion))                
                    idOpcion = Session["idOpcion"].ToString();                                                                                                            
                else
                    Session["idOpcion"] = idOpcion;

                ViewBag.idOpcion = idOpcion;

                List<DatosTrabajador> lst = DevolverDatosTrabajador(CODI_EMPL_PER);
                obj.sCodTrabajador = lst[0].CODI_EMPL_PER;
                obj.sTrabajador = lst[0].NOMB_CORT_PER;
                obj.sCodPlanilla = lst[0].TIPO_PLAN_TPL;
                obj.sPlanillaT = lst[0].DESC_TIPO_TPL;
                obj.sCodCargo = lst[0].CODI_NIVE_TNI;
                obj.sCargoT = lst[0].NOMB_PUES_TNI;
                obj.sCodDepencia = lst[0].CODI_DEPE_TDE;
                obj.sDepenciaT = lst[0].DESC_LARG_TDE;
                obj.sModalidad = lst[0].ABRE_LABO_PER;
                obj.sFehIng = lst[0].FECH_INGR_PER.ToShortDateString();
                obj.slPeriodoT = (SelectList)JQuery.SelectListAddItem(DevolverSolicitudDescansoFisico(lst[0].TIPO_PLAN_TPL, lst[0].CODI_EMPL_PER), "Valor", "Texto", "", "Seleccione un periodo...");
                obj.slEstado = (SelectList)JQuery.SelectListAddItem(DevolverDatosFiltroEstadoSolicitud(), "Valor", "Texto", "", "Seleccione un estado...");

            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return RedirectToAction("Error400", "Error");
            }

            
            return View(obj);
        }

        /*
        [HttpPost]
        [Authorize]
        public FilePathResult obtenerRutaJson(string nombreControl)
        {
            string strFile = "";
            try
            {
                switch (nombreControl)
                {
                    case "slPeriodo":
                        strFile = "/Json/Periodo.json";
                        break;
                    case "slPersonal":
                        strFile = "/Json/Personal.json";
                        break;
                }
            }
            catch (Exception ex)
            { }

            return File(strFile, "text/x-json");
        }
        */

        private List<DatosTrabajador> DevolverDatosTrabajador(String CODI_EMPL_PER)
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
                /*
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
                */
                throw;
            }
            return lst;
        }
                
        private List<ItemSelectList> DevolverSolicitudDescansoFisico(String TIPO_PLAN_TPL, String CODI_EMPL_PER)
        {
            List<ItemSelectList> lstItemSelectList = new List<ItemSelectList>();            
            ItemSelectList itemSelectList = new ItemSelectList();

            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();

            try
            {
                obj.TIPO_PLAN_TPL = TIPO_PLAN_TPL;
                obj.CODI_EMPL_PER = CODI_EMPL_PER;
                lst = new RecursosHumanosServicio().DevolverSolicitudDescansoFisico(obj);

                foreach (SolicitudDescansoFisico item in lst)
                {
                    //ItemSelectList _Obj = new ItemSelectList();
                    itemSelectList = new ItemSelectList();
                    itemSelectList.Valor = item.ANIO_GENE_DFI;
                    itemSelectList.Texto = item.PERI_GENE_DFI;
                    lstItemSelectList.Add(itemSelectList);
                }
            }
            catch (Exception ex)
            {
                /*
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
                */
                throw;
            }

            return lstItemSelectList;
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult ObtenerDiasporAnio(String TIPO_PLAN_TPL, String CODI_EMPL_PER, String PERI_GENE_DFI)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            List<SolicitudDescansoFisico> lst = new List<SolicitudDescansoFisico>();
            
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

            return Json(lst);
        }

        [HttpPost]
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult DevolverDetalleSolicitudDescansoFisico(string dato)
        {
            FiltroSolicitud obj = new FiltroSolicitud();
            JavaScriptSerializer jss = new JavaScriptSerializer();
            List<FiltroSolicitud> lstFiltroSolicitud;
            JQGrid objGrid = new JQGrid();
            try
            {

                lstFiltroSolicitud = jss.Deserialize<List<FiltroSolicitud>>(dato);
                obj = lstFiltroSolicitud[0];

                objGrid = new RecursosHumanosServicio().DevolverDetalleSolicitudDescansoFisico(obj);
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
        public List<ItemSelectList> DevolverDatosFiltroEstadoSolicitud()
        {
            List<ItemSelectList> lst = new List<ItemSelectList>();

            try
            {
                lst = new RecursosHumanosServicio().DevolverDatosFiltroEstadoSolicitud();
            }
            catch (Exception ex)
            {
                Registro.RegistrarLog(NivelLog.Error, "Error", ex);
                return null;
            }

            return lst;
        }

        [HttpPost]
        [Authorize]        
        [ValidateJsonAntiForgeryToken]
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
        [Authorize]
        [ValidateJsonAntiForgeryToken]
        public JsonResult ListarAccesoOpcionMenu(string idOpcion)
        {            

            List<Control> lstConntrol = new List<Control>();
            FiltroUsuario fil = new FiltroUsuario();

            try
            {
                fil.SISTEMAS_SIS = ConfigurationManager.AppSettings.Get("SistemaCodigo").ToString();
                fil.CODI_MOD = ConfigurationManager.AppSettings.Get("ModuloCodigo").ToString();
                fil.CODI_OPCI_OPC = idOpcion;
                fil.USUARIO_USU = Session["UserName"].ToString();

                lstConntrol = new SeguridadServicio().ListarOpcionMenu(fil);
            }
            catch
            {
                return null;
            }

            return Json(lstConntrol, JsonRequestBehavior.AllowGet);
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