
Partial Class Tubercolosi_Lista
    Inherits System.Web.UI.Page

    Protected Sub ImageButton5_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton5.Click
        Response.Redirect("dettaglio.aspx", True)
    End Sub
End Class
'Dim dataItem As ListViewDataItem = CType(e.Item, ListViewDataItem)
'Dim id As Integer
'        id = lstTabelle.DataKeys(dataItem.DisplayIndex).Values(0).ToString
'        If e.CommandName = "aggiorna" Then
'            _idElemento = id
'            PulisciPopUp()
'            CaricaCampi(id, _tipoTabella)
'            Pop.Show()
'        End If