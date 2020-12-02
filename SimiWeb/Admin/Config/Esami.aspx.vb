Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Admin_Config_Esami
    Inherits System.Web.UI.Page
    Private _mobjEsami As New BllEsami
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaCombo()
            BindView()
        End If
    End Sub
    Private Sub BindView()
        lstEsami.DataSource = _mobjEsami.GetViewAgente_Metodo_Materiale
        lstEsami.DataBind()
    End Sub
    Private Sub CaricaCombo()
        agente.DataSource = _mobjEsami.GetAllAgenteJson
        agente.DataTextField = "Descrizione"
        agente.DataValueField = "Codice"
        agente.DataBind()
        materiale.DataSource = _mobjEsami.GetAllMaterialeJson
        materiale.DataTextField = "Descrizione"
        materiale.DataValueField = "Codice"
        materiale.DataBind()
        metodo.DataSource = _mobjEsami.GetAllMetodoJson
        metodo.DataTextField = "Descrizione"
        metodo.DataValueField = "Codice"
        metodo.DataBind()
    End Sub

    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Dim localTable As New Agente_Metodo_Materiale
        localTable.IdAgente = agente.SelectedValue
        localTable.IdMateriale = materiale.SelectedValue
        localTable.IdMetodo = metodo.SelectedValue
        localTable.IdMalattia = 0
        Try
            _mobjEsami.AddAgente_Metodo_Materiale(localTable)
            BindView()
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub lstEsami_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstEsami.ItemCommand

        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer = lstEsami.DataKeys(dataItem.DisplayIndex).Values(0)

        If e.CommandName = "Elimina" Then
            _mobjEsami.DeleteAgente_Metodo_Material(id)

        End If
        BindView()
    End Sub
End Class
