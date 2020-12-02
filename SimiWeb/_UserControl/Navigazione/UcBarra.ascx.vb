
Partial Class _UserControl_Navigazione_UcBarra
    Inherits System.Web.UI.UserControl

    Protected Sub imgHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgHome.Click
        Response.Redirect("~/Home.aspx", True)
    End Sub

    Protected Sub imgEmail_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgEmail.Click
        Response.Redirect("~/Messaggi/Box.aspx?tipo=inbox", True)
    End Sub

    Protected Sub imgExit_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgExit.Click
        Session.Abandon()
        Roles.DeleteCookie()
        FormsAuthentication.SignOut()

        Response.Redirect("~/Default.aspx", True)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        online.Text = HttpContext.Current.User.Identity.Name.ToString
    End Sub
End Class
