Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports Helper
Imports FlexCel.Core
Imports FlexCel.XlsAdapter
Imports System.Data



Partial Class Admin_User_BulkUSer
    Inherits System.Web.UI.Page
    Dim _MobjGeografiche As New BllGeografiche
    Dim _mobjUtenti As New BllUser
    Dim _user As String = ""
    Private _PathUpload As String = "~/public/"
    Private _File As String = ""
    Private _strFilePath As String = ""
    Private _FileInfo As String
    Private _idDipendente As Integer
    Private reportStart As New FlexCel.Report.FlexCelReport

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindRoles()
            CaricaRegioni(regione)
            'bindLista()
        End If
    End Sub
    Private Sub BindRoles()
        ruolo.DataSource = Roles.GetAllRoles
        ruolo.DataBind()
        ruolo.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaRegioni(ByRef ctr As DropDownList)
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = _MobjGeografiche.GetAllRegioniJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    'Private _mob As New BllGravi
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_PathUpload", _PathUpload)
        Me.ViewState.Add("_File", _File)
        Me.ViewState.Add("_strFilePath", _strFilePath)
        Me.ViewState.Add("_FileInfo", _FileInfo)
        Return MyBase.SaveViewState()
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _PathUpload = ViewState("_PathUpload")
        _File = ViewState("_File")
        _strFilePath = ViewState("_strFilePath")
        _FileInfo = ViewState("_FileInfo")
    End Sub

    Protected Sub ButtonUploadFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUploadFile.Click

        If FileUploadExcel.HasFile Then


            Try

                Dim fileinfo As New IO.FileInfo(FileUploadExcel.PostedFile.FileName)
                Dim strCsvFilePath As String = Server.MapPath(_PathUpload) & fileinfo.Name
                FileUploadExcel.SaveAs(strCsvFilePath)


                LabelUpload.Text = "Upload File Name: " & _
                 FileUploadExcel.PostedFile.FileName & "<br>" & _
                 "Type: " & _
                 FileUploadExcel.PostedFile.ContentType & _
                 " File Size: " & _
                 FileUploadExcel.PostedFile.ContentLength & " kb<br>"

                'Dim strFilePath As String = Server.MapPath(_PathUpload)
                _strFilePath = Server.MapPath(_PathUpload)
                _FileInfo = fileinfo.Name

                ImportFile(_strFilePath + _FileInfo, False)
            Catch ex As Exception

            End Try

        End If


    End Sub
    Private Sub ImportFile(FileName As String, Formatted As Boolean)


        Try

            Dim Xls As ExcelFile = New XlsFile()

            Try
                Dim coltypes(6) As ColumnImportType


                Dim i As Integer = 0

                For Each p As ColumnImportType In coltypes
                    p = ColumnImportType.Text
                Next
                Xls.Open(FileName, TFileFormats.Text, ";", 1, 1, coltypes)
            Catch ex As Exception
                lblDisplay.Text = ex.Message
            End Try



           Dim dataset1 As New DataSet

            Dim DataT As New DataTable
            'We will create a DataTable "SheetN" for each sheet on the Excel sheet.
            For sheet As Integer = 1 To Xls.SheetCount
                Xls.ActiveSheet = sheet

                'sheetCombo.Items.Add(Xls.SheetName)

                DataT = dataset1.Tables.Add("Sheet" & sheet.ToString())
                DataT.BeginLoadData()
                Try
                    Dim ColCount As Integer = 6 'Xls.ColCount
                    'Add one column on the dataset for each used column on Excel.
                    For c As Integer = 1 To ColCount
                        'Here we will add all strings, since we do not know what we are waiting for.
                        DataT.Columns.Add(TCellAddress.EncodeColumn(c), GetType([String]))
                    Next

                    Dim dr As String() = New String(ColCount - 1) {}

                    Dim RowCount As Integer = Xls.RowCount
                    For r As Integer = 1 To RowCount
                        Array.Clear(dr, 0, dr.Length)
                        'This loop will only loop on used cells. It is more efficient than looping on all the columns.
                        For cIndex As Integer = Xls.ColCountInRow(r) To 1 Step -1
                            'reverse the loop to avoid calling ColCountInRow more than once.
                            Dim Col As Integer = Xls.ColFromIndex(r, cIndex)

                            If Formatted Then
                                Dim rs As TRichString = Xls.GetStringFromCell(r, Col)
                                dr(Col - 1) = rs.Value
                            Else
                                Dim XF As Integer = 0
                                'This is the cell format, we will not use it here.
                                Dim val As Object = Xls.GetCellValueIndexed(r, cIndex, XF)

                                Dim Fmla As TFormula = TryCast(val, TFormula)
                                If Fmla IsNot Nothing Then
                                    'When we have formulas, we want to write the formula result. 
                                    'If we wanted the formula text, we would not need this part.
                                    dr(Col - 1) = Convert.ToString(Fmla.Result)
                                Else
                                    dr(Col - 1) = Convert.ToString(val)
                                End If
                            End If
                        Next
                        DataT.Rows.Add(dr)
                    Next
                Finally
                    DataT.EndLoadData()
                End Try

                Dim EndFill As DateTime = DateTime.Now

                ' statusBar.Text = [String].Format("Time to load file: {0}    Time to fill dataset: {1}     Total time: {2}", (EndOpen - StartOpen).ToString(), (EndFill - EndOpen).ToString(), (EndFill - StartOpen).ToString())
            Next






            '    DisplayGrid.DataSource = _MobjDipendente.AddOrario(dataset1, _idDipendente)
            DisplayGrid.DataSource = dataset1.Tables(0)
            DisplayGrid.DataBind()
            'sheetCombo.DataBind()
            'sheetCombo.SelectedIndex = 0

            lblDisplay.Text = FileName
        Catch
            lblDisplay.Text = "Error Loading File"
            DisplayGrid.DataSource = Nothing
            DisplayGrid.DataMember = ""
            ' sheetCombo.Items.Clear()
            Throw
        End Try
    End Sub
End Class