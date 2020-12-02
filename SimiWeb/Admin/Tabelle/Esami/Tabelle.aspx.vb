Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Admin_Tabelle_Esami_Tabelle
    Inherits System.Web.UI.Page
    Private _tipoTabella As String = ""
    Private _idElemento As Integer
    Private _mobjEsami As New BllEsami
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idElemento", _idElemento)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idElemento = CInt(ViewState("_idElemento"))
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        _tipoTabella = Request.QueryString("tipo")
        If Not Page.IsPostBack Then
            'pnlDati.Visible = False
            startup()
            BindData(_tipoTabella)
            addJAvascript()

        End If
    End Sub
    Private Sub startup()
        linkNuovo.Visible = False
        lstTabelle.Visible = False
    End Sub
    Private Sub addJAvascript()

    End Sub

#Region "Metodoi"
    Public Sub BindData(ByVal tabella As String)
        Dim intestazione As String = "Tabella attualmente selezionata:"
        linkNuovo.Visible = False
        Select Case tabella
            Case "Materiale"
                lblIntestazione.Text = "Materiale"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo materiale"
                lblListaDescrizione.Text = "Lista materiale"
                linkNuovo.Text = "Nuovo materiale"
                lstTabelle.DataSource = _mobjEsami.GetAllMaterialeList
                '  pnlDati.Visible = True
                lstTabelle.Visible = True
            Case "Metodo"
                lblIntestazione.Text = "Metodo"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo metodo"
                lblListaDescrizione.Text = "Lista metodo"
                lstTabelle.DataSource = _mobjEsami.GetAllMetodoList
                '  pnlDati.Visible = True
                lstTabelle.Visible = True
            Case "AgenteEziologico"
                lblIntestazione.Text = "Agente eziologico"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo agente"
                ' lblTestata.Text = intestazione & "Agente eziologico"
                lblListaDescrizione.Text = "Lista agente eziologico"
                lstTabelle.DataSource = _mobjEsami.GetAllAgenteList
                '   pnlDati.Visible = True
                lstTabelle.Visible = True
            Case "Veicolo"
                lblIntestazione.Text = "Veicolo"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo veicolo"
                ' lblTestata.Text = intestazione & "Agente eziologico"
                lblListaDescrizione.Text = "Lista Veicoli"
                lstTabelle.DataSource = _mobjEsami.GetAllVeicoloList
                '   pnlDati.Visible = True
                lstTabelle.Visible = True
            Case Else
                lstTabelle.DataSource = ""
                '   pnlDati.Visible = False
                lstTabelle.Visible = False
        End Select
        lstTabelle.DataBind()
    End Sub
    Private Sub AddElemento(ByVal TipoTabella As String)
        Select Case TipoTabella
            Case "Materiale"
                Dim mat As New Materiale
                mat.id = Nothing
                mat.Codice = Codice.Text
                mat.CodiceMinistero = CodiceMinistero.Text
                mat.Descrizione = Descrizione.Text
                mat.DescrizioneBreve = DescrizioneBreve.Text
                mat.Help = help.Text
                _mobjEsami.AddMateriale(mat)
            Case "Metodo"
                Dim met As New Metodo
                met.id = Nothing
                met.Codice = Codice.Text
                met.CodiceMinistero = CodiceMinistero.Text
                met.Descrizione = Descrizione.Text
                met.DescrizioneBreve = DescrizioneBreve.Text
                met.Help = help.Text
                _mobjEsami.AddMetodo(met)
            Case "AgenteEziologico"
                Dim age As New Agente_Eziologico
                age.id = Nothing
                age.Codice = Codice.Text
                age.CodiceMinistero = CodiceMinistero.Text
                age.Descrizione = Descrizione.Text
                age.DescrizioneBreve = DescrizioneBreve.Text
                age.Help = help.Text
                _mobjEsami.AddAgente(age)
            Case "Veicolo"
                Dim vei As New Veicolo
                vei.id = Nothing
                vei.Codice = Codice.Text
                vei.CodiceMinistero = CodiceMinistero.Text
                vei.Descrizione = Descrizione.Text
                vei.DescrizioneBreve = DescrizioneBreve.Text
                vei.Help = help.Text
                _mobjEsami.AddVeicolo(vei)
            Case Else
                Throw New Exception("Nessuna Tabella è stata selezionata")
        End Select
    End Sub
    Private Sub UpdateElemento(ByVal TipoTabella As String)
        Select Case TipoTabella
            Case "Materiale"
                Dim mat As New Materiale
                mat.id = _idElemento
                mat.Codice = Codice.Text
                mat.CodiceMinistero = CodiceMinistero.Text
                mat.Descrizione = Descrizione.Text
                mat.DescrizioneBreve = DescrizioneBreve.Text
                mat.Help = help.Text
                _mobjEsami.UpdateMAteriale(mat)
            Case "Metodo"
                Dim met As New Metodo
                met.id = _idElemento
                met.Codice = Codice.Text
                met.CodiceMinistero = CodiceMinistero.Text
                met.Descrizione = Descrizione.Text
                met.DescrizioneBreve = DescrizioneBreve.Text
                met.Help = help.Text
                _mobjEsami.UpdateMetodo(met)
            Case "AgenteEziologico"
                Dim age As New Agente_Eziologico
                age.id = _idElemento
                age.Codice = Codice.Text
                age.CodiceMinistero = CodiceMinistero.Text
                age.Descrizione = Descrizione.Text
                age.DescrizioneBreve = DescrizioneBreve.Text
                age.Help = help.Text
                _mobjEsami.UpdateAgente(age)
            Case "Veicolo"
                Dim vei As New Veicolo
                vei.id = _idElemento
                vei.Codice = Codice.Text
                vei.CodiceMinistero = CodiceMinistero.Text
                vei.Descrizione = Descrizione.Text
                vei.DescrizioneBreve = DescrizioneBreve.Text
                vei.Help = help.Text
                _mobjEsami.UpdateVeicolo(vei)
            Case Else
                Throw New Exception("Nessuna Tabella è stata selezionata")
        End Select

    End Sub
