$(document).ready(function () {

    var selectedRows = {};
    var token = $('input[name="__RequestVerificationToken"]').val();

    Init();

    function Init()
    {
        cargargrilla();
    }

    function cargargrilla()
    {
        $("#grdConcepto").jqGrid({
            url: requrlConsulta,
            datatype: 'json',
            async: false,
            mtype: 'POST',
            loadBeforeSend: function (jqXHR) {
                jqXHR.setRequestHeader("__RequestVerificationToken", token);
            },
            jsonReader: {
                root: "rows",
                page: "page",
                total: "total",
                records: "records",
                repeatitems: true
            },
            colNames: [
                'Tipo Concepto',
                'Cadena',
                'Codigo Concepto',
                'Nombre Concepto',                                
                'Estado',                
                'Query',
                'Mensaje',
                'Usuario Registro',
                'Fecha Registro',
                'Usuario Modificación',
                'Fecha Modificación'
            ],
            colModel: [
                { name: 'TIPO_PARAM_DFI', index: 'TIPO_PARAM_DFI', hidden: false, align: "center", width: 120, sortable: false },
                { key: true, name: 'CADE_PARAM_DFI', index: 'CODI_PARAM_DFI', hidden: true, align: "center", width: 220, sortable: false },
                { name: 'CODI_PARAM_DFI', index: 'CODI_PARAM_DFI', hidden: false, align: "center", width: 220, sortable: false },
                { name: 'NOM_PARAM_DFI', index: 'NOM_PARAM_DFI', hidden: false, align: "center", width: 100, sortable: false },                
                { name: 'ESTA_PARAM_DFI', index: 'ESTA_PARAM_DFI', hidden: false, align: "center", width: 100, sortable: false },
                { name: 'QRY_PARAM_DFI', index: 'QRY_PARAM_DFI  ', hidden: false, align: "center", width: 130, sortable: false },
                { name: 'MSJ_PARAM_DFI', index: 'MSJ_PARAM_DFI', hidden: false, align: "center", width: 150, sortable: false },
                { name: 'LOGI_REG_PARAM_DFI', index: 'LOGI_REG_PARAM_DFI', hidden: false, align: "center", width: 90, sortable: false },
                { name: 'FECH_REG_PARAM_DFI', index: 'FECH_REG_PARAM_DFI', hidden: false, align: "center", width: 90, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } },
                { name: 'LOGI_ACT_PARAM_DFI', index: 'LOGI_ACT_PARAM_DFI', hidden: false, align: "center", width: 90, sortable: false },
                { name: 'FECH_ACT_PARAM_DFI', index: 'FECH_ACT_PARAM_DFI', hidden: false, align: "center", width: 90, sortable: false, formatter: 'date', formatoptions: { srcformat: 'd/m/Y', newformat: 'd/m/Y' } }
            ],
            rowNum: 5, rowList: [5, 10, 15, 20, 25, 30], pager: '#pageConcepto', sortname: 'NOM_PARAM_DFI', viewrecords: true, sortorder: "asc",
            height: 285,
            autowidth: true,
            shrinkToFit: false,
            caption: "Resultados - Lista de Conceptos",
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
                var nroreg = $("#grdConcepto").getGridParam("records");
                if (nroreg <= 0) { }
                else {
                    var rows = $("#grdConcepto").getDataIDs();
                    for (var i = 0; i < rows.length; i++) {
                        var psiCosEst = $("#grdConcepto").getCell(rows[i], "ESTA_PARAM_DFI");
                        var rowData = $('#grdConcepto').jqGrid('getRowData', rows[i]);

                        if (psiCosEst == "1"){ rowData.ESTA_PARAM_DFI = 'ACTIVO'; }
                        else if (psiCosEst == "0") { rowData.ESTA_PARAM_DFI = 'INACTIVO'; }
                        
                        $('#grdConcepto').jqGrid('setRowData', rows[i], rowData);
                    }
                }               
            },
            loadError: function (xhr, st, err) {
                window.location.href = requrlError;
            }
        }).navGrid('#pageConcepto', { refresh: false, search: false, add: false, edit: false, del: false });
    }

    $('#btnNuevo').click(function () {

        $.ajax({
            async: false,
            type: "POST",
            headers: {
                "__RequestVerificationToken": token
            },
            url: requrlEncriptarDatosNuevo,
            data: "{'dato':'0'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (response) {
                var json = "";
                for (var item in response) {

                    if (item == 0) {
                        json = response[item];
                    }
                }
                var url = requrlMantenimiento + "?sTip=" + encodeURIComponent(json);
                location.href = url;

            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = requrlError;
            }
        });

        
    });

    $('#btnEditar').click(function () {
        var selRowIds = jQuery('#grdConcepto').jqGrid('getGridParam', 'selarrrow');
        if (selRowIds.length == 1) {
            for (var rowId in selectedRows) {
                var FehIni = $("#grdConcepto").jqGrid('getCell', rowId, 'FECH_REG_PARAM_DFI');
                var FehFin = $("#grdConcepto").jqGrid('getCell', rowId, 'FECH_ACT_PARAM_DFI');
                FehIni = FehIni.substr(0, 10);
                FehIni = FehIni.split('/')
                FehFin = FehFin.substr(0, 10);
                FehFin = FehFin.split('/')
                var sEstado = $("#grdConcepto").jqGrid('getCell', rowId, 'ESTA_PARAM_DFI');
                var iCodEstado = 0;
                if (sEstado == "ACTIVO")
                { iCodEstado = 1;}
                else if (sEstado == "INACTIVO")
                { iCodEstado = 0;}

                var jsdato = JSON.stringify({
                    TIPO_PARAM_DFI: parseInt($("#grdConcepto").jqGrid('getCell', rowId, 'TIPO_PARAM_DFI'),10),
                    CODI_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'CODI_PARAM_DFI'),
                    NOM_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'NOM_PARAM_DFI'),
                    ESTA_PARAM_DFI: iCodEstado,
                    QRY_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'QRY_PARAM_DFI'),
                    MSJ_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'MSJ_PARAM_DFI'),
                    LOGI_REG_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'LOGI_REG_PARAM_DFI'),
                    FECH_REG_PARAM_DFI: new Date(FehIni[2], FehIni[1] - 1, FehIni[0]),
                    LOGI_ACT_PARAM_DFI: $("#grdConcepto").jqGrid('getCell', rowId, 'LOGI_ACT_PARAM_DFI'),
                    FECH_ACT_PARAM_DFI: new Date(FehFin[2], FehFin[1] - 1, FehFin[0])
                });
            }
            jsdato = "[" + jsdato + "]";


            $.ajax({
                async: false,
                type: "POST",
                headers: {
                    "__RequestVerificationToken": token
                },
                url: requrlEncriptarDatosEditar,
                data: "{'dato':'" + jsdato + "','tipo':'1'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {                   
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

                    var url = requrlMantenimiento + "?sTip=" + encodeURIComponent(tipo) + "&sDato=" + encodeURIComponent(json);
                    location.href = url;

                },
                error: function (xhr, ajaxOptions, thrownError) {
                    window.location.href = requrlError;
                }
            });

            
        }
        else { alert('Seleccione solo una fila para editar'); }
    });

    
});