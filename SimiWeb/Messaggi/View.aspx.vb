Imports Simiweb.BusinessFacade
Imports Simiweb.DataLinq
Partial Class Messaggi_View
    Inherits System.Web.UI.Page
    Private _mobjMessaggio As New BllMessaggio
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim idMessaggio As Integer = Session("idMessaggio")
            Dim messaggio As Messaggio = _mobjMessaggio.GetById(idMessaggio)

            Try
                Dim lista As String()

                With messaggio

                    lista = .ToUser.Split(";")


                    For Each s As String In lista
                        toUser.Text = toUser.Text & s.ToString & Constants.vbCrLf
                    Next
                    from.Text = .SentByUser
                    'toUser.Text = .ToUser


                    Email.Text = .ToMail
                    data.Text = .DataWeb
                    soggetto.Text = .Subject
                    txtTesto.Text = .Body
                End With
            Catch ex As Exception
                lblErrore.Text = ex.ToString
            End Try
        End If
    End Sub
End Class
