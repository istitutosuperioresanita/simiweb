Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports Helper
Imports System.IO
Imports iTextSharp.text.pdf

Partial Class Focolaio_Riepilogo
    Inherits System.Web.UI.Page
    Private _idMalattia As Integer = 0
    Private _idFocolaio As Integer = 0
    Private _malattia As String = ""
    Private _mobjFocolaio As New BllFocolaio
    Private _mobjUser As New BllUser
    Private _ruolo As String
    Private _lettura As Boolean = True
    Private _aggiornamento As Boolean = True
    Private _eliminazione As Boolean = True
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_malattia", _malattia)
        Me.ViewState.Add("_idMalattia", _idMalattia)
        Me.ViewState.Add("_idFocolaio", _idFocolaio)
        Me.ViewState.Add("_ruolo", _ruolo)

        Me.ViewState.Add("_lettura", _lettura)
        Me.ViewState.Add("_aggiornamento", _aggiornamento)
        Me.ViewState.Add("_eliminazione", _eliminazione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _malattia = ViewState("_malattia")
        _ruolo = ViewState("_ruolo")
        _idMalattia = CInt(ViewState("_idMalattia"))
        _idFocolaio = CInt(ViewState("_idFocolaio"))
        _lettura = CBool(ViewState("_lettura"))
        _aggiornamento = CBool(ViewState("_aggiornamento"))
        _eliminazione = CBool(ViewState("_eliminazione"))
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _idFocolaio = Session("idFocolaio")
            _ruolo = Roles.GetRolesForUser(User.Identity.Name)(0).ToString
            Dim profilo As Utenti_Profilo = _mobjUser.GetProfiloByUsername(User.Identity.Name)
            _lettura = profilo.Letttura
            _aggiornamento = profilo.Aggiornamento
            _eliminazione = profilo.Eliminazione


            UcFocolaio1.idFocolaio = _idFocolaio
            CaricaValori()
            CheckPermessi()
            impostaJavascript()
            CheckStato()

        End If
    End Sub
    Private Sub CaricaValori()
        Dim focolaio As Focolaio_InfoResult = _mobjFocolaio.GetInfo(_idFocolaio)
        With focolaio
            stato.Text = .Stato
            malattiaLabel.Text = .malattia
            _malattia = .malattia
        End With

    End Sub
    Private Sub CheckPermessi()
        If _ruolo = "asl" Or _ruolo = "medico" Then
            UcFocolaio1.Modifica = True
            pnlInvalida.Visible = True
            If _ruolo = "medico" Then
                pnlNotifica.Visible = False
            Else
                pnlNotifica.Visible = True
            End If
        Else
            UcFocolaio1.Modifica = False
            pnlInvalida.Visible = False
            pnlNotifica.Visible = False
        End If

        If _aggiornamento = False Then
            UcFocolaio1.Modifica = False            
            pnlNotifica.Visible = False
            pnlInvalida.Visible = False
        End If
    End Sub
    Private Sub impostaJavascript()
        invalida.Attributes("onclick") = "javascript:return confirm('Attenzione il record verrà invalidato, proseguire ?');"
        notifica.Attributes("onclick") = "javascript:return confirm('Si sta per notificare la segnalazione, proseguire ?');"
        '  stampa.Attributes("onclick") = "javascript:alert('La stampa sarà implementata dopo la fase di test');return false;"
    End Sub
    Protected Sub notifica_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles notifica.Click
        Try
            _mobjFocolaio.cambiaStato(_idFocolaio, "Notifica")
            CaricaValori()
            'UcFocolaio1.Modifica = False
            CheckStato()
            UcFocolaio1.CaricaFocolaio(_idFocolaio)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Protected Sub invalida_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles invalida.Click
        Try
            _mobjFocolaio.cambiaStato(_idFocolaio, "Archiviata")
            CaricaValori()
            'UcFocolaio1.Modifica = True
            UcFocolaio1.CaricaFocolaio(_idFocolaio)


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub stampaFocolaio()
        Dim focolaio As Focolaio_ViewResult = _mobjFocolaio.GetFocolaioView(_idFocolaio)
        Dim pdfTemplate As String = Server.MapPath("~/Stampe/Focolaio_3.pdf")
        '  Dim newFile As String = Server.MapPath("~/TEmp/Focolaio.pdf")


        Using m As New MemoryStream

            Dim pdfReader As PdfReader = New PdfReader(pdfTemplate)
            Dim pdfStampera As PdfStamper = New PdfStamper(pdfReader, m)
            Dim pdfFormFields As AcroFields = pdfStampera.AcroFields

            pdfStampera.Writer.CloseStream = False


            With focolaio



                pdfFormFields.SetField("malattia", .malattia)
                pdfFormFields.SetField("regione", .regione)
                pdfFormFields.SetField("provincia", .Provincia)
                pdfFormFields.SetField("comune", .Comune)
                pdfFormFields.SetField("comunita", .Comunita)
                pdfFormFields.SetField("numeropersone", .PersoneRischio)
                pdfFormFields.SetField("indirizzo", .Indirizzo)
                pdfFormFields.SetField("telefono", .Telefono)
                pdfFormFields.SetField("agente", .agente)
                pdfFormFields.SetField("veicolo", .Veicolo)
                pdfFormFields.SetField("datraInizio", .dataInizio)
                pdfFormFields.SetField("durata", .durata)
                pdfFormFields.SetField("numweoCasi", .NumeroCasi)
                pdfFormFields.SetField("LuogoOrigine", .LuogoOrigine)
                pdfFormFields.SetField("note", .Note)
                pdfFormFields.SetField("dataSegnalazione", .DataSegnalazione)
                pdfFormFields.SetField("dataNotifica", Helper.IsNullDate(.DataNotifica))
                pdfFormFields.SetField("aslNotifica", .AslNotifica)
                pdfFormFields.SetField("aslResidenza", "")
                pdfFormFields.SetField("segnalatore", "")

            End With

            pdfStampera.FormFlattening = True
            pdfReader.Close()
            pdfStampera.Close()
            Response.ContentType = "application/pdf"
            Response.AddHeader("Content-disposition", String.Format("attachment; filename={0};", "Focolaio.pdf"))
            m.WriteTo(Response.OutputStream)
        End Using
    End Sub
    'Protected Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete
    '    malattiaLabel.Text = UcFocolaio1.Malattia
    '    stato.Text = UcFocolaio1.Stato
    '    'CheckStato()
    'End Sub
    Private Sub CheckStato()
        pnlNotifica.Visible = True
        pnlInvalida.Visible = True
        If stato.Text = "Notifica" Then
            pnlNotifica.Visible = False
        End If
        If _ruolo = "medico" Then
            pnlNotifica.Visible = False
            If stato.Text = "Notifica" Then
                UcFocolaio1.Modifica = False
                pnlInvalida.Visible = False
            End If
        End If
        If stato.Text = "Archiviata" Then
            pnlNotifica.Visible = False
            pnlInvalida.Visible = False
        End If
    End Sub

    Protected Sub messaggio_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles messaggio.Click
        Response.Redirect("~/messaggi/Nuovo.aspx?tipo=focolaio", True)
    End Sub

    Protected Sub stampa_Click(sender As Object, e As System.Web.UI.ImageClickEventArgs) Handles stampa.Click
        stampaFocolaio()
    End Sub
End Class
