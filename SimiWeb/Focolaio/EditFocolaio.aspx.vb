Imports System.Threading
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Focolaio_EditFocolaio
    Inherits System.Web.UI.Page
    Private _idMalattia As Integer = 0
    Private _malattia As String = ""
    Private _idFocolaio As Integer = 0
    Private _record As String
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjAccesorie As New BllAccessorie
    Private _MobjEsame As New BllEsami
    Private _MobjFocolaio As New BllFocolaio
    Private _MobjUtente As New BllUser
    Private _idRegione As String = ""
    Private _idAsl As String = ""
    Private _username As String = ""
    Private _ruolo As String = ""
    'Private _lettura As Boolean = True
    'Private _aggiornamento As Boolean = True
    'Private _eliminazione As Boolean = True
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_malattia", _malattia)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_idFocolaio", _idFocolaio)
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_username", _username)
        Me.ViewState.Add("_ruolo", _ruolo)

        'Me.ViewState.Add("_lettura", _lettura)
        'Me.ViewState.Add("_aggiornamento", _aggiornamento)
        'Me.ViewState.Add("_eliminazione", _eliminazione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _malattia = ViewState("_malattia")
        _idMalattia = CInt(ViewState("_idMalattia"))
        _idFocolaio = CInt(ViewState("_idFocolaio"))
        _idAsl = ViewState("_idFocolaio")
        _idRegione = ViewState("_idRegione")
        _username = ViewState("_username")
        _ruolo = ViewState("_ruolo")

        '_lettura = ViewState("_lettura")
        '_aggiornamento = ViewState("_aggiornamento")
        '_eliminazione = ViewState("_eliminazione")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idFocolaio = Session("idFocolaio")
            _username = User.Identity.Name
            _ruolo = Roles.GetRolesForUser(_username)(0).ToString
            'Dim utente As Utenti_Profilo = _MobjUtente.GetProfiloByUsername(_username)
            '_lettura = utente.Letttura
            '_aggiornamento = utente.Aggiornamento


            CaricaValoriStartUp()
            AddJavascript()
            Carica()
            If _ruolo = "medico" Then
                stato.SelectedValue = "Segnalazione"
                stato.Enabled = False
            End If
            Regione.Enabled = False
            reqAgente.Enabled = False
        End If
    End Sub
    Private Sub Carica()
        Dim LocalDataList As Focolaio
        Try
            LocalDataList = _MobjFocolaio.GetFromId(_idFocolaio)


            If LocalDataList Is Nothing Then
                Throw New Exception("Si è verificato un errore contattare supporto tecnico")
            Else
                With LocalDataList
                    _idMalattia = .idMalattia
                    dataInizio.Text = Helper.IsNullDate(.dataInizio)
                    CodiceFocolaio.Text = .codiceFocolaio
                    dataweb.Text = Helper.IsNullDate(.DataWeb)
                    datanotifica.Text = Helper.IsNullDate(.DataNotifica)
                    datasegnalazione.Text = Helper.IsNullDate(.DataSegnalazione)
                    durata.Text = .durata

                    If Not .IdAgente Is Nothing Then
                        CaricaAgente(Me.Agente)
                    End If
                    Agente.SelectedValue = .IdAgente
                    Comune.SelectedValue = .idComune
                    Comunita.SelectedValue = .idComunita

                    Provincia.SelectedValue = .idprovincia
                    _idAsl = .idAslNotifica
                    Regione.SelectedValue = .idRegione '
                    Veicolo.SelectedValue = .idVeicolo
                    Indirizzo.Text = .Indirizzo
                    LuogoOrigine.SelectedValue = .LuogoOrigine
                    note.Text = .Note
                    numeroCasi.Text = .NumeroCasi
                    PersoneRischio.Text = .personeRischio
                    Telefono.Text = .Telefono
                    VeicoloStato.SelectedValue = .VeicoloStato
                    AgenteStato.SelectedValue = .AgenteStato
                    stato.SelectedValue = .Stato
                    _username = .username






                    If Not .idprovincia Is Nothing And .idprovincia <> "" Then
                        Provincia.DataSource = _MobjGeografiche.GetAllProvinceJsonByIdRegione(.idRegione)
                        Provincia.DataTextField = "descrizione"
                        Provincia.DataValueField = "codice"
                        Provincia.DataBind()
                        Provincia.SelectedValue = .idprovincia
                    End If

                    If Not .idComune Is Nothing And .idComune <> "" Then
                        Comune.DataSource = _MobjGeografiche.GetAllComuniByIdProvinciaJson(.idprovincia)
                        Comune.DataTextField = "descrizione"
                        Comune.DataValueField = "codice"
                        Comune.DataBind()
                        Comune.SelectedValue = .idComune
                    End If

                    If .Stato = "Notifica" Then
                        stato.Enabled = False
                    End If

                    VeicoloTesto.Text = .Veicolo
                End With
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub CaricaValoriStartUp()
        CAricaIntestazione()
        CaricaRegioni(Regione)
        CaricaColletivita(Comunita)
        ' CaricaAgente(Agente)
    End Sub
    Private Sub AddJavascript()
        Me.Regione.Attributes("onchange") = "RemoveItem('Comune');getProvinceByIdRegione('Provincia',this.value);"
        Me.Provincia.Attributes("onchange") = "getComuni('Provincia','Comune');"
        Me.dataNotifica.Attributes("onblur") = "check_date(this);"
        Me.dataInizio.Attributes("onblur") = "check_date(this);CheckNotifica();"
        Me.dataSegnalazione.Attributes("onblur") = "check_date(this);"
        Me.PersoneRischio.Attributes("onblur") = "isnum(this);"
        Me.durata.Attributes("onblur") = "isnum(this);"
    End Sub
    Private Function impostaEntity() As Focolaio
        Dim localdataEntity As New Focolaio
        With localdataEntity
            If _idFocolaio = 0 Then
                Throw New Exception("Id = 0")
            End If
            .id = _idFocolaio
            .codiceFocolaio = CodiceFocolaio.Text
            .idAslNotifica = _idAsl
            .dataInizio = dataInizio.Text
            .DataModifica = Now
            .DataWeb = Helper.ConvertEmptyDateToNothing(dataweb.Text)
            .DataNotifica = Helper.ConvertEmptyDateToNothing(dataNotifica.Text)
            .DataSegnalazione = Helper.ConvertEmptyDateToNothing(dataSegnalazione.Text)
            .durata = durata.Text
            .IdAgente = Request.Form("ctl00$Contenuto$Agente") '
            .idComune = Request.Form("ctl00$Contenuto$Comune")
            .idComunita = Request.Form("ctl00$Contenuto$Comunita")
            .idMalattia = _idMalattia
            .idprovincia = Request.Form("ctl00$Contenuto$Provincia")
            .idRegione = Regione.SelectedValue
            .idVeicolo = Request.Form("ctl00$Contenuto$Veicolo")
            .Indirizzo = Indirizzo.Text
            .LuogoOrigine = LuogoOrigine.SelectedValue
            .Note = note.Text
            .NumeroCasi = numeroCasi.Text
            .personeRischio = PersoneRischio.Text
            .Telefono = Telefono.Text
            .VeicoloStato = VeicoloStato.SelectedValue
            .AgenteStato = AgenteStato.SelectedValue
            .Stato = stato.SelectedValue
            .Veicolo = VeicoloTesto.Text
            .LastUser = User.Identity.Name
            .username = _username
        End With
        Return localdataEntity
    End Function
    Private Sub Salva()
        Try

            _MobjFocolaio.username = User.Identity.Name
            _MobjFocolaio.record = _malattia
            _MobjFocolaio.Update(impostaEntity)
            Response.Redirect("Riepilogo.aspx", True)
        Catch ex As Exception
            lblErrore.Visible = True
            lblErrore.Text = ex.ToString
            btnSalva.Enabled = False
        End Try
    End Sub

    Private Sub CAricaIntestazione()
        Dim Info As Focolaio_InfoResult = _MobjFocolaio.GetInfo(_idFocolaio)
        With Info

            _malattia = .malattia
            focolaioLabel.Text = .malattia

        End With



    End Sub
#Region "Caricamento DropDownList"
    Private Sub CaricaColletivita(ByRef ctr As DropDownList)
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = _MobjAccesorie.GettAllComunitaJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaAgente(ByRef ctr As DropDownList)
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = _MobjEsame.GetAgenteByIdMalattiaJson(_idMalattia)
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaRegioni(ByRef ctr As DropDownList)
        ctr.DataValueField = "Codice"
        ctr.DataTextField = "Descrizione"
        ctr.DataSource = _MobjGeografiche.GetAllRegioniJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
#End Region
    Protected Sub btnSalva_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        Salva()
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return CheckInfo();"
    End Sub
    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx", True)
    End Sub
End Class
