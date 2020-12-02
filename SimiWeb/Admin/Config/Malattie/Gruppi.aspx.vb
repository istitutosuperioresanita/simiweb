
Partial Class Admin_Config_Malattie_Gruppi
    Inherits System.Web.UI.Page

    Protected Sub btnCrea_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCrea.Click
        Response.Redirect("edit.aspx?type=new", True)
    End Sub

    Protected Sub btnAggiungi_Click(sender As Object, e As System.EventArgs) Handles btnAggiungi.Click

    End Sub
End Class
