

// Data Get
function funDataGET(pURL, pArrDataClasses, pArrDataClassesRequired, pArrInputTypes, pIsAddRow, arrHeaderText, pArrColumnWidth, pArrInputGroupSign, pIdColumn, pIsEditAllowed, pIsDeleteAllowed) {

    // Table Header
    funTableHeader(arrHeaderText, pIsAddRow);

    // Get Data
    $.get(pURL, {}, function (data, status) {

        // JSON Parse [data]
        var vData = JSON.parse(data);

        // Check Data
        $.each(vData, function (i, jsonData) {

            // Check All Values In JSON Array
            $.each(vData[i], function (key, value) {

                // Check If Array Contains Key of Class
                if (jQuery.inArray(key, pArrDataClasses) !== -1) {

                    // Generate Row
                    funGenerateRow(
                        pArrInputTypes,
                        pArrDataClasses,
                        pArrDataClassesRequired,
                        jsonData,
                        pIsAddRow,
                        pArrColumnWidth,
                        pArrInputGroupSign,
                        pIdColumn,
                        pIsEditAllowed,
                        pIsDeleteAllowed);

                    // Exit Loop
                    return false;

                } // End Check if Array Contains Key of Class

            }); // End of Each Value in JSON Array

        }) // End of Each Data

    }) // End of GET data

} // End of Function - Data GET

// Generate Table
function funGenerateRow(pArrInputTypes, pArrDataClasses, pArrDataClassesRequired, pArrData, pIsAddRow, pArrColumnWidth, pArrInputGroupSign, pIdColumn, pIsEditAllowed, pIsDeleteAllowed) {

    // Row Content
    var vRowContent;
    // Row Open Tag
    vRowContent += '<tr class="tblRow" data-id="' + pArrData[pIdColumn] + '">';

    // Check If Add Row Option Required
    if (pIsAddRow) {

        // Add Row Content
        var vAddRowContent = '<td class="5%"><button class="btn btn-light btnAddRow"><i class="fa fa-plus-circle"></i></button></td>';
        // Add To Row
        vRowContent += vAddRowContent;
    }



    // Check ALl
    $.each(pArrInputTypes, function (i, data) {

        // Value
        var vIsInputRequired = '';
        if (pArrDataClassesRequired[i]) {
            vIsInputRequired = 'Required';
        }

        // Input Group
        var vInputGroupText = '';
        var vInputGroupTextEndTag = '';

        // Check If Input Group
        if (pArrInputGroupSign[i]) {

            // Input Group
            vInputGroupText = '<div class="input-group">' +
                '<div class="input-group-prepend">' +
                '<span class="input-group-text" id="basic-addon1">' + pArrInputGroupSign[i] + '</span>' +
                '</div>';
            vInputGroupTextEndTag = '</div>';
        }

        // Cell Content
        var vCellContent;

        // Image
        if (pArrInputTypes[i] == 'img') {

            // Cell Content
            vCellContent = '<td width="' + pArrColumnWidth[i] + '">' + vInputGroupText + '<img class="imgView ' + pArrDataClasses[i] + ' " src="' + pArrData[pArrDataClasses[i]] + '" width="40" />' + vInputGroupTextEndTag + '</td>';
        }
        else {

            // Cell Content
            vCellContent = '<td width="' + pArrColumnWidth[i] + '">' + vInputGroupText + '<input type="' + pArrInputTypes[i] + '" class="form-control ' + pArrDataClasses[i] + ' " ' + vIsInputRequired + '  value="' + pArrData[pArrDataClasses[i]] + '" />' + vInputGroupTextEndTag + '</td>';
        }

        // Add Cell Content to Row Content
        vRowContent += vCellContent;
    })

    if (pIsDeleteAllowed) {

        vRowContent += '<td><button class="btn btn-light btnDelete" data-id="' + pArrData[pIdColumn] + '" title="@appResource.btnDelete"><i class="fa fa-trash"></button></td>';
        vRowContent += '<td><input type="checkbox" class="IsDeleted d-none" data-id="' + pArrData[pIdColumn] + '" /></td>';
    }

    // End of Row Tag
    vRowContent += '</tr>';

    // Append Row Content to Table Body
    $('.tblDataBody').append(vRowContent);

} // End of Function

// Table Header
function funTableHeader(pArrHeaderText, pIsAddRow) {

    // Table Header Open Tag
    var vRowContent = '<tr>';

    // Check If Add Row
    if (pIsAddRow) {

        // Is Add Row
        vRowContent += '<th width="5%"></th>';
    }

    // Check All THead Cells
    $.each(pArrHeaderText, function (i, headerText) {

        // Add Cell To Row Content
        vRowContent += '<th>' + pArrHeaderText[i] + '</td>'
    })

    // Table Header Close Tag
    vRowContent += '</tr>'

    // Append Row Content to Table Body
    $('.tblDataHeader').append(vRowContent);
}

