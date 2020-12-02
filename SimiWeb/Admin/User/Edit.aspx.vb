Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports System.Net.Mail

Partial Class Admin_User_Edit
    Inherits System.Web.UI.Page
    Private _m_userName As String = ""
    Private _m_password As String = ""
    Private _mobjUser As New BllUser
    Private _mobGeografiche As New BllGeografiche
    Private _mobjMalattie As New BllMalattie
    'Private _m_userName As String = ""
    'Private _mobjProfilo As New BllProfilo
    Private _idProfilo As Integer
    Protected Overloads Overrides Function SaveViewState() As Object
        'Me.ViewState.Add("_id", _id)
        Me.ViewState.Add("_idProfilo", _idProfilo)
        Me.ViewState.Add("_m_userName", _m_userName)
        Me.ViewState.Add("_m_password", _m_password)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        '_id = CInt(ViewState("_id"))
        _idProfilo = CInt(ViewState("_idProfilo"))
        _m_userName = ViewState("_m_userName")
        _m_password = ViewState("_m_password")
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            '_m_userName = Me.Request.QueryString("UserName")
            _m_userName = Session("username")
            passwordGenerata.Text = ""
            passwordGenerata.Visible = False
            lblPassword.Visible = False
            ImpostaJavascript()
            Bind(Regione, _mobGeografiche.GetAllRegioniJson())
            Bind(gruppiMalattie, _mobjMalattie.GetAllGruppiMalattie)
            Try
                CaricaInfoMember()
                CaricaDati()
                CaricaPermessi()
            Catch ex As Exception
                ErrorMessage.Visible = True
                ErrorMessage.Text = ex.ToString
            End Try
        End If

        accountLabel.Visible = False
        accountLabel.Text = ""
        profilolabel.Visible = False
        profilolabel.Text = ""
        permessiLabel.Visible = False
        permessiLabel.Text = ""
    End Sub
    Private Sub ImpostaJavascript()
        cmbRole.Attributes("onchange") = "checkProfilo()"
        Regione.Attributes("onchange") = "checkProfilo()"
        Asl.Attributes("onchange") = "checkProfilo()"
    End Sub
    Private Sub CaricaInfoMember()
        ' show the user's details
        Dim user As MembershipUser = Membership.GetUser(_m_userName)
        usernameVis.Text = user.UserName
        '  lnkEmail.Text = user.Email
        '  lnkEmail.NavigateUrl = "mailto:" & user.Email
        Registered.Text = user.CreationDate.ToString("f")
        lastLogin.Text = user.LastLoginDate.ToString("f")
        'LastActivity.Text = user.LastActivityDate.ToString("f")
        chkOnlineNow.Checked = user.IsOnline
        chkApproved.Checked = user.IsApproved
        chkLockedOut.Checked = user.IsLockedOut
        ' chkLockedOut.Enabled = user.IsLockedOut


        UserName.Text = user.UserName

        'cambio fatto il 19/03/2012
        'Password.Text = user.GetPassword(_m_userName)
        'ConfirmPassword.Text = Password.Text
        '----------------------------
        '  _m_password = user.GetPassword(_m_userName)
        Mail.Text = user.Email

        BindRoles()
        Dim rol As String() = Roles.GetRolesForUser(_m_userName)
        cmbRole.SelectedValue = rol(0)

        UserName.Enabled = False
    End Sub
    Private Sub CaricaPermessi()
        Dim localtable As Utenti_Gruppi_Malattie = _mobjUser.GetGruppoMelattieFromUsername(_m_userName)
        With localtable
            gruppiMalattie.SelectedValue = .id_Malattie_gruppo
        End With


    End Sub
    Private Sub CaricaDati()
        Dim localtable As Utenti_Profilo = _mobjUser.GetProfiloByUsername(_m_userName)
        With localtable
            nome.Text = .Nome
            Cognome.Text = .Cognome
            Telefono.Text = .Telefono
            Regione.SelectedValue = .idRegione
            Bind(Asl, _mobGeografiche.GetAllAslByIdRegioneJson(.idRegione))
            Asl.SelectedValue = .idAsl
            Mail.Text = .Email
            lettura.Checked = .Letttura
            modifica.Checked = .Aggiornamento
            eliminazione.Checked = .Eliminazione
        End With
    End Sub
    Private Function ImpostaEntityProfilo() As Utenti_Profilo
        Dim localTable As New Utenti_Profilo
        With localTable
            .username = UserName.Text
            .Nome = nome.Text
            .Cognome = Cognome.Text
            .Telefono = Telefono.Text
            .Email = Mail.Text
            .idAsl = Asl.SelectedValue
            .idRegione = Regione.SelectedValue
            .Letttura = lettura.Checked
            .Aggiornamento = modifica.Checked
            .Eliminazione = eliminazione.Checked
        End With
        Return localTable
    End Function
    Private Sub Bind(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto))
        cmb.DataSource = ds
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Private Sub BindRoles()
        cmbRole.DataSource = Roles.GetAllRoles
        cmbRole.DataBind()
        cmbRole.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub
    Protected Sub Regione_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Regione.SelectedIndexChanged
        Bind(Asl, _mobGeografiche.GetAllAslByIdRegioneJson(Regione.SelectedValue))
    End Sub

    Protected Sub btnSalvaProfilo_Click(sender As Object, e As System.EventArgs) Handles btnSalvaProfilo.Click
        salvaProfilo()
    End Sub
    Private Sub salvaProfilo()
        Try
            'aggiorno i ruoli

            Dim currRoles() As String = Roles.GetRolesForUser(_m_userName)
            If currRoles.Length > 0 Then
                Roles.RemoveUserFromRoles(UserName.Text, currRoles)
            End If
            Roles.AddUserToRole(_m_userName, cmbRole.SelectedValue)

            _mobjUser.UpdateProfilo(ImpostaEntityProfilo())
            profilolabel.Visible = True
            profilolabel.Text = "Profilo aggiornato con successo"
        Catch ex As Exception
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString
        End Try
    End Sub

    'Protected Sub btnSalvaAccount_Click(sender As Object, e As System.EventArgs) Handles btnSalvaAccount.Click
    '    SalvaAccount()
    'End Sub
    'Private Sub SalvaAccount()
    'End Sub
    Private Sub ResettaPassword()
        Try
            Dim newPassword As String = ""
            Dim messaggio As String = ""
            Dim mittente As String = ConfigurationManager.AppSettings("mittente")
            Dim mailbody As String = "La sua nuova password è: "
            _m_userName = UserName.Text

            'aggiorno la password
            Dim user As MembershipUser = Membership.GetUser(_m_userName)

            'user.ResetPassword()
            Dim pattern As String = "[^a-zA-Z0-9]"
            newPassword = Membership.GeneratePassword(8, 0)
            newPassword = Regex.Replace(newPassword, pattern, "9")

            user.ChangePassword(user.ResetPassword(), newPassword)
            _m_password = newPassword
            passwordGenerata.Text = newPassword


            'Setto la forzatura del cambio password
            user.Comment = "CambiarePassword"
            Membership.UpdateUser(user)


            'Inserisco Body email
            mailbody = mailbody & _m_password

            'Visualizzo la pw generata
            passwordGenerata.Visible = True
            lblPassword.Visible = True
            Try
                Dim mm As New MailMessage(mittente, Mail.Text)
                mm.Subject = "Simiweb 2.0"
                mm.Body = mailbody
                mm.SubjectEncoding = System.Text.Encoding.UTF8
                mm.IsBodyHtml = True
                Dim smtp As New SmtpClient
                '(4) Send the MailMessage (will use the Web.config settings)
                smtp.Send(mm)
                messaggio = "Email inviata con successo"
                'Catch ex As Net.Mail.SmtpException
                '    messaggio = "Si è verificato un errore con l'invio del messaggio di post elettronica: "
                '    Select Case ex.StatusCode
                '        Case SmtpStatusCode.ServiceNotAvailable
                '            messaggio = messaggio & "servizio non disponibile"
                '        Case SmtpStatusCode.MailboxUnavailable
                '            messaggio = messaggio & "destinatario Irragiungibile"
                '        Case SmtpStatusCode.GeneralFailure
                '            messaggio = messaggio & "host inesistente"
                '        Case Else
                '            messaggio = messaggio & "Errore generico"
                '    End Select
            Catch ex As Exception
                Throw ex
            End Try
            accountLabel.Visible = True
            accountLabel.Text = "Password resettata e inviata con successo <br/> sarà necessario cambiarla al primo accesso"
        Catch ex As Exception
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString()
        End Try
    End Sub
    Private Sub SalvaPermessi()
        Try
            Dim UtentiGruppiMalattie As New Utenti_Gruppi_Malattie
            'UtentiGruppiMalattie.username = _m_userName
            'UtentiGruppiMalattie.id_Malattie_gruppo = gruppiMalattie.SelectedValue
            _mobjUser.Update_permessi(_m_userName, lettura.Checked, modifica.Checked, eliminazione.Checked)
            _mobjUser.UpdateUserToMalattieGruppo(_m_userName, gruppiMalattie.SelectedValue)
            permessiLabel.Visible = True
            permessiLabel.Text = "Permessi aggiornati con successo"
        Catch ex As Exception
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString()
        End Try
    End Sub

    Protected Sub btnResettaPassword_Click(sender As Object, e As System.EventArgs) Handles btnResettaPassword.Click
        ResettaPassword()
    End Sub

    Protected Sub btnPermessi_Click(sender As Object, e As System.EventArgs) Handles btnPermessi.Click
        SalvaPermessi()
    End Sub
End Class
