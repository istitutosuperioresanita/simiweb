Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllFocolaio
    Private _mobjdataAccess As New DalFocolaio
    Private _username As String
    Private _record As String
    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property record() As String
        Get
            Return _record
        End Get
        Set(ByVal value As String)
            _record = value
        End Set
    End Property
    Public Function Add(ByVal localtable As Focolaio) As Integer
        Try



            Dim mobjProfilo As New DalProfilo

            Dim profilo As Utenti_Profilo = mobjProfilo.GetByUsername(_username)

            '    localtable.idRegione = profilo.idRegione
            localtable.idAslNotifica = profilo.idAsl


            Dim id As Integer
            id = _mobjdataAccess.Add(localtable)
            If BllConfig.retrieveTracingStatus = True Then

                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                id = localtable.id
                With audit
                    .idRecord = id
                    .sezione = "Focolaio"
                    .tipo_operazione = "Inserimento"
                    .categoria = "Focolaio"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
            End If
            Return id
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub Update(ByVal localtable As Focolaio)
        Try
            Dim mobjProfilo As New DalProfilo

            Dim profilo As Utenti_Profilo = mobjProfilo.GetByUsername(_username)

            localtable.idAslNotifica = profilo.idAsl
            '   localtable.idRegione = profilo.idRegione
            _mobjdataAccess.Update(localtable)
            If BllConfig.retrieveTracingStatus = True Then
                Dim id As Integer
                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                id = localtable.id
                With audit
                    .idRecord = id
                    .sezione = "Focolaio"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "Focolaio"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Delete(ByVal id As Integer)
        Try
            _mobjdataAccess.Delete(id)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetFromId(ByVal id As Integer) As Focolaio
        Try
            If BllConfig.retrieveTracingStatus = True Then
                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = id
                    .sezione = "Focolaio"
                    .tipo_operazione = "visualizzazione"
                    .categoria = "Focolaio"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
            End If
            Return _mobjdataAccess.GetFromId(id)            
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetLista(ByVal idMalattia As Nullable(Of Integer), _
                             ByVal idComune As String, _
                             ByVal dataNotificaDa As Nullable(Of Date), _
                             ByVal dataNotificaA As Nullable(Of Date), _
                             ByVal dataSegnalazioneDa As Nullable(Of Date), _
                             ByVal dataSegnalazioneA As Nullable(Of Date), _
                             Optional ByVal idAslNotifica As String = Nothing, _
                             Optional ByVal IdRegione As String = Nothing, _
                             Optional ByVal Username As String = Nothing, _
                             Optional ByVal UsernameMedico As String = Nothing) As List(Of Focolaio_ListaResult)
        Try

            'Dim mobjProfilo As New DalProfilo

            'Dim profilo As Utenti_Profilo = mobjProfilo.GetByUsername(_username)

            Return _mobjdataAccess.GetLista(idMalattia, _
                                                     idComune, _
                                                     dataNotificaDa, _
                                                     dataNotificaA, _
                                                     dataSegnalazioneDa, _
                                                     dataSegnalazioneA, _
                                                     idAslNotifica, _
                                                     IdRegione, _
                                                     Username, _
                                                     UsernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetElenco(Optional ByVal stato As String = Nothing, _
                                                Optional ByVal idMalattia As Nullable(Of Integer) = Nothing, _
                                                Optional ByVal NotificatoDa As String = Nothing, _
                                                Optional ByVal idComuneResidenza As String = Nothing, _
                                                Optional ByVal Criterio As String = Nothing, _
                                                Optional ByVal DataDa As Nullable(Of Date) = Nothing, _
                                                Optional ByVal DataA As Nullable(Of Date) = Nothing, _
                                                Optional ByVal Asl As String = Nothing, _
                                                Optional ByVal idRegione As String = Nothing) As List(Of Focolaio_ElenchiResult)

        If IsNothing(DataDa) Then
            DataDa = "01/01/1900"
        End If

        If IsNothing(DataA) Then
            DataA = Now.ToShortDateString
        End If

        Dim str As New System.Text.StringBuilder

        str.Append(" SELECT ")
        str.Append("mal.DescrizioneBreve as malattia")
        str.Append(",reg.descrizione as regione")
        str.Append(",prov.descrizione as Provincia")
        str.Append(",com.descrizione as Comune")
        str.Append(",Comunita.DescrizioneBreve as Comunita")
        str.Append(",PersoneRischio ")
        str.Append(",Indirizzo")
        str.Append(",Telefono")
        str.Append(",age.descrizione as agente")
        str.Append(",AgenteStato as agenteIdentificato")
        str.Append(",vei.descrizione as Veicolo")
        str.Append(",VeicoloStato as veicoloIdentificato")
        str.Append(",durata")
        str.Append(",NumeroCasi")
        str.Append(",LuogoOrigine")
        str.Append(",dataInizio")
        str.Append(",DataSegnalazione ")
        str.Append(",DataNotifica ")
        str.Append(",Stato ")
        str.Append(" FROM dbo.Focolaio ")
        str.Append(" INNER Join ")
        str.Append(" dbo.GEo_Regioni as reg ")
        str.Append(" ON dbo.Focolaio.IdRegione = reg.idRegione ")
        str.Append(" INNER JOIN dbo.Geo_Province prov ")
        str.Append(" ON dbo.Focolaio.idProvincia = prov.idProvincia ")
        str.Append(" INNER JOIN dbo.Geo_Comuni com ")
        str.Append(" ON dbo.Focolaio.idComune = com.CodiceComune")
        str.Append(" INNER JOIN dbo.Malattie mal ")
        str.Append(" ON dbo.Focolaio.idMalattia = mal.id_malattia ")
        str.Append(" INNER JOIN dbo.comunita ")
        str.Append(" ON dbo.Focolaio.idComunita = comunita.codice")
        str.Append(" LEFT JOIN dbo.Agente_Eziologico age ")
        str.Append(" ON dbo.Focolaio.IdAgente = age.codice	 ")
        str.Append(" LEFT JOIN dbo.veicolo vei ")
        str.Append(" ON dbo.Focolaio.Idveicolo = vei.Codice ")

        str.Append(BizClass.FocolaioFilterQueryBuilder(Criterio, _
                                                 DataDa, _
                                                 DataA, _
                                                 NotificatoDa, _
                                                 Asl, _
                                                 idRegione, _
                                                 idComuneResidenza,
                                                 idMalattia, _
                                                 stato))

        Dim rs As List(Of Focolaio_ElenchiResult) = _mobjdataAccess.GetElenchi(str.ToString)


        Return rs


    End Function

    Public Function GetFocolaioView(ByVal id As Integer) As Focolaio_ViewResult
        Try
            Return _mobjdataAccess.GetFocoalioView(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub cambiaStato(ByVal id As Integer, ByVal stato As String)
        Try
            _mobjdataAccess.CambiaStato(id, stato)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportData(Optional ByVal idRegione As String = Nothing, Optional ByVal idAsl As String = Nothing) As List(Of Focolaio_EsportaResult)
        Try
            Return _mobjdataAccess.ExportData(idRegione, idAsl)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Focolaio_export(Optional ByVal idRegionea As String = Nothing, _
                                    Optional ByVal idAsl As String = Nothing, _
                                    Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                    Optional ByVal username As String = Nothing, _
                                    Optional ByVal usernamMedico As String = Nothing) As List(Of Focolaio_exportResult)
        Try
            Return _mobjdataAccess.ExportFocolaio(idRegionea, idAsl, anno, username, usernamMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetInfo(ByVal id As Integer) As Focolaio_InfoResult
        Try
            Return _mobjdataAccess.GetInfo(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