// Table Clear
function funTableClear() {

    // Clear
    $('.tblDataBody').html('');
    $('.tblDataHeader').html('');
}


// Delete Confirm Check
$('body').on('click', '.btnDelete', function () {

    var vRowId = $(this).attr('data-id');

    //var vCheckBox = $('.IsDeleted data-id["' + vRowId + '"]');

    var vCheckBox = $(".IsDeleted[data-id='" + vRowId + "']");
    vCheckBox.prop("checked", true);

    // Get Closest Row
    var $tr = $(this).closest('.tblRow');
    // Row to Delete -  Background Color
    $tr.addClass('table-danger');



})

// Add New Row
$('body').on('click', '.btnAddRow', function () {
    // Get Closest Row
    var $tr = $(this).closest('.tblRow');
    // Clone
    var $clone = $tr.clone();
    // Clear Values
    $clone.find('input').val('');
    // Clear Image Source
    $clone.find('img').attr('src', '');
    // Attribute of Id
    $clone.attr('data-id', '0');
    // Insert Row After Current Row
    $tr.after($clone);
})

// Data Edit
$('body').on('click', '.btnDataEdit', function () {

    // API Paramter Start
    var vAPIParameterStartChar = 'p';
    // System Message - Declaration
    var vSystemMessageText;
    var vSystemMessageTypeId;

    $('.tblRow').each(function () {

        // Row Parameters
        var vRowParameters = [];
        // Row To Edit
        var vRowToEdit = $(this);
        // Row Id
        var vRowId = $(this).attr('data-id');
        // Is Valid
        var vIsValid = true;

        // Add Id
        var vParameterIdName = vAPIParameterStartChar + vIdColumn;
        vRowParameters.push({ name: vParameterIdName, value: vRowId });
        // Add Query Type
        var vParameterQueryType = vAPIParameterStartChar + "QueryTypeId";
        vRowParameters.push({ name: vParameterQueryType, value: vQueryTypeId_AddEdit });

        // Add Query Type
        var vParameterIsDeleted = vAPIParameterStartChar + "IsDeleted";
        var vParameterIsDeletedValue = vRowToEdit.find('input.' + 'IsDeleted').prop('checked')
        vRowParameters.push({ name: vParameterIsDeleted, value: vParameterIsDeletedValue });

        // Check All
        $.each(arrDataClasses, function (i, data) {

            // Each Parameter
            var vValue = vRowToEdit.find('input.' + arrDataClasses[i]).val();
            var vParameterName = vAPIParameterStartChar + arrDataClasses[i];

            // Is Required - GET
            var vIsRequired = vRowToEdit.find('input.' + arrDataClasses[i]).prop('required');



            // Check Is Required
            if (vIsRequired) {
                if (vValue) {
                    // Push Values
                    vRowParameters.push({ name: vParameterName, value: vValue });
                }
                else {

                    vIsValid = false;
                    // Validation Error
                    vRowToEdit.find('input.' + arrDataClasses[i]).addClass('bg-danger');

                }
            }
            else {
                // Add [Not Required]
                vRowParameters.push({ name: vParameterName, value: vValue });
            }
        })

        // Check if Valid Row
        if (vIsValid) {
            // Save
            $.ajax({
                type: "GET",
                url: vURL,
                async: false,
                data: vRowParameters,
                contentType: "application/json",
                success: function (data) {
                    // Return Result
                    var vJSONResult = JSON.parse(data);
                    // Message
                    vSystemMessageText = vJSONResult[0].SystemMessageText;
                    vSystemMessageTypeId = vJSONResult[0].SystemMessageTypeId;
                }
            });
        }

    })

    //// Reload
    //funReload();
    // Notification
    funNotification(vSystemMessageText, vSystemMessageTypeId);


})

// Row Select
$('body').on('click', '.tblRow', function () {

    $('.tblRow').removeClass('table-primary');
    $(this).addClass('table-primary');

})

// Refresh Data
$('.btnReload').on('click', function () {
    // Reload
    funReload();
})

// Reload
function funReload() {

    // Table Clear
    funTableClear();
    // DataGET [GENERATE TABLE]
    funDataGET(
        vURL,
        arrDataClasses,
        arrDataClassesRequired,
        arrInputTypes,
        vIsAddRow,
        arrHeaderText,
        arrColumnWidth,
        arrInputGroupSign,
        vIdColumn,
        vIsEditAllowed,
        vIsDeleteAllowed);
}