Imports FlexCel.Core
Imports FlexCel.XlsAdapter
Imports System.IO
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports FlexCel.Render
Imports FlexCel.Pdf
Imports System.Globalization

Partial Class Notifica_Elenchi
    Inherits System.Web.UI.Page
    Private _mobjNotifica As New BllNotifica
    Private _mobjMalattie As New BllMalattie
    Private _mobjGeografiche As New BllGeografiche
    Private _idAsl As String = Nothing
    Private _idRegione As String = Nothing
    Private _ruolo As String = ""
    Private _username As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_ruolo", _ruolo)
        Me.ViewState.Add("_username", _username)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idAsl = ViewState("_idAsl")
        _idRegione = ViewState("_idRegione")
        _ruolo = ViewState("_ruolo")
        _username = ViewState("_username")

    End Sub
    Protected Sub btnExcel_Click(sender As Object, e As System.EventArgs) Handles btnExcel.Click
        CreaExcel()
    End Sub

    Private Sub AddData(Xls As ExcelFile)
        If _ruolo = "admin" Or _ruolo = "regione" Or _ruolo = "laboratorio" Then
            Xls.NewFile(1, TExcelFileFormat.v2007)
        Else
            Xls.NewFile(1, TExcelFileFormat.v2003)
        End If
        Xls.PrintXResolution = 600
        Xls.PrintYResolution = 600
        Xls.PrintOptions = TPrintOptions.None
        Xls.PrintPaperSize = TPaperSize.A4



        Dim all As Boolean = False

        Dim exp As List(Of Notifica_ElenchiResult) = _mobjNotifica.GetElenchi(Helper.ConvertEmptyStringToNothing(stato.SelectedValue), _
                                                                                    Helper.ConvertIntegerToNothing(Malattie.SelectedValue), _
                                                                                    Helper.ConvertEmptyStringToNothing(provenienza.SelectedValue), _
                                                                                    Helper.ConvertEmptyStringToNothing(comune.SelectedValue), _
                                                                                    Helper.ConvertEmptyStringToNothing(criterio.SelectedValue), _
                                                                                    Helper.ConvertEmptyDateToNothing(dataDa.Text), _
                                                                                    Helper.ConvertEmptyDateToNothing(dataA.Text), _
                                                                                    Helper.ConvertEmptyStringToNothing(_idAsl), _
                                                                                    Helper.ConvertEmptyStringToNothing(Regione.SelectedValue), _
                                                                                    User.Identity.Name, _
                                                                                    _ruolo)





        Dim x As Integer = 1
        Dim y As Integer = 1


        Xls.SetCellValue(x, 1, "Cognome")
        Xls.SetCellValue(x, 2, "Nome")
        Xls.SetCellValue(x, 3, "Sesso")
        Xls.SetCellValue(x, 4, "data nascita")
        Xls.SetCellValue(x, 5, "malattia")
        Xls.SetCellValue(x, 6, "ICDIX")
        Xls.SetCellValue(x, 7, "Tipo caso")
        Xls.SetCellValue(x, 8, "Com Sintomi")
        Xls.SetCellValue(x, 9, "data primi sintomi")
        Xls.SetCellValue(x, 10, "data segnalazione")
        Xls.SetCellValue(x, 11, "data notifica")
        Xls.SetCellValue(x, 12, "Asl Residenza")
        Xls.SetCellValue(x, 13, "Asl Notifica")
        Xls.SetCellValue(x, 14, "Com Residenza")


        Xls.SetCellValue(x, 15, "Citt Italiana")
        Xls.SetCellValue(x, 16, "Ricovero")
        Xls.SetCellValue(x, 17, "strutturaRicovero")
        Xls.SetCellValue(x, 18, "indirizzoDomicilio")
        Xls.SetCellValue(x, 19, "StatoVaccinale")
        Xls.SetCellValue(x, 20, "ID")

        x = x + 1

        Dim fmtData As TFlxFormat



        Dim data As New Date(2010, 1, 1)
        For Each row As Notifica_ElenchiResult In exp
            Xls.SetCellValue(x, 1, row.Cognome)
            Xls.SetCellValue(x, 2, row.Nome)
            Xls.SetCellValue(x, 3, row.sesso)
            fmtData = Xls.GetCellVisibleFormatDef(x, 4)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 4, Xls.AddFormat(fmtData))
            If IsNothing(row.DataNascita) Then
                Xls.SetCellValue(x, 4, "", Xls.OptionsDates1904)
            Else
                Xls.SetCellValue(x, 4, FlxDateTime.ToOADate(row.DataNascita, Xls.OptionsDates1904))
            End If


            Xls.SetCellValue(x, 5, row.Malattia)
            Xls.SetCellValue(x, 6, row.ICDIX)
            Xls.SetCellValue(x, 7, "")
            Xls.SetCellValue(x, 8, row.ComunePrimiSintomi)

            fmtData = Xls.GetCellVisibleFormatDef(x, 9)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 9, Xls.AddFormat(fmtData))
            If IsNothing(row.DataPrimiSintomi) Then
                Xls.SetCellValue(x, 9, "", Xls.OptionsDates1904)
            Else

                Xls.SetCellValue(x, 9, FlxDateTime.ToOADate(row.DataPrimiSintomi, Xls.OptionsDates1904))
            End If

            fmtData = Xls.GetCellVisibleFormatDef(x, 10)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 10, Xls.AddFormat(fmtData))
            Xls.SetCellValue(x, 10, FlxDateTime.ToOADate(row.dataSegnalazione, Xls.OptionsDates1904))


            fmtData = Xls.GetCellVisibleFormatDef(x, 11)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 11, Xls.AddFormat(fmtData))
            If IsNothing(row.datanotifica) Then
                Xls.SetCellValue(x, 11, "", Xls.OptionsDates1904)
            Else
                Xls.SetCellValue(x, 11, FlxDateTime.ToOADate(row.datanotifica, Xls.OptionsDates1904))
            End If
            Xls.SetCellValue(x, 12, row.AslDiResidenza)
            Xls.SetCellValue(x, 13, row.AslDiNotifica)
            Xls.SetCellValue(x, 14, row.ComuneResidenza)

            Xls.SetCellValue(x, 15, row.Cittadinanza_Italiana)
            Xls.SetCellValue(x, 16, row.ricovero)
            Xls.SetCellValue(x, 17, row.strutturaRicovero)
            Xls.SetCellValue(x, 18, row.indirizzoDomicilio)
            Xls.SetCellValue(x, 19, row.StatoVaccinale)
            Xls.SetCellValue(x, 20, row.id)



            x = x + 1
        Next
    End Sub

    Protected Sub btnReport_Click(sender As Object, e As System.EventArgs) Handles btnReport.Click
        Dim xls As XlsFile = New XlsFile(True)

        AddData(xls)

        'Save the file as Pdf
        Dim Pdf As FlexCelPdfExport = New FlexCelPdfExport(xls, True)
        Try
            Dim PdfStream As MemoryStream = New MemoryStream()
            Try
                Pdf.BeginExport(PdfStream)
                Pdf.PrintRangeLeft = 1
                Pdf.PrintRangeRight = 1
                Pdf.PageLayout = TPageLayout.Outlines
                Pdf.ExportAllVisibleSheets(False, "Report")
                Pdf.EndExport()

                SendToBrowser(PdfStream, "application/pdf", "report.pdf")
            Finally
                PdfStream.Close()
            End Try
        Finally
            Pdf.Dispose()
        End Try
    End Sub
    Private Sub SendToBrowser(OutStream As MemoryStream, MimeType As String, FileName As String)
        Response.Clear()
        Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName)
        Dim MemData As Byte() = OutStream.ToArray()
        Response.AddHeader("Content-Length", Convert.ToString(MemData.Length, CultureInfo.InvariantCulture))
        Response.ContentType = MimeType
        Response.BinaryWrite(MemData)
        Response.End()
    End Sub


    Private Sub CreaExcel()
        Dim xls As XlsFile = New XlsFile(True)
        Dim filename As String = ""
        AddData(xls)
        'Save the file as XLS
        Dim XlsStream As MemoryStream = New MemoryStream()
        Try
            If _ruolo = "admin" Or _ruolo = "regione" Or _ruolo = "laboratorio" Then
                xls.Save(XlsStream, TFileFormats.Xlsx)
                filename = "report.xlsx"
            Else
                xls.Save(XlsStream, TFileFormats.Xls)
                filename = "report.xls"
            End If
            SendToBrowser(XlsStream, "application/excel", filename)
        Finally
            XlsStream.Close()
        End Try
    End Sub
    Private Sub CreaCSv()
        Dim xls As XlsFile = New XlsFile(True)
        AddData(xls)

        'Save the file as CSV (Comma separated values)
        Dim XlsStream As MemoryStream = New MemoryStream()
        Try
            xls.Save(XlsStream, TFileFormats.Text, ";", Encoding.Unicode)
            SendToBrowser(XlsStream, "text/csv", "report.csv")
        Finally
            XlsStream.Close()
        End Try
    End Sub

    Private Sub CreaPdf()
        Dim xls As XlsFile = New XlsFile(True)
        AddData(xls)
        '  xls.PrintOptions = TPrintOptions.Orientation
        'Save the file as Pdf
        xls.PrintNumberOfHorizontalPages = 0

        Dim Pdf As FlexCelPdfExport = New FlexCelPdfExport(xls, True)

        Try
            Dim PdfStream As MemoryStream = New MemoryStream()
            Try
                Pdf.BeginExport(PdfStream)
                Pdf.PageLayout = TPageLayout.Outlines
                Pdf.PrintRangeLeft = 1
                Pdf.PrintRangeRight = 1

                Pdf.ExportAllVisibleSheets(False, "Report")
                Pdf.EndExport()

                SendToBrowser(PdfStream, "application/pdf", "report.pdf")
            Finally
                PdfStream.Close()
            End Try
        Finally
            Pdf.Dispose()
        End Try
    End Sub

    Protected Sub btnCsv_Click(sender As Object, e As System.EventArgs) Handles btnCsv.Click
        CreaCSv()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _username = User.Identity.Name
            Dim mobjProfilo As New BllUser
            Dim profilo As Utenti_Profilo = mobjProfilo.GetProfiloByUsername(_username)
            _idAsl = profilo.idAsl
            _idRegione = profilo.idRegione
            Dim currRoles() As String = Roles.GetRolesForUser(_username)
            _ruolo = LCase(currRoles(0).ToString)

            If _ruolo = "asl" Then
                pnlAsl.Visible = True
            End If


            ImpostaJavascript()

            bind(Malattie, _mobjMalattie.GetAllMalattieJson(BllMalattie.tipo.visualizzabili))
            bind(comune, _mobjGeografiche.GetAllComuniByIdRegioneJson(_idRegione))
            bind(Regione, _mobjGeografiche.GetAllRegioniJson)
            impostacampi()
        End If

    End Sub
    Private Sub impostacampi()
        If LCase(_ruolo) = "iss" Then
            Regione.Enabled = True
            comune.Enabled = False

        Else
            Regione.SelectedValue = _idRegione
            Regione.Enabled = False
        End If
    End Sub
    Private Sub ImpostaJavascript()
        dataDa.Attributes("onblur") = "check_date(this);"
        dataA.Attributes("onblur") = "check_date(this);"
    End Sub
    Private Sub bind(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto))
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataSource = ds
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub

End Class
