Imports System.Collections.Generic
Imports System.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports Simiweb.BusinessFacade
Imports FlexCel.Core
Imports Helper
Partial Class Admin_Config_Referenti_Lista
    Inherits System.Web.UI.Page
    Private _idRegione As String = ""
    Private _idMedico As Integer = 0
    Private _mobjMedico As New BllMedico
    Private _mobjUtenti As New BllUser
    Private _mobjGeo As New BllGeografiche
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idRegione", _idRegione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idRegione = ViewState("_idRegione")
    End Sub
    Private Sub bindView()
        lstMedici.DataSource = _mobjMedico.GetAllMedicoByIdRegione(regione.SelectedValue)
        lstMedici.DataBind()
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ImpostaCampi()
        End If
    End Sub
    Private Sub ImpostaCampi()
        Dim regioniDs As List(Of JsonDto) = _mobjGeo.GetAllRegioniJson

        Carica(regione, regioniDs)
        ' CaricaAsl(regione.SelectedValue)

    End Sub
    Private Sub Carica(ByRef ctr As DropDownList, ByVal dts As List(Of JsonDto), Optional ByVal sel As String = "")
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = dts
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
        If sel <> "" Then
            ctr.SelectedValue = sel
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

    Protected Sub regione_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles regione.SelectedIndexChanged

        bindView()
    End Sub
    'Private Sub CaricaAsl(ByVal idRegione As String)
    '    Dim aslDs As List(Of JsonDto) = _mobjGeo.GetAllAslByIdRegioneJson(idRegione)
    '    Carica(asl, aslDs)
    'End Sub

    Protected Sub cerca_Click(sender As Object, e As System.EventArgs) Handles cerca.Click
        bindView()
    End Sub

End Class
