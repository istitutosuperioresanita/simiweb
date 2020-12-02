Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class Notifica_EditStato
    Inherits System.Web.UI.Page
    Private _idNotifica As Integer = 0
    Private _MobjMalattia As New BllMalattie
    Private _MobjGeografiche As New BllGeografiche
    Private _MobjNotifica As New BllNotifica
    Private _MobjAccesorie As New BllAccessorie
    Private _MobjUser As New BllUser
    Private _MobjMedico As New BllMedico
    Private _idRegione As String = ""
    Private _idAsl As String = ""
    Private _idMalattia As Integer = 0
    Private _idClinica As Integer = 0
    Private _ruolo As String = ""
    Private _username As String = ""
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_ruolo", _ruolo)
        Me.ViewState.Add("_username", _username)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idNotifica = CInt(ViewState("_idNotifica"))
        _idMalattia = CInt(ViewState("_idMalattia"))
        _ruolo = ViewState("_ruolo")
        _username = ViewState("_username")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        message.Text = ""
        message.Visible = False
        If Not Page.IsPostBack Then
            _username = User.Identity.Name
            Dim utente As Utenti_Profilo = _MobjUser.GetProfiloByUsername(_username)
            Dim gruppoMalattia As String = ""

            _ruolo = Roles.GetRolesForUser(_username)(0).ToString
            _idRegione = utente.idRegione
            _idAsl = utente.idAsl
            _idNotifica = Session("idNotifica")
            CaricaMedico(ReferenteUlss)
            CaricaAsl(aslnotifica)
            addJAvascript()
            caricaEntity(_idNotifica)

            If _idNotifica <> 0 Then
            End If
            If _MobjMalattia.CanChange(_idMalattia, gruppoMalattia) = False And statoScheda.SelectedValue = "Notifica" Then
                malattia.Enabled = False
            End If
            CaricaMalattia(malattia, gruppoMalattia, _idMalattia)

            aslnotifica.Enabled = False
            BindIntestazione()
            impostaVincoli()
        End If
    End Sub
    Private Sub impostaVincoli()
        If _ruolo = "medico" Then
            datanotifica.Enabled = False
            statoScheda.Enabled = False
            MedicoSegnalatore.Enabled = False
            origineSegnalazione.Enabled = False
            ReferenteUlss.Enabled = False
        End If
    End Sub
    Private Sub addJAvascript()
        Me.datanotifica.Attributes("onblur") = "check_date(this);CheckNotifica()"
        Me.datasegnalazione.Attributes("onblur") = "check_date(this);"
        Me.statoScheda.Attributes("onchange") = "CheckNotifica();"
        Me.datanotifica.Attributes("onblur") = "CheckNotifica()"
        Me.malattia.Attributes("onchange") = "CheckMalattia()"

    End Sub

    Private Sub caricaEntity(ByVal idNotifica As Integer)
        Try
            Dim notificaInfo As Notifica_InfoResult = _MobjNotifica.GetInfoNotifica(_idNotifica)
            With notificaInfo
                datasegnalazione.Text = .DataSegnalazione
                datanotifica.Text = Helper.IsNullDate(.DataNotifica)
                MedicoSegnalatore.Text = .medicoSegnalatore
                ReferenteUlss.SelectedValue = .IdReferenteUlss
                dataprimisintomi.Value = .DataPrimiSintomi
                statoScheda.SelectedValue = .stato
                aslnotifica.SelectedValue = .idAslNotifica
                origineSegnalazione.SelectedValue = .origineSegnalazione
                If statoScheda.SelectedValue = "Notifica" Then
                    statoScheda.Enabled = False
                End If
                'malattia.SelectedValue = .idmalattia
                _idMalattia = .idmalattia
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub Salva()
        Try
            Dim lista As New List(Of String)
            If statoScheda.SelectedValue = "Notifica" And _MobjNotifica.Notificabile(_idNotifica, lista, _idMalattia) = False Then
                For Each s As String In lista
                    message.Text = s & message.Text
                Next
                message.Visible = True

            Else
                Dim malattiaCambiata As Boolean = False
                If _idMalattia <> malattia.SelectedValue Then
                    malattiaCambiata = True
                Else
                    malattiaCambiata = False
                End If
                _MobjNotifica.username = User.Identity.Name
                _MobjNotifica.record = UcStatoSegnalazione1.nome + " " + UcStatoSegnalazione1.cognome
                _MobjNotifica.UpdateInfo(_idNotifica, _
                                            Helper.ConvertEmptyDateToNothing(datanotifica.Text), _
                                            datasegnalazione.Text, _
                                            statoScheda.SelectedValue, _
                                            ReferenteUlss.SelectedValue, _
                                            MedicoSegnalatore.Text, _
                                            aslnotifica.SelectedValue, _
                                            malattia.SelectedValue, _
                                            origineSegnalazione.SelectedValue, _
                                            malattiaCambiata)

                Response.Redirect("Riepilogo.aspx?tab=info", True)
            End If
        Catch ex As Exception
            message.Text = ex.ToString
            message.Visible = True
            ' btn.Enabled = False
        End Try

    End Sub
    Private Sub CaricaMedico(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjMedico.GetAllMedicoJsonByPArameters(_idRegione, Helper.ConvertEmptyStringToNothing(_idAsl))
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub CaricaMalattia(ByRef ctr As DropDownList, ByVal gruppo As String, ByVal idMalattia As String)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjMalattia.GetAllMalattieJson(BllMalattie.tipo.Gruppo, gruppo, _username)
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
        ctr.SelectedValue = idMalattia
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        Me.Form.Attributes("onsubmit") = "javascript:return CheckInfo();"
    End Sub

    Protected Sub btn_Click(sender As Object, e As System.EventArgs) Handles btn.Click
        Salva()
    End Sub
    Private Sub CaricaAsl(ByRef ctr As DropDownList)
        ctr.DataTextField = "Descrizione"
        ctr.DataValueField = "Codice"
        ctr.DataSource = _MobjGeografiche.GetAllAslByIdRegioneJson(_idRegione)
        ctr.DataBind()
        ctr.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub BindIntestazione()
        Dim notificaInfo As Notifica_InfoResult = _MobjNotifica.GetInfoNotifica(_idNotifica)
        With notificaInfo
            UcStatoSegnalazione1.malattia = .malattia
            UcStatoSegnalazione1.nome = .nome
            UcStatoSegnalazione1.cognome = .cognome
            _idMalattia = .idmalattia
        End With
    End Sub

    Protected Sub btnAnnulla_Click(sender As Object, e As System.EventArgs) Handles btnAnnulla.Click
        Response.Redirect("Riepilogo.aspx", True)
    End Sub
End Class
