$(document).ready(function () {

    var selectedRows = {};
    var token = $('input[name="__RequestVerificationToken"]').val();

    $(".select2").select2();

    init();

    function init() {
        $('#sCodTrabajador').attr('aria-hidden', 'true').hide();
        $('#sCodPlanilla').attr('aria-hidden', 'true').hide();
        $('#sCodDepencia').attr('aria-hidden', 'true').hide();
        $('#sCodCargo').attr('aria-hidden', 'true').hide();        
        cargarGrilla();
        cargarControles();
    }

    /*
    function ShowModalAutenticacion() {
        var token = FuncionJS.GetToken();

        $("#modalSolicitud").load(requrlModalAutenticacion + '?token=' + token,
            function () {
                $("#modalSolicitud").modal("show");
            });
    }
    */

    function cargarControles() {

        $("#btnNuevo").addClass("disabled");
        $("#btnEditar").addClass("disabled");
        $("#btnEliminar").addClass("disabled");

        var idOpcion = $("#hdOpcion").val();

        $.ajax({
            headers: {
                "__RequestVerificationToken": token
            },
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
                    var valorSel = document.getElementById('sCodTrabajador').value;
                    var value = document.getElementById('sCodPlanilla').value;
                    var slPeriodoT = $('#slPeriodoT');
                    var slPeriodoTSel = slPeriodoT.val();
                    var sCodCargo = document.getElementById('sCodCargo').value;
                    var sCodDepend = document.getElementById('sCodDepencia').value;
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
                'Secuencia',
                'Fecha Registro'
            ],
            colModel: [
                { name: 'CODI_EMPL_PER', index: 'CODI_EMPL_PER', hidden: true, align: "center", width: 120, sortable: false },
                { name: 'NOMB_EMPL_PER', index: 'NOMB_EMPL_PER', hidden: true, align: "center", width: 220, sortable: false },
                { name: 'DESC_PLAN_TPL', index: 'DESC_PLAN_TPL', hidden: true, align: "center", width: 100, sortable: false },
                { name: 'TIPO_PLAN_TPL', index: 'TIPO_PLAN_TPL', hidden: true, align: "center", width: 100, sortable: false },
                { name: 'NOMB_PUES_TNI', index: 'NOMB_PUES_TNI', hidden: true, align: "center", width: 100, sortable: false },
                { name: 'NOMB_EST_DDF', index: 'NOMB_EST_DDF', hidden: false, align: "center", width: 130, sortable: false },
                { name: 'CODI_EST_DDF', index: 'CODI_EST_DDF', hidden: true, align: "center", width: 150, sortable: false },
                { name: 'INIC_PROG_DDF', index: 'INIC_PROG_DDF', hidden: false, align: "center", width: 90, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
                { name: 'FINA_PROG_DDF', index: 'FINA_PROG_DDF', hidden: false, align: "center", width: 90, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
                { name: 'ANIO_GENE_DFI', index: 'ANIO_GENE_DFI', hidden: false, align: "center", width: 125, sortable: false },
                { name: 'PERI_GENE_DDF', index: 'PERI_GENE_DDF', hidden: false, align: "center", width: 120, sortable: false },
                { name: 'DIAS_PROG_DDF', index: 'DIAS_PROG_DDF', hidden: false, align: "center", width: 60, sortable: false },
                { name: 'OBSE_REGI_DDF', index: 'OBSE_REGI_DDF', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'OBSE_ACTU_DDF', index: 'OBSE_ACTU_DDF', hidden: false, align: "center", width: 150, sortable: false },                
                { key: true, name: 'CADE_SOLI_DFI', index: 'CADE_SOLI_DFI', hidden: true, align: "center", width: 150, sortable: false },
                { name: 'SECU_PROG_DDF', index: 'SECU_PROG_DDF', hidden: true, align: "center", width: 150, sortable: false },
                { name: 'FECH_REGI_DDF', index: 'FECH_REGI_DDF', hidden: false, align: "center", width: 150, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
            ],
            rowNum: 10, rowList: [10, 15, 20, 25], pager: '#pageSolicitud', sortname: 'CODI_EMPL_PER', viewrecords: true, sortorder: "asc",
            height: 285,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Solicitudes",
            rownumbers: true,
            reloadAfterEdit: false,
            reloadAfterSubmit: false,
            autoencode: false,
            loadonce: false,
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
            loadError: function (xhr, st, err) {
                window.location.href = requrlError;
            }
        }).navGrid('#pageSolicitud', { refresh: false, search: false, add: false, edit: false, del: false });        
    }

    function updateDialog(action) {
        return {
            url: API_URL
            , closeAfterAdd: true
            , closeAfterEdit: true
            , afterShowForm: function (formId) { }
            , modal: true
            , onclickSubmit: function (params) {
                var list = $("#grdSolicitud");
                var selectedRow = list.getGridParam("selrow");
                rowData = list.getRowData(selectedRow);
                params.url += rowData.Id;
                params.mtype = action;
            }
            , width: "300"
        };
    }

    $('#btnNuevo').click(function () {
        //var slTrabajadorB = $('#sCodTrabajador');        
        var valorSel = document.getElementById('sCodTrabajador').value;

        $.ajax({
            async: false,
            type: "POST",
            headers: {
                "__RequestVerificationToken": token
            },
            url: requrlEncriptarDatosNuevo,
            data: "{'dato':'" + valorSel + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {                
                var json = "";                                
                for (var item in response) {

                    if (item == 0) {
                        json = response[item];
                    }                     
                }
                var url = requrlMantenimiento + '?CODI_EMPL_PER=' + encodeURIComponent(json);
                location.href = url;

            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = requrlError;
            }
        });

        
    });

    /*
    $(function () {
        $(".multiselect").multiselect();
    });
    */

    $("#slEstado").change(function () {
        //$("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
    })

    function pad(str, max) {
        str = str.toString();
        return str.length < max ? pad("0" + str, max) : str;
    }
    /*
    $("#slPeriodoT").change(function () {
        
    })
    */

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

            $.ajax({
                async: false,
                type: "POST",
                headers: {
                    "__RequestVerificationToken": token
                },
                url: requrlEncriptarDatosEditar,
                data: "{'dato':'" + jsdato + "','tipo':'2'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    //window.location.href = response[index].Url + response[index].Controlador + "/" + response[index].Action;                        
                    //window.location.href = requrlConsultaModulo + "?usuario=" + encodeURIComponent(usuario);
                    var json = "";
                    var tipo = "";
                    var i = 1;
                    for (var item in response) {

                        if (item == 0) {
                            json = response[item];
                        } else {
                            tipo = response[item];
                        }

                        i++;
                    }

                    var url = requrlEditar + '?dato=' + encodeURIComponent(json) + '&tip=' + encodeURIComponent(tipo);

                    window.location.href = url;
                    
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    window.location.href = requrlError;                    
                }
            });
            
        }
        else { alert('Seleccione solo una fila para editar'); }
    });

    $('#btnEliminar').click(function () {
        var selRowIds = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selarrrow');
        
        if (selRowIds.length > 0) {
            var selRowId = jQuery('#grdSolicitud').jqGrid('getGridParam', 'selrow')
            var celValue = jQuery('#grdSolicitud').jqGrid('getCell', selRowId, 'CODI_EST_DDF');

            if (celValue == "1" || celValue == "2" || celValue == "4" || celValue == "5" || celValue == "6")
            {
                alert("Solo se puede anular solicitudes en estado SOLICITADA");
                return;
            }
            if (confirmar('la Anulación de Solicitud'))
            {
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
                    headers: {
                        "__RequestVerificationToken": token
                    },                    
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
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        alert("Error");
                    }
                });
            }
        }
        else { alert('Seleccione al menos una solicitud para anular'); }
    });

    function confirmar(sMensaje) {
        if (confirm("¿Seguro que desea continuar con " + sMensaje + "?")) {
            return true;
        }
        else {
            return false;
        }
    }

    $("#btnBuscar").click(function () {
        Periodo();
        //cargarGrilla();
        $("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
    })

    function Periodo()
    {
        var valorSel = document.getElementById('sCodTrabajador').value;
        var value = document.getElementById('sCodPlanilla').value;
        var slPeriodoT = $('#slPeriodoT');
        var slPeriodoTSel = slPeriodoT.val();

        $("#lsFehIniGen").html("");
        $("#lsFehFinGen").html("");
        $("#lsFehIniGoc").html("");
        $("#lsFehFinGoc").html("");

        $("#lsDGozados").html("");
        $("#lsDProgram").html("");
        $("#lsDpProgramar").html("");
        $("#lsTotal").html("");

        $.ajax({
            headers: {
                "__RequestVerificationToken": token
            },
            url: requrlDatosPeriodo,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'TIPO_PLAN_TPL':'" + value + "','CODI_EMPL_PER':'" + valorSel + "','PERI_GENE_DFI':'" + slPeriodoTSel + "'}",
            dataType: "json",
            success: function (response) {
                $.each(response, function (index, item) {
                    var sFIG = new Date(parseInt(response[index].INIC_GENE_DFI.substring(6)))
                    var sFFG = new Date(parseInt(response[index].FINA_GENE_DFI.substring(6)))
                    var sFIGo = new Date(parseInt(response[index].INIC_GOCE_DFI.substring(6)))
                    var sFFGo = new Date(parseInt(response[index].FINA_GOCE_DFI.substring(6)))

                    $("#lsFehIniGen").html(pad(sFIG.getDate(), 2) + "/" + pad((sFIG.getMonth() + 1), 2) + "/" + sFIG.getFullYear())
                    $("#lsFehFinGen").html(pad(sFFG.getDate(), 2) + "/" + pad((sFFG.getMonth() + 1), 2) + "/" + sFFG.getFullYear())
                    $("#lsFehIniGoc").html(pad(sFIGo.getDate(), 2) + "/" + pad((sFIGo.getMonth() + 1), 2) + "/" + sFIGo.getFullYear())
                    $("#lsFehFinGoc").html(pad(sFFGo.getDate(), 2) + "/" + pad((sFFGo.getMonth() + 1), 2) + "/" + sFFGo.getFullYear())

                    $("#lsDGozados").html(response[index].DIAS_GOZA_DFI)
                    $("#lsDProgram").html(response[index].DIAS_PROG_DFI)
                    $("#lsDpProgramar").html(response[index].DIAS_XPROG_DFI)
                    $("#lsTotal").html(response[index].DIAS_GENE_DFI)
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error3");
            }
        });
        //$("#grdSolicitud").trigger("reloadGrid", { fromServer: true, page: 1 });
    }
});