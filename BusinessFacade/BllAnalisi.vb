Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllAnalisi
    Inherits BizClass
    Private _mobjdataAccess As New DalAnalisi
    Public Function GetMod16(Optional ByVal idregione As String = Nothing, _
                         Optional ByVal idAsl As String = Nothing, _
                         Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                         Optional ByVal mese As Nullable(Of Integer) = Nothing) As List(Of Analisi_Mod16Result)
        Try
            Return _mobjdataAccess.GetMod16(idregione, _
                                            idAsl, _
                                            anno, _
                                            mese)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAnalisi_Notifica(Optional ByVal Criterio As String = Nothing, _
                                            Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                            Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                            Optional ByVal NotificatoDa As String = Nothing, _
                                            Optional ByVal Asl As String = Nothing, _
                                            Optional ByVal idRegione As String = Nothing) As List(Of Analisi_NotificaResult)


        Dim str As New System.Text.StringBuilder

        str.Append("select  ")
        str.Append(" Geo_Regioni.Descrizione as Regione ")
        str.Append(",dbo.Geo_asl.descrizione as aslNotifica ")
        str.Append(",Geo_asl_Residenza.descrizione as aslResidenza ")
        str.Append(",dbo.Geo_Comuni.descrizione  as comune ")
        str.Append(",dbo.Malattie.DescrizioneBreve as malattia ")
        str.Append(",dbo.Notifica_Clinica.DataPrimiSintomi ")
        str.Append(",dbo.Notifica_Clinica.StatoVaccinale as vaccino")
        str.Append(",dbo.Notifica.DataSegnalazione ")
        str.Append(",dbo.Notifica.DataNotifica ")
        str.Append(",CASE WHEN dbo.Notifica_Anagrafica.Sesso is null then 'n.i.' ELSE Sesso END as sesso ")
        str.Append(",CASE   WHEN (dbo.Notifica_Anagrafica.Eta >= 0  AND dbo.Notifica_Anagrafica.Eta < 15 )    THEN '0-14'    ")
        str.Append("	    WHEN (dbo.Notifica_Anagrafica.Eta >= 15 AND dbo.Notifica_Anagrafica.Eta < 25 )    THEN '15-24'	 ")
        str.Append("	    WHEN (dbo.Notifica_Anagrafica.Eta >= 25 AND dbo.Notifica_Anagrafica.Eta < 65 )    THEN '25-64'  	   ")
        str.Append("		WHEN (dbo.Notifica_Anagrafica.Eta > 64 )  THEN '64 >' END  as classe ")
        str.Append(",CASE   WHEN (dbo.Notifica_Anagrafica.Eta =0)   THEN  '0'    ")
        str.Append("	    WHEN (dbo.Notifica_Anagrafica.Eta >= 1 AND dbo.Notifica_Anagrafica.Eta  < 5   )    THEN '01-04'	     ")
        str.Append("	    WHEN (dbo.Notifica_Anagrafica.Eta >= 5 AND dbo.Notifica_Anagrafica.Eta  < 10  )    THEN '05-09'  	     ")
        str.Append("		WHEN (dbo.Notifica_Anagrafica.Eta >=10 AND  dbo.Notifica_Anagrafica.Eta < 15 )    THEN '10-14'  ")
        str.Append("		WHEN (dbo.Notifica_Anagrafica.Eta >=15 AND  dbo.Notifica_Anagrafica.Eta < 25 )    THEN '15-24'  ")
        str.Append("		WHEN (dbo.Notifica_Anagrafica.Eta >=25 AND  dbo.Notifica_Anagrafica.Eta < 65 )    THEN '25-64'  ")
        str.Append("		WHEN (dbo.Notifica_Anagrafica.Eta > 64 )    THEN '64 >' END  as classe2 ")
        'str.Append(",CAST(YEAR(DataPrimiSintomi) as varchar) + '-' + CAST(MONTH(DataPrimiSintomi) as varchar) as TrendSintomi ")
        'str.Append(",CAST(YEAR(DataNotifica) as varchar) + '-' + CAST(MONTH(DataNotifica)as varchar) as TrendNotifica ")
        str.Append(",CAST(YEAR(DataPrimiSintomi) as varchar) + '-'+ RIGHT('00' + CAST(MONTH(DataPrimiSintomi) AS varchar(2)),2)   as TrendSintomi ")
        str.Append(",CAST(YEAR(DataNotifica) as varchar) + '-'+ RIGHT('00' + CAST(MONTH(DataNotifica) AS varchar(2)),2)   as TrendNotifica ")
        str.Append(",Notifica_Clinica.Classificazione ")
        str.Append(",Notifica.Stato ")

        str.Append("From")
        str.Append(" dbo.Notifica INNER JOIN dbo.Notifica_Anagrafica ")
        str.Append(" ON  dbo.Notifica.id = dbo.Notifica_Anagrafica.idNotifica ")
        str.Append(" INNER JOIN dbo.Notifica_Clinica ")
        str.Append(" ON dbo.Notifica.id = dbo.Notifica_Clinica.IdNotifica ")
        str.Append(" INNER JOIN dbo.Geo_asl ")
        str.Append(" ON dbo.Notifica.AslDiNotifica = dbo.Geo_asl.idAsl ")
        str.Append(" INNER JOIN dbo.ReferenteUlss   ")
        str.Append(" ON dbo.Notifica.IdReferenteAsl = dbo.ReferenteUlss.id ")
        str.Append(" INNER JOIN dbo.Malattie ")
        str.Append(" ON dbo.Notifica_Clinica.idMalattia = dbo.Malattie.id_malattia	 ")
        str.Append(" LEFT JOIN dbo.Geo_Regioni ")
        str.Append(" ON dbo.Notifica.idRegione = dbo.Geo_Regioni.IdRegione ")
        str.Append(" Left Join ")
        str.Append(" dbo.Geo_asl AS Geo_asl_Residenza ")
        str.Append(" ON dbo.Notifica.AslDiResidenza = Geo_asl_Residenza.idAsl ")
        str.Append(" LEFT JOIN dbo.Geo_Comuni ")
        str.Append(" ON dbo.Notifica_Anagrafica.IdComuneResidenza = dbo.Geo_Comuni.CodiceComune ")


        str.Append(BizClass.NotificaFilterQueryBuilder(Criterio, _
                                                        DataDa, _
                                                        DataA, _
                                                        NotificatoDa, _
                                                        Asl, _
                                                        idRegione, _
                                                        Nothing))


        Dim a As String = str.ToString



        Dim rs As List(Of Analisi_NotificaResult) = _mobjdataAccess.GetAnalisi_Notifica(str.ToString)


        Return rs



    End Function
    Public Function GetAnalisiFocolaio(Optional ByVal Criterio As String = Nothing, _
                                               Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                               Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                               Optional ByVal NotificatoDa As String = Nothing, _
                                               Optional ByVal Asl As String = Nothing, _
                                               Optional ByVal IdRegione As String = Nothing) As List(Of Analisi_FocolaioResult)


        Dim str As New System.Text.StringBuilder

        str.Append(" SELECT ")
        str.Append("mal.DescrizioneBreve as malattia")
        str.Append(",reg.descrizione as regione")
        str.Append(",Geo_asl.Descrizione as AslNotifica")
        str.Append(",prov.descrizione as Provincia")
        str.Append(",com.descrizione as Comune")
        str.Append(",Comunita.DescrizioneBreve as Comunita")
        str.Append(",age.descrizione as agente")
        str.Append(",AgenteStato as agenteIdentificato")
        str.Append(",focolaio.Veicolo")
        str.Append(",VeicoloStato as veicoloIdentificato")
        str.Append(",dataInizio")
        str.Append(",Stato")
        str.Append(",DataSegnalazione")
        str.Append(",DataNotifica")
        str.Append(",DataModifica")
        str.Append(",CAST(YEAR(dataInizio) as varchar) + '-' + CAST(MONTH(dataInizio) as varchar) as TrendInizio")
        str.Append(",CAST(YEAR(DataNotifica) as varchar) + '-' + CAST(MONTH(DataNotifica)as varchar) as TrendNotifica      ")
        str.Append(" FROM dbo.Focolaio ")
        str.Append(" INNER Join")
        str.Append(" dbo.GEo_Regioni reg")
        str.Append(" ON dbo.Focolaio.IdRegione = reg.idRegione	")
        str.Append(" INNER JOIN dbo.Geo_Province prov")
        str.Append(" ON dbo.Focolaio.idProvincia = prov.idProvincia ")
        str.Append(" INNER JOIN dbo.Geo_Comuni com ")
        str.Append(" ON dbo.Focolaio.idComune = com.CodiceComune ")
        str.Append(" INNER JOIN dbo.Malattie mal ")
        str.Append(" ON dbo.Focolaio.idMalattia = mal.id_malattia ")
        str.Append(" LEFT JOIN dbo.Geo_asl ")
        str.Append("	ON dbo.Focolaio.idAslNotifica = dbo.Geo_asl.idAsl ")
        str.Append(" INNER JOIN dbo.comunita ")
        str.Append(" ON dbo.Focolaio.idComunita = comunita.codice ")
        str.Append(" LEFT JOIN dbo.Agente_Eziologico age ")
        str.Append("ON dbo.Focolaio.IdAgente = age.codice ")
        str.Append(" LEFT JOIN dbo.veicolo vei ")
        str.Append(" ON dbo.Focolaio.Idveicolo = vei.Codice ")


        str.Append(BizClass.FocolaioFilterQueryBuilder(Criterio, _
                                                        DataDa, _
                                                        DataA, _
                                                        NotificatoDa, _
                                                        Asl, _
                                                        IdRegione))

        Dim rs As List(Of Analisi_FocolaioResult) = _mobjdataAccess.GetAnalisi_Focolaio(str.ToString)


        Return rs

    End Function
End Class
