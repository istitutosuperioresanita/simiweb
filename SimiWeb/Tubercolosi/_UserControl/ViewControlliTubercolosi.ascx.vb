
Partial Class Tubercolosi__UserControl_ViewControlliTubercolosi
    Inherits System.Web.UI.UserControl

    Protected Sub lnkNuovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkNuovo.Click
        Response.Redirect("Controlli.aspx", True)
    End Sub
End Class
