Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcNews
    Inherits System.Web.UI.UserControl
    Private _mobjMessaggio As New BllMessaggio
    Private _username As String
    Private _id As Integer = 0
    Private _idRegione As String = Nothing
    Public Property username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Public Property idRegione As String
        Get
            Return _idRegione
        End Get
        Set(ByVal value As String)
            _idRegione = value
        End Set
    End Property


    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Bind()
        End If
    End Sub
    Private Sub Bind()
        lst.DataSource = _mobjMessaggio.GetLatestNews(_idregione)
        lst.DataBind()
    End Sub
    Protected Sub lst_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lst.ItemCommand
        'Dim config As New BllConfig
        'Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        '_id = CInt(lst.DataKeys(dataItem.DisplayIndex).Values(1))


        'Dim categoria As String = lst.DataKeys(dataItem.DisplayIndex).Values(3).ToString
        'Dim sezione As String = lst.DataKeys(dataItem.DisplayIndex).Values(2).ToString

        'If e.CommandName = "sel" Then
        '    If LCase(categoria) = "notifica" Then
        '        Session("idNotifica") = _id
        '        Response.Redirect(config.retrievePathLastOperation(categoria, sezione), True)

        '    End If
        '    If LCase(categoria) = "focolaio" Then
        '        Session("idFocolaio") = _id
        '        Response.Redirect(config.retrievePathLastOperation(categoria, sezione), True)

        '    End If
        'End If
    End Sub

End Class
