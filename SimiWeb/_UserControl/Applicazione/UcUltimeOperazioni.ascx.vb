Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcUltimeOperazioni
    Inherits System.Web.UI.UserControl
    Private _mobjAudit As New BllAudit
    Private _username As String
    Private _id As Integer = 0
    Public Property username As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Bind()
        End If
    End Sub
    Private Sub Bind()
        lst.DataSource = _mobjAudit.Log_Auditing_retrieve_by_username(_username)
        lst.DataBind()
    End Sub
    Protected Sub lst_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lst.ItemCommand
        Dim config As New BllConfig
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        _id = CInt(lst.DataKeys(dataItem.DisplayIndex).Values(1))


        Dim categoria As String = lst.DataKeys(dataItem.DisplayIndex).Values(3).ToString
        Dim sezione As String = lst.DataKeys(dataItem.DisplayIndex).Values(2).ToString

        If e.CommandName = "sel" Then
            If LCase(categoria) = "notifica" Then
                Session("idNotifica") = _id
                Response.Redirect(config.retrievePathLastOperation(categoria, sezione), True)

            End If
            If LCase(categoria) = "focolaio" Then
                Session("idFocolaio") = _id
                Response.Redirect(config.retrievePathLastOperation(categoria, sezione), True)

            End If
        End If
    End Sub

    Protected Sub lst_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lst.ItemDataBound
        Dim dataItem As ListViewDataItem = DirectCast(e.Item, ListViewDataItem)

        'vista_questionari item = (vista_questionari)dataItem.DataItem;
        Dim item As Log_Auditing_retrieve_by_usernameResult = DirectCast(dataItem.DataItem, Log_Auditing_retrieve_by_usernameResult)

        If Not IsNothing(item.lastUser) Then
            If item.username <> item.lastUser Then
                Dim riga As HtmlTableRow = DirectCast(e.Item.FindControl("riga"), HtmlTableRow)
                riga.BgColor = "FFD7D1"
            Else
                Dim lblLastUser As Label = DirectCast(e.Item.FindControl("effettuataLabel"), Label)
                lblLastUser.Text = ""
            End If
        End If



    End Sub
End Class
