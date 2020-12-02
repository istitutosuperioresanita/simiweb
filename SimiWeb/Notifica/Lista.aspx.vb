Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Notifica_Lista
    Inherits System.Web.UI.Page
    Private _mobjGEografiche As New BllGeografiche
    Private _mobjMalattia As New BllMalattie
    Private _mobjNotifica As New BllNotifica
    Private _mobjUser As New BllUser
    Private _id As Integer = 0
    Private _doppio As String = ""
    Private _idAsl As String = ""
    Private _idRegione As String = ""
    Private _ruolo As String = ""
    Private _lettura As Boolean = True
    Private _aggiornamento As Boolean = True
    Private _eliminazione As Boolean = True
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
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
        _ruolo = ViewState("_ruolo")
        _lettura = CBool(ViewState("_lettura"))
        _aggiornamento = CBool(ViewState("_aggiornamento"))
        _eliminazione = CBool(ViewState("_eliminazione"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _ruolo = Roles.GetRolesForUser(User.Identity.Name)(0).ToString
            _doppio = Request.QueryString("id")
            If Not _doppio Is Nothing Then
                idScheda.Text = _doppio.ToString
            End If


            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)
            _idRegione = profilo.idRegione
            _idAsl = profilo.idAsl
            _lettura = profilo.Letttura
            _aggiornamento = profilo.Aggiornamento
            _eliminazione = profilo.Eliminazione
            CaricaAsl(aslNotifica)
            CaricaAsl(aslResidemza)

            If _ruolo = "asl" Then
                aslResidemza.SelectedValue = _idAsl
                aslNotifica.SelectedValue = _idAsl
            End If

            If _ruolo = "regione" Then
                pnlRegione.Visible = True
            Else
                pnlRegione.Visible = False
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
        Me.malattia.Attributes("onchange") = "checkMalattia()"
    End Sub
    Private Sub CaricaValoriStartUp()
        CaricaComune(comuneSintomi)
        CaricaComune(comuneResidenza)
        CaricaMalattie(malattia)
        ' BindLista()

    End Sub
    Private Sub BindLista()

        If _ruolo = "regione" Then
            LstNotifica.DataSource = _mobjNotifica.GetNotificaListaRegione(Helper.ConvertEmptyStringToNothing(cognome.Text), _
                                          Nothing, _
                                          Helper.ConvertEmptyDateToNothing(dataNascita.Text), _
                                          Helper.ConvertEmptyStringToNothing(codiceFiscale.Text), _
                                          Helper.ConvertIntegerToNothing(malattia.SelectedValue), _
                                          Helper.ConvertEmptyStringToNothing(comuneResidenza.SelectedValue), _
                                          Helper.ConvertEmptyStringToNothing(comuneSintomi.SelectedValue), _
                                          Helper.ConvertEmptyStringToNothing(stato.SelectedValue), _
                                          Helper.ConvertEmptyDateToNothing(dataNotificaDa.Text), _
                                          Helper.ConvertEmptyDateToNothing(dataNotificaA.Text), _
                                          Helper.ConvertEmptyDateToNothing(dataSegnalazioneDa.Text), _
                                          Helper.ConvertEmptyDateToNothing(dataSegnalazioneA.Text), _
                                          Helper.ConvertEmptyStringToNothing(aslNotifica.SelectedValue), _
                                          Helper.ConvertEmptyStringToNothing(aslResidemza.SelectedValue), _
                                          Helper.ConvertEmptyStringToNothing(_idRegione), _
                                          Helper.ConvertIntegerToNothing(idScheda.Text), _
                                          User.Identity.Name, _
                                          _ruolo)
        Else



            LstNotifica.DataSource = _mobjNotifica.GetNotificaLista(Helper.ConvertEmptyStringToNothing(cognome.Text), _
                                                      Nothing, _
                                                      Helper.ConvertEmptyDateToNothing(dataNascita.Text), _
                                                      Helper.ConvertEmptyStringToNothing(codiceFiscale.Text), _
                                                      Helper.ConvertIntegerToNothing(malattia.SelectedValue), _
                                                      Helper.ConvertEmptyStringToNothing(comuneResidenza.SelectedValue), _
                                                      Helper.ConvertEmptyStringToNothing(comuneSintomi.SelectedValue), _
                                                      Helper.ConvertEmptyStringToNothing(stato.SelectedValue), _
                                                      Helper.ConvertEmptyDateToNothing(dataNotificaDa.Text), _
                                                      Helper.ConvertEmptyDateToNothing(dataNotificaA.Text), _
                                                      Helper.ConvertEmptyDateToNothing(dataSegnalazioneDa.Text), _
                                                      Helper.ConvertEmptyDateToNothing(dataSegnalazioneA.Text), _
                                                      Helper.ConvertEmptyStringToNothing(aslNotifica.SelectedValue), _
                                                      Helper.ConvertEmptyStringToNothing(aslResidemza.SelectedValue), _
                                                      Helper.ConvertEmptyStringToNothing(_idRegione), _
                                                      Helper.ConvertIntegerToNothing(idScheda.Text), _
                                                      User.Identity.Name, _
                                                      _ruolo)
        End If
        LstNotifica.DataBind()
    End Sub
    Private Sub CaricaComune(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjGEografiche.GetAllComuniByIdRegioneJson(_idRegione)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub
    Private Sub CaricaMalattie(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjMalattia.GetAllMalattieJson(BllMalattie.tipo.valide)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub
    Private Sub CaricaAsl(ByRef ctr As DropDownList)
        ctr.DataSource = _mobjGEografiche.GetAllAslByIdRegioneJson(_idRegione)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "codice"
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare", ""))
    End Sub
    Protected Sub btncerca_Click(sender As Object, e As System.EventArgs) Handles btncerca.Click
        '  BindLista()
    End Sub
    Protected Sub LstNotifica_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles LstNotifica.ItemCommand
        Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        _id = LstNotifica.DataKeys(dataItem.DisplayIndex).Value
        If e.CommandName = "sel" Then
            Session("idNotifica") = _id
            Response.Redirect("~/Notifica/Riepilogo.aspx", True)
        End If
        If e.CommandName = "invalida" Then
            _mobjNotifica.CambiaStato(_id, "Archiviata")
        End If
    End Sub
    Protected Sub pager_PreRender(sender As Object, e As System.EventArgs) Handles pager.PreRender
        bindLista()
    End Sub

    Protected Sub cerca_Click(sender As Object, e As System.EventArgs) Handles btncerca.Click
        pager.SetPageProperties(0, pager.MaximumRows, False)
    End Sub


    Protected Sub LstNotifica_ItemDataBound(sender As Object, e As System.Web.UI.WebControls.ListViewItemEventArgs) Handles LstNotifica.ItemDataBound
        Dim imgDelete As ImageButton = e.Item.FindControl("invalida")
        Dim lblAsl As Label = e.Item.FindControl("lblIdAsl") 'ID asl notifica
        Dim descrizioneAsl As Label = e.Item.FindControl("DescrizioneLabel") ' descrizione asl notifica

        If _idAsl <> lblAsl.Text Then
            descrizioneAsl.Font.Bold = True
            descrizioneAsl.Font.Italic = True
        End If
        If _aggiornamento = False Then
            imgDelete.Visible = False
        Else
            imgDelete.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà invalidato, proseguire ?');"
        End If




    End Sub

    Protected Sub btnPulisci_Click(sender As Object, e As System.EventArgs) Handles btnPulisci.Click
        dataNascita.Text = ""
        codiceFiscale.Text = ""
        malattia.SelectedValue = ""
        comuneResidenza.SelectedValue = ""
        comuneSintomi.SelectedValue = ""
        stato.SelectedValue = ""
        cognome.Text = ""        
        dataNotificaDa.Text = ""
        dataNotificaA.Text = ""
        dataSegnalazioneDa.Text = ""
        dataSegnalazioneA.Text = ""
        idScheda.Text = ""
    End Sub
End Class
