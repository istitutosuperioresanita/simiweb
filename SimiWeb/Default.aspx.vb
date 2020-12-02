
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub btnLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Try

        
        If Membership.ValidateUser(Me.txtUsername.Text, Me.txtPassword.Text) Then

            FormsAuthentication.RedirectFromLoginPage(Me.txtUsername.Text, True)

                Dim p As MembershipUser = Membership.GetUser(Me.txtUsername.Text)

            If p.Comment = "CambiarePassword" Then
                Response.Redirect("change.aspx", True)
            Else
                Response.Redirect("home.aspx")
            End If
        Else
            txtErrore.Visible = True
            txtErrore.Text = "autenticazione fallita"

            End If
        Catch ex As Exception
            Dim p As String = ex.ToString
        End Try
    End Sub
End Class
