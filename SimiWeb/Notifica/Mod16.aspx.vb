Imports FlexCel.Core
Imports FlexCel.XlsAdapter
Imports System.IO
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports FlexCel.Render
Imports FlexCel.Pdf
Imports System.Globalization
Partial Class Notifica_Mod16
    Inherits System.Web.UI.Page
    Private _mobjAnalisi As New BllAnalisi
    Private _idAsl As String = Nothing
    Private _idRegione As String = Nothing
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
    Private Sub BindAnno()

        Dim annoCorrente As Integer = DatePart(DateInterval.Year, Now())

        For i = 2008 To annoCorrente
            anno.Items.Add(New ListItem(i.ToString, i.ToString))
        Next


    End Sub

    Private Sub AddData(Xls As ExcelFile)
        Xls.NewFile(1, TExcelFileFormat.v2003)


        Dim exp As List(Of Analisi_Mod16Result) = _mobjAnalisi.GetMod16(_idRegione, _
                                                                          _idAsl, _
                                                                          Helper.ConvertIntegerToNothing(anno.SelectedValue), _
                                                                          Helper.ConvertIntegerToNothing(mese.SelectedValue))


        Dim x As Integer = 1
        Dim y As Integer = 1

        Xls.SetPrintMargins(New TXlsMargins(0.25, 0.75, 0.25, 0.75, 0.29999999999999999, 0.29999999999999999))
        Xls.PrintXResolution = 65533
        Xls.PrintYResolution = 65533
        Xls.PrintOptions = TPrintOptions.None
        Xls.PrintPaperSize = TPaperSize.A4
        Xls.DefaultColWidth = 2925
        Xls.SetColWidth(1, 10861)

        Dim ColFmt As TFlxFormat


        Xls.SetCellValue(x, 1, "Malattia")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(2))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 2, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 2, "M_0_14")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(3))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 3, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 3, "F_0_14")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(4))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 4, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 4, "M_15_24")


        ColFmt = Xls.GetFormat(Xls.GetColFormat(5))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 5, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 5, "F_15_24")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(6))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 6, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 6, "M_25_64")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(7))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 7, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 7, "F_25_64")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(8))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 8, Xls.AddFormat(ColFmt))
        Xls.SetCellValue(x, 8, "M_64>>")

        ColFmt = Xls.GetFormat(Xls.GetColFormat(9))
        ColFmt.HAlignment = THFlxAlignment.right
        Xls.SetCellFormat(x, 9, Xls.AddFormat(ColFmt))

        Xls.SetCellValue(x, 9, "F_64>>")



        x = x + 1

        '  Dim fmtData As TFlxFormat



        Dim data As New Date(2010, 1, 1)
        For Each row As Analisi_Mod16Result In exp
            Xls.SetCellValue(x, 1, row.malattia)
            Xls.SetCellValue(x, 2, row.M_0_14)
            Xls.SetCellValue(x, 3, row.F_0_14)
            Xls.SetCellValue(x, 4, row.M_15_24)
            Xls.SetCellValue(x, 5, row.F_15_24)
            Xls.SetCellValue(x, 6, row.M_25_64)
            Xls.SetCellValue(x, 7, row.F_25_64)
            Xls.SetCellValue(x, 8, row.M_64__)
            Xls.SetCellValue(x, 9, row.F_64__)




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
                Pdf.ExportAllVisibleSheets(False, "Mod16")
                Pdf.EndExport()

                SendToBrowser(PdfStream, "application/pdf", "Mod16.pdf")
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
            SendToBrowser(XlsStream, "application/excel", "Mod16.xls")
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
            SendToBrowser(XlsStream, "text/csv", "Mod16.csv")
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

                Pdf.ExportAllVisibleSheets(False, "Mod16")
                Pdf.EndExport()

                SendToBrowser(PdfStream, "application/pdf", "Mod16.pdf")
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
            Dim mobjProfilo As New BllUser
            Dim profilo As Utenti_Profilo = mobjProfilo.GetProfiloByUsername(User.Identity.Name)
            _idAsl = profilo.idAsl
            _idRegione = profilo.idRegione
            BindAnno()
        End If

    End Sub
End Class
