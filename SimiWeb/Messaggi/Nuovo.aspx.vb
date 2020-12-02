Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports System.Net.Mail
Imports System.IO
Imports Simiweb.DataAccess

Partial Class Messagi_Nuovo
    Inherits System.Web.UI.Page
    Private _mobjUser As New BllUser
    Private _mobjMessaggio As New BllMessaggio
    Private _idRegione As String = Nothing
    Private _idASl As String = Nothing
    Private _idNotifica As Integer = 0
    Private _idFocolaio As Integer = 0
    Public Enum CustomerReportKind
        malattia
    End Enum
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idASl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Me.ViewState.Add("_idNotifica", _idNotifica)
        Me.ViewState.Add("_idFocolaio", _idFocolaio)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idASl = ViewState("_idAsl")
        _idRegione = ViewState("_idRegione")
        _idNotifica = ViewState("_idNotifica")
        _idFocolaio = ViewState("_idFocolaio")
    End Sub
    Private Sub ImpostaJavascript()
        ' btn.Attributes("onclick") = "javascript:alert('Invio email non abilitato in fasse di test');"

        Me.Email.Attributes("onblur") = "multiEmail(this);"

    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            lblErrore.Visible = False
            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)
            _idASl = profilo.idAsl
            _idRegione = profilo.idRegione

            Dim testo As String = ""
            Dim tipo As String = Request.QueryString("tipo")
            Dim id As Integer = 0
            CaricaDestinatari()
            Select Case LCase(tipo)
                Case "notifica"
                    _idNotifica = Session("idNotifica")
                    testo = impostaNotifica(profilo.Nome, profilo.Cognome)
                    pnlAllegato.Visible = True
                    allegato.Checked = True
                Case "focolaio"
                    _idFocolaio = Session("idFocolaio")
                    testo = impostaFocolaio(profilo.Nome, profilo.Cognome)
                    pnlAllegato.Visible = True
                    allegato.Checked = True

                Case Else
                    testo = ""
                    _idFocolaio = 0
                    _idNotifica = 0
                    pnlAllegato.Visible = False
                    allegato.Checked = False
                    testo = impostaMEssaggio(profilo.Nome, profilo.Cognome)
            End Select
            txtTesto.Text = testo
            ImpostaJavascript()
        End If
    End Sub
    Private Sub CaricaDestinatari()

        Dim dest As List(Of JsonDto) = _mobjUser.GetAllProfilesEmailJson(_idRegione)


        'destinatario.DataSource = _mobjUser.GetAllProfilesJson(_idRegione)
        'destinatario.DataSource = dest
        'destinatario.DataTextField = "descrizione"
        'destinatario.DataValueField = "codice"
        'destinatario.DataBind()
        'destinatario.Items.Insert(0, New ListItem("Selezionare...", ""))


        lista.DataSource = dest
        lista.DataTextField = "descrizione"
        lista.DataValueField = "codice"
        lista.DataBind()
        '        destinatario.Items.Insert(0, New ListItem("Selezionare...", ""))


    End Sub
    Private Function impostaNotifica(ByVal nome As String, ByVal cognome As String) As String
        Dim messaggio As String = ""

        Try
            messaggio = "<b>Messaggio generato dal sistema Simiweb 2.0 </b><br/> <hr /> <br/>"
            messaggio = messaggio + "<b>Il seguente messaggio è stato inviato da: </b> <br/>"
            messaggio = messaggio + "<b>Nome:</b> " & nome & "<br/>"
            messaggio = messaggio + "<b>Cognome: </b>" & cognome & "<br/>"
            If _idNotifica <> 0 Then

                Dim _mobjNotifica As New BllNotifica

                Dim infoNotifica As Notifica_InfoResult = _mobjNotifica.GetInfoNotifica(_idNotifica)
                With infoNotifica
                    messaggio = messaggio + "<b>Relativo a: </b>" & "<br/>"
                    messaggio = messaggio + "<b>nome: </b>" & Left(.nome, 2) & "<br/>"
                    messaggio = messaggio + "<b>cognome: </b>" & Left(.cognome, 2) & "<br/>"
                    messaggio = messaggio + "<b>malattia: </b>" & .malattia & "<br/>"
                    messaggio = messaggio + "<b>data sintomi: </b>" & .DataPrimiSintomi & "<br/>"
                    messaggio = messaggio + "<b>medico segnalatore: </b>" & .ReferenteUlss & "<br/>"
                End With
            End If
            messaggio = messaggio + "<hr/>"
            'End With
        Catch ex As Exception
            messaggio = ""
        End Try
        Return messaggio

    End Function
    Private Function impostaFocolaio(ByVal nome As String, ByVal cognome As String) As String
        Dim messaggio As String = ""

        Try
            messaggio = "<b>Messaggio generato dal sistema Simiweb 2.0 </b><br/> <hr /> <br/>"
            messaggio = messaggio + "<b>Il seguente messaggio è stato inviato da: </b> <br/>"
            messaggio = messaggio + "<b>Nome:</b> " & nome & "<br/>"
            messaggio = messaggio + "<b>Cognome: </b>" & cognome & "<br/>"
            If _idFocolaio <> 0 Then
                Dim _mobjFocolaio As New BllFocolaio
                Dim infofocolaio As Focolaio_ViewResult = _mobjFocolaio.GetFocolaioView(_idFocolaio)
                With infofocolaio
                    messaggio = "<b>Relativo al focolaio: </b> <br/>"
                    messaggio = messaggio + "<b>Malattia: </b>" & .malattia & "<br/>"
                    messaggio = messaggio + "<b>Comune: </b>" & .Comune & "<br/>"
                    messaggio = messaggio + "<b>data inizio: </b>" & .dataInizio & "<br/>"
                    messaggio = messaggio + "<b>Data Notifica: </b>" & .DataNotifica & "<br/>"
                End With
            End If
            messaggio = messaggio + "<hr/>"

        Catch ex As Exception
            messaggio = ""
        End Try
        Return messaggio
    End Function
    Private Function impostaMEssaggio(ByVal nome As String, ByVal cognome As String) As String
        Dim messaggio As String = ""

        Try
            messaggio = "<b>Messaggio generato dal sistema Simiweb 2.0 </b><br/> <hr /> <br/>"
            messaggio = messaggio + "<b>Il seguente messaggio è stato inviato da: </b> <br/>"
            messaggio = messaggio + "<b>Nome:</b> " & nome & "<br/>"
            messaggio = messaggio + "<b>Cognome: </b>" & cognome & "<br/>"
            messaggio = messaggio + "<hr/>"

        Catch ex As Exception
            messaggio = ""
        End Try
        Return messaggio
    End Function
    Private Function GenerateGUID() As String
        Dim sGUID As String
        sGUID = System.Guid.NewGuid.ToString()
        Return sGUID
    End Function

    Protected Sub btn_Click(sender As Object, e As System.EventArgs) Handles btn.Click
        Salva()

    End Sub
    Private Sub Salva()
        Dim output = ""
        Dim cc As String()
        Dim messaggio As String = ""

        messaggio = messaggio + HttpUtility.HtmlDecode(txtTesto.Text)

        Try
            Dim mittente As String = ConfigurationManager.AppSettings("mittente")

            cc = Email.Text.Split(";")

            Try
                Dim mm As New MailMessage(mittente, "xxxx@xxxxx.it")
                mm.Subject = soggetto.Text
                mm.Body = messaggio
                mm.SubjectEncoding = System.Text.Encoding.UTF8
                mm.IsBodyHtml = True


                If _idFocolaio <> 0 And allegato.Checked = True Then
                    Dim stampa As New Stampa
                    Dim pdf As MemoryStream = stampa.StampaFocolaio(_idFocolaio)

                    mm.Attachments.Add(New Attachment(pdf, "Focolaio.pdf", "application/pdf"))

                End If

                If _idNotifica <> 0 And allegato.Checked = True Then
                    Dim stampa As New Stampa
                    Dim pdf As MemoryStream = stampa.StampaNotifica(_idNotifica, True)

                    mm.Attachments.Add(New Attachment(pdf, "Notifica.pdf", "application/pdf"))

                End If




                If cc(0) <> "" Then
                    For Each item As String In cc
                        mm.CC.Add(item.ToString)
                    Next
                End If

                'nuovo
                Dim p As String = ""
                For Each Item As ListItem In lista.Items
                    If Item.Selected Then
                        mm.CC.Add(Item.Value)
                        p = p & ";" & Item.Value
                    End If
                Next


                Dim smtp As New SmtpClient
                smtp.Send(mm)

                Dim msg As New Messaggio

                msg.SentByUser = User.Identity.Name
                msg.Body = messaggio
                msg.Subject = soggetto.Text
                msg.ToUser = p
                msg.ToMail = p
                msg.DataWeb = Now


                _mobjMessaggio.Add(msg)


                ' output = "Email inviata con successo"
                Response.Redirect("box.aspx?tipo=outbox", True)
            Catch ex As Net.Mail.SmtpException
                output = "Si è verificato un errore con l'invio del messaggio di post elettronica: "
                Select Case ex.StatusCode
                    Case SmtpStatusCode.ServiceNotAvailable
                        output = output & "servizio non disponibile"
                    Case SmtpStatusCode.MailboxUnavailable
                        output = output & "destinatario Irragiungibile"
                    Case SmtpStatusCode.GeneralFailure
                        output = output & "host inesistente"
                    Case Else
                        output = output & "Errore generico"
                End Select
                lblErrore.Text = output
                lblErrore.Visible = True
            Catch ex2 As Exception
                output = "Si è verificato un errore nell'invio della posta contattare supporto tecnico"
                lblErrore.Text = output
                lblErrore.Visible = True
            End Try
        Catch ex As Exception
            output = "errore generico"
            lblErrore.Text = output
            lblErrore.Visible = True
        End Try
    End Sub
End Class
