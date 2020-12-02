Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports Helper
Partial Class Admin_User_Lista
    Inherits System.Web.UI.Page
    Dim _MobjGeografiche As New BllGeografiche
    Dim _mobjUtenti As New BllUser
    Dim _user As String = ""

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            BindRoles()
            CaricaRegioni(regione)
            'bindLista()
        End If
    End Sub
    Private Sub bindLista()
        lstUtenti.DataSource = _mobjUtenti.GetProfilesView(ConvertEmptyStringToNothing(regione.SelectedValue), _
                                                           Nothing, _
                                                           ConvertEmptyStringToNothing(email.Text), _
                                                           ConvertEmptyStringToNothing(nome.Text), _
                                                           ConvertEmptyStringToNothing(cognome.Text), _
                                                           ConvertEmptyStringToNothing(ruolo.SelectedValue))
        lstUtenti.DataBind()
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
    Protected Sub lstUtenti_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstUtenti.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim username As String = lstUtenti.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "aggiorna" Then
            Session("username") = username
            Response.Redirect("edit.aspx", True)
        End If
        If e.CommandName = "elimina" Then
            Dim user As MembershipUser = Membership.GetUser(username)
            user.IsApproved = False
            Membership.UpdateUser(user)
            lstUtenti.DataBind()
        End If
    End Sub

    Protected Sub pager_PreRender(sender As Object, e As System.EventArgs) Handles pager.PreRender
        bindLista()
    End Sub

    Protected Sub cerca_Click(sender As Object, e As System.EventArgs) Handles cerca.Click
        pager.SetPageProperties(0, pager.MaximumRows, False)
    End Sub
    Protected Sub lstUtenti_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lstUtenti.ItemDataBound

        Dim imgDelete As ImageButton = e.Item.FindControl("imgDelete")
        imgDelete.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà eliminato, proseguire ?');"

    End Sub
End Class
