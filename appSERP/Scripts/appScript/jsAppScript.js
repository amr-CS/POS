/// <reference path="../jquery-3.3.1.min.js" />
/// <reference path="../datatable/jquery.datatables.min.js" />

            //// Load System Config Functions
            // Buttons
            funButtonsConfig();
            // DataTable
            //funDataTableInit();
            // Table Row Select
            TableRowSelect();
            // Pre Loader
            //funLoadingPreLoader();
            // ToolTip
            funUtilityInitToolTip();
            // True False Sign
            funTrueFalseSign();
            // Data Is Active
            funDataIsActive();


// Initiate Data Buttons
function funButtonsConfig() {

    //// Create
    // Create Buttons
    var vCreateButton = $('.btnCreate');
    // Initiate Button
    vCreateButton.addClass('btn-success');
    // Create Utility
    var vUtilityCreateButton = $('.btnUtilityCreate');

    // Create Utitlity
    vUtilityCreateButton.removeClass('btn-success');
    vUtilityCreateButton.addClass('btn-secondary');

    //// Edit
    // Edit Buttons
    var vEditButton = $('.btnEdit');
    // Initiate Button
    vEditButton.addClass('btn-light');
    // Edit Icons
    var vEditIcon = $('.icoEdit');
    // Initiate Icon
    var vIcon = '<i class="fa fa-pencil"></i>';
    vEditIcon.html(vIcon);


    //// Delete
    // Delete Buttons
    var vDeleteButton = $('.btnDelete');
    // Initiate Button
    vDeleteButton.addClass('btn-light');
    // Delete Icons
    var vDeleteIcon = $('.icoDelete');
    // Initiate Icon
    var vIcon = '<i class="fa fa-times"></i>';
    vDeleteIcon.html(vIcon);

};

// DataTable Initiate
function funDataTableInit(dtSearch, dtDisplay, dtTo, dtFrom, dtTotal, dtRecord
    , dtShowing, dtNoData, dtFilteredFrom, dtDisplay
    , dtFirst, dtPrevious, dtNext, dtLast, pMessageTop) {


    //// Setup - add a text input to each footer cell
    //$(' .tblData thead th').each(function () {
    //    var title = $(this).text();
    //    //$(this).append('<input type="text" class="form-control" placeholder="' + dtSearch + ' ' + title + '" />');
    //    $(this).append('<input type="text" class="form-control" placeholder="" />');
    //});

    //var table = $("#example").DataTable({
    //    columnDefs: [
    //        { "type": "html-input", "targets": [1, 2, 3] }
    //    ]
    //});

    var vDataTable = $('.tblData').DataTable({
        "ordering": false,
        "oLanguage": {
            "sSearch": dtSearch,
            "sZeroRecords": dtNoData,
            "sInfo": dtDisplay + " _START_ " + dtTo + " _END_ " + dtFrom + " _TOTAL_ " + dtRecord,
            "sInfoEmpty": dtRecord + " 0 " + dtFrom + " 0 " + dtTo + " 0 " + dtShowing,
            "sEmptyTable": dtNoData,
            "sInfoFiltered": "(" + dtFilteredFrom + "  _MAX_ " + dtRecord + ")",
            "sLengthMenu": dtDisplay + " _MENU_ " + dtRecord,
            "oPaginate": {
                "sFirst": dtFirst,
                "sPrevious": dtPrevious,
                "sNext": dtNext,
                "sLast": dtLast
            }
        },
        'stateSave': true,
        dom: 'Bfrtip',
        buttons: [
            {
                extend: 'print',
                messageTop: $('.divViewHeaderTitleText').text(),
                messageBottom: 'White Cloud',
                exportOptions: {
                    stripHtml: false,
                    columns: "thead th:not(.noExport)"
                },
                customize: function (win) {
                    $(win.document.body)
                        .attr('direction', 'rtl')
                        .css('font-size', '12px')



                    $(win.document.body).find('table')
                        .addClass('compact')
                        .css('font-size', '12px')
                        .attr('dir', 'rtl')
                        ;
                }
            },
            {
                extend: 'excel',
                text: 'Save current page',
                exportOptions: {
                    stripHtml: false,
                    columns: "thead th:not(.noExport)",
                    modifier: {
                        page: 'current'
                    }
                }
            }
        ]
    });


    $('.buttons-pdf, .buttons-print, .buttons-excel').addClass('btn btn-light');
    $('.buttons-pdf, .buttons-print, .buttons-excel').removeClass('dt-button');
    $('.buttons-pdf, .buttons-print, .buttons-excel').text("");

    //// Apply the search
    //vDataTable.columns().every(function () {
    //    var that = this;
    //    $('table  th.thActions > input ').prop('disabled', true);
    //    $('input', this.header()).on('keyup change', function () {
    //        if (that.search() !== this.value) {
    //            that
    //                .search(this.value)
    //                .draw();
    //        }
    //    });
    //}); // End of Apply Search

    //$('.dataTables_filter').remove();
}

