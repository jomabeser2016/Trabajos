using RecursosHumanos.Models.ValidacionCustom;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace RecursosHumanos.Models
{
    public class ModalSolicitud
    {
        [DisplayName("Token")]
        public string token { get; set; }

        [DisplayName("Fecha Inicio")]
        [Required(ErrorMessage = "Ingrese la Fecha Inicio")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public string sFehIni { get; set; }

        [DisplayName("Fecha Fin")]
        [Required(ErrorMessage = "Ingrese la Fecha Fin")]
        //[DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        //[DateGreaterThanAttribute("sFehIni", "La fecha final no puede ser menor a la fecha de inicio")]
        public string sFehFin { get; set; }

        [DisplayName("Observaciones")]        
        public string sObserv { get; set; }

        [DisplayName("Goce Inicio")]
        public String sFehIniGoc { get; set; }

        [DisplayName("Goce Fin")]
        public String sFehFinGoc { get; set; }
    }
}