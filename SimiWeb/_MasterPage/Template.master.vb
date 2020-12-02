
Partial Class _MasterPage_Template
    Inherits System.Web.UI.MasterPage
    Private _role As String
    Public ReadOnly Property ruolo As String
        Get
            ruolo = _role
        End Get
    End Property
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim currRoles() As String = Roles.GetRolesForUser(HttpContext.Current.User.Identity.Name)
        Dim _role As String = currRoles(0).ToString
    End Sub
End Class

