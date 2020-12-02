Imports Simiweb.BusinessFacade
Imports System.Data.Linq
Imports DevExpress.Utils
Imports DevExpress.XtraPrinting
Imports DevExpress.Charts.Native
Imports DevExpress.XtraPrintingLinks
Imports Simiweb.DataLinq

Partial Class Notifica_AnalisiReport
    Inherits System.Web.UI.Page
    Private _mobjAnalisi As New BllAnalisi
    Private _MyDataDa As Nullable(Of Date) = Nothing
    Private _MyDataA As Nullable(Of Date) = Nothing
    Private _MydataRiferimento As String = Nothing
    Private _MyProvenienza As String = Nothing
    Private _idAsl As String = Nothing
    Private _idRegione As String = Nothing

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

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            impostaCampi()
            Dim mobjProfilo As New BllUser
            Dim profilo As Utenti_Profilo = mobjProfilo.GetProfiloByUsername(User.Identity.Name)
            _idAsl = profilo.idAsl
            _idRegione = profilo.idRegione
            dataDa.Text = Request.QueryString("dataDa")
            dataA.Text = Request.QueryString("dataA")
            Dim criterio = Request.QueryString("criterio")
            Dim prov As String = Request.QueryString("provenienza")
            Select Case prov
                Case "1"
                    Provenienza.Text = "Notificati da questa asl"
                Case "2"
                    Provenienza.Text = "Residenti in questa asl ma segnalate da altre asl"
                Case "3"
                    Provenienza.Text = "Notificati e residenti in questa asl"                    
            End Select


            Select Case criterio
                Case "1"
                    dataRiferimento.Text = "data inizio sintomi/data segnalazione"
                Case "2"
                    dataRiferimento.Text = "data segnalazione"
                Case "3"
                    dataRiferimento.Text = "data notifica/data segnalazione"
                Case "4"
                    dataRiferimento.Text = "data inizio sintomi"
                Case "5"
                    dataRiferimento.Text = "data notifica"
            End Select

            'ObjAnalisiDs.TypeName = "Simiweb.BusinessFacade.BllAnalisi"
            'ObjAnalisiDs.SelectMethod = "GetAnalisiStandard2"
            ObjAnalisiDs.SelectParameters.Add("NotificatoDa", TypeCode.String, Helper.ConvertEmptyStringToNothing(prov))
            ObjAnalisiDs.SelectParameters.Add("Criterio", TypeCode.String, Helper.ConvertEmptyStringToNothing(criterio))
            ObjAnalisiDs.SelectParameters.Add("DataDa", TypeCode.DateTime, Helper.ConvertEmptyDateToNothing(dataDa.Text))
            ObjAnalisiDs.SelectParameters.Add("DataA", TypeCode.DateTime, Helper.ConvertEmptyDateToNothing(dataA.Text))
            ObjAnalisiDs.SelectParameters.Add("Asl", TypeCode.String, _idAsl)
            ObjAnalisiDs.SelectParameters.Add("idRegione", TypeCode.String, _idRegione)
            'ObjAnalisiDs.Select()

            'ObjAnalisiDs.DataBind()

        End If
    End Sub
    Private Sub impostaCampi()


        If User.IsInRole("regione") Then
            filter_asl.Visible = True
        End If
    End Sub
    Private Sub Export(ByVal saveAs As Boolean)

        gridExport.OptionsPrint.PrintHeadersOnEveryPage = checkPrintHeadersOnEveryPage.Checked
        If checkPrintFilterHeaders.Checked Then
            gridExport.OptionsPrint.PrintFilterHeaders = True
        Else
            gridExport.OptionsPrint.PrintFilterHeaders = False
        End If
        If checkPrintColumnHeaders.Checked Then
            gridExport.OptionsPrint.PrintColumnHeaders = True
        Else
            gridExport.OptionsPrint.PrintColumnHeaders = False
        End If
        If checkPrintRowHeaders.Checked Then
            gridExport.OptionsPrint.PrintRowHeaders = True
        Else
            gridExport.OptionsPrint.PrintRowHeaders = False
        End If
        If checkPrintDataHeaders.Checked Then
            gridExport.OptionsPrint.PrintDataHeaders = True
        Else
            gridExport.OptionsPrint.PrintDataHeaders = False
        End If

        Dim fileName As String = "Simiweb Report"

        gridExport.OptionsPrint.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated

        Select Case listExportFormat.SelectedIndex
            Case 0

                gridExport.ExportPdfToResponse(fileName, saveAs)
            Case 1
                gridExport.ExportXlsToResponse(fileName, saveAs)
            Case 2
                gridExport.ExportMhtToResponse(fileName, "utf-8", "Report simiweb", True, saveAs)
            Case 3
                gridExport.ExportRtfToResponse(fileName, saveAs)
            Case 4
                gridExport.ExportTextToResponse(fileName, saveAs)
            Case 5 ' TODO
                gridExport.ExportHtmlToResponse(fileName, "utf-8", "Report simiweb", True, saveAs)
        End Select
    End Sub

    Protected Sub buttonSaveAs_Click(sender As Object, e As System.EventArgs) Handles buttonSaveAs.Click
        Export(True)
    End Sub

    Protected Sub reset_Click(sender As Object, e As System.EventArgs) Handles reset.Click
        '        <dx:PivotGridField Area="RowArea" AreaIndex="0" FieldName="malattia" Caption="Malattia" ID="Row_Malattia"></dx:PivotGridField>
        '<dx:PivotGridField Area="DataArea" AreaIndex="0" FieldName="malattia" Caption="Malattia" ID="Area_Malattia" SummaryType="Count"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="0" FieldName="sesso" Caption="sesso" ID="Filter_Sesso"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="1" FieldName="Classificazione" Caption="Classificazione" ID="filter_classificazione"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="2" FieldName="classe" Caption="Classe eta (4 range)" ID="filter_classe"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="3" FieldName="classe2" Caption="Classe eta (6 range)" ID="filter_classe2"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="4" FieldName="comune" Caption="Comuni" ID="filter_Comuni"></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="5" FieldName="TrendSintomi" Caption="Data sintomi"  ID="filter_primiSintomi" ></dx:PivotGridField>
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="6" FieldName="TrendNotifica" Caption="Data Notifica"   ID="filter_dataNotifica" ></dx:PivotGridField>                              
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="7" FieldName="Stato" Caption="Stato"  ID="filter_stato" ></dx:PivotGridField>  
        '<dx:PivotGridField Area="FilterArea"  AreaIndex="8" FieldName="aslNotifica" Caption="Asl notifica"  ID="filter_asl" Visible="False" ></dx:PivotGridField>  

        grid.BeginUpdate()

        grid.Fields("malattia").Area = DevExpress.XtraPivotGrid.PivotArea.RowArea
        grid.Fields("malattia").AreaIndex = 0



        grid.Fields("sesso").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("sesso").AreaIndex = 0

        grid.Fields("Classificazione").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("Classificazione").AreaIndex = 1

        grid.Fields("classe").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("classe").AreaIndex = 2

        grid.Fields("classe2").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("classe2").AreaIndex = 3

        grid.Fields("comune").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("comune").AreaIndex = 4

        grid.Fields("TrendSintomi").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("TrendSintomi").AreaIndex = 5

        grid.Fields("TrendNotifica").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("TrendNotifica").AreaIndex = 6

        grid.Fields("Stato").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("Stato").AreaIndex = 7

        grid.Fields("aslNotifica").Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea
        grid.Fields("aslNotifica").AreaIndex = 8


        grid.EndUpdate()
    End Sub
End Class
