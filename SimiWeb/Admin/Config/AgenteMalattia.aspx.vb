Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Admin_Config_AgenteMalattia
    Inherits System.Web.UI.Page
    Private _mobjEsami As New BllEsami
    Private _mobjMalattia As New BllMalattie
    Private _idEsame As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaCombo()
            BindView()
        End If
        lblErrore.Visible = False
    End Sub
    Private Sub BindView()
        lstEsami.DataSource = _mobjEsami.GetViewAgente_Malattia
        lstEsami.DataBind()
    End Sub
    Private Sub CaricaCombo()
        agente.DataSource = _mobjEsami.GetAllAgenteJson
        agente.DataTextField = "Descrizione"
        agente.DataValueField = "Codice"
        agente.DataBind()
        malattia.DataSource = _mobjMalattia.GetAllMalattieJson(BllMalattie.tipo.tutte)
        malattia.DataTextField = "Descrizione"
        malattia.DataValueField = "codice"
        malattia.DataBind()
    End Sub
    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Dim localTable As New Agente_Malattia
        localTable.CodiceAgente = agente.SelectedValue
        localTable.IdMalattia = malattia.SelectedValue
        Try
            _mobjEsami.AddAgente_Malattia(localTable)
            BindView()
        Catch ex As Exception
            lblErrore.Text = ex.ToString
            lblErrore.Visible = True
        End Try

    End Sub

    Protected Sub lstEsami_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles lstEsami.ItemDataBound

        Dim imgDelete As ImageButton = e.Item.FindControl("imgDelete")
        imgDelete.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà eliminato, proseguire ?');"
    End Sub

    Protected Sub lstEsami_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstEsami.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        _idEsame = lstEsami.DataKeys(dataItem.DisplayIndex).Value

        If e.CommandName = "elimina" Then
            Try
                _mobjEsami.DeleteAgente_Malattia(_idEsame) '
                BindView()

            Catch ex As Exception
                lblErrore.Visible = True
                lblErrore.Text = ex.ToString
            End Try

        End If
    End Sub
End Class
