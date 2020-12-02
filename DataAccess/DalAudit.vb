Imports System.Data
Imports System.Data.Linq
Imports System.Collections.Generic
Imports System.Linq
Imports System.Data.SqlClient
Imports Simiweb.DataLinq
Public Class DalAudit
    Public Sub add(ByVal localtable As Audit)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Audits.InsertOnSubmit(localtable)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub Update(ByVal LocalTable As Audit)

        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Audits.Attach(LocalTable)
                ObjDataContext.Refresh(RefreshMode.KeepCurrentValues, LocalTable)
                ObjDataContext.SubmitChanges(ConflictMode.ContinueOnConflict)
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetByUsername(ByVal username As String) As Audit
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Audits Select tab Where tab.username = username).SingleOrDefault
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetViewByUsername(ByVal username As String) As List(Of Audit)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Audits Select tab Where TAB.username = username Order By TAB.data Descending Take 5).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function Log_Auditing_retrieve_by_username(ByVal username As String) As List(Of Log_Auditing_retrieve_by_usernameResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.Log_Auditing_retrieve_by_username(username).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetViewByIdRecord(ByVal idRecord As Integer) As List(Of Audit)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return (From tab In ObjDataContext.Audits Select tab Where tab.idRecord = idRecord Order By tab.data Descending).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Sub Delete(ByVal id As Integer)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                ObjDataContext.Audits.DeleteOnSubmit( _
                    (From tab In ObjDataContext.Audits _
                     Where tab.id = id).Single)
                ObjDataContext.SubmitChanges()
            End Using
        Catch ex As Exception
            Throw ex
        Finally

        End Try
    End Sub
    Public Function GetHistoryAnagraficaByIdNotifica(ByVal id As Integer) As List(Of History_Notifica_Anagrafica_ViewResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                Return ObjDataContext.History_Notifica_Anagrafica_View(id).ToList 
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetHistoryClinicaByIdNotifica(ByVal id As Integer) As List(Of History_Clinica_ViewResult)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                'Return (From tab In ObjDataContext.History_Notifica_Clinicas Select tab Where tab.IdNotifica = id Order By tab.DataModifica Descending).ToList
                Return ObjDataContext.History_Clinica_View(id).ToList
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetMibByIdNotifica(ByVal id As Integer) As List(Of History_Notifica_MIB)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                'Return (From tab In ObjDataContext.History_Notifica_Anagraficas Select tab Where tab.idNotifica = id Order By tab.DataModifica Descending).ToList
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetTbcByIdNotifica(ByVal id As Integer) As List(Of History_Notifica_Tbc)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                'Return (From tab In ObjDataContext.History_Notifica_Anagraficas Select tab Where tab.idNotifica = id Order By tab.DataModifica Descending).ToList
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
    Public Function GetTbcFattoriByIdNotifica(ByVal id As Integer) As List(Of History_Notifica_Tbc_Fattore)
        Try
            Using ObjDataContext As SimiWebLinqDataContext = New SimiWebLinqDataContext
                'Return (From tab In ObjDataContext.History_Notifica_Anagraficas Select tab Where tab.idNotifica = id Order By tab.DataModifica Descending).ToList
                Return Nothing
            End Using
        Catch ex As Exception
            Throw ex
        Finally
        End Try
    End Function
End Class