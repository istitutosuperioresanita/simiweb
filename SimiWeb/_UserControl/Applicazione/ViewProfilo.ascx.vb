Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_Applicazione_ViewProfilo
    Inherits System.Web.UI.UserControl
    Private _mobjUser As New BllUser
    Private _username As String
    Public Property username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
        End Set
    End Property
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CaricaInfo()
        End If
    End Sub
    Private Sub CaricaInfo()
        Dim localtable As Profilo_ViewResult = _mobjUser.GetViewByUsername(_username)
        With localtable
            nome.Text = .Nome
            Cognome.Text = .Cognome
            Telefono.Text = .Telefono
            Regione.Text = .Regione
            Asl.Text = .Asl
            Mail.Text = .Email
        End With
    End Sub
End Class
