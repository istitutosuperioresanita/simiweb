Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllMib
    Inherits BusinessFacade.BizClass
    Private mobjdataAccess As New DAlMib
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
    Public Function GetMib(ByVal idNotifica As Integer) As Notifica_MIB
        Try

            'If BllConfig.retrieveTracingStatus = True Then

            '    Dim mobjAudit As New BllAudit
            '    Dim audit As New Audit
            '    With audit
            '        .idRecord = idNotifica
            '        .sezione = "Notifica"
            '        .tipo_operazione = "Visualizza"
            '        .categoria = "Specifiche Mib"
            '        .username = _username
            '        .Record = _record
            '        .data = Date.Now
            '    End With
            '    mobjAudit.Add(audit)
            'End If

            Return mobjdataAccess.GetMib(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMibView(ByVal idNotifica As Integer) As notifica_View_mibResult
        Try
            Return mobjdataAccess.GetMibView(idNotifica)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function notificabile(ByVal idNotifica As Integer, ByRef errorLista As List(Of String)) As Boolean

        Try
            'Dim xelement As XElement = xelement.Load()
            'Dim employees As IEnumerable(Of XElement) = xelement.Elements()
            '' Read the entire XML
            'For Each employee In employees
            '    '  Console.WriteLine(employee)
            'Next employee


            Dim mib As Notifica_MIB = mobjdataAccess.GetMib(idNotifica)
            Dim lista As New List(Of String)
            Dim isnotificabile As Boolean = True
            Dim sorveglianza = True
            If Not mib Is Nothing Then


                With mib

                    'campi obbligatoi

                    If (.Metodo1 = "") Then
                        lista.Add("Inserire almeno un metodo diagnostico (sez. MIB) <br />")
                        isnotificabile = False
                    End If

                    If (.Materiale1 = "") Then
                        lista.Add("Inserire almeno un materiale (sez. MIB)  <br />")
                        isnotificabile = False
                    End If

                    If (.Qc_Sepsi = "no" And .Qc_Meningite = "no" And .QC_Cellulite = "no" And .QC_Epiglottite = "no" And .QC_Peritonite = "no" And .QC_Pericardite = "no" And .QC_Artrite = "no" And .Qc_Polmonite = "no") Then
                        lista.Add("Inserire almeno un quadro clinico (sez. MIB)  <br />")
                        isnotificabile = False
                    End If

                    '#################################################
                    '################controlli########################
                    '#################################################

                    ' If .IdAgenteEziologico = "000000" And .Liquor = "4" Then ' agente non identificato
                    ' lista.Add("Caso non conforme per la sorveglianza Italiana in quanto l' agente non è identificato ed il liquor è limpido, contattare ISS per maggiori informazioni (sez. MIB)  <br />")
                    'sorveglianza = False
                    'End If


                    'Polmonite
                    Dim polominite As Boolean = False
                    If .Qc_Sepsi = "no" And .Qc_Meningite = "no" And .QC_Cellulite = "no" And .QC_Epiglottite = "no" And .QC_Peritonite = "no" And .QC_Pericardite = "no" And .QC_Artrite = "no" And .Qc_Polmonite = "si" Then
                        sorveglianza = True

                    End If

                    Dim materiale As Boolean = False

                    If (.Materiale1 = "Sangue" Or .Materiale1 = "Liquor" Or .Materiale1 = "Liquido pleurico" Or _
                        .Materiale2 = "Sangue" Or .Materiale2 = "Liquor" Or .Materiale2 = "Liquido pleurico") Then
                        materiale = True

                    End If

                    If polominite = True And materiale = False Then
                        lista.Add("Attenzione non è possibile salvare il caso in quanto se quadro clinico è polmonite il materiale di isolamento deve essere sangue,liquor o Liquido pleurico, contattare ISS per maggiori informazioni (sez. MIB) <br />")
                        isnotificabile = False
                    End If

                End With
            Else
                isnotificabile = False
                lista.Add("Inserire almeno un metodo diagnostico (sez. MIB) <br />")
                lista.Add("Inserire almeno un materiale (sez. MIB)  <br />")
                lista.Add("Inserire almeno un quadro clinico (sez. MIB)  <br/>")
                lista.Add("Per notificare compilare almeno i seguenti campi :<br/>")
            End If

            errorLista = lista
            Return isnotificabile
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Add(ByVal localtable As Notifica_MIB) As Integer
        Try

            Dim id As Integer
            id = mobjdataAccess.Add(localtable)
            Dim mobjAudit As New BllAudit
            Dim info As Notifica_InfoResult = mobjdataNotifica.GetInfo(localtable.idNotifica)
            If BllConfig.retrieveTracingStatus = True Then
                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "mib"
                    .tipo_operazione = "Inserimento"
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
                            ''Dim audit As New Audit
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
            Return localtable.id

        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Update(ByVal localtable As Notifica_MIB)
        Try
            Dim id As Integer
            id = localtable.idNotifica
            mobjdataAccess.Update(localtable)


            Dim info As Notifica_InfoResult = mobjdataNotifica.GetInfo(localtable.idNotifica)


            Dim mobjAudit As New BllAudit

            If BllConfig.retrieveTracingStatus = True Then

                Dim audit As New Audit
                With audit
                    .idRecord = localtable.idNotifica
                    .sezione = "mib"
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
                            'Dim auditNot As New Audit
                            With audit
                                .idRecord = localtable.idNotifica
                                .sezione = "mib"
                                .tipo_operazione = "aggiornamento"
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
            'Dim service As New BllExtService
            'service.UpdateMibToMib(localtable)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function ExportMib(ByVal idRegione As String, _
                              ByVal idAsl As String, _
                              ByVal anno As Nullable(Of Integer), _
                              Optional ByVal username As String = Nothing, _
                              Optional ByVal usernameMedico As String = Nothing) As List(Of Notifica_Mib_EsportaResult)
        Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
            Return ObjDataContext.Notifica_Mib_Esporta(idRegione, idAsl, anno, username, usernameMedico).ToList
        End Using
    End Function
End Class
