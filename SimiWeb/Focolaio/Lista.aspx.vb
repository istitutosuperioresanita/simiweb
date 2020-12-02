Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Focolaio_Lista
    Inherits System.Web.UI.Page
    Private _mobjGEografiche As New BllGeografiche
    Private _mobjMalattia As New BllMalattie
    Private _mobjEsami As New BllEsami
    Private _mobjFocolaio As New BllFocolaio
    Private _mobjUSer As New BllUser
    Private _idRegione As String = ""
    Private _idAsl As String = ""
    Private _username As String = ""
    Private _usernameMedico As String = ""
    Private _ruolo As String = ""
    Private _lettura As Boolean = True
    Private _aggiornamento As Boolean = True
    Private _eliminazione As Boolean = True


    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_usernameMedico", _usernameMedico)
        Me.ViewState.Add("_username", _username)
        Me.ViewState.Add("_ruolo", _ruolo)


        Me.ViewState.Add("_lettura", _lettura)
        Me.ViewState.Add("_aggiornamento", _aggiornamento)
        Me.ViewState.Add("_eliminazione", _eliminazione)

        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idRegione = ViewState("_idRegione")
        _idAsl = ViewState("_idAsl")
        _username = ViewState("_username")
        _usernameMedico = ViewState("_usernameMedico")
        _ruolo = ViewState("_ruolo")


        _lettura = ViewState("_lettura")
        _aggiornamento = ViewState("_aggiornamento")
        _eliminazione = ViewState("_eliminazione")

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim messaggio As String
            messaggio = Request.QueryString("esito")
            If messaggio = "1" Then
                Page.ClientScript.RegisterStartupScript(Me.GetType, "alertDelete", "alert('Salvataggio effettuato con successo');", True)

            End If
            _username = User.Identity.Name

            _ruolo = Roles.GetRolesForUser(User.Identity.Name)(0).ToString


            Dim utente As Utenti_Profilo = _mobjUSer.GetProfiloByUsername(_username)         

            _lettura = utente.Letttura
            _aggiornamento = utente.Aggiornamento
            _eliminazione = utente.Eliminazione
            _idAsl = utente.idAsl
            _idRegione = utente.idRegione
            If _ruolo = "medico" Then
                _usernameMedico = _username
            Else
                _usernameMedico = Nothing
            End If



            CaricaValoriStartUp()
            ImpostaJavascript()
        End If
    End Sub

    Private Sub ImpostaJavascript()
        Me.dataNotificaDa.Attributes("onblur") = "check_date(this);"
        Me.dataNotificaA.Attributes("onblur") = "check_date(this);"
        Me.dataSegnalazioneDa.Attributes("onblur") = "check_date(this);"
        Me.dataSegnalazioneA.Attributes("onblur") = "check_date(this);"
    End Sub


    Private Sub CaricaValoriStartUp()
        CaricaComune(comune)
        CaricaMalattie(malattia)      
    End Sub
    Private Sub CaricaComune(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjGEografiche.GetAllComuniByIdRegioneJson(_idRegione)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub
    Private Sub CaricaMalattie(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjMalattia.GetAllMalattieJson(BllMalattie.tipo.focolaio)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub
    Private Sub CaricaAgente(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjEsami.GetAllAgenteJson
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub

    Protected Sub lstFocolaio_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles lstFocolaio.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        Dim idFocolaio As Integer = lstFocolaio.DataKeys(dataItem.DisplayIndex).Values(0).ToString
        If e.CommandName = "sel" Then
            Session("idFocolaio") = idFocolaio
            Response.Redirect("riepilogo.aspx", True)
        End If
    End Sub
    Public Sub Bind()
        lstFocolaio.DataSource = _mobjFocolaio.GetLista(Helper.ConvertIntegerToNothing(malattia.SelectedValue), _
                                                       Helper.ConvertEmptyStringToNothing(comune.SelectedValue), _
                                                       Helper.ConvertEmptyDateToNothing(dataNotificaDa.Text), _
                                                       Helper.ConvertEmptyDateToNothing(dataNotificaA.Text), _
                                                       Helper.ConvertEmptyDateToNothing(dataSegnalazioneDa.Text), _
                                                       Helper.ConvertEmptyDateToNothing(dataSegnalazioneA.Text), _
                                                       Helper.ConvertEmptyStringToNothing(_idAsl), _
                                                       _idRegione, _
                                                       _username, _
                                                       _usernameMedico)
        lstFocolaio.DataBind()
    End Sub
    Protected Sub pager_PreRender(sender As Object, e As System.EventArgs) Handles pager.PreRender
        Bind()
    End Sub

    Protected Sub cerca_Click(sender As Object, e As System.EventArgs) Handles btnCerca.Click
        pager.SetPageProperties(0, pager.MaximumRows, False)
    End Sub
End Class
