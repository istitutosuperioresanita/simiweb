Imports System.Net.Mail
Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class change
    Inherits System.Web.UI.Page
    Private _mobjUSer As New BllUser
    Protected Sub invia_Click(sender As Object, e As System.EventArgs) Handles salva.Click
        Dim m_user As String = ""
        Dim mailUSer As String = ""
        Dim messaggio As String = ""

        Dim nome As String = HttpContext.Current.User.Identity.Name
        Dim user As MembershipUser = Membership.GetUser(nome)
        Dim oldStoredPw As String = ""
        Try

            oldStoredPw = vecchiaPassword.Text

            If user.ChangePassword(vecchiaPassword.Text, Password.Text) = True Then
                user.Comment = "passwordCambiata"
                Membership.UpdateUser(user)
                messaggio = "Password aggiornata con successo"
            Else
                messaggio = "Controllare la vecchia password"
            End If

            lnkHome.Visible = True
        Catch ex As Exception
            messaggio = ex.ToString
            lnkHome.Visible = False
        End Try
        lblmessaggio.Text = messaggio
    End Sub


End Class
