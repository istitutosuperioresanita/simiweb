Imports System.Web.UI.DataVisualization.Charting

Partial Class _UserControl_Applicazione_UcStato
    Inherits System.Web.UI.UserControl
    Private _modifica As Boolean = False
    Private _dataSegnalazione As String
    Private _dataNotifica As String
    Private _segnalatore As String
    Private _aslNotifica As String
    Private _aslResidenza As String
    Private _referente As String
    Private _inserita As String
    Private _origineSegnalazione As String
    Public _qualita As String
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_dataSegnalazione", _dataSegnalazione)
        Me.ViewState.Add("_dataNotifica", _dataNotifica)
        Me.ViewState.Add("_segnalatore", _segnalatore)
        Me.ViewState.Add("_aslNotifica", _aslNotifica)
        Me.ViewState.Add("_aslResidenza", _aslResidenza)
        Me.ViewState.Add("_referente", _referente)
        Me.ViewState.Add("_inserita", _inserita)
        Me.ViewState.Add("_origineSegnalazione", _origineSegnalazione)
        Me.ViewState.Add("_qualita", _qualita)

        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _dataSegnalazione = CStr(ViewState("_dataSegnalazione"))
        _dataNotifica = CStr(ViewState("_dataNotifica"))
        _segnalatore = CStr(ViewState("_segnalatore"))
        _aslNotifica = CStr(ViewState("_aslNotifica"))
        _aslResidenza = CStr(ViewState("_aslResidenza"))
        _referente = CStr(ViewState("_referente"))
        _inserita = CStr(ViewState("_inserita"))
        _origineSegnalazione = CStr(ViewState("_origineSegnalazione"))
        _qualita = CStr(ViewState("_qualita"))


    End Sub
    Public Property Modifica() As Boolean
        Get
            Return _modifica
        End Get
        Set(ByVal value As Boolean)
            _modifica = value
        End Set
    End Property
    Public Property dataSegnalazione() As String
        Get
            Return _dataSegnalazione
        End Get
        Set(ByVal value As String)
            _dataSegnalazione = value
        End Set
    End Property
    Public Property dataNotifica() As String
        Get
            Return _dataNotifica
        End Get
        Set(ByVal value As String)
            _dataNotifica = value
        End Set
    End Property

    Public Property segnalatore() As String
        Get
            Return _segnalatore
        End Get
        Set(ByVal value As String)
            _segnalatore = value
        End Set
    End Property
    Public Property aslNotifica() As String
        Get
            Return _aslNotifica
        End Get
        Set(ByVal value As String)
            _aslNotifica = value
        End Set
    End Property
    Public Property aslResidenza() As String
        Get
            Return _aslResidenza
        End Get
        Set(ByVal value As String)
            _aslResidenza = value
        End Set
    End Property
    Public Property referente() As String
        Get
            Return _referente
        End Get
        Set(ByVal value As String)
            _referente = value
        End Set
    End Property
    Public Property origineSegnalazione() As String
        Get
            Return _origineSegnalazione
        End Get
        Set(ByVal value As String)
            _origineSegnalazione = value
        End Set
    End Property
    Public Property inserita() As String
        Get
            Return _inserita
        End Get
        Set(ByVal value As String)
            _inserita = value
        End Set
    End Property
    Public Sub ControllaModifica()
        lnkAggiorna.Visible = _modifica
        CaricaDati()
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'CaricaGraficoDemo()
            ' CaricaDati()
            _qualita = "100"
            lnkAggiorna.Visible = _modifica
            CaricaDati()
        End If
        CaricaGraficoDemo()

    End Sub
    Private Sub CaricaGraficoDemo()
        Dim rnd As New Random

        Dim DaysOfWeek() As String = {"Gen", "Feb", "Mar", "Apr", "Giu", "Lug", "Ago", "Set", "Ott", "Nov", "Dic"}

        For Each DOW As String In DaysOfWeek
            Dim total2009 As Decimal = rnd.NextDouble * 500 + 100
            Dim total2010 As Decimal = rnd.NextDouble * 500 + 100
            Dim total2011 As Decimal = rnd.NextDouble * 500 + 100
            Chart1.Series(0).Points.AddXY(DOW, total2009)
            Chart1.Series(1).Points.AddXY(DOW, total2010)
            Chart1.Series(2).Points.AddXY(DOW, total2011)


        Next



    End Sub

    Private Sub CaricaDati()
        datanotificaLabel.Text = _dataNotifica
        datasegnalazionelabel.Text = _dataSegnalazione
        MedicoSegnalatoreLabel.Text = _segnalatore
        ReferenteUlssLabel.Text = _referente
        aslResidenzaLabel.Text = _aslResidenza
        aslNotificaLabel.Text = _aslNotifica
        inseritaDa.Text = _inserita
        origine.Text = _origineSegnalazione
    End Sub

    Protected Sub lnkAggiorna_Click(sender As Object, e As System.EventArgs) Handles lnkAggiorna.Click
        Response.Redirect("editStato.aspx", True)
    End Sub

End Class
