Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_UcFocolaio
    Inherits System.Web.UI.UserControl
    Dim messaggio As String
    Private _idFocolaio As Integer
    Private _mobjFocolaio As New BllFocolaio
    Private _modifica As Boolean = False
    Private _malattia As String
    Private _stato As String


    Public Property idFocolaio() As Integer
        Get
            Return _idFocolaio
        End Get
        Set(ByVal value As Integer)
            _idFocolaio = value
        End Set
    End Property
    Public Property Modifica() As Boolean
        Get
            Return _Modifica
        End Get
        Set(ByVal value As Boolean)
            _Modifica = value
        End Set
    End Property
    'Public Property Malattia() As String
    '    Get
    '        Return _malattia
    '    End Get
    '    Set(ByVal value As String)
    '        _malattia = value
    '    End Set
    'End Property
    Public Property Stato() As String
        Get
            Return _stato
        End Get
        Set(ByVal value As String)
            _stato = value
        End Set
    End Property
    Public Sub CaricaFocolaio(ByVal idFocolaio As Integer)
        _idFocolaio = idFocolaio
        CaricaVista(_idFocolaio)

        If _modifica = True And (_stato = "Notifica" Or _stato = "Segnalazione") Then
            lnkAggiorna.Visible = True
        Else
            lnkAggiorna.Visible = False
        End If

        'If _modifica = False Then
        '    lnkAggiorna.Visible = False
        'End If


    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaVista(_idFocolaio)
            If _modifica = False Then
                lnkAggiorna.Visible = False
            End If
        End If
    End Sub
    Private Sub CaricaVista(ByVal idFocolaio As Integer)
        Try
            Dim focolaioView As Focolaio_ViewResult = _mobjFocolaio.GetFocolaioView(_idFocolaio)
            With focolaioView
                Agente.Text = .agente
                comune.Text = .Comune
                comunita.Text = .Comunita
                dataInizio.Text = .dataInizio
                ' .DataModifica
                dataNotifica.Text = Helper.IsNullDate(.DataNotifica)
                dataSegnalazione.Text = .DataSegnalazione
                ' .DataWeb
                agenteIdentificato.Text = .agenteIdentificato
                durata.Text = .durata
                Indirizzo.Text = .Indirizzo
                LuogoOrigine.Text = .LuogoOrigine
                AslNotifica.Text = .AslNotifica
                ' .malattia
                note.Text = .Note
                numeroCasi.Text = .NumeroCasi
                numeropersone.Text = .PersoneRischio
                provincia.Text = .Provincia
                Regione.Text = .regione
                ' .Stato
                Telefono.Text = .Telefono
                Veicolo.Text = .Veicolo
                '    veicoloIdentificato.Text = .veicoloIdentificato
                veicoloIdentificato.Text = .Veicolo
                ' .VeicoloStato
                _malattia = .malattia
                _stato = .Stato
                inseritoDa.Text = .InseritaDa
            End With
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub lnkAggiorna_Click(sender As Object, e As System.EventArgs) Handles lnkAggiorna.Click
        Response.Redirect("EditFocolaio.aspx", True)
    End Sub

End Class
