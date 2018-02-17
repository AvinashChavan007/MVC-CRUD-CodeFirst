$.ajaxSetup({ cache: false });

function InitTables(){
    agGrid.LicenseManager.setLicenseKey("ag-Grid_Evaluation_License_Key_Not_for_Production_100Devs15_February_2018__MTUxODY1MjgwMDAwMA==600d5a723b746ad55afff76eb446f0ad");
                                         
};

// custom ag-grid cell renderers
// params needs to be the cellRendererParams used for that column
// icon: the type of icon to show (i.e: fa fa-pencil).
// type: the type of icon this is - used for the class.
// value: automatically from ag-grid. The value of the current cell.
function agIconCellRender(params) {
    return '<span class="' + params.type + ' t-left t-xs" data-tooltip="Edit" data-id="' + params.value + '"><i class="' + params.icon + '"></i></span>';
}

var DataTableHandler = {
    currentTable: {
        table: null,
        setTable: function (val) {
            this.table = val;
        }
    },
    dataTableDictionary: {
    },
    selectedRowDictionary: {
    },
    handleDataTableDefaults: function () {
        // datatable defaults
        $.extend($.fn.dataTable.defaults, {

            "preDrawCallback": function (oSettings, json) {
                $('.dataTables_filter').each(function (index) {
                    $(this).appendTo($(this).closest('.panel').find('.table-search'));
                    $(this).find('input').attr("placeholder", "Search...").focus();
                });
            },
            "drawCallback": function (settings, json) { // initialize any tooltips that are needed on the table
            },
            "serverSide": true,
            "ordering": true,
            "searching": true,
            "dom": "rftS",
            "scroller": {
                "loadingIndicator": true
            }
        });
    },
    generateDtHeight: function () {
        return $(".tray_main").height() - $(".js-panel-dt .panel-heading").outerHeight() - 65;
    }
};

function setPanelHeight() {
    $(".js-setHeight").height($(".tray_main").height() - 34);
}

function setTableHeight() {
    var tableHeight = $(".diagonal-table-holder > table").outerHeight();
    var tableSearchHeight = $(".table-search").outerHeight();
    // calculate height of diagonal table
    var diagonalTableHeight = $(".tray_main").height() - $(".js-panel-dt .panel-heading").outerHeight() - $(".diagonal-table-header").outerHeight();
    // if table-search exists, adjust height of diagonal table accordingly
    if ($(".table-search").length > 0) {
        diagonalTableHeight -= tableSearchHeight;
    }

    // set diagonal table height so scrollbar remains consistent site-wide
    $(".diagonal-table-holder").css("height", diagonalTableHeight);

    // align table headers if diagonal table has scrollbars
    if (tableHeight > diagonalTableHeight) {
        $(".diagonal-table-header").css("padding-right", "17px");
    }
}

function getAntiforgeryToken() {
    return $("[name='__RequestVerificationToken']").val();
}