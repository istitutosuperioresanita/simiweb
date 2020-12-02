Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Helper
Partial Class Admin_Tabelle_Malattie_Lista
    Inherits System.Web.UI.Page
    Private _mobjMalattia As New BllMalattie

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            bindView()
        End If
    End Sub
    Private Sub bindView()
        lstMAlattia.DataSource = _mobjMalattia.GetAllMalattieList(BllMalattie.tipo.valide, ConvertEmptyStringToNothing(malattiatesto.Text))
        lstMAlattia.DataBind()
    End Sub
    Protected Sub btnNuovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNuovo.Click
        Response.Redirect("Add.aspx", True)
    End Sub

    Protected Sub lstMAlattia_ItemCommand(sender As Object, e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstMAlattia.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer = lstMAlattia.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "sel" Then
            Session("Admin_malattia_id") = id
            Response.Redirect("edit.aspx", True)
        End If
    End Sub

    Protected Sub btnCerca_Click(sender As Object, e As System.EventArgs) Handles btnCerca.Click
        bindView()
    End Sub
End Class
