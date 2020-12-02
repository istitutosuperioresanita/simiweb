Imports System.Data
Imports System.Data.Linq
Imports Simiweb.DataLinq
Imports Simiweb.DataAccess
Public Class BllAudit
    Private mobjdataAccess As New DalAudit
    Public Sub Add(ByVal localtable As Audit)
        Dim mobjConfig As New BllConfig
        Dim enableTracing As Boolean = mobjConfig.enableTracing

        Try
            If enableTracing = True Then
                mobjdataAccess.add(localtable)
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Sub DeleteAdd(ByVal id As Integer)
        Try
            mobjdataAccess.Delete(id)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function GetByUsername(ByVal username As String) As Audit
        Try
            Return mobjdataAccess.GetByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function Log_Auditing_retrieve_by_username(ByVal username As String) As List(Of Log_Auditing_retrieve_by_usernameResult)
        Try
            Return mobjdataAccess.Log_Auditing_retrieve_by_username(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetViewByUsername(ByVal username As String) As List(Of Audit)
        Try
            Return mobjdataAccess.GetViewByUsername(username)
        Catch ex As Exception
            Throw ex
        End Try
    End Function




    Public Function GetViewByIdRecord(ByVal idRecord As Integer) As List(Of Audit)
        Try
            Return mobjdataAccess.GetViewByIdRecord(idRecord)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetHistoryClinicaByIdNotifica(ByVal idRecord As Integer) As List(Of History_Clinica_ViewResult)
        Try
            Return mobjdataAccess.GetHistoryClinicaByIdNotifica(idRecord)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetHistoryAnagraficaByIdNotifica(ByVal idRecord As Integer) As List(Of History_Notifica_Anagrafica_ViewResult)
        Try
            Return mobjdataAccess.GetHistoryAnagraficaByIdNotifica(idRecord)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
