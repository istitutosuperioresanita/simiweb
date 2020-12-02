//<script language="javascript" type="text/javascript">
//    //--- For Checkbox in Gridview
//    function SelectAll(id) {
//        var frm = document.forms[0];

//        for (i = 0; i < frm.elements.length; i++) {
//            if (frm.elements[i].type == "checkbox") {
//                frm.elements[i].checked = document.getElementById(id).checked;

//            }
//        }

//    }
//    </script>

function checkProfilo() {
    var ruolo = $('#cmbRole').val();

    switch(ruolo)
    {
    case 'admin':
        $('#Asl').val('');
        $('#Regione').val('');
        break;
    case 'asl':
//        $('#Asl').val('');
//        $('#Regione').val('');
        break;
    case 'iss':
        $('#Asl').val('');
        $('#Regione').val('');
        break;
    case 'ministero':
        $('#Asl').val('');
        $('#Regione').val('');
        break;
    case 'regione':
       $('#Asl').val('');
//        $('#Regione').val('');
       break;
   case '':
       $('#Asl').val('');
       $('#Regione').val('');
       break;
    }
}
