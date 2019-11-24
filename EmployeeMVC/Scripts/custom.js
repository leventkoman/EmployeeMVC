$(function() {
    $("#tblPersoneller").
    DataTable({
            "language": {
                "url":"//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        });
});
$(function () {
    $("#tblDepertmanlar").
        DataTable({
            "language": {
                "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Turkish.json"
            }
        });
});
function CheckDataTypeIsValid(dataElement) {
    var value = $(dataElement).val();
    if (value=='') {
        $(dataElement).valid("false");
    } else {
        $(dataElement).valid();
    }
}