Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Regione_Medici_Lista
    Inherits System.Web.UI.Page
    Private _idRegione As String = ""
    Private _idMedico As Integer = 0
    Private _mobjMedico As New BllMedico
    Private _mobjUtenti As New BllUser
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idRegione", _idRegione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idRegione = ViewState("_idRegione")
    End Sub
    Private Sub bindView()
        lstMedici.DataSource = _mobjMedico.GetAllMedicoByIdRegione(_idRegione)
        lstMedici.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim utenti As Utenti_Profilo = _mobjUtenti.GetProfiloByUsername(User.Identity.Name)
            _idRegione = utenti.idRegione
            bindView()
        End If
    End Sub

    Protected Sub lstMedici_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstMedici.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer
        id = lstMedici.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        _idMedico = id
        If e.CommandName = "aggiorna" Then
            Session("_idMedico") = _idMedico
            Response.Redirect("edit.aspx", True)
        End If
        If e.CommandName = "elimina" Then
            _mobjMedico.Invalida(_idMedico)
            bindView()
        End If

    End Sub

    Protected Sub nuovo_Click(sender As Object, e As System.EventArgs) Handles nuovo.Click
        Session("_idMedico") = 0
        Response.Redirect("edit.aspx", True)
    End Sub
End Class