#End Region
#Region "Eventi Controlli"
    Protected Sub linkNuovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkNuovo.Click
        PulisciPopUp()
        Pop.Show()
    End Sub
    Protected Sub BtnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSalva.Click
        Try
            If _idElemento = 0 Then
                AddElemento(_tipoTabella)
            Else
                UpdateElemento(_tipoTabella)
            End If
            BindData(_tipoTabella)
        Catch ex As Exception
            lblErrore.Text = ex.ToString
        End Try
    End Sub
#End Region
#Region "Formattazione Form"
    Private Sub PulisciPopUp()
        Codice.Text = ""
        Descrizione.Text = ""
        DescrizioneBreve.Text = ""
        help.Text = ""
    End Sub
#End Region

    Protected Sub lstTabelle_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstTabelle.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim id As Integer
        id = lstTabelle.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "aggiorna" Then
            _idElemento = id
            PulisciPopUp()
            CaricaCampi(id, _tipoTabella)
            Pop.Show()
        End If
        If e.CommandName = "elimina" Then
            Elimina(id, _tipoTabella)
            BindData(_tipoTabella)
        End If

    End Sub
    Private Sub CaricaCampi(ByVal id As Integer, ByVal tipoTabella As String)
        Select Case _tipoTabella
            Case "Materiale"
                Dim mat As Materiale = _mobjEsami.GetMaterialeById(id)
                Codice.Text = mat.Codice
                Descrizione.Text = mat.Descrizione
                DescrizioneBreve.Text = mat.DescrizioneBreve
                help.Text = mat.Help
                Codice.Enabled = False
            Case "Metodo"
                Dim met As Metodo = _mobjEsami.GetMetodoById(id)
                Codice.Text = met.Codice
                Descrizione.Text = met.Descrizione
                DescrizioneBreve.Text = met.DescrizioneBreve
                help.Text = met.Help
                Codice.Enabled = False
            Case "AgenteEziologico"
                Dim age As Agente_Eziologico = _mobjEsami.GetAgenteById(id)
                Codice.Text = age.Codice
                Descrizione.Text = age.Descrizione
                DescrizioneBreve.Text = age.DescrizioneBreve
                help.Text = age.Help
                Codice.Enabled = False
            Case "Veicolo"
                Dim vei As Veicolo = _mobjEsami.GetVeicoloById(id)
                Codice.Text = vei.Codice
                Descrizione.Text = vei.Descrizione
                DescrizioneBreve.Text = vei.DescrizioneBreve
                help.Text = vei.Help
                Codice.Enabled = False
        End Select
    End Sub
    Private Sub Elimina(ByVal id As Integer, ByVal tipoTabella As String)
        Select Case _tipoTabella
            Case "Materiale"
                _mobjEsami.DeleteMateriale(id)
            Case "Metodo"
                _mobjEsami.DeleteMetodo(id)
            Case "AgenteEziologico"
                _mobjEsami.DeleteAgente(id)
            Case "Veicolo"
                _mobjEsami.DeleteVeicolo(id)
        End Select
    End Sub
End Class
