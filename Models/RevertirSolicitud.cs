using System;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class RevertirSolicitud
    {
        [DisplayName("Dependencia")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slDependencia { get; set; }

        [DisplayName("Planilla")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slPlanilla { get; set; }

        [DisplayName("Cargo")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slCargo { get; set; }

        [DisplayName("Periodo Generación")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slPeriodo { get; set; }

        [DisplayName("Periodo Solicitud")]
        [Required(ErrorMessage = "Seleccione un criterio de búsqueda")]
        public SelectList slMes { get; set; }

        [DisplayName("Trabajador")]
        public SelectList slTrabajador { get; set; }
    }
}