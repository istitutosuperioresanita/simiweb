function CompareDate() {
    var datanascita = $('#DataNascita').val();
    var dataprimisintomi = $('#DataPrimiSintomi').val();

    datanascita = PrendiData(datanascita);
    dataprimisintomi = PrendiData(dataprimisintomi);
    if (
    (datanascita > dataprimisintomi)
 ) {
        alert('Controllare la sequenza temporale delle date \n la data di nascita deve essere <= ' + $('#DataPrimiSintomi').val() + ' (data primi sintomi) ');
        return false
    }
    return true
}

function PrendiData(cDate) {
    var aTmp = cDate.split('/');
    var nDAy = aTmp[0];
    var nMonth = aTmp[1];
    var nYear = aTmp[2];
    return parseInt(nYear + nMonth + nDAy)

}