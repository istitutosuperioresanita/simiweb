Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_Segnalazione
    Inherits System.Web.UI.Page
    Private _MobjMalattia As New BllMalattie
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjAccesorie As New BllAccessorie
    Private _MobjAnagrafica As New BllNotifica
    Private _MobjMedico As New BllMedico
    Private _MobjUSer As New BllUser

    Private _idNotifica As Integer = 0
    Private _idMalattia As Integer = 0
    Private _malattia As String = ""
    Private _nomelbl As String = ""
    Private _cognomelbl As String = ""
    Private _cUser As String = ""
    Private _idAsl As String = ""
    Private _idRegione As String = ""
    Private _ruolo As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_malattia", _malattia)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_nomelbl", _nomelbl)
        Me.ViewState.Add("_cognomelbl", _cognomelbl)
        Me.ViewState.Add("_ruolo", _ruolo)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _malattia = ViewState("_malattia")
        _idMalattia = CInt(ViewState("_idMalattia"))
        _nomelbl = ViewState("_nomelbl")
        _cognomelbl = ViewState("_cognomelbl")
        _ruolo = ViewState("_ruolo")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.Response.Cache.SetCacheability(HttpCacheability.NoCache)
        Response.Expires = 0
        Response.Cache.SetNoStore()
        Response.AppendHeader("Pragma", "no-cache")

        If Not Page.IsPostBack Then
            Dim currRoles() As String = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)
            _ruolo = currRoles(0).ToString


            Dim utente As Utenti_Profilo = _MobjUSer.GetProfiloByUsername(User.Identity.Name)
            _idAsl = utente.idAsl
            _idRegione = utente.idRegione
            _idMalattia = CInt(Request.QueryString("idMalattia"))
            _malattia = CStr(Request.QueryString("Malattia"))
            If _MobjMalattia.Notificabile(_idMalattia) = False Then
                statoScheda.SelectedValue = "Segnalazione"
                statoScheda.Enabled = False
            End If
            If _ruolo = "regione" Or _ruolo = "laboratorio" Or _ruolo = "medico" Then
                pnlRegione.Visible = True
                reqAsl.Enabled = True
                CaricaAsl(aslNotifica, _idRegione)
                If _ruolo = "medico" Then
                    aslNotifica.SelectedValue = _idAsl
                    aslNotifica.Enabled = False
                End If
            End If
            If _ruolo = "medico" Then
                medicoSegnalatore.Text = utente.Nome & " " & utente.Cognome
                medicoSegnalatore.Enabled = False
                statoScheda.SelectedValue = "Segnalazione"
                statoScheda.Enabled = False
                origineSegnalazione.SelectedValue = "Medico segnalatore"
                origineSegnalazione.Enabled = False
                datanotifica.Enabled = False
            End If
            CaricaValoriStartUp()
            AddJavascript()
            datasegnalazione.Text = Now.ToShortDateString
        Else
            _cUser = User.Identity.Name
        End If
    End Sub
    Private Sub CaricaValoriStartUp()
        operatore.Text = User.Identity.Name
        malattiaLabel.Text = _malattia
        CaricaNazioni(Nazionalita)
        CaricaProvince(ProvinciaNascita)
        CaricaProvince(ProvinciaDomicilio)
        CaricaProvince(ProvinciaResidenza)
        CaricaProfessioni(Professione)
        CaricaNazioni(NazioneResidenza)
        CaricaNazioni(NazioneNascita)
        CaricaMedico(Referente)
        ImpostaCriteri()
    End Sub

    Private Sub ImpostaCriteri()
        Dim criteri As Malattie_Criteri = _MobjMalattia.GetCriteri(_idMalattia)
        With criteri
            Clinico.Enabled = .Clinico
            Epidemiologico.Enabled = .Epidemilogico
            Laboratorio.Enabled = .Laboratorio
            divClinici.InnerHtml = Server.HtmlDecode(.Clinico_help)
            divEpidemiologico.InnerHtml = Server.HtmlDecode(.Epidemilogico_Help)
            divLaboratorio.InnerHtml = Server.HtmlDecode(.Laboratorio_help)
        End With
    End Sub
    Private Sub AddJavascript()
        'anagrafica
        Me.ProvinciaResidenza.Attributes("onchange") = "getComuni('ProvinciaResidenza','ComuneResidenza');"
        Me.ProvinciaDomicilio.Attributes("onchange") = "getComuni('ProvinciaDomicilio','ComuneDomicilio');"
        Me.ProvinciaNascita.Attributes("onchange") = "getComuni('ProvinciaNascita','ComuneNascita');"
        Me.NatoEstero.Attributes("onchange") = "AbilitaEstero();"
        Me.DataNascita.Attributes("onblur") = "check_date(this);"
        Me.SenzaFissaDimora.Attributes("onchange") = "AbilitaResidenza();"
        Me.Professione.Attributes("onchange") = "checkProfessione();"
        Me.altraProfessione.Attributes("onblur") = "checkProfessione();"
        Me.arrivoItalia.Attributes("onblur") = "checkEstero();"


        Me.DataPrimiSintomi.Attributes("onblur") = "check_date(this);"
        Me.datasegnalazione.Attributes("onblur") = "check_date(this);"
        Me.datanotifica.Attributes("onblur") = "checkDataNotifica();check_date(this);"

        Me.Ricovero.Attributes("onchange") = "checkLuogoRicovero();"
        Me.LuogoRicovero.Attributes("onblur") = "checkLuogoRicovero();"
        Me.StrutturaRicovero.Attributes("onblur") = "checkLuogoRicovero();"


        Me.statoScheda.Attributes("onchange") = "checkDataNotifica();"

        Me.DataDoseVaccino.Attributes("onblur") = "check_date(this);"

        Me.StatoVaccinale.Attributes("onchange") = "AbilitaVaccino();"
        Me.Nome.Attributes("onchange") = "Showgrid();"
        Me.Cognome.Attributes("onchange") = "Showgrid();"
    End Sub

