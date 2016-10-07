using SAT.Libreria.Model;
using SAT.Libreria.Seguridad.Encriptacion;
using SAT.SAF.App.Servicios.Bus;
using SAT.SAF.Model.SE.Seguridad;
using RecursosHumanos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SAT.SAF.Model.GA.RecursosHumanos.SolicitudDescansoFisico;

namespace RecursosHumanos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            FormsIdentity formIdentity = System.Web.HttpContext.Current.User.Identity as FormsIdentity;
            string usuario = formIdentity.Name.ToString();
            //string codEmpl = System.Web.HttpContext.Current.Request.Cookies["slnRecursosHumanos"]["codEmpl"].ToString();

            var llave = AES.ObtenerKey(ConfigurationManager.AppSettings.Get("AplicativoLogin"));
            byte[] keyByte = UTF8Encoding.UTF8.GetBytes(llave);

            usuario = AES.Desencriptar(usuario, keyByte).Trim();
            //codEmpl = AES.Desencriptar(codEmpl, keyByte).Trim();                       
            
            //ViewData["ListaMenu"] = LlenarMenu();           

            if (Session["UserName"] == null)
            {
                List<DatosTrabajadorLogin> lst = DevolverDatosTrabajadorLogin(usuario);
                Session["UserName"] = usuario;
                Session["Name"] = lst[0].NOMB_CORT_PER;
                Session["Nivel"] = lst[0].CODI_NIVE_TNI;
                Session["Gerencia"] = lst[0].DESC_LARG_TDE;
                Session["Dependencia"] = lst[0].CODI_DEPE_TDE;
                Session["Imagen"] = lst[0].IMAG_EMPL_PER;

                Session["codDep"] = lst[0].CODI_DEPE_TDE;
                Session["codNiv"] = lst[0].CODI_NIVE_TNI;
                Session["codEmp"] = lst[0].CODI_EMPL_PER; 

                /*
                HttpCookie ck = new HttpCookie("slnGerencia");
                ck["coddepe"] = lst[0].CODI_DEPE_TDE;
                ck["codnive"] = lst[0].CODI_NIVE_TNI;
                ck["codEmpl"] = lst[0].CODI_EMPL_PER; 
                ck.Expires = DateTime.Now.AddMinutes(30);
                Response.Cookies.Add(ck);
                */
            }

            if (Session["ListaMenuSesion"] == null)
            {
                Session["ListaMenuSesion"] = LlenarMenu(usuario);
            }

            return View();
        }

        private List<Menu> LlenarMenu(string usuario)
        {
            List<Menu> menuLista = new List<Menu>();
            //List<Menu> menuListaResultado = new List<Menu>();            
            UrlHelper urlHelper = new UrlHelper(ControllerContext.RequestContext);
            //Menu objMenu;
            SeguridadServicio obj = new SeguridadServicio();
            FiltroUsuario objFiltroUsuario = new FiltroUsuario();

            try
            {

                objFiltroUsuario.USUARIO_USU = usuario;
                objFiltroUsuario.SISTEMAS_SIS = ConfigurationManager.AppSettings.Get("SistemaCodigo").ToString();
                objFiltroUsuario.CODI_MOD = ConfigurationManager.AppSettings.Get("ModuloCodigo").ToString();

                menuLista = new SeguridadServicio().ListarMenuPorUsuario(objFiltroUsuario);

                foreach (Menu item in menuLista)
                {                    
                    if (item.MenuPadre == "0")
                    {
                        item.Link = string.Empty;                        
                    }
                    else
                    {
                        item.Link = urlHelper.Action(item.Action, item.Controler, new { idOpcion = item.Id });                        
                    }
                }

                /*
                foreach(Menu item in menuLista){
                    objMenu = new Menu();
                    objMenu.CodigoSistema = item.CodigoSistema;
                    objMenu.CodigoModulo = item.CodigoModulo;
                    objMenu.Id = item.Id;
                    objMenu.Nombre = item.Nombre;
                    if (item.MenuPadre == " ")
                    {
                        objMenu.Link = string.Empty;
                        objMenu.MenuPadre = "0";
                    }
                    else {
                        objMenu.Link = urlHelper.Action(item.Action, item.Controler);
                        objMenu.MenuPadre = item.MenuPadre;
                    }                    

                    menuListaResultado.Add(objMenu);
                    
                }
                */

                /*
                menuLista.Add(new Menu(1, "Vacaciones", string.Empty, 0));
                menuLista.Add(new Menu(2, "Concepto", urlHelper.Action("Concepto", "Concepto"), 1));
                menuLista.Add(new Menu(3, "Revertir Solicitud", urlHelper.Action("RevertirSolicitud", "RevertirSolicitud"), 1));
                menuLista.Add(new Menu(4, "Solicitud", urlHelper.Action("Solicitud", "Solicitud"), 1));
                menuLista.Add(new Menu(5, "Valorar Solicitud", urlHelper.Action("ValorarSolicitud", "ValorarSolicitud"), 1));
                menuLista.Add(new Menu(6, "Sub Opcion", "#", 5));
                menuLista.Add(new Menu(7, "Sub Sub Opcion", "#", 6));

                menuLista.Add(new Menu(8, "Vacaciones", string.Empty, 0));
                menuLista.Add(new Menu(9, "Sub Opcion", "#", 8));
                menuLista.Add(new Menu(10, "Sub Sub Opcion", "#", 9));
                */
                /*
                menuLista.Add(new Menu(6, "Artigos do Sr. Coelho", string.Empty, 0));
                menuLista.Add(new Menu(7, "Artigo 1", string.Empty, 6));
                menuLista.Add(new Menu(8, "Artigo 1.1", string.Empty, 7));
                menuLista.Add(new Menu(9, "Artigo 1.1.1", string.Empty, 8));
                menuLista.Add(new Menu(10, "Artigo 1.1.2", string.Empty, 8));

                menuLista.Add(new Menu(11, "Artigo 2", string.Empty, 6));
                menuLista.Add(new Menu(12, "Artigo 2.1", string.Empty, 11));
                menuLista.Add(new Menu(13, "Artigo 2.2", string.Empty, 11));
                menuLista.Add(new Menu(14, "Artigo 2.3", string.Empty, 11));
                menuLista.Add(new Menu(15, "Artigo 2.3.1", string.Empty, 14));
                */
            }
            catch
            {
                throw;
            }

            return menuLista;
            //return menuListaResultado;
        }

        private List<DatosTrabajadorLogin> DevolverDatosTrabajadorLogin(string USUARIO_USU)
        {
            List<DatosTrabajadorLogin> lst = new List<DatosTrabajadorLogin>();
            FiltroUsuario obj = new FiltroUsuario();
            try
            {
                obj.USUARIO_USU = USUARIO_USU;
                lst = new RecursosHumanosServicio().DevolverDatosTrabajadorLogin(obj);
            }
            catch (Exception ex)
            {
                
                throw;
            }

            return lst;
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            if (Request.Cookies["slnRecursosHumanos"] != null)
            {
                HttpCookie myCookie = new HttpCookie("slnRecursosHumanos");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            if (Request.Cookies["slnGerencia"] != null)
            {
                HttpCookie myCookie = new HttpCookie("slnGerencia");
                myCookie.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(myCookie);
            }
            return RedirectToAction("index", "Home");
        }
    }
}