// Table Row Select
function TableRowSelect() {
    // SELECTED ROW In Any Table
    $(" tbody tr").click(function () {
        $('.selected').removeClass('selected');
        $(this).addClass("selected");
        var vId = $(this).attr('data-id');
    });
}

funLoadingPreLoader();
// Loading Pre Loader
function funLoadingPreLoader() {
    // On Load Complete
    window.onload = function () {
        // Hide Loader
        $('.divLoading').animate({ 'opacity': '0' })
        $('.divLoading').hide();
        // Show Content
        $('.divViewContent').fadeIn("slow");
    };
}

// Utility Init Tooltip
function funUtilityInitToolTip() {

    // Copy, Cut, Paste
    $('.btnCopy').tooltip();
    $('.btnCut').tooltip();
    $('.btnPaste').tooltip();

   

    // Print
    $('.btnPrint').tooltip();

    // Sort
    $('.btnSortAsc').tooltip();
    $('.btnSortDesc').tooltip();

    // Edit, Create
    $('.btnEdit').tooltip();
    $('.btnCreate').tooltip();

    // Export
    $('.btnPDF').tooltip();
    $('.btnExcel').tooltip();
    $('.btnWord').tooltip();

    // Close
    $('.btnClose').tooltip();

    // Navigation
    $('.btnLast').tooltip();
    $('.btnFirst').tooltip();
    $('.btnPrev').tooltip();
    $('.btnNext').tooltip();

    // Full Screen
    $('.btnFullScreen').tooltip();
   
}
$('body').on('hover', '.btnDelete', function () {
    $('.btnDelete').tooltip()
})

// True False Sign
function funTrueFalseSign() {
    // TRUE OR FALSE CASE
    $("td:contains('True')").html('<div class=" h5"><i class="fa fa-check text-success"></i></div>');
    $("td:contains('False')").html('<div class=" h5"><i class="fa fa-minus text-danger"></i></div>');
};

// Data Is Active
function funDataIsActive() {
    // Is Active Case
    $('.dataIsActive').each(function () {

        var vIsActive = $(this).parent().attr('data-active');


        if (vIsActive == 'True' || vIsActive == '1') {
            $(this).html('<div class=" h5"><i class="fa fa-check text-success"></i></div>');
        }
        else {
            $(this).html('<div class=" h5"><i class="fa fa-minus text-danger"></i></div>');
        }
    });
}

// Set Object Name From Side Bar
$('.appSideBar a').on('click', function () {
    var vObjectName = $(this).attr('data-Object-Name')

    localStorage.setItem('lsSideBarItem', vObjectName);

    //$.post('/Home/funObjectName', { pObjectName: vObjectName }, function (status) { console.log(status) })
});


// Reload Pages
//$(function () {
//    // Click Event for SideBar
//    $(".divSidebarItem").click(function (e) {

//        // Remove Active Class From All Items
//        $('.divSidebarItem').removeClass('divSidebarItemActive');
//        // Add Class Selected to Current Sidebar Item
//        $(this).addClass('divSidebarItemActive');

//        // Prevent Default [Default is go to Page with reload]
//        //e.preventDefault();
//        // Path of Current Sidebar Item
//        var vPath = $(this).attr('href');

//        //});
//        //  window.location.href = vPath;
//        var vId = $(this).attr('data-Object-id');
//        $.post('/Home/GetUserObject', { pObject: vId }, null)
//    });
//});





//Search Modal
$(document).ready(function () {
    $("body").on("keyup", ".txtSearch", function () {
        var value = $(this).val().toLowerCase();
        $(".tblData tbody tr ").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
        });
    });
});



