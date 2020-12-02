
Partial Class _UserControl_Applicazione_UcStatoSegnalazione
    Inherits System.Web.UI.UserControl
    Private _idNotifica As Integer
    Private _idMalattia As Integer
    Private _nome As String
    Private _cognome As String
    Private _malattia As String
    Public Property IdNotifica() As Integer
        Get
            Return _idNotifica
        End Get
        Set(ByVal value As Integer)
            _idNotifica = value
        End Set
    End Property
    Public Property idMalattia() As Integer
        Get
            Return _idMalattia
        End Get
        Set(ByVal value As Integer)
            _idMalattia = value
        End Set
    End Property
    Public Property nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property
    Public Property cognome() As String
        Get
            Return _cognome
        End Get
        Set(ByVal value As String)
            _cognome = value
        End Set
    End Property
    Public Property malattia() As String
        Get
            Return _malattia
        End Get
        Set(ByVal value As String)
            _malattia = value
        End Set
    End Property
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_nome ", _nome)
        Me.ViewState.Add("_cognome", _cognome)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _nome = CStr(ViewState("_nome "))
        _cognome = CStr(ViewState("_cognome"))
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            malattialbl.Text = _malattia
            nomelbl.Text = _nome
            cognomelbl.Text = _cognome
        End If
    End Sub

    Protected Sub lnkRitorna_Click(sender As Object, e As System.EventArgs) Handles lnkRitorna.Click
        Response.Redirect("riepilogo.aspx", True)
    End Sub
End Class
