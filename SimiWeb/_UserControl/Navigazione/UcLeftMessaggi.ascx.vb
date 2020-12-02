
Partial Class _UserControl_Navigazione_UcLeftMessaggi
    Inherits System.Web.UI.UserControl
    Protected Sub lnkMailInviate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMailInviate.Click
        Response.Redirect("box.aspx?tipo=outbox", True)
    End Sub

    Protected Sub lnkMailRicevute_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkMailRicevute.Click
        Response.Redirect("box.aspx?tipo=inbox", True)
    End Sub

    Protected Sub LnkNuovoMessaggio_Click(sender As Object, e As System.EventArgs) Handles LnkNuovoMessaggio.Click
        Response.Redirect("nuovo.aspx", True)
    End Sub

    Protected Sub LinkRubrica_Click(sender As Object, e As System.EventArgs) Handles LinkRubrica.Click
        Response.Redirect("rubrica.aspx", True)
    End Sub
End Class
