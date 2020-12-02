Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Admin_Tabelle_Accesorie_Tabelle
    Inherits System.Web.UI.Page
    Private _tipoTabella As String = ""
    Private _idElemento As Integer
    Private _mobjAccesorie As New BllAccessorie
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
            Case "Comunita"
                lblIntestazione.Text = "Comunità"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo Comunità"
                lblListaDescrizione.Text = "Lista Comunità"
                lstTabelle.DataSource = _mobjAccesorie.GettAllComunitaList
                '  pnlDati.Visible = True
                lstTabelle.Visible = True
            Case "Professione"
                lblIntestazione.Text = "Professione"
                linkNuovo.Visible = True
                linkNuovo.Text = "Nuovo Professione"
                lblListaDescrizione.Text = "Lista professioni"
                lstTabelle.DataSource = _mobjAccesorie.GettAllProfessioniList
                '  pnlDati.Visible = True
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
            Case "Comunita"
                Dim com As New Comunita
                com.id = Nothing
                com.Codice = Codice.Text
                com.CodiceMinistero = CodiceMinistero.Text
                com.Descrizione = Descrizione.Text
                com.DescrizioneBreve = DescrizioneBreve.Text
                'mat.Help = help.Text
                _mobjAccesorie.AddComunita(com)
            Case "Professione"
                Dim pro As New Professione
                pro.id = Nothing
                pro.codice = Codice.Text
                pro.CodiceMinistero = CodiceMinistero.Text
                pro.Descrizione = Descrizione.Text
                pro.DescrizioneBreve = DescrizioneBreve.Text
                _mobjAccesorie.AddProfessione(pro)
            Case Else
                Throw New Exception("Nessuna Tabella è stata selezionata")
        End Select
    End Sub
    Private Sub UpdateElemento(ByVal TipoTabella As String)
        Select Case TipoTabella
            Case "Comunita"
                Dim com As New Comunita
                com.id = _idElemento
                com.Codice = Codice.Text
                com.CodiceMinistero = CodiceMinistero.Text
                com.Descrizione = Descrizione.Text
                com.DescrizioneBreve = DescrizioneBreve.Text
                _mobjAccesorie.UpdateComunita(com)

            Case "Professione"
                Dim pro As New Professione
                pro.id = _idElemento
                pro.codice = Codice.Text
                pro.CodiceMinistero = CodiceMinistero.Text
                pro.Descrizione = Descrizione.Text
                pro.DescrizioneBreve = DescrizioneBreve.Text
                _mobjAccesorie.UpdateProfessione(pro)

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
            Case "Comunita"
                Dim com As Comunita = _mobjAccesorie.GetComunitaById(id)
                Codice.Text = com.Codice
                Descrizione.Text = com.Descrizione
                DescrizioneBreve.Text = com.DescrizioneBreve
                CodiceMinistero.Text = com.CodiceMinistero
                Codice.Enabled = False
            Case "Professione"
                Dim pro As Professione = _mobjAccesorie.GetProfessioneById(id)
                Codice.Text = pro.codice
                Descrizione.Text = pro.Descrizione
                DescrizioneBreve.Text = pro.DescrizioneBreve
                CodiceMinistero.Text = pro.CodiceMinistero
                Codice.Enabled = False
        End Select
    End Sub
    Private Sub Elimina(ByVal id As Integer, ByVal tipoTabella As String)
        Select Case _tipoTabella
            Case "Comunita"
                _mobjAccesorie.DeleteComunita(id)
            Case "Professione"
                _mobjAccesorie.DeleteProfessione(id)
        End Select
    End Sub
End Class

