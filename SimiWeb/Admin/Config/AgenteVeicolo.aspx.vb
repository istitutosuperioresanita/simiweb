Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Admin_Config_AgenteVeicolo
    Inherits System.Web.UI.Page
    Private _mobjEsami As New BllEsami
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaCombo()
            BindView()
        End If
    End Sub
    Private Sub BindView()
        lstEsami.DataSource = _mobjEsami.GetViewAgente_Veicolo
        lstEsami.DataBind()
    End Sub
    Private Sub CaricaCombo()
        agente.DataSource = _mobjEsami.GetAllAgenteJson
        agente.DataTextField = "Descrizione"
        agente.DataValueField = "Codice"
        agente.DataBind()
        veicolo.DataSource = _mobjEsami.GetAllVeicoloJson
        veicolo.DataTextField = "Descrizione"
        veicolo.DataValueField = "Codice"
        veicolo.DataBind()
    End Sub
    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Dim localTable As New Agente_Veicolo
        localTable.IdAgente = agente.SelectedValue
        localTable.IdVeicolo = veicolo.SelectedValue
        Try
            _mobjEsami.AddAgente_Veicolo(localTable)
            BindView()
        Catch ex As Exception

        End Try

    End Sub
End Class