#Region "Metodi Form"
    Protected Sub btn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn.Click
        'btn.Attributes.Add("onclick", "javascript:" + btn.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(btn, ""))
        Salva()
        Response.Redirect("Riepilogo.aspx?id=" & _idNotifica, True)
    End Sub

    Private Function impostaEntity() As Notifica

        Dim localdataEntity As New Notifica



        With localdataEntity
            If _ruolo = "regione" Or _ruolo = "laboratorio" Then
                .AslDiNotifica = aslNotifica.SelectedValue
            End If

            .DataModifica = Now
            .DataNotifica = Helper.ConvertEmptyDateToNothing(datanotifica.Text)
            .DataSegnalazione = datasegnalazione.Text
            .DataWeb = Now
            .IdReferenteAsl = Referente.SelectedValue
            .medicoSegnalatore = medicoSegnalatore.Text
            .username = User.Identity.Name
            .qualita = 50
            .Stato = statoScheda.SelectedValue
            .origineSegnalazione = origineSegnalazione.SelectedValue
        End With

        Dim ana As New Anagrafica
        With ana
            .CodiceFiscale = codiceFiscale.Text
            .CodiceFiscaleNonConosciuto = ""
            .CodiceRegionaleCriptazione = "12345678"
            .Cognome = Cognome.Text
            '  .idProvinciaResidenza = Request.Form("ctl00$Contenuto$ProvinciaResidenza")
            .NatoEstero = NatoEstero.SelectedValue
            .idProvinciaNascita = Request.Form("ctl00$Contenuto$ProvinciaNascita")
            .IdComuneNascita = Request.Form("ctl00$Contenuto$ComuneNascita")
            .DataNascita = DataNascita.Text
            .altraProfessione = altraProfessione.Text
            .ArrivoItalia = arrivoItalia.Text
            .Eta = 0
            .IdProvinciaDomicilio = Request.Form("ctl00$Contenuto$ProvinciaDomicilio")
            .IdComuneDomicilio = Request.Form("ctl00$Contenuto$ComuneDomicilio")
            .IdComuneResidenza = Request.Form("ctl00$Contenuto$ComuneResidenza")
            .IdNazionalitaCittadinanza = Nazionalita.SelectedValue
            .IdProfessione = Professione.SelectedValue
            .IdNazioneNascita = Nazionalita.SelectedValue            
            .Nome = Nome.Text
            .NumeroStp = NumeroSTP.Text
            .StranieroNonInRegola = StranieroNonInRegola.Text
            .Sesso = sesso.SelectedValue
            .DataWeb = Now
            .DataModifica = Now
            .LastUser = _cUser

            'aggiunti dopo
            .idProvinciaResidenza = ProvinciaResidenza.SelectedValue
            .IndirizzoResidenza = IndirizzoResidenza.Text
            .IndirizzoDomicilio = indirizzoDiDomicilio.Text
            .SenzaFissaDimora = SenzaFissaDimora.Text
            .Telefono = Telefono.Text
            .CodiceEni = CodiceEni.Text
            .IdNazioneResidenza = NazioneResidenza.SelectedValue

            '  .residenzaEstero = ResidenteEstero.Text

        End With

        Dim cli As New Clinica
        With cli
            .IdMalattia = _idMalattia
            .StatoVaccinale = StatoVaccinale.SelectedValue
            .CriterioClinico = Helper.ConvertBooleanToString(Clinico.Checked)
            .CriterioEpidemiologico = Helper.ConvertBooleanToString(Epidemiologico.Checked)
            .CriterioLaboratorio = Helper.ConvertBooleanToString(Laboratorio.Checked)
            .RicoveroOspedaliero = Ricovero.SelectedValue
            .StatoVaccinale = StatoVaccinale.SelectedValue
            .DataDoseUltimoVaccino = Helper.ConvertEmptyDateToNothing(DataDoseVaccino.Text)
            .DoseVaccino = DoseVaccino.Text
            .DataPrimiSintomi = DataPrimiSintomi.Text
            .DataWeb = Now
            .DataModifica = Now
            .LuogoRicovero = LuogoRicovero.Text
            .StrutturaRicovero = StrutturaRicovero.Text
            .LastUSer = _cUser
        End With



        localdataEntity.Anagrafica = ana
        localdataEntity.Clinica = cli

        Return localdataEntity
    End Function

    Private Sub Salva()

        Try
            _MobjAnagrafica.username = _cUser 'User.Identity.Name
            _MobjAnagrafica.record = Nome.Text + " " + Cognome.Text
            _idNotifica = _MobjAnagrafica.AddSegnalazione(impostaEntity)
            If _idNotifica <> 0 Then
                Session("idNotifica") = _idNotifica
            Else
                Throw New Exception("Si è verificato un errore imprevisto contattare assistenza tecnica")
            End If

        Catch ex As Exception
            Throw New Exception("Si è verificato un errore imprevisto contattare assistenza tecnica")
            btn.Enabled = False

        End Try

    End Sub


