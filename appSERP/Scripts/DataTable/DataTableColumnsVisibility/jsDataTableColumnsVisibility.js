var vListcheckedCheckBox = [];
function fnDatatableColumnsAppendCheckboxes(pTable, pColumns, pChkBoxDiv) {
    var nRow = $('table thead tr')[0];
    $.each(nRow.cells, function (i, v) {

        var vContent =
            '<div class="list-group-item d-flex">' +
            '<input type="checkbox" class="mr-1 ml-1" sort-id ="' + i + '" id = "chk' + i + '" data-text = "' + v.innerText + '">' +
            '<label class="control-label mr-1 ml-1" for="customCheck1" >' + v.innerText + '</label>' +
            '</div>';

        pChkBoxDiv.append(vContent);

    });

}
function fnDatatableColumnsVisibility(pTable, pChkBoxElement) {


    var dt = pTable.DataTable();
    dt.columns(pChkBoxElement.attr('sort-id')).visible(!pChkBoxElement.is(':checked'));
    pTable.css('width', '100%');
    if (pChkBoxElement.is(':checked')) {
        $('input[type=checkbox]').each(function (key, value) {
          
            if ($(this).is(':checked')) {
                $('table >thead > tr > th:contains("' + $(this).attr('data-text') + '")').attr('data-visible', 'false');

            }
            else {
                $('table >thead > tr > th:contains("' + $(this).attr('data-text') + '")').attr('data-visible', 'true');

            }

        });

        //$('table thead tr th')
        if (vListcheckedCheckBox.indexOf(pChkBoxElement.attr('id')) < 0) {
            vListcheckedCheckBox.push(pChkBoxElement.attr('id'));
            localStorage.setItem("lstchkbox", vListcheckedCheckBox);

        }
    }
    else {
    

        if (vListcheckedCheckBox.indexOf(pChkBoxElement.attr('id')) >= 0) {
            vListcheckedCheckBox.splice(vListcheckedCheckBox.indexOf(pChkBoxElement.attr('id')), 1);


        }

    }
}