using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecursosHumanos.Models;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.Helpers;
using RecursosHumanos.App_Start;
using System.Threading.Tasks;

namespace RecursosHumanos.Controllers
{
    public class ConceptoController : Controller
    {
        // GET: Concepto
        public ActionResult Concepto()
        {
            return View();
        }
    }
}