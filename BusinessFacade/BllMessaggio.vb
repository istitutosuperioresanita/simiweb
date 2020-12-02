Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Imports System.Net.Mail
Public Class BllMessaggio
    Private _mobjdataAccess As New DalMessaggio
    Public Function GetSentByUsername(ByVal username As String) As List(Of Messaggio)
        Try
            Return _mobjdataAccess.GetSentByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetReceivedByUsername(ByVal username As String) As List(Of Messaggio)
        Try
            Return _mobjdataAccess.GetReceivedByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Add(ByVal messaggio As Messaggio) As Integer
        Try
            Return _mobjdataAccess.Add(messaggio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal idMessaggio As Integer) As Messaggio
        Try
            Return _mobjdataAccess.GetById(idMessaggio)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Delete(ByVal idMessaggio As Integer)
        Try
            _mobjdataAccess.Delete(idMessaggio)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetLatestNews(ByVal idRegione As String) As List(Of Messaggio_New)
        Try
            Return _mobjdataAccess.GetLatestNews(idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetInboxByUsername(ByVal username As String) As List(Of Messaggio_InboxByUsernameResult)
        Try
            Return _mobjdataAccess.GetInBoxByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetOutboxByUsername(ByVal username As String) As List(Of Messaggio_OutBoxByUsernameResult)
        Try
            Return _mobjdataAccess.GetOutBoxByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMailSupervisore(ByVal idRegione As String) As List(Of MailSupervisoriResult)
        Try
            Return _mobjdataAccess.GetMailSupervisore(idRegione)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
