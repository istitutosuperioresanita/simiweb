Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Partial Class _UserControl_ViewCasiFocolaio
    Inherits System.Web.UI.UserControl
    Private _id As Integer = 0
    Protected Sub LstNotifica_ItemCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ListViewCommandEventArgs) Handles LstNotifica.ItemCommand
        'Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
        '_id = LstNotifica.DataKeys(dataItem.DisplayIndex).Value
        'If e.CommandName = "sel" Then
        '    Session("idNotifica") = _id
        '    Response.Redirect("~/Notifica/Riepilogo.aspx", True)
        'End If
    End Sub
End Class
