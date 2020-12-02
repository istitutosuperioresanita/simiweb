Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Messagi_Box
    Inherits System.Web.UI.Page
    Private _mobjMEssaggio As New BllMessaggio
    Private _tipoOperazione As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then


            _tipoOperazione = Request.QueryString("tipo")

            If _tipoOperazione = "inbox" Then
                bindInBox()
            Else
                bindOutBox()
            End If
        End If
    End Sub
    Private Sub bindInBox()
        pnlInbox.Visible = True
        inbox.DataSource = _mobjMEssaggio.GetInboxByUsername(User.Identity.Name)
        inbox.DataBind()
        pnlOutBox.Visible = False
        FunzioneLabel.Text = "Posta arrivata"
    End Sub
    Private Sub bindOutBox()
        pnlInbox.Visible = False
        pnlOutBox.Visible = True
        Outbox.DataSource = _mobjMEssaggio.GetOutboxByUsername(User.Identity.Name)
        Outbox.DataBind()
        FunzioneLabel.Text = "Posta Inviata"
    End Sub
    Protected Sub Outboxe_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles Outbox.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer
        id = Outbox.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "view" Then
            Session("idMessaggio") = id
            Response.Redirect("View.aspx")
        End If
        If e.CommandName = "elimina" Then
            _mobjMEssaggio.Delete(id)
            bindOutBox()
        End If
    End Sub
    Protected Sub inbox_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles inbox.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer
        id = inbox.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "view" Then
            Session("idMessaggio") = id
            Response.Redirect("View.aspx")
        End If
        If e.CommandName = "elimina" Then
            _mobjMEssaggio.Delete(id)
            bindOutBox()
        End If
    End Sub
End Class
