function getComuni(source, target) {
    source = '#' + source;
    target = '#' + target;
    var Provincia = $(source).val()
    $.ajax({
        type: "POST",
        //   url: "Addnotifica.aspx/GetComuni",
        url: "../WebServices/Geografiche.asmx/GetComuni",
        data: "{'idProvincia': '" + Provincia + "'}",
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

function getProvince(target, codiceItalia) {

    var cod = codiceItalia;

    if (cod == 'undefined' || cod != '000') {
        return;
    }
    else {
        // source = '#' + source;
        target = '#' + target;
        // var Provincia = $(source).val()
        $.ajax({
            type: "POST",
            url: "../WebServices/Geografiche.asmx/getProvince",
            //   data: "{'idProvincia': '" + Provincia + "'}",            
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                AjaxSucceededProvince(msg, target);
            },
            error: AjaxFailedProvince
        });
    }
}
function AjaxSucceededProvince(result, target) {
    var ddl = $(target);
    ddl.find('option').remove();

    ddl.append($('<option></option>').val('').html('Selezionare...'));
    var i;
    for (i = 0; i < result.d.length; i++) {

        ddl.append($('<option></option>').val(result.d[i].Codice).html(result.d[i].Descrizione));
    };

}
function AjaxFailedProvince(result) {
    alert(result.status + ' ' + result.statusText);
}

//PROVINCIE BY ID REGIONE

function getProvinceByIdRegione(target, codiceRegione) {

    var codRegione = codiceRegione;

    if (codRegione == 'undefined') {
        return;
    }
    else {
        // source = '#' + source;
        target = '#' + target;   
        $.ajax({
            type: "POST",
            url: "../WebServices/Geografiche.asmx/GetAllProvinceIdRegione",
            data: "{'idRegione': '" + codRegione + "'}",            
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                AjaxSucceededProvinceByIdRegione(msg, target);
            },
            error: AjaxFailedProvinceByIdRegione
        });
    }
}
function AjaxSucceededProvinceByIdRegione(result, target) {
    var ddl = $(target);
    ddl.find('option').remove();

    ddl.append($('<option></option>').val('').html('Selezionare...'));
    var i;
    for (i = 0; i < result.d.length; i++) {

        ddl.append($('<option></option>').val(result.d[i].Codice).html(result.d[i].Descrizione));
    };
}
function AjaxFailedProvinceByIdRegione(result) {
    alert(result.status + ' ' + result.statusText);
}



//NAZIONI

function CaricaNazioni(target) {

    target = '#' + target;
    $.ajax({
        type: "POST",
        url: "../WebServices/Geografiche.asmx/GetNazioni",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            AjaxSucceededNazioni(msg,target);
        },
        error: AjaxFailedNazioni
    });
}


function AjaxSucceededNazioni(result,target) {
        var ddl = $(target);
        ddl.find('option').remove();

        ddl.append($('<option></option>').val('').html('Selezionare...'));
        var i;
        for (i = 0; i < result.d.length; i++) {

            ddl.append($('<option></option>').val(result.d[i].Codice).html(result.d[i].Descrizione));
        };
    }



    function AjaxFailedNazioni(result) {
        alert(result.status + ' ' + result.statusText);
    }


    // Pulisci Campi

    function RemoveItem(target) {
        target = '#' + target;
        var ddl = $(target);
        ddl.find('option').remove();
    }