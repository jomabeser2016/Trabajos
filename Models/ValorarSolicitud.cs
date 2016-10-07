using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class ValorarSolicitud
    {
        [DisplayName("Dependencia")]
        public SelectList slDependencia { get; set; }

        [DisplayName("Planilla")]
        public SelectList slPlanilla { get; set; }

        [DisplayName("Cargo")]
        public SelectList slCargo { get; set; }

        [DisplayName("Periodo Generación")]
        public SelectList slPeriodo { get; set; }

        [DisplayName("Periodo Solicitud")]
        public SelectList slMes { get; set; }

        [DisplayName("Trabajador")]
        public SelectList slTrabajador { get; set; }
    }
}