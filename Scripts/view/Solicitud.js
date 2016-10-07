$(document).ready(function () {
    var selectedRows = {};
    $(".select2").select2();
    init();

    function init() {
        
        $('#sCodPlanilla').attr('aria-hidden', 'true').hide();
        $('#sCodDepencia').attr('aria-hidden', 'true').hide();
        $('#sCodCargo').attr('aria-hidden', 'true').hide();
        
        $.getJSON(
            "/Solicitud/obtenerRutaJson",
            {
                nombreControl: "slPersonal"
            },
            function (data) {

                var slCriterio = $("#slTrabajadorB");
                slCriterio.empty();

                for (u in data.Personas.Persona) {
                    slCriterio.append("<option value=" + data.Personas.Persona[u].valor +
                            ">" + data.Personas.Persona[u].texto + "</option>");
                }
            });
        cargarGrilla();
    }

    function ShowModalAutenticacion() {
        var token = FuncionJS.GetToken();

        $("#modalSolicitud").load(requrlModalAutenticacion + '?token=' + token,
            function () {
                $("#modalSolicitud").modal("show");
            });
    }

    function cargarGrilla() {        
        $("#grdSolicitud").jqGrid({
            url: requrlMostrarSolicitud,
            datatype: 'json',
            async: false,
            mtype: 'POST',
            postData: {
                token: function () { return FuncionJS.GetToken(); },
                dato: function () {
                    
                    var slTrabajadorB = $('#slTrabajadorB');
                    var valorSel = slTrabajadorB.val();
                    var value = document.getElementById('sCodPlanilla').value;
                    var slPeriodoT = $('#slPeriodoT');
                    var slPeriodoTSel = slPeriodoT.val();
                    var sCodCargo = document.getElementById('sCodCargo').value;
                    var sCodDepend = document.getElementById('sCodDepencia').value;
                    var sCodEstado = '';                    
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
            colNames: ['Fecha Inicio', 'Fecha Fin', 'Días', 'Estado','Observacion'],
            colModel: [            
            { name: 'FECH_REGI_DDF', index: 'FECH_REGI_DDF', width: 90, align: "center", sorttype: 'date', datefmt: 'd-m-y' },
            { name: 'FINA_PROG_DDF', index: 'FINA_PROG_DDF', width: 90, align: "center", sorttype: 'date', datefmt: 'd-m-y' },
            { name: 'DIAS_PROG_DDF', index: 'DIAS_PROG_DDF', width: 80, align: 'center', sorttype: false },
            { name: 'NOM_EST_DDF', index: 'NOM_EST_DDF', width: 80, align: 'center', sorttype: false },
            { name: 'OBSE_REGI_DDF', index: 'OBSE_REGI_DDF', width: 150, align: "center", sortable: false }],
            rowNum: 5, rowList: [5, 10, 15, 20], pager: '#pageSolicitud', sortname: 'FECH_REGI_DDF', viewrecords: true, sortorder: "asc",
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
            gridComplete: function () {
            var nroreg = $("#grdSolicitud").getGridParam("records");
            if (nroreg <= 0) {
                //var myfirstrow = { fehIni: "12/06/2016", fehFin: "13/06/2016", iDias: "2", vObserv: "Pruebas" };
                //$("#grdSolicitud").addRowData("1", myfirstrow);
               // alert("No se encontraron registros.");
            } else {                
                var rows = $("#grdSolicitud").getDataIDs();                
                //LOGICA PARA PODER SETEAR NUEVAMENTE LOS VALORES AL PAGINAR
                for (var rowId in selectedRows) {
                    $("#grdSolicitud").setSelection(rowId, true);
                }

            }
        },
        }).navGrid('#pageSolicitud', {
            refresh: true,
            search: true,
            add: true,
            edit: true,
            del: true
        }, {
            editCaption: "The Edit Dialog",
            recreateForm: true,
            checkOnUpdate: true,
            checkOnSubmit: true,
            closeAfterEdit: true,
            errorTextFormat: function (data) {
                return 'Error: ' + data.responseText
            }
        },
        {
            closeAfterAdd: true,
            recreateForm: true,
            errorTextFormat: function (data) {
                return 'Error: ' + data.responseText
            }
        },
        {
            errorTextFormat: function (data) {
                return 'Error: ' + data.responseText
            }
        }
        );
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

    $('#btnMan').click(function () {
        var slTrabajadorB = $('#slTrabajadorB');
        var valorSel = slTrabajadorB.val();
        var url = requrlMantenimiento + '?CODI_EMPL_PER=' + valorSel;
        location.href=url;
    });

    $(function () {
        $(".multiselect").multiselect();
    });

    $("#slTrabajadorB").change(function () {        
        var slTrabajadorB = $('#slTrabajadorB');
        var valorSel = slTrabajadorB.val();
        
        $.ajax({
            url: requrlDatosTrabajador,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'CODI_EMPL_PER':'" + valorSel + "'}",
            dataType: "json",
            success: function (response) {
                $.each(response, function (index, item) {
                    var dateString = response[index].FECH_INGR_PER.substr(6);
                    var currentTime = new Date(parseInt(dateString));
                    var month = currentTime.getMonth() + 1;
                    var day = currentTime.getDate();
                    var year = currentTime.getFullYear();
                    var date = day + "/" + month + "/" + year;                                        

                    $("#sCodTrabajador").val(response[index].CODI_EMPL_PER);
                    $("#sTrabajador").val(response[index].NOMB_CORT_PER);
                    $("#sDepenciaT").val(response[index].DESC_LARG_TDE);
                    $("#sCodDepencia").val(response[index].CODI_DEPE_TDE);
                    $("#sCargoT").val(response[index].NOMB_PUES_TNI);
                    $("#sCodCargo").val(response[index].CODI_NIVE_TNI);
                    $("#sPlanillaT").val(response[index].DESC_TIPO_TPL);
                    $("#sCodPlanilla").val(response[index].TIPO_PLAN_TPL);
                    $("#sModalidad").val(response[index].ABRE_LABO_PER);                    
                    $("#sFehIng").val(date);
                    
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error1");
            }
        });

        var value = document.getElementById('sCodPlanilla').value;
        $.ajax({
            url: requrlPeriodo,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'TIPO_PLAN_TPL':'" + value + "','CODI_EMPL_PER':'" + valorSel + "'}",
            dataType: "json",
            success: function (response) {
                var slPeriodo = $("#slPeriodoT");
                slPeriodo.empty();
                $.each(response, function (index, item) {
                    slPeriodo.append("<option value=" + response[index].ANIO_GENE_DFI +
                            ">" + response[index].ANIO_GENE_DFI + "</option>");
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error2");
            }
        });
        var slPeriodoT = $('#slPeriodoT');
        var slPeriodoTSel = slPeriodoT.val();
        $.ajax({
            url: requrlDatosPeriodo,
            type: 'POST',
            async: false,
            contentType: 'application/json;charset=utf-8',
            data: "{'TIPO_PLAN_TPL':'" + value + "','CODI_EMPL_PER':'" + valorSel + "','PERI_GENE_DFI':'" + slPeriodoTSel + "'}",
            dataType: "json",
            success: function (response) {
                $.each(response, function (index, item) {
                    $("#sDGozados").val(response[index].DIAS_GOZA_DFI)
                    $("#sDProgram").val(response[index].DIAS_PROG_DFI)
                    $("#sDpProgramar").val(response[index].DIAS_XPROG_DFI)
                    $("#sTotal").val(response[index].DIAS_GENE_DFI)
                })
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert("error3");
            }
        });

        cargarGrilla();
        //$('#sCodPlanilla').attr('aria-hidden', 'true').hide();
    });

});