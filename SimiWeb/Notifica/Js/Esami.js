function getMateriale(source, target) {
    source = '#' + source;
    target = '#' + target;
    var metodo = $(source).val()
    $.ajax({
        type: "POST",
        //   url: "Addnotifica.aspx/GetComuni",
        url: "../WebServices/Geografiche.asmx/GetMaterialeByMetodo",
        data: "{'IdMetodo': '" + metodo + "'}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            AjaxSucceeded(msg, source, target);
        },
        error: AjaxFailed
    });
}
function AjaxSucceeded(result, source, target) {
    var ddl = $(target);
    ddl.find('option').remove();

    ddl.append($('<option></option>').val('').html('Selezionare...'));
    var i;
    for (i = 0; i < result.d.length; i++) {

        ddl.append($('<option></option>').val(result.d[i].Codice).html(result.d[i].Descrizione));
    };
}
function AjaxFailed(result) {
    alert(result.status + ' ' + result.statusText);
}