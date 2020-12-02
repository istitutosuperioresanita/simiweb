
Partial Class Iss_Analisi
    Inherits System.Web.UI.Page
    Protected Sub avanti_Click(sender As Object, e As System.EventArgs) Handles avanti.Click
        Dim stringa As String = ""


        If dataDa.Text = "" Then
            dataDa.Text = "01/01/1900"
        End If

        If dataA.Text = "" Then
            dataA.Text = Now.ToShortDateString
        End If

        stringa = stringa & "dataDa=" & dataDa.Text
        stringa = stringa & "&dataA=" & dataA.Text
        stringa = stringa & "&criterio=" & TipodataRiferimento.SelectedValue.ToString





        '  stringa = HttpUtility.UrlEncode(stringa)

        Response.Redirect("analisireport.aspx?" & stringa, True)
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Me.dataDa.Attributes("onchange") = "check_date(this);"
            Me.dataA.Attributes("onblur") = "check_date(this);"
        End If
    End Sub
End Class
