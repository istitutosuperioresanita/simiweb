
Partial Class Admin_Config_Malattie_Edit
    Inherits System.Web.UI.Page
    Private _idGruppo As Integer = 0
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tipo As String = Request.QueryString("type")
        If tipo = "new" Then
            _idGruppo = 0
        End If
    End Sub
End Class