#End Region

#Region "Sub"

    Private Sub CaricaAsl(ByRef ctr As DropDownList, ByVal idRegione As String)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjGeografiche.GetAllAslByIdRegioneJson(_idRegione)
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaNazioni(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjGeografiche.GetAllNazioniJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaProvince(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "IdProvincia"
        ctr.DataSource = _MobjGeografiche.GetAllProvince
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaProfessioni(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjAccesorie.GettAllProfessioniJson
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaMedico(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjMedico.GetAllMedicoJsonByPArameters(_idRegione, Helper.ConvertEmptyStringToNothing(_idAsl))
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub

#End Region

#Region "Jquery Call"
    <System.Web.Services.WebMethod(EnableSession:=True)> _
    Public Shared Function lista(ByVal nome As String, ByVal cognome As String) As Object
        Dim p As New BllNotifica
        Dim myuser As New BllUser
        Dim utente As Utenti_Profilo = myuser.GetProfiloByUsername(HttpContext.Current.User.Identity.Name)
        Dim asl As String = Nothing
        Dim regione As String = Nothing
        asl = utente.idAsl
        regione = utente.idRegione

        Return p.GetNotificaDoppi(cognome, _
                                  nome, _
                                  , _
                                   Helper.ConvertEmptyStringToNothing(asl), _
                                   Helper.ConvertEmptyStringToNothing(asl), _
                                   regione)
    End Function
#End Region

#Region "Procedure Formattazione"

#End Region

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return ValidatePage();"
    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("~/Home.aspx", True)
    End Sub
End Class
