Imports FlexCel.Core
Imports FlexCel.XlsAdapter
Imports System.IO
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports FlexCel.Render
Imports FlexCel.Pdf
Imports System.Globalization
Imports Helper
Partial Class Focolaio_Elenchi
    Inherits System.Web.UI.Page
    Private _mobjFocolaio As New BllFocolaio
    Private _mobjMalattie As New BllMalattie
    Private _mobjGeografiche As New BllGeografiche
    Private _mobjUser As New BllUser
    Private _idAsl As String = ""
    Private _idRegione As String = ""
    Public Enum CustomerReportKind
        malattia
    End Enum
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idAsl = ViewState("_idAsl")
        _idRegione = ViewState("_idRegione")

    End Sub
    Protected Sub btnExcel_Click(sender As Object, e As System.EventArgs) Handles btnExcel.Click
        CreaExcel()
    End Sub

    Private Sub AddData(Xls As ExcelFile)
        Xls.NewFile(1, TExcelFileFormat.v2003)


        Dim exp As List(Of Focolaio_ElenchiResult) = _mobjFocolaio.GetElenco(Helper.ConvertEmptyStringToNothing(stato.SelectedValue), _
                                                                                    Helper.ConvertIntegerToNothing(Malattie.SelectedValue), _
                                                                                    "1", _
                                                                                    Helper.ConvertEmptyStringToNothing(comune.SelectedValue), _
                                                                                    Helper.ConvertEmptyStringToNothing(criterio.SelectedValue), _
                                                                                    Helper.ConvertEmptyDateToNothing(dataDa.Text), _
                                                                                    Helper.ConvertEmptyDateToNothing(dataA.Text), _
                                                                                    Helper.ConvertEmptyStringToNothing(_idAsl), _
                                                                                    Helper.ConvertEmptyStringToNothing(_idRegione))

        ' 1= asldi Notifica

        Dim x As Integer = 1
        Dim y As Integer = 1



        Xls.SetCellValue(x, 1, "Malattia")
        Xls.SetCellValue(x, 2, "Regione")
        Xls.SetCellValue(x, 3, "Provincia")
        Xls.SetCellValue(x, 4, "comune")
        Xls.SetCellValue(x, 5, "Comunita")
        Xls.SetCellValue(x, 6, "PersoneRischio")
        Xls.SetCellValue(x, 7, "Indirizzo")
        Xls.SetCellValue(x, 8, "Telefono")
        Xls.SetCellValue(x, 9, "agente")
        Xls.SetCellValue(x, 10, "agenteIdentificato")
        Xls.SetCellValue(x, 11, "Veicolo")
        Xls.SetCellValue(x, 12, "veicoloIdentificato")

        Xls.SetCellValue(x, 13, "durata")
        Xls.SetCellValue(x, 14, "NumeroCasi")
        Xls.SetCellValue(x, 15, "LuogoOrigine")
        Xls.SetCellValue(x, 16, "dataInizio")
        Xls.SetCellValue(x, 17, "DataSegnalazione")
        Xls.SetCellValue(x, 18, "DataNotifica")
        Xls.SetCellValue(x, 19, "stato")


        x = x + 1

        Dim fmtData As TFlxFormat



        Dim data As New Date(2010, 1, 1)
        For Each row As Focolaio_ElenchiResult In exp
            Xls.SetCellValue(x, 1, row.malattia)
            Xls.SetCellValue(x, 2, row.regione)
            Xls.SetCellValue(x, 3, row.Provincia)
            Xls.SetCellValue(x, 4, row.Comune)
            Xls.SetCellValue(x, 5, row.Comunita)
            Xls.SetCellValue(x, 6, row.PersoneRischio)
            Xls.SetCellValue(x, 7, row.Indirizzo)
            Xls.SetCellValue(x, 8, row.Telefono)
            Xls.SetCellValue(x, 9, row.agente)
            Xls.SetCellValue(x, 10, row.agenteIdentificato)
            Xls.SetCellValue(x, 11, row.Veicolo)
            Xls.SetCellValue(x, 12, row.veicoloIdentificato)
            Xls.SetCellValue(x, 13, row.durata)
            Xls.SetCellValue(x, 14, row.NumeroCasi)
            Xls.SetCellValue(x, 15, row.LuogoOrigine)

            fmtData = Xls.GetCellVisibleFormatDef(x, 16)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 16, Xls.AddFormat(fmtData))
            If IsNothing(row.dataInizio) Then
                Xls.SetCellValue(x, 16, "", Xls.OptionsDates1904)
            Else

                Xls.SetCellValue(x, 16, FlxDateTime.ToOADate(row.dataInizio, Xls.OptionsDates1904))
            End If

            fmtData = Xls.GetCellVisibleFormatDef(x, 17)
            fmtData.Format = "dd/mm/YYYY"
            Xls.SetCellFormat(x, 17, Xls.AddFormat(fmtData))
            Xls.SetCellValue(x, 17, FlxDateTime.ToOADate(row.DataSegnalazione, Xls.OptionsDates1904))


            Xls.SetCellFormat(x, 18, Xls.AddFormat(fmtData))
            If IsNothing(row.DataNotifica) Then
                Xls.SetCellValue(x, 18, "", Xls.OptionsDates1904)
            Else
                Xls.SetCellValue(x, 18, FlxDateTime.ToOADate(row.DataNotifica, Xls.OptionsDates1904))
            End If
            Xls.SetCellValue(x, 19, row.Stato)






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
        AddData(xls)
        'Save the file as XLS
        Dim XlsStream As MemoryStream = New MemoryStream()
        Try
            xls.Save(XlsStream)
            SendToBrowser(XlsStream, "application/excel", "report.xls")
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

        'Save the file as Pdf
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
            ImpostaJavascript()

            Dim utente As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)

            _idRegione = utente.idRegione
            _idAsl = utente.idAsl

            bind(Malattie, _mobjMalattie.GetAllMalattieJson(BllMalattie.tipo.focolaio))
            bind(comune, _mobjGeografiche.GetAllComuniByIdRegioneJson(_idRegione))


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
