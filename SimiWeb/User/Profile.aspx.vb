Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class User_Profile
    Inherits System.Web.UI.Page
    Private _m_userName As String = ""
    Private _mobjProfilo As New BllUser
    Private _mobGeografiche As New BllGeografiche

    Private _idProfilo As Integer
    Protected Overloads Overrides Function SaveViewState() As Object
        Me.ViewState.Add("_idProfilo", _idProfilo)
        Me.ViewState.Add("_m_userName", _m_userName)
        '   _idProfilo = ViewState("_m_userName")
        Return MyBase.SaveViewState
    End Function
    Protected Overloads Overrides Sub LoadViewState(ByVal savedState As Object)
        MyBase.LoadViewState(savedState)
        '_id = CInt(ViewState("_id"))
        _idProfilo = CInt(ViewState("_idProfilo"))
        _m_userName = ViewState("_m_userName")
    End Sub
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            _m_userName = User.Identity.Name
            Bind(Regione, _mobGeografiche.GetAllRegioniJson())
            CaricaInfoMember()
            CaricaDati()
        End If
        ErrorMessage.Text = ""
    End Sub
    Private Sub CaricaInfoMember()
        ' show the user's details
        Dim user As MembershipUser = Membership.GetUser(_m_userName)
        usernameVis.Text = user.UserName
        Password.Text = ""
        ConfirmPassword.Text = ""
        Mail.Text = user.Email
        Registered.Text = user.CreationDate.ToShortDateString
        lastLogin.Text = user.LastLoginDate.ToShortDateString
        BindRoles()
        Dim rol As String() = Roles.GetRolesForUser(_m_userName)
        cmbRole.SelectedValue = rol(0)
        cmbRole.Enabled = False
    End Sub
    Private Sub CaricaDati()
        Dim localtable As Utenti_Profilo = _mobjProfilo.GetProfiloByUsername(_m_userName)
        Try
            With localtable
                nome.Text = .Nome
                Cognome.Text = .Cognome
                Telefono.Text = .Telefono
                Regione.SelectedValue = .idRegione
                Bind(Asl, _mobGeografiche.GetAllAslByIdRegioneJson(.idRegione))
                Asl.SelectedValue = .idAsl
                Mail.Text = .Email
            End With
        Catch ex As Exception

        End Try
    End Sub
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
        cmbRole.Items.Insert(0, New ListItem("Selezionare..."))
    End Sub

    Protected Sub btnSalvaProfilo_Click(sender As Object, e As System.EventArgs) Handles btnSalvaProfilo.Click
        salvaProfilo()
    End Sub
    Private Sub salvaProfilo()
        Try




            Dim user_m As MembershipUser = Membership.GetUser(_m_userName)
            user_m.Email = Mail.Text
            Membership.UpdateUser(user_m)
            _mobjProfilo.UpdateProfiloUserInfo(_m_userName, _
                                               Mail.Text, _
                                               Telefono.Text)
            ErrorMessage.Text = "I dati del suo profilo sono salvati corretamente"
        Catch ex As Exception
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString
        End Try
    End Sub

    Protected Sub btnSalvaPassword_Click(sender As Object, e As System.EventArgs) Handles btnSalvaPassword.Click
        salvaPassword()
    End Sub
    Private Sub salvapassword()
        Try


            Dim user_m As MembershipUser = Membership.GetUser(_m_userName)
            user_m.ChangePassword(user_m.ResetPassword, Password.Text)
            'user_m.Email = Mail.Text
            'Membership.UpdateUser(user_m)
            ErrorMessage.Text = "La password è stata modificata correttamente"
        Catch ex As Exception
            ErrorMessage.Visible = True
            ErrorMessage.Text = ex.ToString
        End Try
    End Sub
End Class

