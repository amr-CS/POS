$(document).ready(function () {
    excel = new ExcelGen({
        "src_id": "tblData",
        "show_header": true
    });
    $(".btnExcel").click(function () {
        excel.generate();
    });
});