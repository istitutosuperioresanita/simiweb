Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllTbc
    Private mobjdataAccess As New DalTbc
    Private mobjdataMail As New DalMessaggio
    Private mobjdataNotifica As New DalNotifica
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
    Public Function GetZoneList(ByVal tipo As Integer) As List(Of JsonDto)
        Try
            Return mobjdataAccess.GetZoneList(tipo)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetTbc(ByVal idNotifica As Integer) As Notifica_Tbc
        Try
            Return mobjdataAccess.GetTbc(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function AddTbc(ByVal localtable As Notifica_Tbc) As Integer
        Try

            Dim id As Integer
            id = mobjdataAccess.AddTbc(localtable)







            Dim info As Notifica_InfoResult = mobjdataNotifica.GetInfo(localtable.idNotifica)
            If BllConfig.retrieveTracingStatus = True Then


                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "tbc"
                    .tipo_operazione = "Inserimento"
                    .categoria = "notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then

                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "mib"
                                .tipo_operazione = "Inserimento"
                                .categoria = "notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
            Return id
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub UpdateTbc(ByVal localtable As Notifica_Tbc)
        Try

            Dim id As Integer
            id = localtable.idNotifica
            mobjdataAccess.UpdateTbc(localtable)
            Dim info As Notifica_InfoResult = mobjdataNotifica.GetInfo(localtable.idNotifica)
            If BllConfig.retrieveTracingStatus = True Then


                Dim mobjAudit As New BllAudit
                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "tbc"
                    .tipo_operazione = "aggiornamento"
                    .categoria = "notifica"
                    .username = _username
                    .Record = _record
                    .data = Date.Now
                End With
                mobjAudit.Add(audit)
                If info.username <> _username Then
                    Dim listaUtentiAsl As List(Of Notifica_mail_cambiamentiResult) = mobjdataMail.GetMailAsl(info.idAslNotifica, info.idAslResidenza)
                    For Each item As Notifica_mail_cambiamentiResult In listaUtentiAsl
                        If item.UserName = info.username Then
                            'Dim audit As New Audit
                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "mib"
                                .tipo_operazione = "Inserimento"
                                .categoria = "notifica"
                                .username = item.UserName
                                .lastUser = _username
                                .Record = _record
                                .data = Date.Now
                                .visionato = 0
                            End With
                            mobjAudit.Add(audit)
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportTbc(Optional ByVal idRegione As String = Nothing, _
                              Optional ByVal idAsl As String = Nothing, _
                              Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                              Optional ByVal username As String = Nothing, _
                              Optional ByVal usernameMedico As String = Nothing) As List(Of tbc_exportResult)
        Try
            Return mobjdataAccess.ExportTBC(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportTbcFattori(Optional ByVal idRegione As String = Nothing, _
                                     Optional ByVal idAsl As String = Nothing, _
                                     Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                     Optional ByVal username As String = Nothing, _
                                     Optional ByVal usernameMedico As String = Nothing) As List(Of tbc_fattori_exportResult)
        Try
            Return mobjdataAccess.ExportTbcFattori(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function ExportMalaria(Optional ByVal idRegione As String = Nothing, _
                                 Optional ByVal idAsl As String = Nothing, _
                                 Optional ByVal anno As Nullable(Of Integer) = Nothing, _
                                 Optional ByVal username As String = Nothing, _
                                 Optional ByVal usernameMedico As String = Nothing) As List(Of malaria_exportResult)
        Try
            Return mobjdataAccess.ExportMalaria(idRegione, idAsl, anno, username, usernameMedico)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
