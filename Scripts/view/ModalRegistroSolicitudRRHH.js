$(document).ready(function () {

    $("#sFehIni").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });
    $("#sFehFin").inputmask("dd/mm/yyyy", { "placeholder": "dd/mm/yyyy" });

    $("#btnAceptar").click(function () {
        if ($("#frmModalNuevaSolicitud").valid()) {
            var sdFehIni = $('#sFehIni').val();
            var sdFehFin = $('#sFehFin').val();
            var sdFehIniG = $("#lsFehIniGoc").html();
            var sdFehFinG = $("#lsFehFinGoc").html();
            var sObserva = $('#sObserv').val();

            //var dFehIni = new Date(sdFehIni);
            //var dFehFin = new Date(sdFehFin);

            var myIDs = jQuery("#grdSolicitud").jqGrid('getDataIDs');
            var id = myIDs.length + 1;

            //if (ValidaFormatoFecha(sdFehIni) == false) {
            //    alert('Formato incorrecto - Fecha Inicio');
            //    return;
            //}
            //if (ValidaFormatoFecha(sdFehFin) == false) {
            //    alert('Formato incorrecto - Fecha Fin');
            //    return;
            //}
            //if (ValidaFechaExiste(sdFehIni) == false) {
            //    alert('Fecha Inicio ingresada no existe ');
            //    return;
            //}
            //if (ValidaFechaExiste(sdFehFin) == false) {
            //    alert('Fecha Inicio ingresada no existe ')
            //    return;
            //}

            //if (ValidarFechaGoce(sdFehIni, sdFehIniG, sdFehFinG) == false) {
            //    alert('Fecha Inicio fuera de rango de goce de Vacaciones')
            //    return;
            //}

            //if (ValidarFechaGoce(sdFehFin, sdFehIniG, sdFehFinG) == false) {
            //    alert('Fecha Fin fuera de rango de goce de Vacaciones')
            //    return;
            //}

            //var FehIni = sdFehIni.split('/');
            //var FehFin = sdFehFin.split('/');

            //var iDias = (new Date(FehFin[2], FehFin[1] - 1, FehFin[0])) - (new Date(FehIni[2], FehIni[1] - 1, FehIni[0]));
            //var iDif = (((iDias / 1000) / 60) / 60) / 24;

            //var iDpProgramar = parseInt($("#lsDpProgramar").html(), 10);
            //alert(iDpProgramar);
            //if (iDif < 7 && iDpProgramar > 7) {
            //    alert('No puede programar menos de 7 días calendarios');
            //    return;
            //}

            for (var i = 0; i < myIDs.length; i++) {
                var rowData = $("#grdSolicitud").jqGrid('getRowData', myIDs[i]);
                var gFehIni = rowData.INIC_PROG_DDF;
                var gFehFin = rowData.FINA_PROG_DDF;

                if (ValidarCruceFecha(sdFehIni, gFehIni, gFehFin) == true) {
                    alert('Fecha Inicio  pertenece a otro rango de fecha ya registrada');
                    return;
                }

            };

            for (var i = 0; i < myIDs.length; i++) {
                var rowData = $("#grdSolicitud").jqGrid('getRowData', myIDs[i]);
                var gFehIni = rowData.INIC_PROG_DDF;
                var gFehFin = rowData.FINA_PROG_DDF;
                alert("gFehIni : " + gFehIni);
                alert("gFehFin : " + gFehFin);
                alert("entro2");
                if (ValidarCruceFecha(sdFehFin, gFehFin, gFehFin) == true) {
                    alert('Fecha Fin pertenece a otro rango de fecha ya registrada');
                    return;
                }
            };


            

            var FehIni = sdFehIni.split('/');
            var FehFin = sdFehFin.split('/');

            var value = document.getElementById('sCodPlanilla').value;
            var codtrab = document.getElementById('sCodTrabajador').value;

            var slPeriodoT = $('#slPeriodo');
            var slPeriodoTSel = slPeriodoT.val();

            var dato = JSON.stringify({
                TIPO_PLAN_TPL: value,
                CODI_EMPL_PER: codtrab,
                ANIO_GENE_DFI: parseInt(slPeriodoTSel),
                FECHA_INI: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                FECHA_FIN: new Date(FehFin[2], FehFin[1] - 1, FehFin[0])
            });

            var sJson = '[' + dato + ']';

            var iCodError = "";
            var sMensaje = "";

            $.ajax({
                url: requrlValidaFechas,
                type: 'POST',
                async: false,
                contentType: 'application/json;charset=utf-8',
                data: "{'dato':'" + sJson + "'}",
                dataType: "json",
                success: function (response) {
                    //id = id + 1;
                    $.each(response, function (index, item) {
                        iCodError = response[index].RESULTADO_CONS
                        sMensaje = response[index].MENSAJE_CONS
                    })
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert("error");
                }
            });

            if (iCodError == "1") {
                alert(sMensaje);
                return;
            }

            //if (ValidarFechaMenor(sdFehIni, sdFehFin)) {
           
                $.ajax({
                    url: requrlCalcularDias,
                    type: 'POST',
                    contentType: 'application/json;charset=utf-8',
                    data: "{'id':'" + id + "','FehIni':'" + sdFehIni + "','FehFin':'" + sdFehFin + "','Observa': '" + sObserva + "'}",
                    dataType: "json",
                    success: function (response) {                        
                        $.each(response, function (index) {
                            $("#grdSolicitud").addRowData(id, response[index]);
                        })
                        $("#modalnuevasolicitud").modal("hide");
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert("error");
                    }
                });
            //}
            //else {
            //    alert('La Fecha Inicio es mayor que la Fecha Final.')
            //}
        }
    });

    function ValidaFechaExiste(fecha) {
        var fechaf = fecha.split("/");
        var day = fechaf[0];
        var month = fechaf[1];
        var year = fechaf[2];
        var date = new Date(year, month, '0');
        if ((day - 0) > (date.getDate() - 0)) {
            return false;
        }
        return true;
    }

    function ValidarFechaMenor(sFehIni, sFehFin) {
        var x = new Date();
        var y = new Date();
        var sFIni = sFehIni.split("/");
        var sFFin = sFehFin.split("/");
        x.setFullYear(sFIni[2], sFIni[1] - 1, sFIni[0]);
        y.setFullYear(sFFin[2], sFFin[1] - 1, sFFin[0]);

        if (x > y)
            return false;
        else
            return true;
    }

    function ValidaFormatoFecha(campo) {
        var RegExPattern = /^\d{1,2}\/\d{1,2}\/\d{2,4}$/;
        if ((campo.match(RegExPattern)) && (campo != '')) {
            return true;
        } else {
            return false;
        }
    }


    function ValidarFechaGoce(sFehVal, sFehIni, sFehFin) {
        var x = new Date();
        var y = new Date();
        var z = new Date();
        var sFIni = sFehIni.split("/");
        var sFFin = sFehFin.split("/");
        var sFFVl = sFehVal.split("/");

        x.setFullYear(sFIni[2], sFIni[1] - 1, sFIni[0]);
        y.setFullYear(sFFin[2], sFFin[1] - 1, sFFin[0]);
        z.setFullYear(sFFVl[2], sFFVl[1] - 1, sFFVl[0]);

        if (z >= x && z <= y)
            return true;
        else
            return false;
    }

    function ValidarCruceFecha(sFehVal, sFehIni, sFehFin) {
        var x = new Date();
        var y = new Date();
        var z = new Date();
        var sFIni = sFehIni.split("/");
        var sFFin = sFehFin.split("/");
        var sFFVl = sFehVal.split("/");

        x.setFullYear(sFIni[2], sFIni[1] - 1, sFIni[0]);
        y.setFullYear(sFFin[2], sFFin[1] - 1, sFFin[0]);
        z.setFullYear(sFFVl[2], sFFVl[1] - 1, sFFVl[0]);

        if (z >= x && z <= y)
            return true;
        else
            return false;
    }

    //$(function () {
    //    $('.datepicker').datepicker({
    //        autoclose: true,
    //        format: "dd/mm/yyyy",
    //        language: 'es',
    //        container: '#modalSolicitud'
    //    }); 
    //});
});