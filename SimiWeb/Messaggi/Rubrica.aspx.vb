Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Helper
Partial Class Messaggi_Rubrica
    Inherits System.Web.UI.Page
    Private _idAsl As String = Nothing
    Private _idRegione As String = Nothing
    Private _MobjUser As New BllUser
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idAsl", _idAsl)
        Me.ViewState.Add("_idRegione", _idRegione)
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        _idAsl = ViewState("_idAsl")
        _idRegione = ViewState("_idRegione")

    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim profilo As Utenti_Profilo = _MobjUser.GetProfiloByUsername(User.Identity.Name)
            _idAsl = profilo.idAsl
            _idRegione = profilo.idRegione
            BindView()
        End If
    End Sub
    Private Sub BindView()
        lstRubrica.DataSource = _MobjUser.GetAllProfiles(_idRegione)
        lstRubrica.DataBind()
    End Sub
End Class
