Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports System.Net.Mail

Partial Class Admin_User_Add
    Inherits System.Web.UI.Page
    Private _m_userName As String = ""
    Private _mobjUser As New BllUser
    Private _mobGeografiche As New BllGeografiche
    Private _mobMessaggio As New BllMessaggio
    Private _mobjMalattie As New BllMalattie
    Private _errore As Boolean = False
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            'risultato.Visible = False
            BindRoles()
            Bind(Regione, _mobGeografiche.GetAllRegioniJson())
            Bind(gruppiMalattie, _mobjMalattie.GetAllGruppiMalattie, 4)
            ImpostaJavascript()
            ErrorMessage.Visible = False
            OperazioniEffettuateLabel.Visible = False
            OperazioniEffettuateLabel.Text = ""
            ErrorMessage.Text = ""
        End If
    End Sub
    Private Sub BindRoles()
        cmbRole.DataSource = Roles.GetAllRoles
        cmbRole.DataBind()
        cmbRole.Items.Insert(0, New ListItem("Selezionare...", ""))
    End Sub

    Private Sub salvaUtente()
        Dim operazioni As String = ""
        Try
            Dim messaggio As String = ""
            Dim mittente As String = ConfigurationManager.AppSettings("mittente")
            Dim rsSupervisori As List(Of MailSupervisoriResult)
            Dim utentiGruppo As New Utenti_Gruppi_Malattie




            'Messaggio per Supervisori
            Dim mailbodyAvviso As String = "Messaggio generato dal sistema Simiweb 2.0 <br/>"
            mailbodyAvviso = mailbodyAvviso & "Gentili colleghi è stata creata l'utenza per:" & nome.Text & "  " & Cognome.Text & " <br/>"
            mailbodyAvviso = mailbodyAvviso & "Cordiali saluti<br/>"

            'Messaggio per Utente
            Dim mailbodyUSer As String = "Messaggio generato dal sistema Simiweb 2.0 <br/>"
            mailbodyUSer = mailbodyUSer & "Gentile collega <br/>"
            mailbodyUSer = mailbodyUSer & "Abbiamo creato l'utenza simiweb <br/>"
            mailbodyUSer = mailbodyUSer & "Il sito è <a href='https://simiweb.azero.veneto.it/'>https://simiweb.azero.veneto.it/</a>  <br/>"
            mailbodyUSer = mailbodyUSer & "Il nome utente è : " & UserName.Text & " <br/>"
            mailbodyUSer = mailbodyUSer & "Qui trova il manuale utente https://simiweb.azero.veneto.it/manuale/manuale.pdf <br/>"


            'Messaggio per Utente Email
            mailbodyUSer = mailbodyUSer & "Riceverà la password con una email separata. <br/>"
            mailbodyUSer = mailbodyUSer & "Cordiali Saluti <br/>"



            Dim mailBody As String = "La vostra password: " & Password.Text
            _m_userName = UserName.Text

            Membership.CreateUser(UserName.Text, Password.Text, Email.Text)
            operazioni = operazioni + "Utente creato con successo <br/>"

            Dim p As MembershipUser = Membership.GetUser(UserName.Text)
            p.Comment = "CambiarePassword"
            Membership.UpdateUser(p)

            Dim profilo As New Utenti_Profilo
            profilo.Nome = nome.Text
            profilo.Cognome = Cognome.Text
            profilo.Telefono = Telefono.Text
            profilo.Email = Email.Text
            profilo.idAsl = Asl.SelectedValue
            profilo.idRegione = Regione.SelectedValue
            profilo.Letttura = lettura.Checked
            profilo.Aggiornamento = modifica.Checked
            profilo.Eliminazione = eliminazione.Checked
            profilo.username = _m_userName

            _mobjUser.AddProfilo(profilo)
            operazioni = operazioni + "Profilo utente creato con successo <br/>"
            Dim currRoles() As String = Roles.GetRolesForUser(_m_userName)
            If currRoles.Length > 0 Then
                Roles.RemoveUserFromRoles(_m_userName, currRoles)
            End If

            Roles.AddUserToRole(_m_userName, cmbRole.SelectedValue)
            operazioni = operazioni + "Ruolo utente creato con successo <br/>"

            utentiGruppo.username = UserName.Text
            utentiGruppo.id_Malattie_gruppo = gruppiMalattie.SelectedValue
            _mobjUser.AddUserToMalattieGruppo(utentiGruppo)

            operazioni = operazioni + "Utente aggiunto al gruppo malattie con successo <br/>"




            Try

                'Messaggio Username
                Dim mm As New MailMessage(mittente, Email.Text)
                mm.Subject = "Simiweb 2.0"
                mm.SubjectEncoding = System.Text.Encoding.UTF8
                mm.IsBodyHtml = True
                mm.Body = mailbodyUSer
                Dim smtp As New SmtpClient
                'invio username
                smtp.Send(mm)
                operazioni = operazioni + "Email con username inviato con successo <br/>"

                'invio password....
                mm.Body = mailBody

                '(4) Send the MailMessage (will use the Web.config settings)
                smtp.Send(mm)
                operazioni = operazioni + "Email con password inviata con successo <br/>"
                'invio avviso
                If cmbRole.SelectedValue = "asl" Then
                    rsSupervisori = _mobMessaggio.GetMailSupervisore(Regione.SelectedValue)
                    For Each t As MailSupervisoriResult In rsSupervisori
                        '   mm.CC.Add(t.email)
                    Next
                End If
                mm.Body = mailbodyAvviso
                smtp.Send(mm)
                operazioni = operazioni + "Email inviata ai referenti e amministratore<br/>"

            Catch ex As Net.Mail.SmtpException
                _errore = True
                messaggio = "Si è verificato un errore con l'invio del messaggio di post elettronica: "
                Select Case ex.StatusCode
                    Case SmtpStatusCode.ServiceNotAvailable
                        messaggio = messaggio & "servizio non disponibile"
                    Case SmtpStatusCode.MailboxUnavailable
                        messaggio = messaggio & "destinatario Irragiungibile"
                    Case SmtpStatusCode.GeneralFailure
                        messaggio = messaggio & "host inesistente"
                    Case Else
                        messaggio = messaggio & "Errore generico"
                End Select
            Catch ex As Exception
                _errore = True
                messaggio = "Errore generico"
            End Try

        Catch ex As Exception
            _errore = True
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString            
        End Try
        OperazioniEffettuate.Text = operazioni
        OperazioniEffettuateLabel.Visible = True
        _errore = False
    End Sub
    Private Sub ImpostaJavascript()
        cmbRole.Attributes("onchange") = "checkProfilo()"
        Regione.Attributes("onchange") = "checkProfilo()"
        Asl.Attributes("onchange") = "checkProfilo()"
    End Sub
    Private Sub Bind(ByRef cmb As DropDownList, ByVal ds As List(Of JsonDto), Optional ByVal selectValue As String = Nothing)
        cmb.DataSource = ds
        cmb.DataTextField = "descrizione"
        cmb.DataValueField = "codice"
        cmb.DataBind()
        cmb.Items.Insert(0, New ListItem("Selezionare...", ""))
        If Not selectValue Is Nothing Then
            cmb.SelectedValue = selectValue
        End If

    End Sub
    Protected Sub Regione_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles Regione.SelectedIndexChanged
        Bind(Asl, _mobGeografiche.GetAllAslByIdRegioneJson(Regione.SelectedValue))
    End Sub
    Protected Sub btnCrea_Click(sender As Object, e As System.EventArgs) Handles btnCrea.Click
        salvaUtente()
    End Sub
End Class
