
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Focolaio_Focolaio
    Inherits System.Web.UI.Page
    Private _idMalattia As Integer = 0
    Private _malattia As String = ""
    Private _idFocolaio As Integer = 0
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjAccesorie As New BllAccessorie
    Private _MobjEsame As New BllEsami
    Private _MobjFocolaio As New BllFocolaio
    Private _MobjUtente As New BllUser
    Private _idRegione As String = ""
    Private _idAsl As String = ""
    Private _username As String = ""
    Private _ruolo As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_malattia", _malattia)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_idFocolaio", _idFocolaio)
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_username", _username)
        Me.ViewState.Add("_ruolo", _ruolo)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _malattia = ViewState("_malattia")
        _idMalattia = CInt(ViewState("_idMalattia"))
        _idFocolaio = CInt(ViewState("_idFocolaio"))
        _idAsl = ViewState("_idFocolaio")
        _username = ViewState("_username")
        _idRegione = ViewState("_idRegione")
        _ruolo = ViewState("_ruolo")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _username = User.Identity.Name
            _ruolo = Roles.GetRolesForUser(User.Identity.Name)(0).ToString
            Dim utente As Utenti_Profilo = _MobjUtente.GetProfiloByUsername(_username)

            _idRegione = utente.idRegione
            _idAsl = utente.idAsl
            _idFocolaio = 0
            _idMalattia = Request.QueryString("idmalattia")
            _malattia = Request.QueryString("malattia")
            CaricaValoriStartUp()
            AddJavascript()
            focolaioLabel.Text = _malattia
            datasegnalazione.Text = Now.ToShortDateString
            Regione.Enabled = False
        End If
        reqAgente.Enabled = False
    End Sub
    Private Sub CaricaValoriStartUp()
        caricaCombo(Agente, _MobjEsame.GetAgenteByIdMalattiaJson(_idMalattia))
        caricaCombo(Regione, _MobjGeografiche.GetAllRegioniJson, _idRegione)
        caricaCombo(Provincia, _MobjGeografiche.GetAllProvinceJsonByIdRegione(Regione.SelectedValue))
        caricaCombo(Comunita, _MobjAccesorie.GettAllComunitaJson)
        If _ruolo = "medico" Then
            stato.SelectedValue = "Segnalazione"
            stato.Enabled = False
        End If
    End Sub
    Private Sub AddJavascript()
        Me.Regione.Attributes("onchange") = "RemoveItem('Comune');getProvinceByIdRegione('Provincia',this.value);"
        Me.Provincia.Attributes("onchange") = "getComuni('Provincia','Comune');"
        Me.datanotifica.Attributes("onblur") = "check_date(this);CheckNotifica();"
        Me.dataInizio.Attributes("onblur") = "check_date(this);"
        Me.dataSegnalazione.Attributes("onblur") = "check_date(this);"
        Me.PersoneRischio.Attributes("onblur") = "isnum(this);"
        Me.durata.Attributes("onblur") = "isnum(this);"
    End Sub

#Region "Sub"
    Private Sub caricaCombo(ByRef ctr As DropDownList, ByVal ds As IList(Of JsonDto), Optional ByVal id As String = "")
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = ds
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
        If id <> "" Then
            ctr.SelectedValue = id
        End If
    End Sub
#End Region
    Private Function impostaEntity() As Focolaio
        Dim localdataEntity As New Focolaio
        With localdataEntity
            If .id > 0 Then
                .id = _idFocolaio
            End If
            .codiceFocolaio = CodiceFocolaio.Text
            .dataInizio = Helper.ConvertEmptyDateToNothing(dataInizio.Text)            
            .DataNotifica = Helper.ConvertEmptyDateToNothing(dataNotifica.Text)
            .DataSegnalazione = Helper.ConvertEmptyDateToNothing(dataSegnalazione.Text)
            .durata = durata.Text
            .IdAgente = Request.Form("ctl00$Contenuto$Agente") 'Agente.SelectedValue
            .idComune = Request.Form("ctl00$Contenuto$Comune") ' Comune.SelectedValue
            .idComunita = Request.Form("ctl00$Contenuto$Comunita") 'Comunita.SelectedValue
            .idMalattia = _idMalattia
            .idprovincia = Request.Form("ctl00$Contenuto$Provincia") 'Provincia.SelectedValue
            .idRegione = Regione.SelectedValue 'Regione.SelectedValue
            .idVeicolo = Request.Form("ctl00$Contenuto$Veicolo") 'Veicolo.SelectedValue
            .Indirizzo = Indirizzo.Text
            .LuogoOrigine = LuogoOrigine.SelectedValue
            .Note = note.Text
            .NumeroCasi = Helper.ConvertIntegerToNothing(numeroCasi.Text)
            .personeRischio = Helper.ConvertIntegerToNothing(PersoneRischio.Text)
            .Telefono = Telefono.Text
            .VeicoloStato = VeicoloStato.SelectedValue
            .AgenteStato = AgenteStato.SelectedValue
            .Stato = stato.SelectedValue
            .DataWeb = Now
            .DataModifica = Now
            .Veicolo = VeicoloTesto.Text
            .LastUser = _username
            .idAslNotifica = _idAsl
            .username = _username

        End With
        Return localdataEntity
    End Function


    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Try
            _MobjFocolaio.username = User.Identity.Name
            _MobjFocolaio.record = _malattia
            Session("idFocolaio") = _MobjFocolaio.Add(impostaEntity)
        Catch ex As Exception
            lblErrore.Text = ex.ToString
            btnSalva.Enabled = False
            Response.End()
        End Try
        Response.Redirect("Riepilogo.aspx", True)
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return CheckInfo();"
    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("../home.aspx", True)
    End Sub
End Class
