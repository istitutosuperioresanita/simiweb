function abilitaExtraPolmonare() {

    if (document.forms[0].SedeExtraPolmonare.checked) {
        document.forms[0].Localizzazione1.disabled = false;
        document.forms[0].Localizzazione2.disabled = false;
    }
    else {
        document.forms[0].Localizzazione1.disabled = true;
        document.forms[0].Localizzazione1.value = '';
        document.forms[0].Localizzazione2.disabled = true;
        document.forms[0].Localizzazione2.value = '';

    }
}

function AbilitaDisseminata() {

    if (document.forms[0].sede_anatomica3.checked) {
        document.forms[0].Tipo_disseminata.disabled = false;
    }
    else {
        document.forms[0].Tipo_disseminata.disabled = true;
        document.forms[0].Tipo_disseminata.value = '';
    }
}

function ControllaLocalizzazioni() {
    if (document.forms[0].Localizzazione1.value != '' || document.forms[0].Localizzazione2.value != '') {
        if (document.forms[0].Localizzazione1.value == document.forms[0].Localizzazione2.value) {
            document.forms[0].Localizzazione2.value = '';
        }

        if (document.forms[0].Localizzazione1.value == '') {
            document.forms[0].Localizzazione2.value = '';
        }

    }
    ControllaDisseminata2()
}

function ControllaDisseminata() {
    var VoceSel
    VoceSel = document.forms[0].Disseminata.value;

    switch (VoceSel) {

        case 'miliare':
            document.forms[0].Miliare.checked = true;
            break;

        case 'localizzazioni':
            if (document.forms[0].Localizzazione1.value == '' || document.forms[0].Localizzazione2.value == '') {
                alert('Per abilitare questa casella bisonga inserire almeno due localizzazioni extrapolmonari');
                document.forms[0].Disseminata.value = '';
            }
            document.forms[0].Miliare.checked = false;
            break;

        case 'sangue':
            document.forms[0].Miliare.checked = false;
            break;

        default:

    }
}

function ControllaDisseminata2() {
    if (((document.forms[0].Localizzazione1.value == '' || document.forms[0].Localizzazione2.value == '') && document.forms[0].Disseminata.checked == 'localizzazioni')) {
        document.forms[0].Disseminata.value = '';
        document.forms[0].Miliare.checked = false;
    }
}

function ControllaMiliare() {
    if (document.forms[0].Miliare.checked == true) {
        document.forms[0].Disseminata.value = 'miliare';
    }
    else {
        document.forms[0].Disseminata.value = '';
    }

}


function Conta() {
    var scrivi;
    if (document.forms[0].Localizzazione1.value == '' && document.forms[0].SedeExtraPolmonare.checked == true) {
        alert('selezionare Una localizzazione')
        return false;
    }

}

function CheckAntibiogramma(){
var antibiogramma = document.forms[0].Antibiogramma.value;

if (antibiogramma == 'Si'){
        document.forms[0].STRE.disabled = false;
        document.forms[0].INH.disabled  = false;
        document.forms[0].RMP.disabled  = false;
        document.forms[0].EMB.disabled  = false;
        document.forms[0].PZA.disabled  = false;
    }
else
    {
        document.forms[0].STRE.value = '';
        document.forms[0].INH.value = '';
        document.forms[0].RMP.value = '';
        document.forms[0].EMB.value = '';
        document.forms[0].PZA.value = '';

        document.forms[0].STRE.disabled = true;
        document.forms[0].INH.disabled  = true;
        document.forms[0].RMP.disabled  = true;
        document.forms[0].EMB.disabled  = true;
        document.forms[0].PZA.disabled  = true;
    }
}

function CheckEsito() {
    if (document.forms[0].Esito.value == 'trasferito') { 
         document.forms[0].trasferito.disabed=false;        
    }
    else
    {
    document.forms[0].trasferito.value='';
    document.forms[0].trasferito.disabed=true;
}

if (document.forms[0].Esito.value == 'interotto') {
    document.forms[0].trattamentoInterotto.disabed = false;
}
else {
    document.forms[0].trattamentoInterotto.value = '';
    document.forms[0].trattamentoInterotto.disabed = true;
    }

}

function TbcPassata() {
    var DiagnosiTubercolosiPassato = $('#DiagnosiTubercolosiPassato').val();
    if (DiagnosiTubercolosiPassato != 'Si') {
        $('#anno').val('');
        $('#mese').val('');
        document.forms[0].anno.disabed = true;
        document.forms[0].mese.disabed = true;
    }
else {
    document.forms[0].anno.disabed = false;
    document.forms[0].mese.disabed = false;
    }
}

function CheckAgente() {
    var Agente = $('#Agente').val();
    if (Agente != '999999') { 
        $('#AltroAgente').val('');
        }
}

function CheckAltroEsameColturale() {
//    var EsameColturaleAltroMateriale = $('#EsameColturaleAltroMateriale').val();
//    if (EsameColturaleAltroMateriale != 'Positivo') {
//        document.forms[0].EsameColturaleDesc.value = '';
//    }

}
function CheckAltroEsameDiretto() {
//    var Esamedirettoaltromateriale = $('#Esamedirettoaltromateriale').val();
//    if (Esamedirettoaltromateriale != 'Positivo') {
//        document.forms[0].EsamedirettoaltromaterialeDesc.value = '';
//    }

}



