$(document).ready(function () {
    var selectedRows = {};
    var token = $('input[name="__RequestVerificationToken"]').val();
    init();

    function init() {
        cargarGrilla();
        CargarTrabajador();
        cargarControles();
    }

    function cargarGrilla() {

        $("#grdSolicitud").jqGrid({
            url: requrlMostrarSolicitud,
            datatype: 'json',
            async: false,
            mtype: 'POST',
            loadBeforeSend: function (jqXHR) {
                jqXHR.setRequestHeader("__RequestVerificationToken", token);
            },
            postData: {
                //token: function () { return FuncionJS.GetToken(); },
                dato: function () {

                    var slTrabajadorB = $('#slTrabajador');
                    var valorSel = slTrabajadorB.val();
                    var value = $('#slPlanilla').val();
                    var slPeriodoT = $('#slPeriodoT');
                    var slPeriodoTSel = slPeriodoT.val();
                    var sCodCargo = $('#slCargo').val();
                    var sCodDepend = $('#slDependencia').val();
                    var sCodEstado = $('#slEstado').val();
                    var datojson = JSON.stringify([{
                        "TIPO_PLAN_TPL": value,
                        "CODI_EMPL_PER": valorSel,
                        "PERI_GENE_DFI": slPeriodoTSel,
                        "CODI_NIVE_TNI": sCodCargo,
                        "CODI_DEPE_TDE": sCodDepend,
                        "CODI_EST_DDF": sCodEstado
                    }]);
                    return datojson;
                }
            },
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: true
            },
            colNames: [
                'Cod. Trabajador',
                'Nombre trabajador',
                'Planilla',
                'Cod. Planilla',
                'Cargo',
                'Estado Solicitud',
                'Cod. Estado',
                'Fecha Inicio',
                'Fecha Fin',
                'Periodo Generación',
                'Periodo Solicitud',
                'Días',
                'Observaciones',
                'Motivo',
                'Cadena',
                'Secuencia'
            ],
            colModel: [
                { name: 'CODI_EMPL_PER', index: 'CODI_EMPL_PER', hidden: false, align: "center", width: 120, sortable: false },
                { name: 'NOMB_EMPL_PER', index: 'NOMB_EMPL_PER', hidden: false, align: "center", width: 220, sortable: false },
                { name: 'DESC_PLAN_TPL', index: 'DESC_PLAN_TPL', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'TIPO_PLAN_TPL', index: 'TIPO_PLAN_TPL', hidden: true, align: "center", width: 100, sortable: false },
                { name: 'NOMB_PUES_TNI', index: 'NOMB_PUES_TNI', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'NOMB_EST_DDF', index: 'NOMB_EST_DDF', hidden: false, align: "center", width: 130, sortable: false },
                { name: 'CODI_EST_DDF', index: 'CODI_EST_DDF', hidden: true, align: "center", width: 150, sortable: false },
                { name: 'INIC_PROG_DDF', index: 'INIC_PROG_DDF', hidden: false, align: "center", width: 90, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }},
                { name: 'FINA_PROG_DDF', index: 'FINA_PROG_DDF', hidden: false, align: "center", width: 90, sortable: false , formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' }},                
                { name: 'ANIO_GENE_DFI', index: 'ANIO_GENE_DFI', hidden: false, align: "center", width: 125, sortable: false },
                { name: 'PERI_GENE_DDF', index: 'PERI_GENE_DDF', hidden: false, align: "center", width: 120, sortable: false },
                { name: 'DIAS_PROG_DDF', index: 'DIAS_PROG_DDF', hidden: false, align: "center", width: 60, sortable: false },
                { name: 'OBSE_REGI_DDF', index: 'OBSE_REGI_DDF', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'OBSE_ACTU_DDF', index: 'OBSE_ACTU_DDF', hidden: false, align: "center", width: 150, sortable: false },
                { key: true, name: 'CADE_SOLI_DFI', index: 'CADE_SOLI_DFI', hidden: true, align: "center", width: 150, sortable: false },
                { name: 'SECU_PROG_DDF', index: 'SECU_PROG_DDF', hidden: true, align: "center", width: 150, sortable: false }
            ],
            rowNum: 10, rowList: [10, 15, 20,25], pager: '#pageSolicitud', sortname: 'CODI_EMPL_PER', viewrecords: true, sortorder: "asc",
            height: 285,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Solicitudes",
            rownumbers: true,
            reloadAfterEdit: false,
            reloadAfterSubmit: false,
            autoencode: false,
            loadonce: true,
            multiselect: true, onSelectRow: function (rowId, status, e) {
                if (status === false) {
                    delete selectedRows[rowId];
                } else {
                    selectedRows[rowId] = status;
                }
            },
            onSelectAll: function (rowIds, status) {
                if (status === true) {
                    for (var i = 0; i < rowIds.length; i++) {
                        selectedRows[rowIds[i]] = true;
                    }
                } else {
                }

            },
            beforeRequest: function () {
                $("#btnBuscar").addClass("disabled");
                $("#modalLoading").modal("show");
            },
            gridComplete: function () {
                var nroreg = $("#grdSolicitud").getGridParam("records");
                if (nroreg <= 0) {                    
                    //alert("No se encontraron registros.");
                } else {

                    //LOGICA PARA PODER PINTAR LAS FILAS SEGUN UNA CONDICION
                    var rows = $("#grdSolicitud").getDataIDs();
                    for (var i = 0; i < rows.length; i++) {

                        var psiCosEst = $("#grdSolicitud").getCell(rows[i], "CODI_EST_DDF");
                        var psiCadLin = $("#grdSolicitud").getCell(rows[i], "CADE_SOLI_DFI");

                        if (psiCosEst == "1")
                        {
                            $("#grdSolicitud").jqGrid('setRowData', rows[i], false, { color: 'black', weightfont: 'bold', background: 'red' });
                            //$("#jqg_grdSolicitud_" + psiCadLin).attr("disabled", true);
                        }
                        if (psiCosEst == "2") {
                            $("#grdSolicitud").jqGrid('setRowData', rows[i], false, { color: 'black', weightfont: 'bold', background: 'orange' });
                        }
                        if (psiCosEst == "4") {
                            $("#grdSolicitud").jqGrid('setRowData', rows[i], false, { color: 'black', weightfont: 'bold', background: 'green' });
                            //$("#jqg_grdSolicitud_" + psiCadLin).attr("disabled", true);
                        }
                        if (psiCosEst == "5") {
                            $("#grdSolicitud").jqGrid('setRowData', rows[i], false, { color: 'black', weightfont: 'bold', background: 'yellow' });
                            //$("#jqg_grdSolicitud_" + psiCadLin).attr("disabled", true);
                        }

                    }

                    //LOGICA PARA PODER SETEAR NUEVAMENTE LOS VALORES AL PAGINAR
                    for (var rowId in selectedRows) {
                        $("#grdPersonas").setSelection(rowId, true);
                    }

                }
                //Para cerrar el modal que indica el estado de proceso ejecutandose
                $("#modalLoading").modal("hide");
                $("#btnBuscar").removeClass("disabled");
            },
            loadError: function (xhr, st, err) {                
                window.location.href = requrlError;

            }
        }).navGrid('#pageSolicitud', { refresh: false, search: false, add: false, edit: false, del: false });
    }

    $("#slDependencia").change(function () { CargarTrabajador(); });

    $("#slPlanilla").change(function () { CargarTrabajador(); });

    $("#slCargo").change(function () { CargarTrabajador(); });

    $("#slEstado").change(function () {
        var slPlanilla = $('#slPlanilla').val();
        var slDependencia = $('#slDependencia').val();
        var slCargo = $('#slCargo').val();
        var sCodEstado = $('#slEstado').val();

        var dato = JSON.stringify([{
            TIPO_PLAN_TPL: slPlanilla,
            CODI_DEPE_TDE: slDependencia,
            CODI_NIVE_TNI: slCargo,
            CODI_EST_DDF: sCodEstado
        }]);

        $.ajax({
            url: requrlPeriodo,
            dataType: "json",
            async: false,
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            data: "{'dato':'" + dato + "'}",
            success: function (response) {
                var slPeriodo = $("#slPeriodo");
                slPeriodo.empty();
                $.each(response, function (index, item) {
                    slPeriodo.append("<option value=" + response[index].Valor +
                            ">" + response[index].Texto + "</option>");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = requrlError;
            }
        });
        CargarTrabajador();
    });

    $("#slPeriodo").change(function () {
        var slPlanilla = $('#slPlanilla').val();
        var slDependencia = $('#slDependencia').val();
        var slCargo = $('#slCargo').val();
        var slPeriodo = $('#slPeriodo').val();
        var sCodEstado = $('#slEstado').val();

        var dato = JSON.stringify([{
            TIPO_PLAN_TPL: slPlanilla,
            CODI_DEPE_TDE: slDependencia,
            CODI_NIVE_TNI: slCargo,
            PERI_GENE_DFI: slPeriodo,
            CODI_EST_DDF: sCodEstado
        }]);

        $.ajax({
            url: requrlDatosPeriodo,
            dataType: "json",
            async: false,
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            data: "{'dato':'" + dato + "'}",
            success: function (response) {
                var slMes = $("#slMes");
                slMes.empty();
                $.each(response, function (index, item) {
                    slMes.append("<option value=" + response[index].Valor +
                            ">" + response[index].Texto + "</option>");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = requrlError;
            }
        });
        CargarTrabajador()
    });

    $("#slMes").change(function () {
        CargarTrabajador();
    });

    $('#btnBuscar').click(function () {
        //$("#grdSolicitud").jqGrid("clearGridData", true).trigger("reloadGrid");
        $("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
        //cargarGrilla();
    });

    $('#btnNuevo').click(function () {
        var url = requrlMantenimiento;
        location.href = url;
    });

    $('#btnEditar').click(function () {
        var selRowIds = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selarrrow');
        if (selRowIds.length == 1) {
            var selRowId = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selrow')
            var celValue = jQuery('#grdSolicitud').jqGrid('getCell', selRowId, 'CODI_EST_DDF');

            if (celValue == "1" || celValue == "2" || celValue == "4" || celValue == "5" || celValue == "6") {
                alert("Solo se puede Editar solicitudes en estado SOLICITADA");
                return;
            }
            for (var rowId in selectedRows) {
                var FehIni = $("#grdSolicitud").jqGrid('getCell', rowId, 'INIC_PROG_DDF');
                var FehFin = $("#grdSolicitud").jqGrid('getCell', rowId, 'FINA_PROG_DDF');
                FehIni = FehIni.substr(0, 10);                
                FehIni = FehIni.split('/')
                FehFin = FehFin.substr(0, 10);
                FehFin = FehFin.split('/')
                //INIC_PROG_DDF: new Date(FehIni.substr(6, 4), FehIni.substr(3, 2) , FehIni.substr(0, 2)),
                var jsdato = JSON.stringify({
                    TIPO_PLAN_TPL: $("#grdSolicitud").jqGrid('getCell', rowId, 'TIPO_PLAN_TPL'),
                    CODI_EMPL_PER: $("#grdSolicitud").jqGrid('getCell', rowId, 'CODI_EMPL_PER'),
                    SECU_PROG_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'SECU_PROG_DDF'),
                    ANIO_GENE_DFI: $("#grdSolicitud").jqGrid('getCell', rowId, 'ANIO_GENE_DFI'),
                    INIC_PROG_DDF: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                    FINA_PROG_DDF: new Date(FehFin[2], FehFin[1] - 1, FehFin[0]),
                    OBSE_REGI_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'OBSE_REGI_DDF'),
                    OBSE_ACTU_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'OBSE_ACTU_DDF'),
                    CODI_EST_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'CODI_EST_DDF')
                });
            }
            var url = requrlEditar + '?dato=' + jsdato + '&tip=1';
            location.href = url;
        }
        else { alert('Seleccione solo una fila para editar');}
    });

    $('#btnEliminar').click(function () {
        var selRowIds = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selarrrow');
        if (selRowIds.length > 0) {
            if (confirmar('la Anulación de Solicitud'))
            {

                var selRowId = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selrow')
                var celValue = jQuery('#grdSolicitud').jqGrid('getCell', selRowId, 'CODI_EST_DDF');

                if (celValue == "1" || celValue == "2" || celValue == "4" || celValue == "5" || celValue == "6") {
                    alert("Solo se puede Anular solicitudes en estado SOLICITADA");
                    return;
                }
                $("#btnEliminar").addClass("disabled");
                $("#modalLoading").modal("show");
                var sJson = '';
                for (var rowId in selectedRows) {
                    var FehIni = $("#grdSolicitud").jqGrid('getCell', rowId, 'INIC_PROG_DDF');
                    var FehFin = $("#grdSolicitud").jqGrid('getCell', rowId, 'FINA_PROG_DDF');
                    FehIni = FehIni.substr(0, 10);
                    FehIni = FehIni.split('/')
                    FehFin = FehFin.substr(0, 10);
                    FehFin = FehFin.split('/')
                    var dFehAct = new Date();
                    //INIC_PROG_DDF: new Date(FehIni.substr(6, 4), FehIni.substr(3, 2) , FehIni.substr(0, 2)),
                    var dato = JSON.stringify({
                        TIPO_PLAN_TPL: $("#grdSolicitud").jqGrid('getCell', rowId, 'TIPO_PLAN_TPL'),
                        CODI_EMPL_PER: $("#grdSolicitud").jqGrid('getCell', rowId, 'CODI_EMPL_PER'),
                        SECU_PROG_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'SECU_PROG_DDF'),
                        ANIO_GENE_DFI: $("#grdSolicitud").jqGrid('getCell', rowId, 'ANIO_GENE_DFI'),
                        INIC_PROG_DDF: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                        FINA_PROG_DDF: new Date(FehFin[2], FehFin[1] - 1, FehFin[0]),
                        DIAS_PROG_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'DIAS_PROG_DDF'),
                        OBSE_REGI_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'OBSE_REGI_DDF'),
                        OBSE_ACTU_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'OBSE_ACTU_DDF'),
                        CODI_EST_DDF: '1',
                        FECH_ACTU_DDF: dFehAct,
                        USER_ACTU_DDF: $("#grdSolicitud").jqGrid('getCell', rowId, 'CODI_EMPL_PER')
                    });

                    if (sJson == '') { sJson = '[' + dato + ','; }
                    else { sJson = sJson + dato + ','; }

                }
                sJson = sJson.substring(0, sJson.length - 1);
                sJson = sJson + ']';

                $.ajax({
                    url: requrlDatos,
                    dataType: "json",
                    async: false,
                    type: 'POST',
                    contentType: 'application/json;charset=utf-8',
                    data: "{'lst':'" + sJson + "'}",
                    success: function (response) {
                        alert('Datos Guardados');
                        $("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
                        //cargarGrilla();
                        $("#btnEliminar").removeClass("disabled");
                        $("#modalLoading").modal("hide");
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert("Error");
                    }
                });
            }
        }
        else {
            alert('Seleccione al menos una solicitud para anular');
        }
    });

    function cargarControles() {

        $("#btnNuevo").addClass("disabled");
        $("#btnEditar").addClass("disabled");
        $("#btnEliminar").addClass("disabled");

        var idOpcion = $("#hdOpcion").val();

        $.ajax({
            url: requrlListarAccesoOpcionMenu,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'idOpcion':'" + idOpcion + "'}",
            dataType: "json",
            success: function (response) {
                $.each(response, function (index, item) {
                    $("#" + response[index].Nombre).removeClass("disabled");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error");
            }
        });

    }

    function confirmar(sMensaje) {
        if (confirm("¿Seguro que desea continuar con " + sMensaje + "?")) {
            return true;
        }
        else {
            return false;
        }
    }

    $('.nav-tabs a[href="#tab_2"]').click(function () {
        var selRowIds = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selarrrow');

        if (selRowIds.length > 1)
        {
            alert('Seleccione solo una solicitud para ver el Historial');
            return;
        }

        if (selRowIds.length  == 0) {
            alert('Seleccione una solicitud para ver el Historial');
            return;
        }

        if (selRowIds.length == 1) {
            for (var rowId in selectedRows)
            {                
                var TIPO_PLAN_TPL = $("#grdSolicitud").jqGrid('getCell', rowId, 'TIPO_PLAN_TPL');
                var CODI_EMPL_PER = $("#grdSolicitud").jqGrid('getCell', rowId, 'CODI_EMPL_PER');
                var ANIO_GENE_DFI = $("#grdSolicitud").jqGrid('getCell', rowId, 'ANIO_GENE_DFI');
                var SECU_PROG_DDF = $("#grdSolicitud").jqGrid('getCell', rowId, 'SECU_PROG_DDF');
                $("#grdHistorial").jqGrid("clearGridData", true).trigger("reloadGrid");
                cargarGrillaHistorial(TIPO_PLAN_TPL, CODI_EMPL_PER, ANIO_GENE_DFI, SECU_PROG_DDF)
            }

        }
    });

    function cargarGrillaHistorial(sTipPla, sCodEmp, sPerGen, sNumFila) {

        $("#grdHistorial").jqGrid({
            url: requrlHistorial,
            datatype: 'json',
            async: false,
            mtype: 'POST',
            postData: {
                token: function () { return FuncionJS.GetToken(); },
                dato: function () {
                    var datojson = JSON.stringify([{
                        "TIPO_PLAN_TPL": sTipPla,
                        "CODI_EMPL_PER": sCodEmp,
                        "PERI_GENE_DFI": sPerGen,
                        "NUM_FILA": sNumFila
                    }]);
                    return datojson;
                }
            },
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: true
            },
            colNames: [
                'Cod. Planilla',
                'Cod. Trabajador',
                'Nombre trabajador',
                'Estado Solicitud',
                'Periodo Generación',
                'Periodo Solicitud',
                'Secuencia',
                'Fecha Inicio',
                'Fecha Fin',
                'Días',
                'Fecha Registro',             
                'Usuario Registro',
                'Observación',
                'Fecha Actualiz.',
                'Usuario Actualiz.',
                'Motivo'
            ],
            colModel: [                
                { name: 'TIPO_PLAN_TPL', index: 'TIPO_PLAN_TPL', hidden: true, align: "center", width: 100, sortable: false },
                { key: true, name: 'CODI_EMPL_PER', index: 'CODI_EMPL_PER', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'NOMB_EMPL_PER', index: 'NOMB_EMPL_PER', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'NOMB_EST_DDF', index: 'NOMB_EST_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'ANIO_GENE_DFI', index: 'ANIO_GENE_DFI', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'PERI_GENE_DDF', index: 'PERI_GENE_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'SECU_PROG_DDF', index: 'SECU_PROG_DDF', hidden: true, align: "center", width: 100, sortable: false },
                { name: 'INIC_PROG_DDF', index: 'INIC_PROG_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'FINA_PROG_DDF', index: 'FINA_PROG_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'DIAS_PROG_DDF', index: 'DIAS_PROG_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'FECH_REGI_DDF', index: 'FECH_REGI_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'USER_REGI_DDF', index: 'USER_REGI_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'OBSE_REGI_DDF', index: 'OBSE_REGI_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'FECH_ACTU_DDF', index: 'FECH_ACTU_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'USER_ACTU_DDF', index: 'USER_ACTU_DDF', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'OBSE_ACTU_DDF', index: 'OBSE_ACTU_DDF', hidden: false, align: "center", width: 100, sortable: false }
            ],
            rowNum: 10, rowList: [10, 15, 20, 25], pager: '#pageHistorial', sortname: 'CODI_EMPL_PER', viewrecords: true, sortorder: "asc",
            height: 285,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Historial",
            rownumbers: true,
            reloadAfterEdit: false,
            reloadAfterSubmit: false,
            autoencode: false,
            loadonce: false,
            loadError: function (xhr, st, err) {
                window.location.href = requrlError;

            }
        }).navGrid('#pageHistorial', { refresh: false, search: false, add: false, edit: false, del: false });
    }

    function CargarTrabajador() {
        var slPlanilla = $('#slPlanilla').val();
        var slDependencia = $('#slDependencia').val();
        var slCargo = $('#slCargo').val();
        var slPeriodo = $('#slPeriodo').val();
        var slMes = $('#slMes').val();
        var sCodEstado = $('#slEstado').val();

        var dato = JSON.stringify([{
            TIPO_PLAN_TPL: slPlanilla,
            CODI_DEPE_TDE: slDependencia,
            CODI_NIVE_TNI: slCargo,
            PERI_GENE_DFI: slPeriodo,
            PERI_GENE_DDF: slMes,
            CODI_EST_DDF: sCodEstado
        }]);
        $("#slTrabajador").empty();
        $.ajax({
            headers: {
                "__RequestVerificationToken": token
            },
            url: requrlMostrarTrabajador,
            dataType: "json",
            async: false,
            type: 'POST',
            contentType: 'application/json;charset=utf-8',
            data: "{'dato':'" + dato + "'}",
            success: function (response) {
                var slTrabajador = $("#slTrabajador");
                slTrabajador.empty();
                $.each(response, function (index, item) {
                    slTrabajador.append("<option value=" + response[index].Valor +
                            ">" + response[index].Texto + "</option>");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error");
            }
        });
    }
});