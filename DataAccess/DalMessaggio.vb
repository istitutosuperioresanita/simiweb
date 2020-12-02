Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalMessaggio
    Public Enum Stato
        Unread = 1
        Read = 2
        Replied = 3
        Forwarded = 4
        Spam = 5
        Filtered = 6
    End Enum
    Public Function GetSentByUsername(ByVal username As String) As List(Of Messaggio)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Messaggios Select tab Where tab.SentByUser = username).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetReceivedByUsername(ByVal username As String) As List(Of Messaggio)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From m In ObjDataContext.Messaggios
                        Where m.ToUser = username _
                        Select m).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Add(ByVal localtable As Messaggio) As Integer
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Messaggios.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
                Dim i As Integer = 1
                i = localtable.MessageID
                Return i
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetById(ByVal idMessaggio As Integer) As Messaggio
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Messaggios Where tab.MessageID = idMessaggio).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetLatestNews(ByVal idRegione As String) As List(Of Messaggio_New)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Messaggio_News Order By tab.data Descending Where tab.idregione = idRegione Or tab.idregione Is Nothing).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetInBoxByUsername(ByVal username As String) As List(Of Messaggio_InboxByUsernameResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Messaggio_InboxByUsername(username).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetOutBoxByUsername(ByVal username As String) As List(Of Messaggio_OutBoxByUsernameResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Messaggio_OutBoxByUsername(username).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub Delete(ByVal idMessaggio As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext

                ObjDataContext.Messaggios.DeleteOnSubmit( _
                    (From mat In ObjDataContext.Messaggios _
                     Where mat.MessageID = idMessaggio).Single)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
    Public Function GetMailSupervisore(ByVal idRegione As String) As List(Of MailSupervisoriResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.MailSupervisori(idRegione).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetMailAsl(ByVal idAsl As String, ByVal idAslResidenza As String) As List(Of Notifica_mail_cambiamentiResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Notifica_mail_cambiamenti(idAsl, idAslResidenza).ToList
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
